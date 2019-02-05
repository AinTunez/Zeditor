namespace Zeditor
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.StateGroupBox = new System.Windows.Forms.ListBox();
            this.StateBox = new System.Windows.Forms.ListBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openESDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveESDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportESDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editESDPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEditorContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noHelpForYouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddStateBtn = new System.Windows.Forms.Button();
            this.DeleteStateBtn = new System.Windows.Forms.Button();
            this.CloneStateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TargetStateBox = new System.Windows.Forms.TextBox();
            this.GoTargetBtn = new System.Windows.Forms.Button();
            this.ConditionTree = new System.Windows.Forms.TreeView();
            this.AddConditionBtn = new System.Windows.Forms.Button();
            this.DeleteConditionBtn = new System.Windows.Forms.Button();
            this.MoveCndUpBtn = new System.Windows.Forms.Button();
            this.MoveCndDownBtn = new System.Windows.Forms.Button();
            this.AddSubconditionBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RenameConditionBtn = new System.Windows.Forms.Button();
            this.EditorTitleBox = new System.Windows.Forms.TextBox();
            this.RevertBtn = new System.Windows.Forms.Button();
            this.saveLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editorControl = new System.Windows.Forms.TabControl();
            this.stateTab = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.EntryCmdBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ExitCmdBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.WhileCmdBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.conditionTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EvaluatorBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PassCmdBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.AddGroupBtn = new System.Windows.Forms.Button();
            this.DeleteGroupBtn = new System.Windows.Forms.Button();
            this.CloneGroupBtn = new System.Windows.Forms.Button();
            this.RenameStateBtn = new System.Windows.Forms.Button();
            this.RenameGroupBtn = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.editorControl.SuspendLayout();
            this.stateTab.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntryCmdBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitCmdBox)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhileCmdBox)).BeginInit();
            this.conditionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluatorBox)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassCmdBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StateGroupBox
            // 
            this.StateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StateGroupBox.DisplayMember = "Key";
            this.StateGroupBox.FormattingEnabled = true;
            this.StateGroupBox.ItemHeight = 16;
            this.StateGroupBox.Location = new System.Drawing.Point(12, 55);
            this.StateGroupBox.Name = "StateGroupBox";
            this.StateGroupBox.Size = new System.Drawing.Size(150, 516);
            this.StateGroupBox.TabIndex = 0;
            this.StateGroupBox.SelectedIndexChanged += new System.EventHandler(this.StateGroupBox_SelectedIndexChanged);
            // 
            // StateBox
            // 
            this.StateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StateBox.DisplayMember = "Name";
            this.StateBox.FormattingEnabled = true;
            this.StateBox.ItemHeight = 16;
            this.StateBox.Location = new System.Drawing.Point(168, 55);
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(170, 516);
            this.StateBox.TabIndex = 1;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.stateToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1449, 28);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openESDToolStripMenuItem,
            this.saveESDToolStripMenuItem,
            this.exportESDToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openESDToolStripMenuItem
            // 
            this.openESDToolStripMenuItem.Name = "openESDToolStripMenuItem";
            this.openESDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openESDToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.openESDToolStripMenuItem.Text = "Open ESD";
            this.openESDToolStripMenuItem.Click += new System.EventHandler(this.openESDToolStripMenuItem_Click);
            // 
            // saveESDToolStripMenuItem
            // 
            this.saveESDToolStripMenuItem.Name = "saveESDToolStripMenuItem";
            this.saveESDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveESDToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.saveESDToolStripMenuItem.Text = "Save ESD";
            this.saveESDToolStripMenuItem.Click += new System.EventHandler(this.saveESDToolStripMenuItem_Click_1);
            // 
            // exportESDToolStripMenuItem
            // 
            this.exportESDToolStripMenuItem.Name = "exportESDToolStripMenuItem";
            this.exportESDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.exportESDToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.exportESDToolStripMenuItem.Text = "Export ESD";
            this.exportESDToolStripMenuItem.Click += new System.EventHandler(this.exportESDToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editESDPropertiesToolStripMenuItem,
            this.saveEditorContentToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editESDPropertiesToolStripMenuItem
            // 
            this.editESDPropertiesToolStripMenuItem.Name = "editESDPropertiesToolStripMenuItem";
            this.editESDPropertiesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.editESDPropertiesToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.editESDPropertiesToolStripMenuItem.Text = "Edit ESD Properties";
            this.editESDPropertiesToolStripMenuItem.Click += new System.EventHandler(this.editESDPropertiesToolStripMenuItem_Click);
            // 
            // saveEditorContentToolStripMenuItem
            // 
            this.saveEditorContentToolStripMenuItem.Name = "saveEditorContentToolStripMenuItem";
            this.saveEditorContentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveEditorContentToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.saveEditorContentToolStripMenuItem.Text = "Save Editor Content";
            this.saveEditorContentToolStripMenuItem.Visible = false;
            this.saveEditorContentToolStripMenuItem.Click += new System.EventHandler(this.saveEditorContentToolStripMenuItem_Click);
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStateToolStripMenuItem,
            this.cloneStateToolStripMenuItem,
            this.deleteStateToolStripMenuItem});
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.stateToolStripMenuItem.Text = "States";
            // 
            // addNewStateToolStripMenuItem
            // 
            this.addNewStateToolStripMenuItem.Name = "addNewStateToolStripMenuItem";
            this.addNewStateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addNewStateToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.addNewStateToolStripMenuItem.Text = "Add New State";
            this.addNewStateToolStripMenuItem.Click += new System.EventHandler(this.addNewStateToolStripMenuItem_Click);
            // 
            // cloneStateToolStripMenuItem
            // 
            this.cloneStateToolStripMenuItem.Name = "cloneStateToolStripMenuItem";
            this.cloneStateToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+N";
            this.cloneStateToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.cloneStateToolStripMenuItem.Text = "Clone State";
            this.cloneStateToolStripMenuItem.Click += new System.EventHandler(this.cloneStateToolStripMenuItem_Click);
            // 
            // deleteStateToolStripMenuItem
            // 
            this.deleteStateToolStripMenuItem.Name = "deleteStateToolStripMenuItem";
            this.deleteStateToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+D";
            this.deleteStateToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.deleteStateToolStripMenuItem.Text = "Delete State";
            this.deleteStateToolStripMenuItem.Click += new System.EventHandler(this.deleteStateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noHelpForYouToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // noHelpForYouToolStripMenuItem
            // 
            this.noHelpForYouToolStripMenuItem.Name = "noHelpForYouToolStripMenuItem";
            this.noHelpForYouToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.noHelpForYouToolStripMenuItem.Text = "About";
            this.noHelpForYouToolStripMenuItem.Click += new System.EventHandler(this.noHelpForYouToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Groups";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(168, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "States";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddStateBtn
            // 
            this.AddStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddStateBtn.Location = new System.Drawing.Point(168, 611);
            this.AddStateBtn.Name = "AddStateBtn";
            this.AddStateBtn.Size = new System.Drawing.Size(170, 28);
            this.AddStateBtn.TabIndex = 12;
            this.AddStateBtn.Text = "Add";
            this.AddStateBtn.UseVisualStyleBackColor = true;
            this.AddStateBtn.Click += new System.EventHandler(this.addNewStateToolStripMenuItem_Click);
            // 
            // DeleteStateBtn
            // 
            this.DeleteStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteStateBtn.Location = new System.Drawing.Point(168, 679);
            this.DeleteStateBtn.Name = "DeleteStateBtn";
            this.DeleteStateBtn.Size = new System.Drawing.Size(170, 28);
            this.DeleteStateBtn.TabIndex = 13;
            this.DeleteStateBtn.Text = "Delete";
            this.DeleteStateBtn.UseVisualStyleBackColor = true;
            this.DeleteStateBtn.Click += new System.EventHandler(this.deleteStateToolStripMenuItem_Click);
            // 
            // CloneStateBtn
            // 
            this.CloneStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloneStateBtn.Location = new System.Drawing.Point(168, 645);
            this.CloneStateBtn.Name = "CloneStateBtn";
            this.CloneStateBtn.Size = new System.Drawing.Size(170, 28);
            this.CloneStateBtn.TabIndex = 14;
            this.CloneStateBtn.Text = "Clone";
            this.CloneStateBtn.UseVisualStyleBackColor = true;
            this.CloneStateBtn.Click += new System.EventHandler(this.cloneStateToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Target State";
            // 
            // TargetStateBox
            // 
            this.TargetStateBox.Location = new System.Drawing.Point(338, 346);
            this.TargetStateBox.Name = "TargetStateBox";
            this.TargetStateBox.Size = new System.Drawing.Size(50, 22);
            this.TargetStateBox.TabIndex = 5;
            this.TargetStateBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TargetStateBox_KeyDown);
            this.TargetStateBox.Leave += new System.EventHandler(this.TargetStateBox_Leave);
            // 
            // GoTargetBtn
            // 
            this.GoTargetBtn.Location = new System.Drawing.Point(250, 374);
            this.GoTargetBtn.Name = "GoTargetBtn";
            this.GoTargetBtn.Size = new System.Drawing.Size(138, 34);
            this.GoTargetBtn.TabIndex = 7;
            this.GoTargetBtn.Text = "Go to Target";
            this.GoTargetBtn.UseVisualStyleBackColor = true;
            this.GoTargetBtn.Click += new System.EventHandler(this.GoTargetBtn_Click);
            // 
            // ConditionTree
            // 
            this.ConditionTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ConditionTree.HideSelection = false;
            this.ConditionTree.Location = new System.Drawing.Point(6, 21);
            this.ConditionTree.Name = "ConditionTree";
            this.ConditionTree.PathSeparator = "-";
            this.ConditionTree.Size = new System.Drawing.Size(230, 658);
            this.ConditionTree.TabIndex = 3;
            this.ConditionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConditionTree_AfterSelect);
            // 
            // AddConditionBtn
            // 
            this.AddConditionBtn.Location = new System.Drawing.Point(250, 85);
            this.AddConditionBtn.Name = "AddConditionBtn";
            this.AddConditionBtn.Size = new System.Drawing.Size(138, 32);
            this.AddConditionBtn.TabIndex = 9;
            this.AddConditionBtn.Text = "Add Condition";
            this.AddConditionBtn.UseVisualStyleBackColor = true;
            this.AddConditionBtn.Click += new System.EventHandler(this.AddConditionBtn_Click);
            // 
            // DeleteConditionBtn
            // 
            this.DeleteConditionBtn.Location = new System.Drawing.Point(250, 161);
            this.DeleteConditionBtn.Name = "DeleteConditionBtn";
            this.DeleteConditionBtn.Size = new System.Drawing.Size(138, 32);
            this.DeleteConditionBtn.TabIndex = 10;
            this.DeleteConditionBtn.Text = "Delete Condition";
            this.DeleteConditionBtn.UseVisualStyleBackColor = true;
            this.DeleteConditionBtn.Click += new System.EventHandler(this.DeleteConditionBtn_Click);
            // 
            // MoveCndUpBtn
            // 
            this.MoveCndUpBtn.Location = new System.Drawing.Point(250, 256);
            this.MoveCndUpBtn.Name = "MoveCndUpBtn";
            this.MoveCndUpBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndUpBtn.TabIndex = 10;
            this.MoveCndUpBtn.Text = "Move ↑";
            this.MoveCndUpBtn.UseVisualStyleBackColor = true;
            this.MoveCndUpBtn.Click += new System.EventHandler(this.MoveCndUpBtn_Click);
            // 
            // MoveCndDownBtn
            // 
            this.MoveCndDownBtn.Location = new System.Drawing.Point(250, 292);
            this.MoveCndDownBtn.Name = "MoveCndDownBtn";
            this.MoveCndDownBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndDownBtn.TabIndex = 11;
            this.MoveCndDownBtn.Text = "Move ↓";
            this.MoveCndDownBtn.UseVisualStyleBackColor = true;
            this.MoveCndDownBtn.Click += new System.EventHandler(this.MoveCndDownBtn_Click);
            // 
            // AddSubconditionBtn
            // 
            this.AddSubconditionBtn.Location = new System.Drawing.Point(250, 123);
            this.AddSubconditionBtn.Name = "AddSubconditionBtn";
            this.AddSubconditionBtn.Size = new System.Drawing.Size(138, 32);
            this.AddSubconditionBtn.TabIndex = 12;
            this.AddSubconditionBtn.Text = "Add Subcondition";
            this.AddSubconditionBtn.UseVisualStyleBackColor = true;
            this.AddSubconditionBtn.Click += new System.EventHandler(this.AddSubconditionBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.RenameConditionBtn);
            this.groupBox1.Controls.Add(this.AddSubconditionBtn);
            this.groupBox1.Controls.Add(this.MoveCndDownBtn);
            this.groupBox1.Controls.Add(this.MoveCndUpBtn);
            this.groupBox1.Controls.Add(this.DeleteConditionBtn);
            this.groupBox1.Controls.Add(this.AddConditionBtn);
            this.groupBox1.Controls.Add(this.ConditionTree);
            this.groupBox1.Controls.Add(this.GoTargetBtn);
            this.groupBox1.Controls.Add(this.TargetStateBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(363, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 685);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // RenameConditionBtn
            // 
            this.RenameConditionBtn.Location = new System.Drawing.Point(250, 199);
            this.RenameConditionBtn.Name = "RenameConditionBtn";
            this.RenameConditionBtn.Size = new System.Drawing.Size(138, 32);
            this.RenameConditionBtn.TabIndex = 13;
            this.RenameConditionBtn.Text = "Rename Condition";
            this.RenameConditionBtn.UseVisualStyleBackColor = true;
            this.RenameConditionBtn.Click += new System.EventHandler(this.RenameConditionBtn_Click);
            // 
            // EditorTitleBox
            // 
            this.EditorTitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTitleBox.Location = new System.Drawing.Point(7, 57);
            this.EditorTitleBox.Name = "EditorTitleBox";
            this.EditorTitleBox.ReadOnly = true;
            this.EditorTitleBox.Size = new System.Drawing.Size(651, 22);
            this.EditorTitleBox.TabIndex = 9;
            // 
            // RevertBtn
            // 
            this.RevertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RevertBtn.Location = new System.Drawing.Point(441, 21);
            this.RevertBtn.Name = "RevertBtn";
            this.RevertBtn.Size = new System.Drawing.Size(217, 30);
            this.RevertBtn.TabIndex = 11;
            this.RevertBtn.Text = "Revert to Saved";
            this.RevertBtn.UseVisualStyleBackColor = true;
            this.RevertBtn.Click += new System.EventHandler(this.RevertBtn_Click);
            // 
            // saveLabel
            // 
            this.saveLabel.AutoSize = true;
            this.saveLabel.Location = new System.Drawing.Point(6, 30);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(86, 17);
            this.saveLabel.TabIndex = 12;
            this.saveLabel.Text = "ESD SAVED";
            this.saveLabel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.saveLabel);
            this.groupBox2.Controls.Add(this.RevertBtn);
            this.groupBox2.Controls.Add(this.EditorTitleBox);
            this.groupBox2.Controls.Add(this.editorControl);
            this.groupBox2.Location = new System.Drawing.Point(772, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 685);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor";
            // 
            // editorControl
            // 
            this.editorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorControl.Controls.Add(this.stateTab);
            this.editorControl.Controls.Add(this.conditionTab);
            this.editorControl.Location = new System.Drawing.Point(3, 85);
            this.editorControl.Name = "editorControl";
            this.editorControl.SelectedIndex = 0;
            this.editorControl.Size = new System.Drawing.Size(659, 597);
            this.editorControl.TabIndex = 0;
            this.editorControl.SelectedIndexChanged += new System.EventHandler(this.UpdateTitleBox);
            // 
            // stateTab
            // 
            this.stateTab.Controls.Add(this.flowLayoutPanel1);
            this.stateTab.Location = new System.Drawing.Point(4, 25);
            this.stateTab.Name = "stateTab";
            this.stateTab.Padding = new System.Windows.Forms.Padding(3);
            this.stateTab.Size = new System.Drawing.Size(651, 568);
            this.stateTab.TabIndex = 0;
            this.stateTab.Text = "State";
            this.stateTab.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.groupBox6);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(645, 562);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.EntryCmdBox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(594, 156);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Entry Commands";
            // 
            // EntryCmdBox
            // 
            this.EntryCmdBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.EntryCmdBox.AutoScrollMinSize = new System.Drawing.Size(27, 16);
            this.EntryCmdBox.BackBrush = null;
            this.EntryCmdBox.CharHeight = 16;
            this.EntryCmdBox.CharWidth = 8;
            this.EntryCmdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EntryCmdBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.EntryCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntryCmdBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.EntryCmdBox.IsReplaceMode = false;
            this.EntryCmdBox.Location = new System.Drawing.Point(3, 18);
            this.EntryCmdBox.Name = "EntryCmdBox";
            this.EntryCmdBox.Paddings = new System.Windows.Forms.Padding(0);
            this.EntryCmdBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.EntryCmdBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("EntryCmdBox.ServiceColors")));
            this.EntryCmdBox.Size = new System.Drawing.Size(588, 135);
            this.EntryCmdBox.TabIndex = 0;
            this.EntryCmdBox.Zoom = 100;
            this.EntryCmdBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.BoxTextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ExitCmdBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 165);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(594, 150);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Exit Commands";
            // 
            // ExitCmdBox
            // 
            this.ExitCmdBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.ExitCmdBox.AutoScrollMinSize = new System.Drawing.Size(27, 16);
            this.ExitCmdBox.BackBrush = null;
            this.ExitCmdBox.CharHeight = 16;
            this.ExitCmdBox.CharWidth = 8;
            this.ExitCmdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ExitCmdBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ExitCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitCmdBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ExitCmdBox.IsReplaceMode = false;
            this.ExitCmdBox.Location = new System.Drawing.Point(3, 18);
            this.ExitCmdBox.Name = "ExitCmdBox";
            this.ExitCmdBox.Paddings = new System.Windows.Forms.Padding(0);
            this.ExitCmdBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.ExitCmdBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("ExitCmdBox.ServiceColors")));
            this.ExitCmdBox.Size = new System.Drawing.Size(588, 129);
            this.ExitCmdBox.TabIndex = 2;
            this.ExitCmdBox.Zoom = 100;
            this.ExitCmdBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.BoxTextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.WhileCmdBox);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 321);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(594, 156);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "While Commands";
            // 
            // WhileCmdBox
            // 
            this.WhileCmdBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.WhileCmdBox.AutoScrollMinSize = new System.Drawing.Size(2, 16);
            this.WhileCmdBox.BackBrush = null;
            this.WhileCmdBox.CharHeight = 16;
            this.WhileCmdBox.CharWidth = 8;
            this.WhileCmdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WhileCmdBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.WhileCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhileCmdBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.WhileCmdBox.IsReplaceMode = false;
            this.WhileCmdBox.Location = new System.Drawing.Point(3, 18);
            this.WhileCmdBox.Name = "WhileCmdBox";
            this.WhileCmdBox.Paddings = new System.Windows.Forms.Padding(0);
            this.WhileCmdBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.WhileCmdBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("WhileCmdBox.ServiceColors")));
            this.WhileCmdBox.Size = new System.Drawing.Size(588, 135);
            this.WhileCmdBox.TabIndex = 2;
            this.WhileCmdBox.Zoom = 100;
            this.WhileCmdBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.BoxTextChanged);
            // 
            // conditionTab
            // 
            this.conditionTab.Controls.Add(this.splitContainer1);
            this.conditionTab.Location = new System.Drawing.Point(4, 25);
            this.conditionTab.Name = "conditionTab";
            this.conditionTab.Size = new System.Drawing.Size(651, 568);
            this.conditionTab.TabIndex = 3;
            this.conditionTab.Text = "Condition";
            this.conditionTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(651, 568);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EvaluatorBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(651, 241);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Evaluator";
            // 
            // EvaluatorBox
            // 
            this.EvaluatorBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.EvaluatorBox.AutoScrollMinSize = new System.Drawing.Size(0, 26);
            this.EvaluatorBox.BackBrush = null;
            this.EvaluatorBox.CharHeight = 16;
            this.EvaluatorBox.CharWidth = 8;
            this.EvaluatorBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EvaluatorBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.EvaluatorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluatorBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.EvaluatorBox.IsReplaceMode = false;
            this.EvaluatorBox.Location = new System.Drawing.Point(3, 18);
            this.EvaluatorBox.Name = "EvaluatorBox";
            this.EvaluatorBox.Paddings = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.EvaluatorBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.EvaluatorBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("EvaluatorBox.ServiceColors")));
            this.EvaluatorBox.Size = new System.Drawing.Size(645, 220);
            this.EvaluatorBox.TabIndex = 0;
            this.EvaluatorBox.WordWrap = true;
            this.EvaluatorBox.Zoom = 100;
            this.EvaluatorBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.BoxTextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PassCmdBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(651, 323);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pass Commands";
            // 
            // PassCmdBox
            // 
            this.PassCmdBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.PassCmdBox.AutoScrollMinSize = new System.Drawing.Size(2, 26);
            this.PassCmdBox.BackBrush = null;
            this.PassCmdBox.CharHeight = 16;
            this.PassCmdBox.CharWidth = 8;
            this.PassCmdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassCmdBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.PassCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PassCmdBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.PassCmdBox.IsReplaceMode = false;
            this.PassCmdBox.Location = new System.Drawing.Point(3, 18);
            this.PassCmdBox.Name = "PassCmdBox";
            this.PassCmdBox.Paddings = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PassCmdBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.PassCmdBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("PassCmdBox.ServiceColors")));
            this.PassCmdBox.Size = new System.Drawing.Size(645, 302);
            this.PassCmdBox.TabIndex = 1;
            this.PassCmdBox.Zoom = 100;
            this.PassCmdBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.BoxTextChanged);
            // 
            // AddGroupBtn
            // 
            this.AddGroupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddGroupBtn.Location = new System.Drawing.Point(12, 611);
            this.AddGroupBtn.Name = "AddGroupBtn";
            this.AddGroupBtn.Size = new System.Drawing.Size(150, 28);
            this.AddGroupBtn.TabIndex = 15;
            this.AddGroupBtn.Text = "Add";
            this.AddGroupBtn.UseVisualStyleBackColor = true;
            this.AddGroupBtn.Click += new System.EventHandler(this.AddGroupBtn_Click);
            // 
            // DeleteGroupBtn
            // 
            this.DeleteGroupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteGroupBtn.Location = new System.Drawing.Point(12, 679);
            this.DeleteGroupBtn.Name = "DeleteGroupBtn";
            this.DeleteGroupBtn.Size = new System.Drawing.Size(150, 28);
            this.DeleteGroupBtn.TabIndex = 16;
            this.DeleteGroupBtn.Text = "Delete";
            this.DeleteGroupBtn.UseVisualStyleBackColor = true;
            this.DeleteGroupBtn.Click += new System.EventHandler(this.DeleteGroupBtn_Click);
            // 
            // CloneGroupBtn
            // 
            this.CloneGroupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloneGroupBtn.Location = new System.Drawing.Point(12, 645);
            this.CloneGroupBtn.Name = "CloneGroupBtn";
            this.CloneGroupBtn.Size = new System.Drawing.Size(150, 28);
            this.CloneGroupBtn.TabIndex = 17;
            this.CloneGroupBtn.Text = "Clone";
            this.CloneGroupBtn.UseVisualStyleBackColor = true;
            this.CloneGroupBtn.Click += new System.EventHandler(this.CloneGroupBtn_Click);
            // 
            // RenameStateBtn
            // 
            this.RenameStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameStateBtn.Location = new System.Drawing.Point(168, 579);
            this.RenameStateBtn.Name = "RenameStateBtn";
            this.RenameStateBtn.Size = new System.Drawing.Size(170, 26);
            this.RenameStateBtn.TabIndex = 18;
            this.RenameStateBtn.Text = "Rename";
            this.RenameStateBtn.UseVisualStyleBackColor = true;
            this.RenameStateBtn.Click += new System.EventHandler(this.RenameStateBtn_Click);
            // 
            // RenameGroupBtn
            // 
            this.RenameGroupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameGroupBtn.Location = new System.Drawing.Point(12, 579);
            this.RenameGroupBtn.Name = "RenameGroupBtn";
            this.RenameGroupBtn.Size = new System.Drawing.Size(150, 26);
            this.RenameGroupBtn.TabIndex = 19;
            this.RenameGroupBtn.Text = "Rename";
            this.RenameGroupBtn.UseVisualStyleBackColor = true;
            this.RenameGroupBtn.Click += new System.EventHandler(this.RenameGroupBtn_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 722);
            this.Controls.Add(this.RenameGroupBtn);
            this.Controls.Add(this.RenameStateBtn);
            this.Controls.Add(this.CloneGroupBtn);
            this.Controls.Add(this.DeleteGroupBtn);
            this.Controls.Add(this.AddGroupBtn);
            this.Controls.Add(this.CloneStateBtn);
            this.Controls.Add(this.DeleteStateBtn);
            this.Controls.Add(this.AddStateBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StateBox);
            this.Controls.Add(this.StateGroupBox);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(1330, 769);
            this.Name = "GUI";
            this.Text = "Zeditor";
            this.Resize += new System.EventHandler(this.GUI_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.editorControl.ResumeLayout(false);
            this.stateTab.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntryCmdBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitCmdBox)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WhileCmdBox)).EndInit();
            this.conditionTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EvaluatorBox)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PassCmdBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox StateGroupBox;
        private System.Windows.Forms.ListBox StateBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openESDToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem exportESDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStateToolStripMenuItem;
        private System.Windows.Forms.Button AddStateBtn;
        private System.Windows.Forms.Button DeleteStateBtn;
        private System.Windows.Forms.Button CloneStateBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEditorContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noHelpForYouToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TargetStateBox;
        private System.Windows.Forms.Button GoTargetBtn;
        private System.Windows.Forms.TreeView ConditionTree;
        private System.Windows.Forms.Button AddConditionBtn;
        private System.Windows.Forms.Button DeleteConditionBtn;
        private System.Windows.Forms.Button MoveCndUpBtn;
        private System.Windows.Forms.Button MoveCndDownBtn;
        private System.Windows.Forms.Button AddSubconditionBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox EditorTitleBox;
        private System.Windows.Forms.Button RevertBtn;
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddGroupBtn;
        private System.Windows.Forms.Button DeleteGroupBtn;
        private System.Windows.Forms.Button CloneGroupBtn;
        private System.Windows.Forms.ToolStripMenuItem editESDPropertiesToolStripMenuItem;
        private System.Windows.Forms.TabControl editorControl;
        private System.Windows.Forms.TabPage stateTab;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private FastColoredTextBoxNS.FastColoredTextBox EntryCmdBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private FastColoredTextBoxNS.FastColoredTextBox ExitCmdBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private FastColoredTextBoxNS.FastColoredTextBox WhileCmdBox;
        private System.Windows.Forms.TabPage conditionTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private FastColoredTextBoxNS.FastColoredTextBox EvaluatorBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private FastColoredTextBoxNS.FastColoredTextBox PassCmdBox;
        private System.Windows.Forms.Button RenameConditionBtn;
        private System.Windows.Forms.Button RenameStateBtn;
        private System.Windows.Forms.ToolStripMenuItem saveESDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button RenameGroupBtn;
    }
}

