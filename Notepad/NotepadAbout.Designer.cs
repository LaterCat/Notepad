
namespace Notepad
{
    partial class NotepadAbout
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
            this.link_Notepad = new System.Windows.Forms.LinkLabel();
            this.BackNotepad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // link_Notepad
            // 
            this.link_Notepad.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.link_Notepad.LinkColor = System.Drawing.Color.Red;
            this.link_Notepad.Location = new System.Drawing.Point(246, 142);
            this.link_Notepad.Name = "link_Notepad";
            this.link_Notepad.Size = new System.Drawing.Size(252, 91);
            this.link_Notepad.TabIndex = 0;
            this.link_Notepad.TabStop = true;
            this.link_Notepad.Text = "如遇问题，点击此处";
            this.link_Notepad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_Notepad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Notepad_LinkClicked);
            // 
            // BackNotepad
            // 
            this.BackNotepad.Location = new System.Drawing.Point(551, 320);
            this.BackNotepad.Name = "BackNotepad";
            this.BackNotepad.Size = new System.Drawing.Size(95, 47);
            this.BackNotepad.TabIndex = 1;
            this.BackNotepad.Text = "返回";
            this.BackNotepad.UseVisualStyleBackColor = true;
            this.BackNotepad.Click += new System.EventHandler(this.BackNotepad_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(263, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "多功能记事本";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NotepadAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackNotepad);
            this.Controls.Add(this.link_Notepad);
            this.Name = "NotepadAbout";
            this.Text = "关于记事本";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel link_Notepad;
        private System.Windows.Forms.Button BackNotepad;
        private System.Windows.Forms.Label label1;
    }
}