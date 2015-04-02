namespace Verkstadsprogram_2014.Views
{
    partial class Verkstad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verkstad));
            this.searchDeadline1 = new Verkstadsprogram_2014.SearchDeadline();
            this.searchCustomer1 = new Verkstadsprogram_2014.SearchCustomer();
            this.buttonNyKund = new System.Windows.Forms.Button();
            this.textBoxScanUppdrag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSeachHamtning = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchDeadline1
            // 
            this.searchDeadline1.AutoSize = true;
            this.searchDeadline1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchDeadline1.Location = new System.Drawing.Point(388, 40);
            this.searchDeadline1.Name = "searchDeadline1";
            this.searchDeadline1.Size = new System.Drawing.Size(178, 26);
            this.searchDeadline1.TabIndex = 48;
            // 
            // searchCustomer1
            // 
            this.searchCustomer1.AutoSize = true;
            this.searchCustomer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchCustomer1.Location = new System.Drawing.Point(13, 84);
            this.searchCustomer1.Margin = new System.Windows.Forms.Padding(4);
            this.searchCustomer1.Name = "searchCustomer1";
            this.searchCustomer1.Size = new System.Drawing.Size(234, 27);
            this.searchCustomer1.TabIndex = 46;
            this.searchCustomer1.CustomerFound += new System.EventHandler(this.searchCustomer1_CustomerFound);
            // 
            // buttonNyKund
            // 
            this.buttonNyKund.Location = new System.Drawing.Point(13, 40);
            this.buttonNyKund.Name = "buttonNyKund";
            this.buttonNyKund.Size = new System.Drawing.Size(75, 23);
            this.buttonNyKund.TabIndex = 49;
            this.buttonNyKund.Text = "Ny kund";
            this.buttonNyKund.UseVisualStyleBackColor = true;
            this.buttonNyKund.Click += new System.EventHandler(this.buttonNyKund_Click);
            // 
            // textBoxScanUppdrag
            // 
            this.textBoxScanUppdrag.Location = new System.Drawing.Point(13, 226);
            this.textBoxScanUppdrag.Name = "textBoxScanUppdrag";
            this.textBoxScanUppdrag.Size = new System.Drawing.Size(234, 20);
            this.textBoxScanUppdrag.TabIndex = 50;
            this.textBoxScanUppdrag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxScanUppdrag_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Sök efter ett uppdrag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Sök efter hämtning:";
            // 
            // textBoxSeachHamtning
            // 
            this.textBoxSeachHamtning.Location = new System.Drawing.Point(13, 277);
            this.textBoxSeachHamtning.Name = "textBoxSeachHamtning";
            this.textBoxSeachHamtning.Size = new System.Drawing.Size(234, 20);
            this.textBoxSeachHamtning.TabIndex = 52;
            this.textBoxSeachHamtning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSeachHamtning_KeyDown);
            // 
            // Verkstad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 665);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSeachHamtning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxScanUppdrag);
            this.Controls.Add(this.searchCustomer1);
            this.Controls.Add(this.buttonNyKund);
            this.Controls.Add(this.searchDeadline1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verkstad";
            this.Text = "Verkstad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SearchDeadline searchDeadline1;
        private SearchCustomer searchCustomer1;
        private System.Windows.Forms.Button buttonNyKund;
        private System.Windows.Forms.TextBox textBoxScanUppdrag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSeachHamtning;
    }
}