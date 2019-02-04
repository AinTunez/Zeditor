﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Timers;
using SoulsFormats.ESD;

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
                StateGroupBox.Items.Clear();
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

            if (ConditionTree.Nodes.Count > 0) ConditionTree.SelectedNode = ConditionTree.Nodes[0];
            EntryCmdBox.Text = currentState.EntryScript;
            ExitCmdBox.Text = currentState.ExitScript;
            WhileCmdBox.Text = currentState.WhileScript;
            ConditionNameBox.Text = "";
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

        //private string ReadCommands(List<ESD.CommandCall> commands)
        //{
        //    List<string> output = new List<string>();
        //    foreach (var cmd in commands)
        //    {
        //        List<string> args = new List<string>();
        //        foreach (var arg in cmd.Arguments)
        //        {
        //            args.Add(EzSembler.Dissemble(arg));
        //        }

        //        string s = "$ " + cmd.CommandBank + ":" + cmd.CommandID + "(";
        //        s += String.Join("; ", args) + ")";
        //        output.Add(s);
        //    }
        //    return String.Join(Environment.NewLine, output);
        //}

        private void WriteCommands(string plainText, ref List<ESD.CommandCall> target)
        {
            string current = "";
            try
            {
                current = "EntryScript";
                currentState.EntryScript = EntryCmdBox.Text;
                current = "ExitScript";
                currentState.ExitScript = ExitCmdBox.Text;
                current = "WhileSCript";
                currentState.WhileScript = WhileCmdBox.Text;
            } catch (Exception ex)
            {
                MessageBox.Show("Error parsing " + current + "\n\n" + ex.ToString());

            }



            //List<ESD.CommandCall> commands = new List<ESD.CommandCall>();
            //var cmdStrings = Regex.Split(plainText, @"\s*[$]\s*").Where(s => !String.IsNullOrWhiteSpace(s));
            //int i = 0;
            //bool success = true;
            //foreach (var str in cmdStrings)
            //{
            //    try
            //    {
            //        var cmd = new ESD.CommandCall();
            //        var metaStr = str.Substring(0, str.IndexOf("("));
            //        var meta = metaStr.Split(':');
            //        cmd.CommandBank = int.Parse(meta[0]);
            //        cmd.CommandID = int.Parse(meta[1]);

            //        var args = Regex.Split(str.Substring(str.IndexOf("(")).Trim(new char[] { '(', ')' }), @"\s*;\s*");
            //        foreach (var arg in args)
            //        {
            //            var argBytes = EzSembler.Assemble(arg);
            //            EzSembler.Dissemble(argBytes);
            //            cmd.Arguments.Add(argBytes);
            //        }
            //        commands.Add(cmd);

            //    } catch (Exception ex)
            //    {
            //        MessageBox.Show("ERROR: Unable to parse command at index " + i + "\n\n" + ex.ToString());
            //        success = false;
            //        break;
            //    }
            //    i++;
            //}
            //if (success) target = commands;
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
                EvaluatorBox.Text = currentCondition.Evaluator;
                PassCmdBox.Text = currentCondition.PassScript;
            }
            UpdateTitleBox();
        }

        private void NotYet()
        {
            MessageBox.Show("Feature not yet implemented.");
        }

        private void AddConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var cnd = new ESD.Condition();
            cnd.Evaluator = "";
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
            cnd.Evaluator = "";
            cnd.TargetState = state ?? (long)0;
            currentCondition.Subconditions.Add(cnd);
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.LastNode;
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
            else if (editorControl.SelectedTab == entryTab) currentState.EntryScript = EntryCmdBox.Text;
            else if (editorControl.SelectedTab == exitTab) currentState.ExitScript = ExitCmdBox.Text;
            else if (editorControl.SelectedTab == whileTab) currentState.WhileScript = WhileCmdBox.Text;
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                currentCondition.PassScript = PassCmdBox.Text;
                currentCondition.Evaluator = EvaluatorBox.Text;
            }
            ShowSuccessLabel();
        }

        private void ShowSuccessLabel()
        {

            saveLabel.Visible = true;
            saveLabelTimer.Stop();
            saveLabelTimer.Start();
        }

        private void RevertBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            else if (editorControl.SelectedTab == entryTab) EntryCmdBox.Text = currentState.EntryScript;
            else if (editorControl.SelectedTab == exitTab) ExitCmdBox.Text = currentState.ExitScript;
            else if (editorControl.SelectedTab == whileTab) WhileCmdBox.Text = currentState.WhileScript;
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                PassCmdBox.Text = currentCondition.PassScript;
                EvaluatorBox.Text = currentCondition.Evaluator;
            }
        }

        private void saveEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void cloneStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var newState = CloneState(currentState);
            long stateId = currentStateGroup.Max(p => p.Key) + 1;
            currentStateGroup[stateId] = newState;
            StateGroupBox_SelectedIndexChanged(sender, e);
            StateBox.SelectedItem = stateId;
        }

        private ESD.State CloneState(ESD.State source)
        {
            var newState = new ESD.State();

            void CloneCondition(ESD.Condition srcCondition, ESD.Condition parentCondition = null)
            {
                var newCondition = new ESD.Condition();
                newCondition.TargetState = srcCondition.TargetState;
                newCondition.Evaluator = srcCondition.Evaluator;
                foreach (var sub in srcCondition.Subconditions) CloneCondition(sub, newCondition);
                newCondition.PassScript = srcCondition.PassScript;
                if (parentCondition == null) newState.Conditions.Add(newCondition);
                else parentCondition.Subconditions.Add(newCondition);
            }

            //ESD.CommandCall CloneCommand(ESD.CommandCall srcCommand)
            //{
            //    var command = new ESD.CommandCall();
            //    command.CommandBank = srcCommand.CommandBank;
            //    command.CommandID = srcCommand.CommandID;
            //    foreach (var arg in srcCommand.Arguments)
            //    {
            //        command.Arguments.Add(Clone(arg));
            //    }
            //    return command;
            //}

            foreach (var condition in source.Conditions) CloneCondition(condition);
            newState.EntryScript = source.EntryScript;
            newState.ExitScript = source.ExitScript;
            newState.WhileScript = source.WhileScript;
            return newState;
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
                else ClearEditors();
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

        private void AddGroupBtn_Click(object sender, EventArgs e)
        {
            var k = GetNewKey();
            if (!k.HasValue) return;
            if (currentESD.StateGroups.Keys.Contains(k.Value))
            {
                MessageBox.Show("ERROR: Key already exists.");
                AddGroupBtn_Click(sender, e);
                return;
            }
            currentESD.StateGroups[k.Value] = new Dictionary<long, ESD.State>();
            StateGroupBox.DataSource = currentESD.StateGroups.Keys.ToList();
            StateGroupBox.SelectedItem = k.Value;
            StateBox_SelectedIndexChanged(sender, e);
            ClearEditors();
        }

        private void CloneGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var k = GetNewKey();
            if (!k.HasValue) return;
            if (currentESD.StateGroups.Keys.Contains(k.Value))
            {
                MessageBox.Show("ERROR: Key already exists.");
                CloneGroupBtn_Click(sender, e);
                return;
            }
            var newGroup = new Dictionary<long, ESD.State>();
            foreach (var pair in currentStateGroup)
            {
                newGroup[pair.Key] = CloneState(currentStateGroup[pair.Key]);
            }
            currentESD.StateGroups[k.Value] = newGroup;
            StateGroupBox.DataSource = currentESD.StateGroups.Keys.ToList();
            StateGroupBox.SelectedItem = k.Value;
            StateBox_SelectedIndexChanged(sender, e);
            ClearEditors();
        }

        private void DeleteGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var key = (long) StateGroupBox.SelectedItem;
            if (DialogResult.OK == MessageBox.Show("Really delete group " + key + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                currentESD.StateGroups.Remove(key);
                StateBox.DataSource = null;
                ClearEditors();
                StateGroupBox.DataSource = currentESD.StateGroups.Keys.ToList();
            }
        }

        private void ClearEditors()
        {
            ConditionTree.Nodes.Clear();
            EditorTitleBox.Text = "";
            PassCmdBox.Text = "";
            WhileCmdBox.Text = "";
            EntryCmdBox.Text = "";
            ExitCmdBox.Text = "";
            EvaluatorBox.Text = "";
            ConditionNameBox.Text = "";
            TargetStateBox.Text = "";
        }

        public long? GetNewKey()
        {
            string key = "";
            var box = InputBox("Key", "Enter new key for state group:", ref key);
            if (box == DialogResult.OK)
            {
                long val;
                bool success = long.TryParse(key.Trim(), out val);
                if (success)
                {
                    return val;
                } else
                {
                    MessageBox.Show("Invalid key.");
                    GetNewKey();
                }
            }
            return null;
        }

        public DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void editESDPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            var editor = new PropertyEditor(currentESD);
            int x = DesktopBounds.Left + (Width - editor.Width) / 2;
            int y = DesktopBounds.Top + (Height - editor.Height) / 2;
            editor.Location = new Point(x, y);
            editor.StartPosition = FormStartPosition.Manual;
            editor.ShowDialog();
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
