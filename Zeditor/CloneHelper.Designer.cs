namespace Zeditor
{
    partial class CloneHelper
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
            this.cloneBtn = new System.Windows.Forms.Button();
            this.abortBtn = new System.Windows.Forms.Button();
            this.stateSelect = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stateSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // cloneBtn
            // 
            this.cloneBtn.Location = new System.Drawing.Point(57, 48);
            this.cloneBtn.Name = "cloneBtn";
            this.cloneBtn.Size = new System.Drawing.Size(75, 23);
            this.cloneBtn.TabIndex = 0;
            this.cloneBtn.TabStop = false;
            this.cloneBtn.Text = "Clone";
            this.cloneBtn.UseVisualStyleBackColor = true;
            this.cloneBtn.Click += new System.EventHandler(this.cloneBtn_Click);
            // 
            // abortBtn
            // 
            this.abortBtn.Location = new System.Drawing.Point(57, 77);
            this.abortBtn.Name = "abortBtn";
            this.abortBtn.Size = new System.Drawing.Size(75, 23);
            this.abortBtn.TabIndex = 1;
            this.abortBtn.TabStop = false;
            this.abortBtn.Text = "Abort";
            this.abortBtn.UseVisualStyleBackColor = true;
            this.abortBtn.Click += new System.EventHandler(this.abortBtn_Click);
            // 
            // stateSelect
            // 
            this.stateSelect.Location = new System.Drawing.Point(12, 12);
            this.stateSelect.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stateSelect.Name = "stateSelect";
            this.stateSelect.Size = new System.Drawing.Size(120, 20);
            this.stateSelect.TabIndex = 0;
            // 
            // CloneHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 116);
            this.Controls.Add(this.stateSelect);
            this.Controls.Add(this.abortBtn);
            this.Controls.Add(this.cloneBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloneHelper";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clone To";
            ((System.ComponentModel.ISupportInitialize)(this.stateSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cloneBtn;
        private System.Windows.Forms.Button abortBtn;
        private System.Windows.Forms.NumericUpDown stateSelect;
    }
}