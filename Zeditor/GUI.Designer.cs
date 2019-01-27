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
            this.StateGroupBox = new System.Windows.Forms.ListBox();
            this.StateBox = new System.Windows.Forms.ListBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openESDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConditionTree = new System.Windows.Forms.TreeView();
            this.TargetStateBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GoTargetBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ViewPassCmdBtn = new System.Windows.Forms.Button();
            this.DeleteConditionBtn = new System.Windows.Forms.Button();
            this.AddConditionBtn = new System.Windows.Forms.Button();
            this.ConditionNameBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DelCmdBtn = new System.Windows.Forms.Button();
            this.AddCmdBtn = new System.Windows.Forms.Button();
            this.BackToStateCmdBtn = new System.Windows.Forms.Button();
            this.CommandListNameBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MoveCmdUpBtn = new System.Windows.Forms.Button();
            this.GeneralCmdBox = new System.Windows.Forms.ListBox();
            this.WhileCmdBtn = new System.Windows.Forms.RadioButton();
            this.ExitCmdBtn = new System.Windows.Forms.RadioButton();
            this.EntryCmdBtn = new System.Windows.Forms.RadioButton();
            this.MoveCndDownBtn = new System.Windows.Forms.Button();
            this.MoveCndUpBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveESDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StateGroupBox
            // 
            this.StateGroupBox.DisplayMember = "Key";
            this.StateGroupBox.FormattingEnabled = true;
            this.StateGroupBox.ItemHeight = 16;
            this.StateGroupBox.Location = new System.Drawing.Point(12, 57);
            this.StateGroupBox.Name = "StateGroupBox";
            this.StateGroupBox.Size = new System.Drawing.Size(67, 628);
            this.StateGroupBox.TabIndex = 0;
            this.StateGroupBox.SelectedIndexChanged += new System.EventHandler(this.StateGroupBox_SelectedIndexChanged);
            // 
            // StateBox
            // 
            this.StateBox.DisplayMember = "Key";
            this.StateBox.FormattingEnabled = true;
            this.StateBox.ItemHeight = 16;
            this.StateBox.Location = new System.Drawing.Point(85, 57);
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(69, 628);
            this.StateBox.TabIndex = 1;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(991, 28);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openESDToolStripMenuItem,
            this.saveESDToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openESDToolStripMenuItem
            // 
            this.openESDToolStripMenuItem.Name = "openESDToolStripMenuItem";
            this.openESDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openESDToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.openESDToolStripMenuItem.Text = "Open ESD";
            this.openESDToolStripMenuItem.Click += new System.EventHandler(this.openESDToolStripMenuItem_Click);
            // 
            // ConditionTree
            // 
            this.ConditionTree.HideSelection = false;
            this.ConditionTree.Location = new System.Drawing.Point(6, 21);
            this.ConditionTree.Name = "ConditionTree";
            this.ConditionTree.Size = new System.Drawing.Size(230, 356);
            this.ConditionTree.TabIndex = 3;
            this.ConditionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConditionTree_AfterSelect);
            // 
            // TargetStateBox
            // 
            this.TargetStateBox.Location = new System.Drawing.Point(338, 315);
            this.TargetStateBox.Name = "TargetStateBox";
            this.TargetStateBox.Size = new System.Drawing.Size(50, 22);
            this.TargetStateBox.TabIndex = 5;
            this.TargetStateBox.TextChanged += new System.EventHandler(this.TargetStateBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Target State";
            // 
            // GoTargetBtn
            // 
            this.GoTargetBtn.Location = new System.Drawing.Point(250, 343);
            this.GoTargetBtn.Name = "GoTargetBtn";
            this.GoTargetBtn.Size = new System.Drawing.Size(138, 34);
            this.GoTargetBtn.TabIndex = 7;
            this.GoTargetBtn.Text = "Go to Target";
            this.GoTargetBtn.UseVisualStyleBackColor = true;
            this.GoTargetBtn.Click += new System.EventHandler(this.GoTargetBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MoveCndDownBtn);
            this.groupBox1.Controls.Add(this.ViewPassCmdBtn);
            this.groupBox1.Controls.Add(this.MoveCndUpBtn);
            this.groupBox1.Controls.Add(this.DeleteConditionBtn);
            this.groupBox1.Controls.Add(this.AddConditionBtn);
            this.groupBox1.Controls.Add(this.ConditionNameBox);
            this.groupBox1.Controls.Add(this.ConditionTree);
            this.groupBox1.Controls.Add(this.GoTargetBtn);
            this.groupBox1.Controls.Add(this.TargetStateBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(160, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 391);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // ViewPassCmdBtn
            // 
            this.ViewPassCmdBtn.Location = new System.Drawing.Point(250, 243);
            this.ViewPassCmdBtn.Name = "ViewPassCmdBtn";
            this.ViewPassCmdBtn.Size = new System.Drawing.Size(138, 46);
            this.ViewPassCmdBtn.TabIndex = 11;
            this.ViewPassCmdBtn.Text = "View Pass Commands";
            this.ViewPassCmdBtn.UseVisualStyleBackColor = true;
            this.ViewPassCmdBtn.Visible = false;
            this.ViewPassCmdBtn.Click += new System.EventHandler(this.ViewPassCmdBtn_Click);
            // 
            // DeleteConditionBtn
            // 
            this.DeleteConditionBtn.Location = new System.Drawing.Point(250, 87);
            this.DeleteConditionBtn.Name = "DeleteConditionBtn";
            this.DeleteConditionBtn.Size = new System.Drawing.Size(138, 23);
            this.DeleteConditionBtn.TabIndex = 10;
            this.DeleteConditionBtn.Text = "Delete Condition";
            this.DeleteConditionBtn.UseVisualStyleBackColor = true;
            this.DeleteConditionBtn.Click += new System.EventHandler(this.DeleteConditionBtn_Click);
            // 
            // AddConditionBtn
            // 
            this.AddConditionBtn.Location = new System.Drawing.Point(250, 58);
            this.AddConditionBtn.Name = "AddConditionBtn";
            this.AddConditionBtn.Size = new System.Drawing.Size(138, 23);
            this.AddConditionBtn.TabIndex = 9;
            this.AddConditionBtn.Text = "Add Condition";
            this.AddConditionBtn.UseVisualStyleBackColor = true;
            this.AddConditionBtn.Click += new System.EventHandler(this.AddConditionBtn_Click);
            // 
            // ConditionNameBox
            // 
            this.ConditionNameBox.Location = new System.Drawing.Point(250, 24);
            this.ConditionNameBox.Name = "ConditionNameBox";
            this.ConditionNameBox.ReadOnly = true;
            this.ConditionNameBox.Size = new System.Drawing.Size(138, 22);
            this.ConditionNameBox.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DelCmdBtn);
            this.groupBox2.Controls.Add(this.AddCmdBtn);
            this.groupBox2.Controls.Add(this.BackToStateCmdBtn);
            this.groupBox2.Controls.Add(this.CommandListNameBox);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.MoveCmdUpBtn);
            this.groupBox2.Controls.Add(this.GeneralCmdBox);
            this.groupBox2.Controls.Add(this.WhileCmdBtn);
            this.groupBox2.Controls.Add(this.ExitCmdBtn);
            this.groupBox2.Controls.Add(this.EntryCmdBtn);
            this.groupBox2.Location = new System.Drawing.Point(570, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 391);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commands";
            // 
            // DelCmdBtn
            // 
            this.DelCmdBtn.Location = new System.Drawing.Point(71, 337);
            this.DelCmdBtn.Name = "DelCmdBtn";
            this.DelCmdBtn.Size = new System.Drawing.Size(70, 40);
            this.DelCmdBtn.TabIndex = 9;
            this.DelCmdBtn.Text = "Delete";
            this.DelCmdBtn.UseVisualStyleBackColor = true;
            this.DelCmdBtn.Click += new System.EventHandler(this.DelCmdBtn_Click);
            // 
            // AddCmdBtn
            // 
            this.AddCmdBtn.Location = new System.Drawing.Point(6, 337);
            this.AddCmdBtn.Name = "AddCmdBtn";
            this.AddCmdBtn.Size = new System.Drawing.Size(59, 40);
            this.AddCmdBtn.TabIndex = 8;
            this.AddCmdBtn.Text = "Add";
            this.AddCmdBtn.UseVisualStyleBackColor = true;
            this.AddCmdBtn.Click += new System.EventHandler(this.AddCmdBtn_Click);
            // 
            // BackToStateCmdBtn
            // 
            this.BackToStateCmdBtn.Location = new System.Drawing.Point(158, 304);
            this.BackToStateCmdBtn.Name = "BackToStateCmdBtn";
            this.BackToStateCmdBtn.Size = new System.Drawing.Size(125, 73);
            this.BackToStateCmdBtn.TabIndex = 7;
            this.BackToStateCmdBtn.Text = "Back to State Commands";
            this.BackToStateCmdBtn.UseVisualStyleBackColor = true;
            this.BackToStateCmdBtn.Visible = false;
            this.BackToStateCmdBtn.Click += new System.EventHandler(this.BackToStateCmdBtn_Click);
            // 
            // CommandListNameBox
            // 
            this.CommandListNameBox.Location = new System.Drawing.Point(6, 24);
            this.CommandListNameBox.Name = "CommandListNameBox";
            this.CommandListNameBox.ReadOnly = true;
            this.CommandListNameBox.Size = new System.Drawing.Size(277, 22);
            this.CommandListNameBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Move ↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MoveCmdUpBtn
            // 
            this.MoveCmdUpBtn.Location = new System.Drawing.Point(158, 153);
            this.MoveCmdUpBtn.Name = "MoveCmdUpBtn";
            this.MoveCmdUpBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCmdUpBtn.TabIndex = 4;
            this.MoveCmdUpBtn.Text = "Move ↑";
            this.MoveCmdUpBtn.UseVisualStyleBackColor = true;
            this.MoveCmdUpBtn.Click += new System.EventHandler(this.MoveCmdUpBtn_Click);
            // 
            // GeneralCmdBox
            // 
            this.GeneralCmdBox.DisplayMember = "CommandID";
            this.GeneralCmdBox.FormattingEnabled = true;
            this.GeneralCmdBox.ItemHeight = 16;
            this.GeneralCmdBox.Location = new System.Drawing.Point(6, 54);
            this.GeneralCmdBox.Name = "GeneralCmdBox";
            this.GeneralCmdBox.Size = new System.Drawing.Size(135, 276);
            this.GeneralCmdBox.TabIndex = 3;
            this.GeneralCmdBox.SelectedIndexChanged += new System.EventHandler(this.GeneralCmdBox_SelectedIndexChanged);
            // 
            // WhileCmdBtn
            // 
            this.WhileCmdBtn.AutoSize = true;
            this.WhileCmdBtn.Location = new System.Drawing.Point(164, 114);
            this.WhileCmdBtn.Name = "WhileCmdBtn";
            this.WhileCmdBtn.Size = new System.Drawing.Size(64, 21);
            this.WhileCmdBtn.TabIndex = 2;
            this.WhileCmdBtn.Text = "While";
            this.WhileCmdBtn.UseVisualStyleBackColor = true;
            this.WhileCmdBtn.CheckedChanged += new System.EventHandler(this.WhileCmdBtn_CheckedChanged);
            // 
            // ExitCmdBtn
            // 
            this.ExitCmdBtn.AutoSize = true;
            this.ExitCmdBtn.Location = new System.Drawing.Point(164, 87);
            this.ExitCmdBtn.Name = "ExitCmdBtn";
            this.ExitCmdBtn.Size = new System.Drawing.Size(51, 21);
            this.ExitCmdBtn.TabIndex = 1;
            this.ExitCmdBtn.Text = "Exit";
            this.ExitCmdBtn.UseVisualStyleBackColor = true;
            this.ExitCmdBtn.CheckedChanged += new System.EventHandler(this.ExitCmdBtn_CheckedChanged);
            // 
            // EntryCmdBtn
            // 
            this.EntryCmdBtn.AutoSize = true;
            this.EntryCmdBtn.Checked = true;
            this.EntryCmdBtn.Location = new System.Drawing.Point(164, 60);
            this.EntryCmdBtn.Name = "EntryCmdBtn";
            this.EntryCmdBtn.Size = new System.Drawing.Size(62, 21);
            this.EntryCmdBtn.TabIndex = 0;
            this.EntryCmdBtn.TabStop = true;
            this.EntryCmdBtn.Text = "Entry";
            this.EntryCmdBtn.UseVisualStyleBackColor = true;
            this.EntryCmdBtn.CheckedChanged += new System.EventHandler(this.EntryCmdBtn_CheckedChanged);
            // 
            // MoveCndDownBtn
            // 
            this.MoveCndDownBtn.Location = new System.Drawing.Point(250, 175);
            this.MoveCndDownBtn.Name = "MoveCndDownBtn";
            this.MoveCndDownBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndDownBtn.TabIndex = 11;
            this.MoveCndDownBtn.Text = "Move ↓";
            this.MoveCndDownBtn.UseVisualStyleBackColor = true;
            this.MoveCndDownBtn.Click += new System.EventHandler(this.MoveCndDownBtn_Click);
            // 
            // MoveCndUpBtn
            // 
            this.MoveCndUpBtn.Location = new System.Drawing.Point(250, 139);
            this.MoveCndUpBtn.Name = "MoveCndUpBtn";
            this.MoveCndUpBtn.Size = new System.Drawing.Size(75, 32);
            this.MoveCndUpBtn.TabIndex = 10;
            this.MoveCndUpBtn.Text = "Move ↑";
            this.MoveCndUpBtn.UseVisualStyleBackColor = true;
            this.MoveCndUpBtn.Click += new System.EventHandler(this.MoveCndUpBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Groups";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(85, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "States";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveESDToolStripMenuItem
            // 
            this.saveESDToolStripMenuItem.Name = "saveESDToolStripMenuItem";
            this.saveESDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveESDToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveESDToolStripMenuItem.Text = "Save ESD";
            this.saveESDToolStripMenuItem.Click += new System.EventHandler(this.saveESDToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 699);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StateBox);
            this.Controls.Add(this.StateGroupBox);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "GUI";
            this.Text = "Zeditor";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox StateGroupBox;
        private System.Windows.Forms.ListBox StateBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openESDToolStripMenuItem;
        private System.Windows.Forms.TreeView ConditionTree;
        private System.Windows.Forms.TextBox TargetStateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoTargetBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton WhileCmdBtn;
        private System.Windows.Forms.RadioButton ExitCmdBtn;
        private System.Windows.Forms.RadioButton EntryCmdBtn;
        private System.Windows.Forms.ListBox GeneralCmdBox;
        private System.Windows.Forms.Button MoveCmdUpBtn;
        private System.Windows.Forms.TextBox ConditionNameBox;
        private System.Windows.Forms.Button AddConditionBtn;
        private System.Windows.Forms.Button DeleteConditionBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CommandListNameBox;
        private System.Windows.Forms.Button ViewPassCmdBtn;
        private System.Windows.Forms.Button BackToStateCmdBtn;
        private System.Windows.Forms.Button DelCmdBtn;
        private System.Windows.Forms.Button AddCmdBtn;
        private System.Windows.Forms.Button MoveCndDownBtn;
        private System.Windows.Forms.Button MoveCndUpBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem saveESDToolStripMenuItem;
    }
}

