using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoulsFormats;

namespace Zeditor
{
    public partial class GUI : Form
    {

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
                int[] nodePath = ConditionTree.SelectedNode.Name.Split('-').Select(k => Int32.Parse(k)).ToArray();
                ESD.Condition cnd = currentState.Conditions[nodePath[0]];
                for (int i = 1; i < nodePath.Count(); i++) cnd = cnd.Subconditions[nodePath[i]];
                return cnd;
            }
        }        
        ESD.CommandCall currentCommand
        {
            get
            {
                if (currentState == null) return null;
                int index = GeneralCmdBox.SelectedIndex;
                if (index == -1) return null;
                if (EntryCmdBtn.Checked) return currentState.EntryCommands[index];
                if (ExitCmdBtn.Checked) return currentState.ExitCommands[index];
                if (WhileCmdBtn.Checked) return currentState.WhileCommands[index];
                return null;
            }
        }

        public GUI()
        {
            InitializeComponent();
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
        }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionTree.Nodes.Clear();
            if (currentState == null) return;
            RefreshCmdBox();
            foreach (var condition in currentState.Conditions)
            {
                AddConditionNode(condition);
            }
            
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
        }

        private void AddConditionNode(ESD.Condition condition, TreeNode parent)
        {
            string cName = parent.Name + "-" + parent.Nodes.Count;
            TreeNode cNode = new TreeNode(cName);
            if (condition.TargetState != null) cNode.Text = "CND " + cName + " → " + condition.TargetState.ToString();
            cNode.Name = cName;
            parent.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
        }

        private void ConditionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var n = ConditionTree.SelectedNode;
            ConditionNameBox.Text = n == null ? "" : n.Text;
            TargetStateBox.Text = currentCondition.TargetState.ToString();
            if (currentCondition != null)
            {
                ViewPassCmdBtn.Visible = true;
            } else
            {
                ViewPassCmdBtn.Visible = false;
            }
        }

        private void TargetStateBox_TextChanged(object sender, EventArgs e)
        {
            if (currentCondition != null)
            {
                long newValue;
                bool success = long.TryParse(TargetStateBox.Text.Trim(), out newValue);
                if (!success || currentCondition.Subconditions.Count == 0)
                {
                    TargetStateBox.Text = currentCondition.TargetState.ToString();
                } else {
                    currentCondition.TargetState = newValue;
                }
            }
        }

        private void NotYet()
        {
            MessageBox.Show("Feature not yet implemented.");
        }

        private void RefreshCmdBox (bool isPassCommands = false)
        {
            GeneralCmdBox.DataSource = null;
            CommandListNameBox.Text = "";
            if (currentState == null) return;
            List<ESD.CommandCall> cmdList = new List<ESD.CommandCall>();

            if (isPassCommands)
            {
                CommandListNameBox.Text = ConditionTree.SelectedNode.Text + " : Pass Commands ";
                cmdList = currentCondition.PassCommands;
                EntryCmdBtn.Enabled = false;
                ExitCmdBtn.Enabled = false;
                WhileCmdBtn.Enabled = false;
                BackToStateCmdBtn.Visible = true;
            } else
            {
                CommandListNameBox.Text = "State " + StateBox.SelectedItem.ToString() + " : Commands ";

                EntryCmdBtn.Enabled = true;
                ExitCmdBtn.Enabled = true;
                WhileCmdBtn.Enabled = true;
                BackToStateCmdBtn.Visible = false;

                if (EntryCmdBtn.Checked) cmdList = currentState.EntryCommands;
                else if (ExitCmdBtn.Checked) cmdList = currentState.ExitCommands;
                else GeneralCmdBox.DataSource = cmdList = currentState.WhileCommands;
            }
            GeneralCmdBox.DataSource = cmdList.Select(cmd => cmd.CommandID).ToList();
        }

        private void EntryCmdBtn_CheckedChanged(object sender, EventArgs e) => RefreshCmdBox();

        private void ExitCmdBtn_CheckedChanged(object sender, EventArgs e) => RefreshCmdBox();

        private void WhileCmdBtn_CheckedChanged(object sender, EventArgs e) => RefreshCmdBox();

        private void GeneralCmdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GeneralCmdBox.SelectedIndex;
        }

        private void AddConditionBtn_Click(object sender, EventArgs e) => NotYet();

        private void DeleteConditionBtn_Click(object sender, EventArgs e) => NotYet();

        private void GoTargetBtn_Click(object sender, EventArgs e) => NotYet();

        private void ViewPassCmdBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition != null) RefreshCmdBox(true);
        }

        private void BackToStateCmdBtn_Click(object sender, EventArgs e)
        {
            RefreshCmdBox();
        }

        private void MoveCndUpBtn_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void MoveCndDownBtn_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void MoveCmdUpBtn_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void AddCmdBtn_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void DelCmdBtn_Click(object sender, EventArgs e)
        {
            NotYet();
        }

        private void saveESDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
