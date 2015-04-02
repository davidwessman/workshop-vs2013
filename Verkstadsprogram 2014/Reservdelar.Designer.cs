namespace Verkstadsprogram_2014
{
    partial class Reservdelar
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
            this.textBoxReservdel = new System.Windows.Forms.TextBox();
            this.numericUpDownReservdel = new System.Windows.Forms.NumericUpDown();
            this.buttonAddReservdel = new System.Windows.Forms.Button();
            this.checkedListBoxReservdelar = new System.Windows.Forms.CheckedListBox();
            this.listBoxReservdelsSearch = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReservdel)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxReservdel
            // 
            this.textBoxReservdel.Location = new System.Drawing.Point(0, 36);
            this.textBoxReservdel.Name = "textBoxReservdel";
            this.textBoxReservdel.Size = new System.Drawing.Size(135, 20);
            this.textBoxReservdel.TabIndex = 1;
            this.textBoxReservdel.TextChanged += new System.EventHandler(this.textBoxReservdel_TextChanged);
            this.textBoxReservdel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxReservdel_KeyDown);
            // 
            // numericUpDownReservdel
            // 
            this.numericUpDownReservdel.DecimalPlaces = 1;
            this.numericUpDownReservdel.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownReservdel.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownReservdel.Name = "numericUpDownReservdel";
            this.numericUpDownReservdel.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownReservdel.TabIndex = 0;
            this.numericUpDownReservdel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxReservdel_KeyDown);
            // 
            // buttonAddReservdel
            // 
            this.buttonAddReservdel.Location = new System.Drawing.Point(84, 0);
            this.buttonAddReservdel.Name = "buttonAddReservdel";
            this.buttonAddReservdel.Size = new System.Drawing.Size(51, 23);
            this.buttonAddReservdel.TabIndex = 2;
            this.buttonAddReservdel.Text = "Ny del";
            this.buttonAddReservdel.UseVisualStyleBackColor = true;
            this.buttonAddReservdel.Click += new System.EventHandler(this.buttonAddReservdel_Click);
            // 
            // checkedListBoxReservdelar
            // 
            this.checkedListBoxReservdelar.FormattingEnabled = true;
            this.checkedListBoxReservdelar.Location = new System.Drawing.Point(0, 62);
            this.checkedListBoxReservdelar.Name = "checkedListBoxReservdelar";
            this.checkedListBoxReservdelar.Size = new System.Drawing.Size(253, 49);
            this.checkedListBoxReservdelar.TabIndex = 3;
            this.checkedListBoxReservdelar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxReservdelar_KeyDown);
            // 
            // listBoxReservdelsSearch
            // 
            this.listBoxReservdelsSearch.FormattingEnabled = true;
            this.listBoxReservdelsSearch.IntegralHeight = false;
            this.listBoxReservdelsSearch.Location = new System.Drawing.Point(141, 0);
            this.listBoxReservdelsSearch.Name = "listBoxReservdelsSearch";
            this.listBoxReservdelsSearch.Size = new System.Drawing.Size(112, 56);
            this.listBoxReservdelsSearch.Sorted = true;
            this.listBoxReservdelsSearch.TabIndex = 89;
            this.listBoxReservdelsSearch.Visible = false;
            this.listBoxReservdelsSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxReservdel_KeyDown);
            // 
            // Reservdelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.listBoxReservdelsSearch);
            this.Controls.Add(this.checkedListBoxReservdelar);
            this.Controls.Add(this.textBoxReservdel);
            this.Controls.Add(this.numericUpDownReservdel);
            this.Controls.Add(this.buttonAddReservdel);
            this.Name = "Reservdelar";
            this.Size = new System.Drawing.Size(256, 114);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReservdel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReservdel;
        private System.Windows.Forms.NumericUpDown numericUpDownReservdel;
        private System.Windows.Forms.Button buttonAddReservdel;
        private System.Windows.Forms.CheckedListBox checkedListBoxReservdelar;
        private System.Windows.Forms.ListBox listBoxReservdelsSearch;

    }
}
