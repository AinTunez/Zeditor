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
            this.AddSiblingConditionBtn = new System.Windows.Forms.Button();
            this.TargetStateNameBox = new System.Windows.Forms.TextBox();
            this.RenameConditionBtn = new System.Windows.Forms.Button();
            this.EditorTitleBox = new System.Windows.Forms.TextBox();
            this.RevertBtn = new System.Windows.Forms.Button();
            this.saveLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editorControl = new System.Windows.Forms.TabControl();
            this.stateTab = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.EntryCmdBox = new ScintillaNET.Scintilla();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ExitCmdBox = new ScintillaNET.Scintilla();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.WhileCmdBox = new ScintillaNET.Scintilla();
            this.conditionTab = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EvaluatorBox = new ScintillaNET.Scintilla();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PassCmdBox = new ScintillaNET.Scintilla();
            this.AddGroupBtn = new System.Windows.Forms.Button();
            this.DeleteGroupBtn = new System.Windows.Forms.Button();
            this.CloneGroupBtn = new System.Windows.Forms.Button();
            this.RenameStateBtn = new System.Windows.Forms.Button();
            this.RenameGroupBtn = new System.Windows.Forms.Button();
            this.StateGroupBox = new System.Windows.Forms.ComboBox();
            this.stateGroupLayoutBox = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.LongFormatBox = new System.Windows.Forms.CheckBox();
            this.MenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.editorControl.SuspendLayout();
            this.stateTab.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.conditionTab.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.stateGroupLayoutBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // StateBox
            // 
            this.StateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StateBox.DisplayMember = "Name";
            this.StateBox.FormattingEnabled = true;
            this.StateBox.HorizontalScrollbar = true;
            this.StateBox.ItemHeight = 16;
            this.StateBox.Location = new System.Drawing.Point(8, 21);
            this.StateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(332, 452);
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
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(1331, 28);
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
            // AddStateBtn
            // 
            this.AddStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddStateBtn.Location = new System.Drawing.Point(11, 487);
            this.AddStateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddStateBtn.Name = "AddStateBtn";
            this.AddStateBtn.Size = new System.Drawing.Size(65, 28);
            this.AddStateBtn.TabIndex = 12;
            this.AddStateBtn.Text = "Add";
            this.AddStateBtn.UseVisualStyleBackColor = true;
            this.AddStateBtn.Click += new System.EventHandler(this.addNewStateToolStripMenuItem_Click);
            // 
            // DeleteStateBtn
            // 
            this.DeleteStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteStateBtn.Location = new System.Drawing.Point(239, 487);
            this.DeleteStateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteStateBtn.Name = "DeleteStateBtn";
            this.DeleteStateBtn.Size = new System.Drawing.Size(96, 28);
            this.DeleteStateBtn.TabIndex = 13;
            this.DeleteStateBtn.Text = "Delete";
            this.DeleteStateBtn.UseVisualStyleBackColor = true;
            this.DeleteStateBtn.Click += new System.EventHandler(this.deleteStateToolStripMenuItem_Click);
            // 
            // CloneStateBtn
            // 
            this.CloneStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloneStateBtn.Location = new System.Drawing.Point(77, 487);
            this.CloneStateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloneStateBtn.Name = "CloneStateBtn";
            this.CloneStateBtn.Size = new System.Drawing.Size(69, 28);
            this.CloneStateBtn.TabIndex = 14;
            this.CloneStateBtn.Text = "Clone";
            this.CloneStateBtn.UseVisualStyleBackColor = true;
            this.CloneStateBtn.Click += new System.EventHandler(this.cloneStateToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Target State";
            // 
            // TargetStateBox
            // 
            this.TargetStateBox.Location = new System.Drawing.Point(337, 402);
            this.TargetStateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TargetStateBox.Name = "TargetStateBox";
            this.TargetStateBox.Size = new System.Drawing.Size(49, 22);
            this.TargetStateBox.TabIndex = 5;
            this.TargetStateBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TargetStateBox_KeyDown);
            this.TargetStateBox.Leave += new System.EventHandler(this.TargetStateBox_Leave);
            // 
            // GoTargetBtn
            // 
            this.GoTargetBtn.Location = new System.Drawing.Point(249, 459);
            this.GoTargetBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTargetBtn.Name = "GoTargetBtn";
            this.GoTargetBtn.Size = new System.Drawing.Size(139, 34);
            this.GoTargetBtn.TabIndex = 7;
            this.GoTargetBtn.TabStop = false;
            this.GoTargetBtn.Text = "Go to Target";
            this.GoTargetBtn.UseVisualStyleBackColor = true;
            this.GoTargetBtn.Click += new System.EventHandler(this.GoTargetBtn_Click);
            // 
            // ConditionTree
            // 
            this.ConditionTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ConditionTree.HideSelection = false;
            this.ConditionTree.Location = new System.Drawing.Point(5, 21);
            this.ConditionTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConditionTree.Name = "ConditionTree";
            this.ConditionTree.PathSeparator = "-";
            this.ConditionTree.Size = new System.Drawing.Size(231, 709);
            this.ConditionTree.TabIndex = 3;
            this.ConditionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConditionTree_AfterSelect);
            // 
            // AddConditionBtn
            // 
            this.AddConditionBtn.Location = new System.Drawing.Point(252, 85);
            this.AddConditionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddConditionBtn.Name = "AddConditionBtn";
            this.AddConditionBtn.Size = new System.Drawing.Size(139, 32);
            this.AddConditionBtn.TabIndex = 9;
            this.AddConditionBtn.TabStop = false;
            this.AddConditionBtn.Text = "New Primary CND";
            this.AddConditionBtn.UseVisualStyleBackColor = true;
            this.AddConditionBtn.Click += new System.EventHandler(this.AddConditionBtn_Click);
            // 
            // DeleteConditionBtn
            // 
            this.DeleteConditionBtn.Location = new System.Drawing.Point(252, 218);
            this.DeleteConditionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteConditionBtn.Name = "DeleteConditionBtn";
            this.DeleteConditionBtn.Size = new System.Drawing.Size(139, 32);
            this.DeleteConditionBtn.TabIndex = 10;
            this.DeleteConditionBtn.TabStop = false;
            this.DeleteConditionBtn.Text = "Delete Condition";
            this.DeleteConditionBtn.UseVisualStyleBackColor = true;
            this.DeleteConditionBtn.Click += new System.EventHandler(this.DeleteConditionBtn_Click);
            // 
            // MoveCndUpBtn
            // 
            this.MoveCndUpBtn.Location = new System.Drawing.Point(252, 313);
            this.MoveCndUpBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveCndUpBtn.Name = "MoveCndUpBtn";
            this.MoveCndUpBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndUpBtn.TabIndex = 10;
            this.MoveCndUpBtn.TabStop = false;
            this.MoveCndUpBtn.Text = "Move ↑";
            this.MoveCndUpBtn.UseVisualStyleBackColor = true;
            this.MoveCndUpBtn.Click += new System.EventHandler(this.MoveCndUpBtn_Click);
            // 
            // MoveCndDownBtn
            // 
            this.MoveCndDownBtn.Location = new System.Drawing.Point(252, 350);
            this.MoveCndDownBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveCndDownBtn.Name = "MoveCndDownBtn";
            this.MoveCndDownBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndDownBtn.TabIndex = 11;
            this.MoveCndDownBtn.TabStop = false;
            this.MoveCndDownBtn.Text = "Move ↓";
            this.MoveCndDownBtn.UseVisualStyleBackColor = true;
            this.MoveCndDownBtn.Click += new System.EventHandler(this.MoveCndDownBtn_Click);
            // 
            // AddSubconditionBtn
            // 
            this.AddSubconditionBtn.Location = new System.Drawing.Point(252, 122);
            this.AddSubconditionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddSubconditionBtn.Name = "AddSubconditionBtn";
            this.AddSubconditionBtn.Size = new System.Drawing.Size(139, 32);
            this.AddSubconditionBtn.TabIndex = 12;
            this.AddSubconditionBtn.TabStop = false;
            this.AddSubconditionBtn.Text = "New Child CND";
            this.AddSubconditionBtn.UseVisualStyleBackColor = true;
            this.AddSubconditionBtn.Click += new System.EventHandler(this.AddSubconditionBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.AddSiblingConditionBtn);
            this.groupBox1.Controls.Add(this.TargetStateNameBox);
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(397, 736);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // AddSiblingConditionBtn
            // 
            this.AddSiblingConditionBtn.Location = new System.Drawing.Point(252, 159);
            this.AddSiblingConditionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddSiblingConditionBtn.Name = "AddSiblingConditionBtn";
            this.AddSiblingConditionBtn.Size = new System.Drawing.Size(139, 32);
            this.AddSiblingConditionBtn.TabIndex = 15;
            this.AddSiblingConditionBtn.TabStop = false;
            this.AddSiblingConditionBtn.Text = "New Sibling CND";
            this.AddSiblingConditionBtn.UseVisualStyleBackColor = true;
            this.AddSiblingConditionBtn.Click += new System.EventHandler(this.AddSiblingConditionBtn_Click);
            // 
            // TargetStateNameBox
            // 
            this.TargetStateNameBox.Location = new System.Drawing.Point(249, 431);
            this.TargetStateNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TargetStateNameBox.Name = "TargetStateNameBox";
            this.TargetStateNameBox.ReadOnly = true;
            this.TargetStateNameBox.Size = new System.Drawing.Size(137, 22);
            this.TargetStateNameBox.TabIndex = 14;
            this.TargetStateNameBox.TabStop = false;
            // 
            // RenameConditionBtn
            // 
            this.RenameConditionBtn.Location = new System.Drawing.Point(252, 256);
            this.RenameConditionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RenameConditionBtn.Name = "RenameConditionBtn";
            this.RenameConditionBtn.Size = new System.Drawing.Size(139, 32);
            this.RenameConditionBtn.TabIndex = 13;
            this.RenameConditionBtn.TabStop = false;
            this.RenameConditionBtn.Text = "Rename Condition";
            this.RenameConditionBtn.UseVisualStyleBackColor = true;
            this.RenameConditionBtn.Click += new System.EventHandler(this.RenameConditionBtn_Click);
            // 
            // EditorTitleBox
            // 
            this.EditorTitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTitleBox.Location = new System.Drawing.Point(11, 25);
            this.EditorTitleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditorTitleBox.Name = "EditorTitleBox";
            this.EditorTitleBox.ReadOnly = true;
            this.EditorTitleBox.Size = new System.Drawing.Size(373, 22);
            this.EditorTitleBox.TabIndex = 9;
            this.EditorTitleBox.TabStop = false;
            // 
            // RevertBtn
            // 
            this.RevertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RevertBtn.Location = new System.Drawing.Point(389, 21);
            this.RevertBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RevertBtn.Name = "RevertBtn";
            this.RevertBtn.Size = new System.Drawing.Size(149, 30);
            this.RevertBtn.TabIndex = 11;
            this.RevertBtn.Text = "Revert to Saved";
            this.RevertBtn.UseVisualStyleBackColor = true;
            this.RevertBtn.Click += new System.EventHandler(this.RevertBtn_Click);
            // 
            // saveLabel
            // 
            this.saveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLabel.Location = new System.Drawing.Point(237, 65);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(277, 16);
            this.saveLabel.TabIndex = 12;
            this.saveLabel.Text = "ESD SAVED";
            this.saveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox2.Location = new System.Drawing.Point(771, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(548, 736);
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
            this.editorControl.Location = new System.Drawing.Point(3, 65);
            this.editorControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editorControl.Name = "editorControl";
            this.editorControl.SelectedIndex = 0;
            this.editorControl.Size = new System.Drawing.Size(543, 668);
            this.editorControl.TabIndex = 0;
            this.editorControl.SelectedIndexChanged += new System.EventHandler(this.editorControl_SelectedIndexChanged);
            // 
            // stateTab
            // 
            this.stateTab.Controls.Add(this.flowLayoutPanel1);
            this.stateTab.Location = new System.Drawing.Point(4, 25);
            this.stateTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateTab.Name = "stateTab";
            this.stateTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateTab.Size = new System.Drawing.Size(535, 639);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(529, 635);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.EntryCmdBox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(451, 156);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Entry Commands";
            // 
            // EntryCmdBox
            // 
            this.EntryCmdBox.AutoCMaxHeight = 9;
            this.EntryCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntryCmdBox.Location = new System.Drawing.Point(3, 17);
            this.EntryCmdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EntryCmdBox.Margins.Left = 0;
            this.EntryCmdBox.Margins.Right = 0;
            this.EntryCmdBox.Name = "EntryCmdBox";
            this.EntryCmdBox.Size = new System.Drawing.Size(445, 137);
            this.EntryCmdBox.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ExitCmdBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 162);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(451, 156);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Exit Commands";
            // 
            // ExitCmdBox
            // 
            this.ExitCmdBox.AutoCMaxHeight = 9;
            this.ExitCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitCmdBox.Location = new System.Drawing.Point(3, 17);
            this.ExitCmdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitCmdBox.Margins.Left = 0;
            this.ExitCmdBox.Margins.Right = 0;
            this.ExitCmdBox.Name = "ExitCmdBox";
            this.ExitCmdBox.Size = new System.Drawing.Size(445, 137);
            this.ExitCmdBox.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.WhileCmdBox);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 322);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(451, 156);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "While Commands";
            // 
            // WhileCmdBox
            // 
            this.WhileCmdBox.AutoCMaxHeight = 9;
            this.WhileCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhileCmdBox.Location = new System.Drawing.Point(3, 17);
            this.WhileCmdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WhileCmdBox.Margins.Left = 0;
            this.WhileCmdBox.Margins.Right = 0;
            this.WhileCmdBox.Name = "WhileCmdBox";
            this.WhileCmdBox.Size = new System.Drawing.Size(445, 137);
            this.WhileCmdBox.TabIndex = 2;
            // 
            // conditionTab
            // 
            this.conditionTab.Controls.Add(this.flowLayoutPanel3);
            this.conditionTab.Location = new System.Drawing.Point(4, 25);
            this.conditionTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.conditionTab.Name = "conditionTab";
            this.conditionTab.Size = new System.Drawing.Size(535, 639);
            this.conditionTab.TabIndex = 3;
            this.conditionTab.Text = "Condition";
            this.conditionTab.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.groupBox3);
            this.flowLayoutPanel3.Controls.Add(this.groupBox4);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(535, 639);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EvaluatorBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(400, 300);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Evaluator";
            // 
            // EvaluatorBox
            // 
            this.EvaluatorBox.AutoCMaxHeight = 9;
            this.EvaluatorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluatorBox.Location = new System.Drawing.Point(3, 17);
            this.EvaluatorBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EvaluatorBox.Name = "EvaluatorBox";
            this.EvaluatorBox.Size = new System.Drawing.Size(394, 281);
            this.EvaluatorBox.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PassCmdBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 306);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(400, 300);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pass Commands";
            // 
            // PassCmdBox
            // 
            this.PassCmdBox.AutoCMaxHeight = 9;
            this.PassCmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PassCmdBox.Location = new System.Drawing.Point(3, 17);
            this.PassCmdBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PassCmdBox.Name = "PassCmdBox";
            this.PassCmdBox.Size = new System.Drawing.Size(394, 281);
            this.PassCmdBox.TabIndex = 2;
            // 
            // AddGroupBtn
            // 
            this.AddGroupBtn.Location = new System.Drawing.Point(5, 74);
            this.AddGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddGroupBtn.Name = "AddGroupBtn";
            this.AddGroupBtn.Size = new System.Drawing.Size(69, 28);
            this.AddGroupBtn.TabIndex = 15;
            this.AddGroupBtn.Text = "Add";
            this.AddGroupBtn.UseVisualStyleBackColor = true;
            this.AddGroupBtn.Click += new System.EventHandler(this.AddGroupBtn_Click);
            // 
            // DeleteGroupBtn
            // 
            this.DeleteGroupBtn.Location = new System.Drawing.Point(269, 74);
            this.DeleteGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteGroupBtn.Name = "DeleteGroupBtn";
            this.DeleteGroupBtn.Size = new System.Drawing.Size(68, 28);
            this.DeleteGroupBtn.TabIndex = 16;
            this.DeleteGroupBtn.Text = "Delete";
            this.DeleteGroupBtn.UseVisualStyleBackColor = true;
            this.DeleteGroupBtn.Click += new System.EventHandler(this.DeleteGroupBtn_Click);
            // 
            // CloneGroupBtn
            // 
            this.CloneGroupBtn.Location = new System.Drawing.Point(83, 74);
            this.CloneGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloneGroupBtn.Name = "CloneGroupBtn";
            this.CloneGroupBtn.Size = new System.Drawing.Size(63, 28);
            this.CloneGroupBtn.TabIndex = 17;
            this.CloneGroupBtn.Text = "Clone";
            this.CloneGroupBtn.UseVisualStyleBackColor = true;
            this.CloneGroupBtn.Click += new System.EventHandler(this.CloneGroupBtn_Click);
            // 
            // RenameStateBtn
            // 
            this.RenameStateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameStateBtn.Location = new System.Drawing.Point(149, 489);
            this.RenameStateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RenameStateBtn.Name = "RenameStateBtn";
            this.RenameStateBtn.Size = new System.Drawing.Size(87, 26);
            this.RenameStateBtn.TabIndex = 18;
            this.RenameStateBtn.Text = "Rename";
            this.RenameStateBtn.UseVisualStyleBackColor = true;
            this.RenameStateBtn.Click += new System.EventHandler(this.RenameStateBtn_Click);
            // 
            // RenameGroupBtn
            // 
            this.RenameGroupBtn.Location = new System.Drawing.Point(151, 74);
            this.RenameGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RenameGroupBtn.Name = "RenameGroupBtn";
            this.RenameGroupBtn.Size = new System.Drawing.Size(113, 28);
            this.RenameGroupBtn.TabIndex = 19;
            this.RenameGroupBtn.Text = "Rename";
            this.RenameGroupBtn.UseVisualStyleBackColor = true;
            this.RenameGroupBtn.Click += new System.EventHandler(this.RenameGroupBtn_Click);
            // 
            // StateGroupBox
            // 
            this.StateGroupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateGroupBox.FormattingEnabled = true;
            this.StateGroupBox.Location = new System.Drawing.Point(5, 32);
            this.StateGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StateGroupBox.Name = "StateGroupBox";
            this.StateGroupBox.Size = new System.Drawing.Size(332, 24);
            this.StateGroupBox.TabIndex = 21;
            this.StateGroupBox.SelectedIndexChanged += new System.EventHandler(this.StateGroupBox_SelectedIndexChanged);
            // 
            // stateGroupLayoutBox
            // 
            this.stateGroupLayoutBox.Controls.Add(this.DeleteGroupBtn);
            this.stateGroupLayoutBox.Controls.Add(this.CloneGroupBtn);
            this.stateGroupLayoutBox.Controls.Add(this.AddGroupBtn);
            this.stateGroupLayoutBox.Controls.Add(this.RenameGroupBtn);
            this.stateGroupLayoutBox.Controls.Add(this.StateGroupBox);
            this.stateGroupLayoutBox.Location = new System.Drawing.Point(5, 105);
            this.stateGroupLayoutBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateGroupLayoutBox.Name = "stateGroupLayoutBox";
            this.stateGroupLayoutBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateGroupLayoutBox.Size = new System.Drawing.Size(352, 117);
            this.stateGroupLayoutBox.TabIndex = 22;
            this.stateGroupLayoutBox.TabStop = false;
            this.stateGroupLayoutBox.Text = "State Groups";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.StateBox);
            this.groupBox8.Controls.Add(this.RenameStateBtn);
            this.groupBox8.Controls.Add(this.AddStateBtn);
            this.groupBox8.Controls.Add(this.CloneStateBtn);
            this.groupBox8.Controls.Add(this.DeleteStateBtn);
            this.groupBox8.Location = new System.Drawing.Point(5, 230);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(352, 530);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "States";
            // 
            // LongFormatBox
            // 
            this.LongFormatBox.AutoSize = true;
            this.LongFormatBox.Location = new System.Drawing.Point(36, 55);
            this.LongFormatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LongFormatBox.Name = "LongFormatBox";
            this.LongFormatBox.Size = new System.Drawing.Size(285, 21);
            this.LongFormatBox.TabIndex = 23;
            this.LongFormatBox.Text = "Save in 64-bit mode (uncheck for PTDE)";
            this.LongFormatBox.UseVisualStyleBackColor = true;
            this.LongFormatBox.CheckedChanged += new System.EventHandler(this.LongFormatBox_CheckedChanged);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 782);
            this.Controls.Add(this.LongFormatBox);
            this.Controls.Add(this.stateGroupLayoutBox);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1338, 767);
            this.Name = "GUI";
            this.Text = "Zeditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GUI_KeyDown);
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
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.conditionTab.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.stateGroupLayoutBox.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox StateBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openESDToolStripMenuItem;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TabPage conditionTab;
        private System.Windows.Forms.Button RenameConditionBtn;
        private System.Windows.Forms.Button RenameStateBtn;
        private System.Windows.Forms.ToolStripMenuItem saveESDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button RenameGroupBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox TargetStateNameBox;
        private System.Windows.Forms.ComboBox StateGroupBox;
        private System.Windows.Forms.GroupBox stateGroupLayoutBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private ScintillaNET.Scintilla EntryCmdBox;
        private ScintillaNET.Scintilla ExitCmdBox;
        private ScintillaNET.Scintilla WhileCmdBox;
        private ScintillaNET.Scintilla EvaluatorBox;
        private ScintillaNET.Scintilla PassCmdBox;
        private System.Windows.Forms.Button AddSiblingConditionBtn;
        private System.Windows.Forms.CheckBox LongFormatBox;
    }
}

