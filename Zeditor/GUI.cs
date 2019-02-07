using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Timers;
using SoulsFormats.ESD;
using System.Text.RegularExpressions;

namespace Zeditor
{
    public partial class GUI : Form
    {
        string filePath = "";
        public static ESD currentESD = null;
        StateGroupHandler currentSGH => (StateGroupHandler)StateGroupBox.SelectedItem ?? null;
        Dictionary<long, ESD.State> currentStateGroup => currentSGH == null ? null : currentSGH.Group;

        StateHandler currentSH => (StateHandler)StateBox.SelectedItem ?? null;
        ESD.State currentState => currentSH == null ? null : currentSH.State;

        ESD.Condition currentCondition
        {
            get
            {
                if (ConditionTree.SelectedNode == null) return null;
                return ConditionsFromNode(ConditionTree.SelectedNode).Condition;
            }
        }
        Dictionary<string, TextStyle> textStyles = new Dictionary<string, TextStyle>();
        bool loaded = false;
        System.Timers.Timer saveLabelTimer = new System.Timers.Timer();

        public GUI()
        {
            InitializeComponent();
            SetTextBoxOptions();
            OnResize();
            loaded = true;

            void hide(Object source, ElapsedEventArgs e)
            {
                if (saveLabel.InvokeRequired)
                {
                    saveLabel.Invoke(new Action(() => saveLabel.Visible = false));
                }
                else
                {
                    saveLabel.Visible = false;
                }

            }
            saveLabelTimer.Interval = 5000;
            saveLabelTimer.Elapsed += hide;
            saveLabelTimer.AutoReset = false;
        }

        public class StateGroupHandler
        {
            public long ID;
            public Dictionary<long, ESD.State> Group => currentESD.StateGroups[ID];
            public string Name
            {
                get => currentESD.StateGroupNames[ID];
                set => currentESD.StateGroupNames[ID] = value;
            }
            public string DisplayName => ID + ": " + Name;

            public StateGroupHandler(long id) => ID = id;
            public override string ToString() => Name;
        }

        public class StateHandler
        {
            public ESD.State State;
            public long ID => State.ID;
            public string DisplayName => State.ID + ": " + State.Name;

            public StateHandler(ESD.State state) => State = state;
        }

        private void openESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ActiveForm.UseWaitCursor = true;
                    currentESD = ESD.ReadWithMetadata(ofd.FileName, true);
                    ActiveForm.Text = "Zeditor - " + Path.GetFileName(ofd.FileName);
                    RefreshStateGroupBox();
                    filePath = ofd.FileName;
                    ActiveForm.UseWaitCursor = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Invalid ESD file." + Environment.NewLine + "---------" + Environment.NewLine + ex.ToString());
                    openESDToolStripMenuItem_Click(sender, e);
                    ActiveForm.UseWaitCursor = false;
                }
            }
        }

        private void StateGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearEditors();
            if (currentStateGroup != null)
            {
                RefreshStateBox();
            }
            else
            {
                StateBox.DisplayMember = "DisplayName";
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

            if (ConditionTree.Nodes.Count > 0) ConditionTree.SelectedNode = ConditionTree.Nodes[0];
            EntryCmdBox.Text = currentState.EntryScript;
            ExitCmdBox.Text = currentState.ExitScript;
            WhileCmdBox.Text = currentState.WhileScript;
            AfterSelect();
            UpdateTitleBox();
        }

        private string ConditionDisplay(ESD.Condition condition)
        {
            if (condition == null) return null;
            if (Regex.IsMatch(condition.Name, @"^Condition\[[A-Za-z0-9]+\]$"))
            {
                string conditionDisplay = condition.Name.Substring(10).TrimEnd(new char[] { '[', ']' });
                conditionDisplay = Regex.Replace(conditionDisplay ?? "", "^[0]+", "");
                return conditionDisplay;
            }
            else
            {
                return condition.Name;

            }
        }

        private void AddConditionNode(ESD.Condition condition)
        {
            int cNum = currentState.Conditions.IndexOf(condition);
            TreeNode cNode = new TreeNode();
            cNode.Name = cNum.ToString();
            cNode.Text = ConditionDisplay(condition);
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
            cNode.Name = cName;
            cNode.Text = ConditionDisplay(condition);
            if (condition.TargetState != null) cNode.Text += " → " + condition.TargetState.ToString();
            cNode.Name = cName;
            parent.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
        }


        private void WriteCommands(string plainText, ref List<ESD.CommandCall> target)
        {
            string current = "";
            try
            {
                current = "EntryScript";
                currentState.EntryScript = EntryCmdBox.Text.Trim();
                current = "ExitScript";
                currentState.ExitScript = ExitCmdBox.Text.Trim();
                current = "WhileScript";
                currentState.WhileScript = WhileCmdBox.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing " + current + "\n\n" + ex.ToString());

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

            EditorTitleBox.Text = currentSGH.Name + " : " + currentState.Name + " : ";
            if (editorControl.SelectedTab == stateTab) EditorTitleBox.Text += "Commands";
            else if (editorControl.SelectedTab == conditionTab) 
            {
                if (currentCondition == null) EditorTitleBox.Text = "";
                else EditorTitleBox.Text += ConditionDisplay(currentCondition);
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
                EvaluatorBox.Text = "";
                PassCmdBox.Text = "";
                TargetStateNameBox.Text = "";
                TargetStateBox.Text = "";
            }
            else
            {
                var t = currentCondition.TargetState;
                if (t == null)
                {
                    TargetStateBox.Text = "";
                    TargetStateNameBox.Text = "";
                } else
                {
                    TargetStateBox.Text = t.ToString();
                    TargetStateNameBox.Text = currentStateGroup[(long)t].Name;
                }
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
                StateBox_SelectedIndexChanged(sender, e);
                ConditionTree.Focus();  
            }
        }

        private void GoTargetBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition != null && currentCondition.TargetState != null)
            {
                int index = currentStateGroup.Keys.ToList().IndexOf((long) currentCondition.TargetState);
                StateBox.SelectedIndex = index;
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
            ConditionTree.Focus();
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

            var path = ConditionTree.SelectedNode.Name;
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.PrevNode;
            ConditionTree.Focus();


        }

        private void MoveCndDownBtn_Click(object sender, EventArgs e)
        {
            ConditionTree.Focus();
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

            var path = ConditionTree.SelectedNode.Name;
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.NextNode;
        }

        private void exportESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Title = "Export ESD";
            sfd.InitialDirectory = Path.GetDirectoryName(filePath);
            sfd.FileName = Path.GetFileName(filePath);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ActiveForm.UseWaitCursor = true;
                currentESD.WriteWithMetadata(sfd.FileName, true);
                filePath = sfd.FileName;
                Form.ActiveForm.Text = "Zeditor - " + Path.GetFileName(sfd.FileName);
                ActiveForm.UseWaitCursor = false;

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
            var cnd = currentCondition;
            if (cnd != null)
            {
                string s = TargetStateBox.Text.Trim();
                int newValue;
                bool success = int.TryParse(s, out newValue);
                if (s == "" && cnd.Subconditions.Count == 0)
                {
                    cnd.TargetState = null;
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                    TargetStateBox.Text = "";
                }
                else if (!success)
                {
                    MessageBox.Show("Invalid target state.");
                    TargetStateBox.Text = cnd.TargetState.ToString();
                }
                else if (cnd.Subconditions.Count > 0)
                {
                    MessageBox.Show("Conditions with subconditions can't have target states.");
                    TargetStateBox.Text = cnd.TargetState.ToString();
                }
                else
                {
                    currentCondition.TargetState = (long)newValue;
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                    TargetStateNameBox.Text = currentStateGroup[(long)newValue].Name;
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
            textStyles["comment"] = new TextStyle(Brushes.DarkGreen, Brushes.White, FontStyle.Regular);
        }

        private void BoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!loaded) return;
            e.ChangedRange.ClearStyle(textStyles.Values.ToArray());
            e.ChangedRange.SetStyle(textStyles["separator"], "[$]");
            e.ChangedRange.SetStyle(textStyles["num"], "[A-Za-z0-9]");
            e.ChangedRange.SetStyle(textStyles["command"], @"\d+:\d+[(]");
            e.ChangedRange.SetStyle(textStyles["regular"], "[():;]");
            e.ChangedRange.SetStyle(textStyles["comment"], @"[/]{2}.*(\n|$)");

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
            else if (editorControl.SelectedTab == stateTab)
            {
                currentState.EntryScript = EntryCmdBox.Text;
                currentState.ExitScript = ExitCmdBox.Text;
                currentState.WhileScript = WhileCmdBox.Text;
            }
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                currentCondition.PassScript = PassCmdBox.Text;
                currentCondition.Evaluator = EvaluatorBox.Text;
            }
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
            else if (editorControl.SelectedTab == stateTab)
            {
                EntryCmdBox.Text = currentState.EntryScript;
                ExitCmdBox.Text = currentState.ExitScript;
                WhileCmdBox.Text = currentState.WhileScript;
            }
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
            currentStateGroup[newState.ID] = newState;
            RefreshStateBox(newState.ID);
        }

        private ESD.State CloneState(ESD.State source, long? groupID = null)
        {
            var newState = new ESD.State();

            void CloneCondition(ESD.Condition srcCondition, ESD.Condition parentCondition = null)
            {
                var newCondition = new ESD.Condition();
                newCondition.Name = srcCondition.Name;
                newCondition.TargetState = srcCondition.TargetState;
                newCondition.Evaluator = srcCondition.Evaluator;
                foreach (var sub in srcCondition.Subconditions) CloneCondition(sub, newCondition);
                newCondition.PassScript = srcCondition.PassScript;
                if (parentCondition == null) newState.Conditions.Add(newCondition);
                else parentCondition.Subconditions.Add(newCondition);
            }

            foreach (var condition in source.Conditions) CloneCondition(condition);
            newState.EntryScript = source.EntryScript;
            newState.ExitScript = source.ExitScript;
            newState.WhileScript = source.WhileScript;


            if (groupID == null || groupID == currentSGH.ID) newState.ID = currentStateGroup.Max(p => p.Key) + 1;
            else newState.ID = source.ID;

            if (Regex.IsMatch(source.Name, @"^State\d+\-\d+$")) newState.Name = "State" + groupID + "-" + newState.ID;
            else newState.Name = source.Name;

            return newState;
        }

        private void addNewStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long stateId = currentStateGroup.Keys.Max() + 1;
            var state = new ESD.State();
            state.ID = stateId;
            state.Name = "State" + currentSGH.ID + "-" + stateId;
            currentStateGroup[stateId] = state;
            StateGroupBox_SelectedIndexChanged(sender, e);
            SelectState(stateId);
        }

        private void deleteStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            long stateId = currentSH.ID;
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
            currentESD.StateGroupNames[k.Value] = "StateGroup" + k.Value;
            ClearEditors();
            RefreshStateGroupBox(k.Value);
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
                newGroup[pair.Key] = CloneState(currentStateGroup[pair.Key], k.Value);
            }
            currentESD.StateGroups[k.Value] = newGroup;
            currentESD.StateGroupNames[k.Value] = "StateGroup" + k.Value;
            ClearEditors();
            RefreshStateGroupBox(k.Value);
        }

        private void DeleteGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var key = (long)StateGroupBox.SelectedItem;
            if (DialogResult.OK == MessageBox.Show("Really delete group " + key + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                currentESD.StateGroups.Remove(key);
                ClearEditors();
                RefreshStateGroupBox();
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
                if (success) return val;
                else
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
            textBox.SelectAll();

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

        private void OnResize()
        {
            int h = flowLayoutPanel1.Height / 3 - 3;
            int w = flowLayoutPanel1.Width - 10;
            groupBox5.Height = h;
            groupBox6.Height = h;
            groupBox7.Height = h;
            groupBox5.Width = w;
            groupBox6.Width = w;
            groupBox7.Width = w;

            int h2 = flowLayoutPanel3.Height / 2 - 3;
            int w2 = flowLayoutPanel3.Width - 10;
            groupBox3.Height = h2;
            groupBox4.Height = h2;
            groupBox3.Width = w2;
            groupBox4.Width = w2;


        }

        private void GUI_Resize(object sender, EventArgs e)
        {
            OnResize();
        }

        private void RenameStateBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            int index = StateBox.SelectedIndex;
            string name = currentState.Name;
            var box = InputBox("Rename State", "Enter a new name for the state: ", ref name);
            if (box == DialogResult.OK)
            {
                string newName = "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    newName = "State" + (long)StateGroupBox.SelectedItem + "-" + currentState.ID;
                }
                else
                {
                    newName = name.Trim();
                }
                currentState.Name = newName;
                RefreshStateBox();
                StateBox.SelectedIndex = index;
            }
        }

        private void RefreshStateBox(long? key = null)
        {
            StateBox.DataSource = null;
            if (currentStateGroup == null) return;
            StateBox.DisplayMember = "DisplayName";
            StateBox.DataSource = currentStateGroup.Values.Select(s => new StateHandler(s)).ToList();
            if (key.HasValue) SelectState(key.Value);
           
        }

        private void SelectState(long key)
        {
            foreach (var item in StateBox.Items)
            {
                var h = (StateHandler)item;
                if (h.ID == key)
                {
                    StateBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectGroup(long key)
        {
            foreach (var item in StateGroupBox.Items)
            {
                var h = (StateGroupHandler)item;
                if (h.ID == key)
                {
                    StateGroupBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void RenameConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            string name = currentCondition.Name;
            var box = InputBox("Rename State", "Enter a new name for " + currentCondition.Name + ":", ref name);
            if (box == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Invalid condition name.");
                    RenameConditionBtn_Click(sender, e);
                }
                else
                {
                    var path = ConditionTree.SelectedNode.Name;
                    currentCondition.Name = name.Trim();
                    StateBox_SelectedIndexChanged(sender, e);
                    SelectNode(path);
                }
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveESDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            SaveEdit(sender, e);
            ActiveForm.UseWaitCursor = true;
            try
            {
                currentESD.WriteWithMetadata(filePath, true);
                ShowSuccessLabel();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ActiveForm.UseWaitCursor = false;
        }

        private void RenameGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var handler = currentSGH;
            string name = currentSGH.Name;
            var box = InputBox("Rename State", "Enter a new name for " + handler.Name + ":", ref name);
            if (box == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    handler.Name = "StateGroup" + handler.ID;
                }
                else
                {
                    handler.Name = name.Trim();
                    RefreshStateGroupBox();
                }
            }
        }

        private void RefreshStateGroupBox(long? key = null)
        {
            StateGroupBox.DataSource = null;
            if (currentESD == null) return;
            StateGroupBox.DisplayMember = "DisplayName";
            StateGroupBox.DataSource = currentESD.StateGroups.Select(kv => new StateGroupHandler(kv.Key)).ToList();
            if (key.HasValue) SelectGroup(key.Value);

        }

        private void editorControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTitleBox();
            OnResize();
        }
    }
}
