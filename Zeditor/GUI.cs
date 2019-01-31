using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SoulsFormats;
using EzSemble;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Timers;

namespace Zeditor
{
    public partial class GUI : Form
    {

        string filePath = "";
        ESD currentESD = null;
        Dictionary<long, ESD.State> currentStateGroup
        {
            get
            {
                if (StateGroupBox.SelectedItem == null) return null;
                long key = (long)StateGroupBox.SelectedItem;
                if (currentESD != null) return currentESD.StateGroups[key];
                return null;
            }
        }
        ESD.State currentState
        {
            get
            {
                if (StateBox.SelectedItem == null) return null;
                long key = (long)StateBox.SelectedItem;
                if (currentStateGroup != null) return currentStateGroup[key];
                return null;
            }
        }
        ESD.Condition currentCondition
        {
            get
            {
                if (ConditionTree.SelectedNode == null) return null;
                return ConditionsFromNode(ConditionTree.SelectedNode).Condition;
            }
        }
        string splitString = Environment.NewLine + "---" + Environment.NewLine;
        Dictionary<string, TextStyle> textStyles = new Dictionary<string, TextStyle>();
        bool loaded = false;
        System.Timers.Timer saveLabelTimer = new System.Timers.Timer();
        

        public GUI()
        {
            InitializeComponent();
            SetTextBoxOptions();
            loaded = true;

            void hide(Object source, ElapsedEventArgs e)
            {
                if (saveLabel.InvokeRequired)
                {
                    saveLabel.Invoke( new Action(() => saveLabel.Visible = false));
                } else
                {
                    saveLabel.Visible = false;
                }

            }
            saveLabelTimer.Interval = 5000;
            saveLabelTimer.Elapsed += hide;
            saveLabelTimer.AutoReset = false;
        }

        private void openESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentESD = ESD.Read(ofd.FileName);
                    Form.ActiveForm.Text = "Zeditor - " + Path.GetFileName(ofd.FileName);
                    StateGroupBox.DataSource = currentESD.StateGroups.Keys.ToList();
                    filePath = ofd.FileName;
                } catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Invalid ESD file." + Environment.NewLine + "---------" + Environment.NewLine + ex.ToString());
                    openESDToolStripMenuItem_Click(sender, e);
                }

            }
        }

        private void StateGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentStateGroup != null)
            {
                StateBox.DataSource = currentStateGroup.Keys.ToList();
            } else
            {
                StateBox.DataSource = null;
            }
            UpdateTitleBox();
        }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionTree.Nodes.Clear();
            if (currentState == null) return;
            foreach (var condition in currentState.Conditions)
            {
                AddConditionNode(condition);
            }
            EntryCmdBox.Text = ReadCommands(currentState.EntryCommands);
            ExitCmdBox.Text = ReadCommands(currentState.ExitCommands);
            WhileCmdBox.Text = ReadCommands(currentState.WhileCommands);
            AfterSelect();
            UpdateTitleBox();

        }

        private void AddConditionNode(ESD.Condition condition)
        {
            int cNum = currentState.Conditions.IndexOf(condition);
            TreeNode cNode = new TreeNode();
            cNode.Name = cNum.ToString();
            cNode.Text = "CND " + cNum;
            if (condition.TargetState != null) cNode.Text += " → " + condition.TargetState.ToString();
            ConditionTree.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
            ConditionTree.SelectedNode = null;
        }

        private string ReadCommands(List<ESD.CommandCall> commands)
        {
            List<string> output = new List<string>();
            foreach (var cmd in commands)
            {
                List<string> args = new List<string>();
                foreach (var arg in cmd.Arguments)
                {
                    args.Add(EzSembler.Dissemble(arg));
                }

                string s = "$ " + cmd.CommandBank + ":" + cmd.CommandID + "(";
                s += String.Join("; ", args) + ")";
                output.Add(s);
            }
            return String.Join(Environment.NewLine, output);
        }

        private void WriteCommands(string plainText, ref List<ESD.CommandCall> target)
        {
            List<ESD.CommandCall> commands = new List<ESD.CommandCall>();
            var cmdStrings = Regex.Split(plainText, @"\s*[$]\s*").Where(s => !String.IsNullOrWhiteSpace(s));
            int i = 0;
            bool success = true;
            foreach (var str in cmdStrings)
            {
                try
                {
                    var cmd = new ESD.CommandCall();
                    var metaStr = str.Substring(0, str.IndexOf("("));
                    var meta = metaStr.Split(':');
                    cmd.CommandBank = int.Parse(meta[0]);
                    cmd.CommandID = int.Parse(meta[1]);

                    var args = Regex.Split(str.Substring(str.IndexOf("(")).Trim(new char[] { '(', ')' }), @"\s*;\s*");
                    foreach (var arg in args)
                    {
                        var argBytes = EzSembler.Assemble(arg);
                        EzSembler.Dissemble(argBytes);
                        cmd.Arguments.Add(argBytes);
                    }
                    commands.Add(cmd);

                } catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Unable to parse command at index " + i + "\n\n" + ex.ToString());
                    success = false;
                    break;
                }
                i++;
            }
            if (success) target = commands;
        }

        private void AddConditionNode(ESD.Condition condition, TreeNode parent)
        {
            string cName = parent.Name + "-" + parent.Nodes.Count;
            TreeNode cNode = new TreeNode(cName);
            cNode.Text = "CND " + cName;
            if (condition.TargetState != null) cNode.Text += " → " + condition.TargetState.ToString();
            cNode.Name = cName;
            parent.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
        }

        private void ConditionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect();
            UpdateTitleBox();

        }

        private void UpdateTitleBox()
        {
            if (currentState == null)
            {
                EditorTitleBox.Text = "";
                return;
            }

            EditorTitleBox.Text = "Group " + StateGroupBox.SelectedItem + " : State " + StateBox.SelectedItem + " : ";
            if (editorControl.SelectedTab == entryTab) EditorTitleBox.Text += "Entry Commands";
            else if (editorControl.SelectedTab == exitTab) EditorTitleBox.Text += "Exit Commands";
            else if (editorControl.SelectedTab == whileTab) EditorTitleBox.Text += "While Commands";
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) EditorTitleBox.Text = "";
                else EditorTitleBox.Text += ConditionNameBox.Text;
            }
        }

        private void AfterSelect()
        {
            if (ConditionTree.SelectedNode == null)
            {
                ConditionNameBox.Text = "";
                EvaluatorBox.Text = "";
                PassCmdBox.Text = "";
            }
            else
            {
                ConditionNameBox.Text = ConditionTree.SelectedNode == null ? "" : ConditionTree.SelectedNode.Text;
                TargetStateBox.Text = currentCondition.TargetState == null ? "" : currentCondition.TargetState.ToString();
                EvaluatorBox.Text = EzSembler.Dissemble(currentCondition.Evaluator);
                PassCmdBox.Text = ReadCommands(currentCondition.PassCommands);
            }
            UpdateTitleBox();
        }

        private void NotYet()
        {
            MessageBox.Show("Feature not yet implemented.");
        }

        private string CmdPreview(ESD.CommandCall command)
        {
            List<string> argStrings = new List<string>();
            foreach (var arg in command.Arguments)
            {
                argStrings.Add(CmdArgPreview(arg));
            }
            return command.CommandID + "(" + String.Join(",", argStrings) + ")";
        }

        private string CmdArgPreview(byte[] arg)
        {
            string s = EzSembler.Dissemble(arg);
            string output = s.Substring(0, Math.Min(6, s.Length)).Trim();
            if (s.Length > 6) output += "...";
            return output;
        }

        private void AddConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var cnd = new ESD.Condition();
            cnd.Evaluator = new byte[] { 0xA1 };
            cnd.TargetState = 0;
            currentState.Conditions.Add(cnd);
            StateBox_SelectedIndexChanged(sender, e);
            ConditionTree.SelectedNode = ConditionTree.Nodes[ConditionTree.Nodes.Count - 1];
        }

        private void AddSubconditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var path = ConditionTree.SelectedNode.Name;
            var state = currentCondition.TargetState;
            currentCondition.TargetState = null;

            var cnd = new ESD.Condition();
            cnd.Evaluator = new byte[] { 0xA1 };
            cnd.TargetState = state ?? (long)0;
            currentCondition.Subconditions.Add(cnd);
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.LastNode;
        }

        private void SelectNode(string path)
        {
            var nodePath = path.Split('-').Select(i => Int32.Parse(i)).ToList();
            TreeNode node = ConditionTree.Nodes[nodePath[0]];
            for (int i = 1; i < nodePath.Count; i++)
            {
                node = node.Nodes[nodePath[i]];
            }
            ConditionTree.SelectedNode = node;
        }

        private void DeleteConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var name = ConditionTree.SelectedNode.Text;
            if (DialogResult.OK == MessageBox.Show("Really delete " + name + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                ConditionsFromNode(ConditionTree.SelectedNode).ParentCollection.Remove(currentCondition);
                StateGroupBox_SelectedIndexChanged(sender, e);
            }
        }

        private void GoTargetBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition != null && currentCondition.TargetState != null)
            {
                StateBox.SelectedItem = currentCondition.TargetState;
            }
        }

        private ConditionHandler ConditionsFromNode(TreeNode node)
        {
            var nodePath = node.Name.Split('-').Select(i => Int32.Parse(i)).ToList();
            if (node.Parent == null) return new ConditionHandler(currentState.Conditions[nodePath[0]], currentState.Conditions);

            ESD.Condition parent = null;
            ESD.Condition cnd = currentState.Conditions[nodePath.First()];
            foreach (var n in nodePath.Skip(1))
            {
                parent = cnd;
                cnd = parent.Subconditions[n];
            }
            return new ConditionHandler(cnd, parent.Subconditions);
        }

        private void RenameAllNodes(TreeNode parentNode = null)
        {
            TreeNodeCollection nodes = parentNode == null ? ConditionTree.Nodes : parentNode.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Name = parentNode == null ? i + "" : parentNode.Name + "-" + i;
                nodes[i].Text = "CND " + nodes[i].Name;
                var cnds = ConditionsFromNode(nodes[i]);
                if (cnds.Condition.TargetState != null)
                {
                    nodes[i].Text = "CND " + nodes[i].Name + " → " + cnds.Condition.TargetState;
                }
                else
                {
                    RenameAllNodes(nodes[i]);
                }
            }
        }

        private void MoveCndUpBtn_Click(object sender, EventArgs e)
        {
            var currentNode = ConditionTree.SelectedNode;
            if (currentNode == null) return;
            TreeNodeCollection parentNodes = currentNode.Parent == null ? ConditionTree.Nodes : currentNode.Parent.Nodes;
            int index = parentNodes.IndexOf(ConditionTree.SelectedNode);
            if (index == 0) return;

            var h = ConditionsFromNode(ConditionTree.SelectedNode);
            var p = h.ParentCollection;
            var c = h.Condition;
            var i = h.Index;

            p.RemoveAt(i);
            p.Insert(i - 1, c);

            parentNodes.Remove(currentNode);
            parentNodes.Insert(i - 1, currentNode);
            RenameAllNodes();

            ConditionTree.SelectedNode = currentNode;
            ConditionTree.Focus();
        }


        private void MoveCndDownBtn_Click(object sender, EventArgs e)
        {
            var currentNode = ConditionTree.SelectedNode;
            if (currentNode == null) return;
            TreeNodeCollection parentNodes = currentNode.Parent == null ? ConditionTree.Nodes : currentNode.Parent.Nodes;
            int index = parentNodes.IndexOf(ConditionTree.SelectedNode);
            if (index == parentNodes.Count - 1) return;

            var h = ConditionsFromNode(ConditionTree.SelectedNode);
            var p = h.ParentCollection;
            var c = h.Condition;
            var i = h.Index;

            p.RemoveAt(i);
            p.Insert(i + 1, c);

            parentNodes.Remove(currentNode);
            parentNodes.Insert(i + 1, currentNode);
            RenameAllNodes();

            ConditionTree.SelectedNode = currentNode;
            ConditionTree.Focus();
        }

        private void ShowSuccessLabel()
        {

            saveLabel.Visible = true;
            saveLabelTimer.Stop();
            saveLabelTimer.Start();
        }

        private void saveESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(filePath);
            sfd.FileName = Path.GetFileName(filePath);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentESD.Write(sfd.FileName);
                filePath = sfd.FileName;
                Form.ActiveForm.Text = "Zeditor - " + Path.GetFileName(sfd.FileName);
            }
        }

        private void TargetStateBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTargetState();
            }
        }

        private void TargetStateBox_Leave(object sender, EventArgs e)
        {
            UpdateTargetState();
        }

        private void UpdateTargetState()
        {
            if (currentCondition != null)
            {
                string s = TargetStateBox.Text.Trim();
                int newValue;
                bool success = int.TryParse(s, out newValue);
                if (!success)
                {
                    MessageBox.Show("Invalid target state.");
                    TargetStateBox.Text = currentCondition.TargetState.ToString();
                }
                else if (currentCondition.Subconditions.Count > 0)
                {
                    MessageBox.Show("Conditions with subconditions can't have target states.");
                    TargetStateBox.Text = currentCondition.TargetState.ToString();
                }
                else
                {
                    currentCondition.TargetState = (long)newValue;
                    string txt = "CND " + ConditionTree.SelectedNode.Name + " → " + newValue;
                    ConditionTree.SelectedNode.Text = txt;
                    ConditionNameBox.Text = txt;
                }
            }
        }

        private void SetTextBoxOptions()
        {
            FastColoredTextBox[] boxes = { PassCmdBox, EntryCmdBox, ExitCmdBox, WhileCmdBox, EvaluatorBox };
            foreach (var box in boxes)
            {
                box.ChangeFontSize(3);
                box.AllowSeveralTextStyleDrawing = true;
                box.WordWrap = true;
            }

            textStyles["separator"] = new TextStyle(Brushes.Red, Brushes.White, FontStyle.Regular);
            textStyles["command"] = new TextStyle(Brushes.Blue, Brushes.White, FontStyle.Regular);
            textStyles["num"] = new TextStyle(Brushes.DarkMagenta, Brushes.White, FontStyle.Bold);
            textStyles["regular"] = new TextStyle(Brushes.Black, Brushes.White, FontStyle.Bold);
        }

        private void BoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!loaded) return;
            e.ChangedRange.ClearStyle(textStyles.Values.ToArray());
            e.ChangedRange.SetStyle(textStyles["separator"], "[$]");
            e.ChangedRange.SetStyle(textStyles["num"], "[A-Za-z0-9]");
            e.ChangedRange.SetStyle(textStyles["command"], @"\d+:\d+[(]");
            e.ChangedRange.SetStyle(textStyles["regular"], "[():;]");
        }

        private void UpdateTitleBox(object sender, EventArgs e)
        {
            UpdateTitleBox();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void SaveEdit(object sender = null, EventArgs e = null)
        {
            if (currentState == null) return;
            else if (editorControl.SelectedTab == entryTab) WriteCommands(EntryCmdBox.Text, ref currentState.EntryCommands);
            else if (editorControl.SelectedTab == exitTab) WriteCommands(ExitCmdBox.Text, ref currentState.ExitCommands);
            else if (editorControl.SelectedTab == whileTab) WriteCommands(WhileCmdBox.Text, ref currentState.WhileCommands);
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                WriteCommands(PassCmdBox.Text, ref currentCondition.PassCommands);
                currentCondition.Evaluator = EzSembler.Assemble(EvaluatorBox.Text);
            }
            ShowSuccessLabel();
        }

        private void RevertBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            else if (editorControl.SelectedTab == entryTab) EntryCmdBox.Text = ReadCommands(currentState.EntryCommands);
            else if (editorControl.SelectedTab == exitTab) ExitCmdBox.Text = ReadCommands(currentState.ExitCommands);
            else if (editorControl.SelectedTab == whileTab) WhileCmdBox.Text = ReadCommands(currentState.WhileCommands);
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                PassCmdBox.Text = ReadCommands(currentCondition.PassCommands);
                EvaluatorBox.Text = EzSembler.Dissemble(currentCondition.Evaluator);
            }
        }

        private void saveEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void cloneStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var newState = new ESD.State();

            byte[] Clone(byte[] src) => EzSembler.Assemble(EzSembler.Dissemble(src));

            void CloneCondition(ESD.Condition srcCondition, ESD.Condition parentCondition = null)
            {
                var newCondition = new ESD.Condition();
                newCondition.TargetState = srcCondition.TargetState;
                newCondition.Evaluator = Clone(srcCondition.Evaluator);
                foreach (var sub in srcCondition.Subconditions) CloneCondition(sub, newCondition);
                foreach (var srcCommand in srcCondition.PassCommands)
                {
                    var newCommand = CloneCommand(srcCommand);
                    newCondition.PassCommands.Add(newCommand);
                }
                if (parentCondition == null) newState.Conditions.Add(newCondition);
                else parentCondition.Subconditions.Add(newCondition);
            }

            ESD.CommandCall CloneCommand(ESD.CommandCall srcCommand)
            {
                var command = new ESD.CommandCall();
                command.CommandBank = srcCommand.CommandBank;
                command.CommandID = srcCommand.CommandID;
                foreach (var arg in srcCommand.Arguments)
                {
                    command.Arguments.Add(Clone(arg));
                }
                return command;
            }

            foreach (var condition in currentState.Conditions) CloneCondition(condition);
            foreach (var srcCommand in currentState.EntryCommands) newState.EntryCommands.Add(CloneCommand(srcCommand));
            foreach (var srcCommand in currentState.ExitCommands) newState.ExitCommands.Add(CloneCommand(srcCommand));
            foreach (var srcCommand in currentState.WhileCommands) newState.WhileCommands.Add(CloneCommand(srcCommand));

            long stateId = currentStateGroup.Max(p => p.Key) + 1;
            currentStateGroup[stateId] = newState;
            StateGroupBox_SelectedIndexChanged(sender, e);
            StateBox.SelectedItem = stateId;
        }

        private void addNewStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long stateId = currentStateGroup.Max(p => p.Key) + 1;
            currentStateGroup[stateId] = new ESD.State();
            StateGroupBox_SelectedIndexChanged(sender, e);
            StateBox.SelectedItem = stateId;
        }

        private void deleteStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            long stateId = (long) StateBox.SelectedItem;
            if (DialogResult.OK == MessageBox.Show("Really delete state " + stateId + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                int i = StateBox.SelectedIndex - 1;
                currentStateGroup.Remove(stateId);
                StateGroupBox_SelectedIndexChanged(sender, e);
                if (i > -1 && i < StateBox.Items.Count) StateBox.SelectedIndex = i;
            }
        }

        private void saveEditorContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void noHelpForYouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("created by AinTunez");
        }
    }

    public class ConditionHandler
    {
        public ESD.Condition Condition;
        public List<ESD.Condition> ParentCollection;
        public int Index => ParentCollection.IndexOf(Condition);

        public ConditionHandler(ESD.Condition cnd, List<ESD.Condition> collection)
        {
            Condition = cnd;
            ParentCollection = collection;
        }
    }
    public enum EditType
    {
        Command, Condition, Null
    }
}
