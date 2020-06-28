using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using SoulsFormats.ESD;
using System.Text.RegularExpressions;
using SoulsFormats.ESD.EzSemble;
using System.Text;
using FastColoredTextBoxNS;

namespace Zeditor
{
    public partial class GUI : Form
    {
        static string lastDirectoryEsdLoadedFrom = null;

        static EzSembleContext ScriptingContext;
        
        static string CommandNames;
        static string FunctionNames;
        static string EnumNames;

        static List<string> CommandList = new List<string>();
        static List<string> FunctionList = new List<string>();

        public static Dictionary<string, string> ToolTips = new Dictionary<string, string>();
        public static string currentWord = "";

        string filePath = "";
        public static ESD currentESD = null;

        private bool IsCurrentlyClearingBoxesDoNotUpdateScriptFields = false;
        
        StateGroupHandler currentSGH => (StateGroupHandler)StateGroupBox.SelectedItem ?? null;
        Dictionary<long, ESD.State> currentStateGroup => currentSGH == null ? null : currentSGH.Group;

        StateHandler currentSH => (StateHandler)StateBox.SelectedItem ?? null;
        ESD.State currentState => currentSH == null ? null : currentSH.State;

        private bool isCurrentlySaving = false;

        ConditionHandler currentCH
        {
            get
            {
                if (ConditionTree.SelectedNode == null) return null;
                return ConditionsFromNode(ConditionTree.SelectedNode);
            }
        }
        ESD.Condition currentCondition
        {
            get
            {
                if (ConditionTree.SelectedNode == null) return null;
                return currentCH.Condition;

            }
        }
        System.Timers.Timer saveLabelTimer = new System.Timers.Timer();

        public GUI()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            OnResize();

            void hide(object source, ElapsedEventArgs e)
            {
                if (saveLabel.InvokeRequired) saveLabel.Invoke(new Action(() => saveLabel.Visible = false));
                else saveLabel.Visible = false;
            }

            saveLabelTimer.Interval = 5000;
            saveLabelTimer.Elapsed += hide;
            saveLabelTimer.AutoReset = false;
        }

        public void InitContext()
        {
            ScriptingContext = new EzSembleContext();
            ToolTips = new Dictionary<string, string>();
            CommandNames = "";
            FunctionNames = "";
            EnumNames = "";


            var result = MessageBox.Show("Load scripting documentation XML?", "Context", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                SetTextBoxOptions();
                return;
            }

            var contextBrowseDialog = new OpenFileDialog()
            {
                InitialDirectory = new FileInfo(typeof(GUI).Assembly.Location).DirectoryName,
                FileName = "ESDScriptingDocumentation_Chr.xml",
                Filter = "XML Files (*.XML)|*.XML",
                Title = "Select Documentation XML"
            };

            void BrowseForDocs()
            {
                if (contextBrowseDialog.ShowDialog() == DialogResult.OK)
                {
                    ScriptingContext = EzSembleContext.LoadFromXml(contextBrowseDialog.FileName);
                }
                else
                {
                    if (MessageBox.Show("Load without any documentation? (Commands/Functions will be numbers)", "Load Without Documentation?,", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SetTextBoxOptions();
                        return;
                    }
                    else
                    {
                        BrowseForDocs();
                    }
                }
            }

            BrowseForDocs();

            CommandNames = SortedString(ScriptingContext.GetAllCommandNames());
            FunctionNames = SortedString(ScriptingContext.GetAllFunctionNames()) + " SetREG0 SetREG1 SetREG2 SetREG3 SetREG4 SetREG5 SetREG6 SetREG7 GetREG0 GetREG1 GetREG2 GetREG3 GetREG4 GetREG5 GetREG6 GetREG7 AbortIfFalse";
            EnumNames = SortedString(ScriptingContext.GetAllEnumNames());

            foreach (string cmdName in ScriptingContext.GetAllCommandNames())
            {
                var id = ScriptingContext.GetCommandID(cmdName);
                var cmd = ScriptingContext.GetCommandInfo(id.Bank, id.ID);

                var sb = new StringBuilder();
                sb.AppendLine(cmd.Description + "\n");

                foreach (var arg in cmd.Args)
                {
                    sb.AppendLine($"\t[{arg.ValueType} {arg.Name}]\n\t\t{arg.Description}");
                }

                ToolTips[cmdName] = sb.ToString().Trim();
            }

            foreach (string functionName in ScriptingContext.GetAllFunctionNames())
            {
                var id = ScriptingContext.GetFunctionID(functionName);
                var fn = ScriptingContext.GetFunctionInfo(id);

                var sb = new StringBuilder();
                sb.AppendLine(fn.Args.Count > 0 ? $"({string.Join(", ", fn.Args.Select(a => a.Name))})" : "()");
                sb.AppendLine(fn.Description + "\n");

                foreach (var arg in fn.Args)
                {
                    sb.AppendLine($"\t[{arg.ValueType} {arg.Name}]\n\t\t{arg.Description}");
                }

                ToolTips[functionName] = sb.ToString().Trim();
            }

            SetTextBoxOptions();
        }

        public static string SortedString(List<string> strings)
        {
            var list = strings.ToList();
            list.Sort();
            return Regex.Replace(string.Join(" ", list), "\\s+", " ");
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

        private bool DoEsdLoad(string esdPath)
        {
            try
            {
                UseWaitCursor = true;
                InitContext();
                currentESD = ESD.ReadWithMetadata(esdPath, false, false, ScriptingContext);
                lastDirectoryEsdLoadedFrom = Path.GetDirectoryName(esdPath);
                LongFormatBox.Checked = currentESD.LongFormat;
                Text = Path.GetFileName(esdPath) + " - Zeditor";
                RefreshStateGroupBox();
                filePath = esdPath;
                UseWaitCursor = false;
                return true;
            }
            catch (Exception ex)
            {
                UTIL.LogException("Unable to load ESD.", ex);
                UseWaitCursor = false;
            }

            return false;
        }

        private void openESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                var startDir = Path.GetDirectoryName(filePath);
                if (Directory.Exists(startDir))
                {
                    ofd.InitialDirectory = startDir;
                    if (File.Exists(filePath))
                       ofd.FileName = Path.GetFileName(filePath);
                }
            }
            else if (lastDirectoryEsdLoadedFrom != null && Directory.Exists(lastDirectoryEsdLoadedFrom))
            {
                ofd.InitialDirectory = lastDirectoryEsdLoadedFrom;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!DoEsdLoad(ofd.FileName))
                {
                    openESDToolStripMenuItem_Click(sender, e);
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

        private void RefreshConditionBox()
        {
            ConditionTree.Nodes.Clear();
            if (currentState == null) return;
            foreach (var condition in currentState.Conditions)
            {
                AddConditionNode(condition);
            }

            if (ConditionTree.Nodes.Count > 0) ConditionTree.SelectedNode = ConditionTree.Nodes[0];
            EntryCmdBox.Text = currentState.EntryScript;
            EntryCmdBox.ClearUndo();
            ExitCmdBox.Text = currentState.ExitScript;
            ExitCmdBox.ClearUndo();
            WhileCmdBox.Text = currentState.WhileScript;
            WhileCmdBox.ClearUndo();
            AfterSelect();
            UpdateTitleBox();
        }
        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshConditionBox();

        }

        private string ConditionDisplay(ESD.Condition condition)
        {
            if (condition == null) return null;
            if (Regex.IsMatch(condition.Name, @"^Condition\[[A-Za-z0-9]+\]\s*(\(\d+\))?$"))
            {
                string conditionDisplay = condition.Name.Substring(10).Replace("[", "").Replace("]", "");
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
   
            try
            {
                currentState.EntryScript = EntryCmdBox.Text.Trim();
                currentState.ExitScript = ExitCmdBox.Text.Trim();
                currentState.WhileScript = WhileCmdBox.Text.Trim();
            }
            catch (Exception ex)
            {
                UTIL.LogException("Error writing commands", ex);

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
                    if (currentStateGroup.ContainsKey((long)t))
                        TargetStateNameBox.Text = currentStateGroup[(long)t].Name;
                    else
                        TargetStateNameBox.Text = "???";
                }
                EvaluatorBox.Text = currentCondition.Evaluator;
                PassCmdBox.Text = currentCondition.PassScript;
            }
            EvaluatorBox.ClearUndo();
            PassCmdBox.ClearUndo();
            UpdateTitleBox();
        }

        private void NotYet()
        {
            MessageBox.Show("Feature not yet implemented.");
        }

        private void ExpandFromList(List<string> list)
        {
            var allNodes = ConditionTree.Nodes.Cast<TreeNode>().SelectMany(GetNodeBranch);
            foreach (var treeNode in allNodes)
            {
                if (list.Contains(treeNode.Name))
                {
                    treeNode.Expand();
                }
            }
        }

        private List<string> ExpandedList()
        {
            List<string> list = new List<string>();
            var allNodes = ConditionTree.Nodes.Cast<TreeNode>().SelectMany(GetNodeBranch);
            foreach (var treeNode in allNodes)
            {
                if (treeNode.IsExpanded)
                    list.Add(treeNode.Name);
            }
            return list;
        }

        private IEnumerable<TreeNode> GetNodeBranch(TreeNode node)
        {
            yield return node;
            foreach (TreeNode child in node.Nodes)
                foreach (var childChild in GetNodeBranch(child))
                    yield return childChild;
        }

        private void AddConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var cnd = new ESD.Condition();
            cnd.Evaluator = "";
            cnd.TargetState = 0;
            currentState.Conditions.Add(cnd);

            var list = ExpandedList();
            StateBox_SelectedIndexChanged(sender, e);
            ConditionTree.SelectedNode = ConditionTree.Nodes[ConditionTree.Nodes.Count - 1];
            ExpandFromList(list);
        }

        private void AddSubconditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var path = ConditionTree.SelectedNode.Name;
            var state = currentCondition.TargetState;
            currentCondition.TargetState = null;

            var cnd = new ESD.Condition();
            cnd.Evaluator = "";
            cnd.TargetState = state ?? 0;
            currentCondition.Subconditions.Add(cnd);

            var list = ExpandedList();
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.LastNode;
            ExpandFromList(list);
        }

        private void AddSubcondition(ESD.Condition cnd, ESD.Condition parent)
        {
            var h = currentCH;
            if (currentCH == null) return;
            var path = ConditionTree.SelectedNode.Name;
            var state = currentCondition.TargetState;

            var list = ExpandedList();
            h.ParentCollection.Insert(h.Index + 1, cnd);
            
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.NextNode;
            ExpandFromList(list);
        }

        private void AddSibling(ESD.Condition sibling)
        {
            var h = currentCH;
            if (currentCH == null) return;
            var path = ConditionTree.SelectedNode.Name;
            var state = currentCondition.TargetState;

            var list = ExpandedList();
            h.ParentCollection.Insert(h.Index + 1, sibling);
            RefreshConditionBox();
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.NextNode;
            ExpandFromList(list);
        }

        private void AddSiblingConditionBtn_Click(object sender, EventArgs e)
        {
            var currentCnd = ConditionsFromNode(ConditionTree.SelectedNode).Condition;

            var newCnd = new ESD.Condition();
            newCnd.Evaluator = "";
            newCnd.PassScript = "";
            newCnd.TargetState = 0;
            newCnd.Name = "PRE-" + currentCnd.Name;

            var path = ConditionTree.SelectedNode.Name;
            var list = ExpandedList();

            foreach (var state in currentSGH.Group.Values)
            {
                void CheckConditionList(List<ESD.Condition> cndList)
                {
                    if (cndList.Contains(currentCnd) && !cndList.Contains(newCnd))
                    {
                        cndList.Insert(cndList.IndexOf(currentCnd), newCnd);
                    }

                    foreach (var subCnd in cndList)
                    {
                        if (subCnd.Subconditions != null)
                        {
                            CheckConditionList(subCnd.Subconditions);
                        }
                    }
                }

                CheckConditionList(state.Conditions);
            }

            RefreshConditionBox();
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.PrevNode;
            ExpandFromList(list);
        }

        private void DeleteConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var sibling = ConditionTree.SelectedNode.NextNode;
            var name = ConditionTree.SelectedNode.Text;
            if (DialogResult.OK == MessageBox.Show("Really delete " + name + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                ConditionsFromNode(ConditionTree.SelectedNode).ParentCollection.Remove(currentCondition);
                var list = ExpandedList();
                RefreshConditionBox();
                ConditionTree.Focus();
                ExpandFromList(list);
                ConditionTree.SelectedNode = sibling;
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
            var nodePath = node.Name.Split('-').Select(i => int.Parse(i)).ToList();
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
                try
                {
                    UseWaitCursor = true;
                    currentESD.WriteWithMetadata(sfd.FileName, false, ScriptingContext);
                    filePath = sfd.FileName;
                    Text = "Zeditor - " + Path.GetFileName(sfd.FileName);
                    UseWaitCursor = false;
                } catch (Exception ex)
                {
                    UTIL.LogException("Error saving ESD", ex);
                }
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
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                }
                else if (cnd.Subconditions.Count > 0)
                {
                    MessageBox.Show("Conditions with subconditions can't have target states.");
                    TargetStateBox.Text = cnd.TargetState.ToString();
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);

                }
                else
                {

                    currentCondition.TargetState = (long)newValue;
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                    if (currentStateGroup.ContainsKey(newValue))
                        TargetStateNameBox.Text = currentStateGroup[(long)newValue].Name;
                    else
                        TargetStateNameBox.Text = "???";
                }
            }
            var path = ConditionTree.SelectedNode.Name;
            RefreshConditionBox();
            SelectNode(path);
        }


        private void SetTextBoxOptions()
        {
            Color IntToColor(int rgb) => Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);

            CommandList = ScriptingContext.GetAllCommandNames();
            FunctionList = ScriptingContext.GetAllFunctionNames();

            IEnumerable<AutocompleteItem> functions = FunctionList.Select(str =>
            {
                int id = ScriptingContext.GetFunctionID(str);
                EzSembleContext.EzSembleMethodInfo info = ScriptingContext.GetFunctionInfo(id);
                string argString = string.Join(", ", info.Args.Select(arg => $"{arg.ValueType} {arg.Name}"));
                if (argString.Length == 2) argString = "No documented arguments.";
                ToolTips[str] = argString;
                return new AutocompleteItem(str + "(", -1, str, info.Description, argString);
            });

            IEnumerable<AutocompleteItem> commands = CommandList.Select(str =>
            {
                (int bank, int id) = ScriptingContext.GetCommandID(str);
                EzSembleContext.EzSembleMethodInfo info = ScriptingContext.GetCommandInfo(bank, id);
                string argString = "(" + string.Join(", ", info.Args.Select(arg => $"{arg.ValueType} {arg.Name}")) + ")";
                if (argString.Length == 2) argString = "No documented arguments.";
                ToolTips[str] = argString;
                return new AutocompleteItem(str + "(", -1, str, info.Description, argString);
            }).Concat(functions);

            FastColoredTextBox[] boxes = { EntryCmdBox, ExitCmdBox, WhileCmdBox, EvaluatorBox, PassCmdBox };
            foreach (var box in boxes)
            {
                box.Language = Language.JS;
                //box.Font = new Font("Consolas", 11f);
                AutocompleteMenu menu = new AutocompleteMenu(box);
                box.ToolTipNeeded += Box_ToolTipNeeded;
                //box.TextChanged += Box_TextChanged;
                if (box == EvaluatorBox)
                {
                    menu.Items.SetAutocompleteItems(functions);
                } else
                {
                    menu.Items.SetAutocompleteItems(commands);
                }

                menu.Items.MaximumSize = new Size(400, 300);
                menu.Items.Width = 250;
                menu.AllowTabKey = true;
                menu.AlwaysShowTooltip = true;
                menu.ToolTipDuration = 1;
                menu.AppearInterval = 250;
            }
        }

        private static List<TextStyle> Styles = new List<TextStyle>();

        private static class TextStyles
        {
            public static TextStyle Number = MakeStyle(Brushes.Orchid, FontStyle.Bold);
            public static TextStyle Grey = MakeStyle(Brushes.Gray);
            public static TextStyle Operator = MakeStyle(Brushes.Blue, FontStyle.Bold);
        }

        public static TextStyle MakeStyle(int r, int g, int b, FontStyle f = FontStyle.Regular)
        {
            var color = Color.FromArgb(r, g, b);
            return MakeStyle(new SolidBrush(color), f);
        }

        private static TextStyle MakeStyle(Brush b, FontStyle f = FontStyle.Regular)
        {
            Styles.Add(new TextStyle(b, Brushes.Transparent, f));
            return Styles.Last();
        }

        private void Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(Styles.ToArray());
            e.ChangedRange.SetStyle(TextStyles.Number, @"\b\d+\b");
            e.ChangedRange.SetStyle(TextStyles.Grey, @"[();]");
            e.ChangedRange.SetStyle(TextStyles.Operator, @"[^A-Za-z0-9();]+");
        }

        private void Box_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            if (ToolTips.Keys.Contains(e.HoveredWord))
            {
                e.ToolTipTitle = e.HoveredWord;
                e.ToolTipText = ToolTips[e.HoveredWord];
            }
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
            currentState.EntryScript = EntryCmdBox.Text;
            currentState.ExitScript = ExitCmdBox.Text;
            currentState.WhileScript = WhileCmdBox.Text;

            if (currentCondition == null) return;
            currentCondition.PassScript = PassCmdBox.Text;
            currentCondition.Evaluator = EvaluatorBox.Text;
        }

        private void ShowSuccessLabel(bool wasActuallySuccess)
        {
            saveLabel.Text = wasActuallySuccess ? "ESD SAVED SUCCESSFULLY" : "ESD SAVE FAILED";
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

        private ESD.Condition CloneCondition(ESD.Condition src, string postfix = " (1)")
        {

            ESD.Condition newCondition = new ESD.Condition();
            var match = Regex.Match(src.Name, @"\(\d+\)$");
            if (match.Success)
            {
                string s = match.Value.Trim('(', ')');
                int val = int.Parse(s);
                postfix = "(" + (val + 1) + ")";
                newCondition.Name = Regex.Replace(src.Name, @"\(\d+\)$", postfix);
            } else
            {
                newCondition.Name = src.Name + postfix;
            }
            newCondition.TargetState = src.TargetState;
            newCondition.Evaluator = src.Evaluator;
            newCondition.PassScript = src.PassScript;
            foreach (var sub in src.Subconditions)
            {
                newCondition.Subconditions.Add(CloneCondition(sub));
            }
            return newCondition;
        }

        private ESD.Condition CloneCondition(ESD.Condition src, ESD.State parent)
        {
            ESD.Condition cnd = CloneCondition(src);
            parent.Conditions.Add(cnd);
            return cnd;
        }

        private ESD.State CloneState(ESD.State source, long? groupID = null, long? stateID = null)
        {
            var newState = new ESD.State();

            foreach (var condition in source.Conditions) newState.Conditions.Add(CloneCondition(condition));

            newState.EntryScript = source.EntryScript;
            newState.ExitScript = source.ExitScript;
            newState.WhileScript = source.WhileScript;

            if (stateID == null)
                newState.ID = currentStateGroup.Max(p => p.Key) + 1;
            else
                newState.ID = stateID.Value;

            if (Regex.IsMatch(source.Name, @"^State\d+\-\d+$")) newState.Name = "State" + currentSGH.ID + "-" + newState.ID;
            else newState.Name = source.Name + " (1)";

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
            MessageBox.Show("-GUI created by AinTunez\n" +
                "-ESD serialization backend created by TKGP\n" +
                "-ESD script documentation and compiler created by Meowmaritus", 
                "About Zeditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            IsCurrentlyClearingBoxesDoNotUpdateScriptFields = true;
            ConditionTree.Nodes.Clear();
            EditorTitleBox.Text = "";
            PassCmdBox.Text = "";
            WhileCmdBox.Text = "";
            EntryCmdBox.Text = "";
            ExitCmdBox.Text = "";
            EvaluatorBox.Text = "";
            TargetStateBox.Text = "";
            IsCurrentlyClearingBoxesDoNotUpdateScriptFields = false;
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
            var editState = currentState;
            var editor = new StateDataEditor(editState);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (!currentStateGroup.ContainsKey(editor.StateID) || currentStateGroup[editor.StateID] == editState)
                {
                    currentStateGroup.Remove(editState.ID);
                    editState.ID = editor.StateID;
                    currentStateGroup[editState.ID] = editState;
                    editState.Name = editor.StateName;
                    RefreshStateBox(editState.ID);
                } else if (editor.StateID != editState.ID)
                {
                    MessageBox.Show("ERROR: State ID already exists.");
                    RenameStateBtn_Click(sender, e);
                }

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

        private void DoSaveInBackground()
        {
            Invoke(new Action(() =>
            {
                isCurrentlySaving = true;

                saveLabel.Text = "Saving...";
                saveLabel.Visible = true;
                saveLabelTimer.Stop();

                UseWaitCursor = true;
                Enabled = false;
            }));

            BeginInvoke(new Action(() =>
            {
                try
                {
                    currentESD.WriteWithMetadata(filePath, false, ScriptingContext);
                    ShowSuccessLabel(true);
                }
                catch (Exception ex)
                {
                    UTIL.LogException("Error saving ESD", ex);
                    ShowSuccessLabel(false);
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        UseWaitCursor = false;
                        Enabled = true;
                        isCurrentlySaving = false;

                    }));
                }
            }));

            
        }

        private void saveESDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            SaveEdit(sender, e);
            BeginInvoke(new Action(() => DoSaveInBackground()));
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

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isCurrentlySaving)
            {
                e.Cancel = true;
                return;
            }

            var isClose = MessageBox.Show("Are you sure you wish to close Zeditor?", 
                "Close App?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

            if (!isClose)
            {
                e.Cancel = true;
            }
        }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                FastColoredTextBox[] boxes = { EntryCmdBox, ExitCmdBox, WhileCmdBox, EvaluatorBox, PassCmdBox };
                foreach (var textBox in boxes)
                {
                    if (!textBox.Focused) continue;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }


        private void LongFormatBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            currentESD.LongFormat = LongFormatBox.Checked;
        }

        private void GUI_Load(object sender, EventArgs e)
        {


            bool isValidAutoFileOpen = false;
            // In try catch because if invalid path was given I think File.Exists would just freak out
            try
            {
                isValidAutoFileOpen = Program.ARGS != null && Program.ARGS.Length == 1 && File.Exists(Program.ARGS[0]);
            }
            catch
            {

            }

            if (isValidAutoFileOpen)
            {
                DoEsdLoad(Program.ARGS[0]);
            }
        }

        private void testEntryScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string plaintext = Regex.Replace(EntryCmdBox.Text, @"\/\/.*\n", "");
            foreach (var cmdTxt in plaintext.Split(';'))
            {
                var cmdLine = cmdTxt.Replace("\r", "").Trim(' ', '\n');
                if (cmdLine.Contains("//"))
                {
                    cmdLine = cmdLine.Substring(0, cmdLine.IndexOf("//"));
                }
                Console.WriteLine(cmdLine);
            }
        }

        private void cloneToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            CloneHelper cloneTo = new CloneHelper();
            if (cloneTo.ShowDialog() == DialogResult.OK)
            {
                ESD.State newState = CloneState(currentState, null, cloneTo.TargetID);
                if (currentStateGroup.ContainsKey(newState.ID))
                    currentStateGroup.Remove(newState.ID);
                currentStateGroup[newState.ID] = newState;
                RefreshStateBox(newState.ID);
            }
        }

        private void searchPrecedingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            long target = currentState.ID;
            Dictionary<ESD.Condition, List<long>> results = new Dictionary<ESD.Condition, List<long>>();
            foreach (ESD.State state in currentStateGroup.Values)
            {
                foreach (ESD.Condition cnd in state.Conditions)
                {
                    CheckForStargetState(state, cnd, target, results);
                }
            }

            var viewer = new SearchResultViewer(results);
            viewer.ShowDialog();
        }

        private void CheckForStargetState(ESD.State state, ESD.Condition cnd, long target, Dictionary<ESD.Condition, List<long>> results)
        {
            if (cnd.TargetState.HasValue)
            {
                if (cnd.TargetState == target)
                {
                    if (!results.ContainsKey(cnd))
                        results[cnd] = new List<long>();
                    results[cnd].Add(state.ID);
                }
            } else
            {
                foreach (var sub in cnd.Subconditions)
                {
                    CheckForStargetState(state, sub, target, results);
                }
            }
        }

        private bool HasTargetState(ESD.Condition cnd, long target)
        {
            if (cnd.TargetState.HasValue)
                return cnd.TargetState.Value == target;
            
            foreach (ESD.Condition sub in cnd.Subconditions)
                    if (HasTargetState(sub, target))
                        return true;

            return false;
        }

        private void ReplaceTargetState(ESD.Condition cnd, long changeFrom, long changeTo)
        {
            if (cnd.TargetState.HasValue)
            {
                if (cnd.TargetState == changeFrom)
                {
                    cnd.TargetState = changeTo;
                    cnd.Name = ConditionDisplay(cnd);
                }
            } else
            {
                foreach (ESD.Condition sub in cnd.Subconditions)
                    ReplaceTargetState(sub, changeFrom, changeTo);
            }
        }

        private void bulkTargetSwitchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var switcher = new BulkTargetSwitch();
            if (switcher.ShowDialog() == DialogResult.OK)
            {
                foreach (ESD.State state in currentStateGroup.Values)
                {
                    foreach (ESD.Condition cnd in state.Conditions)
                        ReplaceTargetState(cnd, switcher.ChangeFrom, switcher.ChangeTo);
                }
            }
        }

        private void EvaluatorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentCondition == null) return;
            currentCondition.Evaluator = EvaluatorBox.Text;
        }

        private void CloneCndBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            AddSibling(CloneCondition(currentCondition));
        }

        private void EntryCmdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentState != null && !IsCurrentlyClearingBoxesDoNotUpdateScriptFields)
                currentState.EntryScript = EntryCmdBox.Text;
        }

        private void ExitCmdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentState != null && !IsCurrentlyClearingBoxesDoNotUpdateScriptFields)
                currentState.ExitScript = ExitCmdBox.Text;
        }

        private void WhileCmdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentState != null && !IsCurrentlyClearingBoxesDoNotUpdateScriptFields)
                currentState.WhileScript = WhileCmdBox.Text;
        }

        private void TargetStateBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class UTIL
    {

        public static void LogException(string message, Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine("* " + message + " *" + Environment.NewLine + ex.Message);

            var trace = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < trace.Count(); i++)
            {
                var line = trace[i];
                int sfIndex = line.LastIndexOf("SoulsFormats");
                int edIndex = line.LastIndexOf("Zeditor");
                if (sfIndex > -1) sb.AppendLine("  at " + line.Substring(sfIndex));
                else if (edIndex > -1) sb.AppendLine("  at " + line.Substring(edIndex));
                else sb.AppendLine("  at " + line);
            }

            var v = new MsgViewer();
            v.msgBox.Text = sb.ToString();
            v.Show();
        }

    }

    public class ToolTipHandler
    {

        private EzSembleContext.EzSembleMethodInfo MethodInfo;
        public string Name => MethodInfo.Name;
        public string Text { get; }

        public ToolTipHandler (EzSembleContext.EzSembleMethodInfo info)
        {
            MethodInfo = info;


        }
    }

}
