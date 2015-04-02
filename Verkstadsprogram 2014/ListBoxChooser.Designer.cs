namespace Verkstadsprogram_2014
{
    partial class ListBoxChooser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.listBoxChosen = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(118, 56);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 1;
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
            // 
            // listBoxChosen
            // 
            this.listBoxChosen.FormattingEnabled = true;
            this.listBoxChosen.Location = new System.Drawing.Point(124, 0);
            this.listBoxChosen.Name = "listBoxChosen";
            this.listBoxChosen.Size = new System.Drawing.Size(112, 56);
            this.listBoxChosen.Sorted = true;
            this.listBoxChosen.TabIndex = 2;
            this.listBoxChosen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxChosen_KeyDown);
            // 
            // ListBoxChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.listBoxChosen);
            this.Controls.Add(this.listBox);
            this.Name = "ListBoxChooser";
            this.Size = new System.Drawing.Size(239, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ListBox listBoxChosen;
    }
}
