namespace Zeditor
{
    partial class PropertyEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.compressionBox = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DS1_Btn = new System.Windows.Forms.RadioButton();
            this.DS2BB_Btn = new System.Windows.Forms.RadioButton();
            this.DS3_Btn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compression";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compressionBox
            // 
            this.compressionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionBox.FormattingEnabled = true;
            this.compressionBox.Location = new System.Drawing.Point(119, 166);
            this.compressionBox.Name = "compressionBox";
            this.compressionBox.Size = new System.Drawing.Size(182, 24);
            this.compressionBox.TabIndex = 2;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(163, 218);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(59, 39);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(84, 218);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(73, 39);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DS3_Btn);
            this.groupBox1.Controls.Add(this.DS2BB_Btn);
            this.groupBox1.Controls.Add(this.DS1_Btn);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(288, 116);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // DS1_Btn
            // 
            this.DS1_Btn.AutoSize = true;
            this.DS1_Btn.Location = new System.Drawing.Point(13, 28);
            this.DS1_Btn.Name = "DS1_Btn";
            this.DS1_Btn.Size = new System.Drawing.Size(260, 21);
            this.DS1_Btn.TabIndex = 0;
            this.DS1_Btn.TabStop = true;
            this.DS1_Btn.Text = "Dark Souls / Dark Souls Remastered";
            this.DS1_Btn.UseVisualStyleBackColor = true;
            // 
            // DS2BB_Btn
            // 
            this.DS2BB_Btn.AutoSize = true;
            this.DS2BB_Btn.Location = new System.Drawing.Point(13, 55);
            this.DS2BB_Btn.Name = "DS2BB_Btn";
            this.DS2BB_Btn.Size = new System.Drawing.Size(251, 21);
            this.DS2BB_Btn.TabIndex = 1;
            this.DS2BB_Btn.TabStop = true;
            this.DS2BB_Btn.Text = "Dark Souls II / SOTFS / Bloodborne";
            this.DS2BB_Btn.UseVisualStyleBackColor = true;
            // 
            // DS3_Btn
            // 
            this.DS3_Btn.AutoSize = true;
            this.DS3_Btn.Location = new System.Drawing.Point(13, 82);
            this.DS3_Btn.Name = "DS3_Btn";
            this.DS3_Btn.Size = new System.Drawing.Size(111, 21);
            this.DS3_Btn.TabIndex = 2;
            this.DS3_Btn.TabStop = true;
            this.DS3_Btn.Text = "Dark Souls III";
            this.DS3_Btn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(119, 135);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(182, 22);
            this.nameBox.TabIndex = 8;
            // 
            // PropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 264);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.compressionBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 311);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 311);
            this.Name = "PropertyEditor";
            this.Text = "ESD Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox compressionBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DS1_Btn;
        private System.Windows.Forms.RadioButton DS2BB_Btn;
        private System.Windows.Forms.RadioButton DS3_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
    }
}