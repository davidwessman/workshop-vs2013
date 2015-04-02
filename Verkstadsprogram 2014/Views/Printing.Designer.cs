namespace Verkstadsprogram_2014.Views
{
    partial class Printing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printing));
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkPrintKund = new System.Windows.Forms.CheckBox();
            this.checkPrintMaskin = new System.Windows.Forms.CheckBox();
            this.checkPrintUppdrag = new System.Windows.Forms.CheckBox();
            this.checkPrintHamtning = new System.Windows.Forms.CheckBox();
            this.listBoxSource = new System.Windows.Forms.ListBox();
            this.listBoxFormat = new System.Windows.Forms.ListBox();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.textBoxPinPassword = new System.Windows.Forms.TextBox();
            this.labelPinPassword = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(12, 411);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "Skriv ut";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkPrintKund, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkPrintMaskin, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkPrintUppdrag, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkPrintHamtning, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 104);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kund";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maskin";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(61, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(210, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Uppdrag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hämtning";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(61, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(61, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(210, 20);
            this.textBox3.TabIndex = 4;
            // 
            // checkPrintKund
            // 
            this.checkPrintKund.AutoSize = true;
            this.checkPrintKund.Enabled = false;
            this.checkPrintKund.Location = new System.Drawing.Point(277, 3);
            this.checkPrintKund.Name = "checkPrintKund";
            this.checkPrintKund.Size = new System.Drawing.Size(89, 17);
            this.checkPrintKund.TabIndex = 5;
            this.checkPrintKund.Text = "Skriv ut kund";
            this.checkPrintKund.UseVisualStyleBackColor = true;
            this.checkPrintKund.CheckedChanged += new System.EventHandler(this.checkPrintKund_CheckedChanged);
            // 
            // checkPrintMaskin
            // 
            this.checkPrintMaskin.AutoSize = true;
            this.checkPrintMaskin.Enabled = false;
            this.checkPrintMaskin.Location = new System.Drawing.Point(277, 29);
            this.checkPrintMaskin.Name = "checkPrintMaskin";
            this.checkPrintMaskin.Size = new System.Drawing.Size(98, 17);
            this.checkPrintMaskin.TabIndex = 5;
            this.checkPrintMaskin.Text = "Skriv ut maskin";
            this.checkPrintMaskin.UseVisualStyleBackColor = true;
            this.checkPrintMaskin.CheckedChanged += new System.EventHandler(this.checkPrintMaskin_CheckedChanged);
            // 
            // checkPrintUppdrag
            // 
            this.checkPrintUppdrag.AutoSize = true;
            this.checkPrintUppdrag.Enabled = false;
            this.checkPrintUppdrag.Location = new System.Drawing.Point(277, 55);
            this.checkPrintUppdrag.Name = "checkPrintUppdrag";
            this.checkPrintUppdrag.Size = new System.Drawing.Size(104, 17);
            this.checkPrintUppdrag.TabIndex = 5;
            this.checkPrintUppdrag.Text = "Skriv ut uppdrag";
            this.checkPrintUppdrag.UseVisualStyleBackColor = true;
            this.checkPrintUppdrag.CheckedChanged += new System.EventHandler(this.checkPrintUppdrag_CheckedChanged);
            // 
            // checkPrintHamtning
            // 
            this.checkPrintHamtning.AutoSize = true;
            this.checkPrintHamtning.Enabled = false;
            this.checkPrintHamtning.Location = new System.Drawing.Point(277, 81);
            this.checkPrintHamtning.Name = "checkPrintHamtning";
            this.checkPrintHamtning.Size = new System.Drawing.Size(108, 17);
            this.checkPrintHamtning.TabIndex = 5;
            this.checkPrintHamtning.Text = "Skriv ut hämtning";
            this.checkPrintHamtning.UseVisualStyleBackColor = true;
            this.checkPrintHamtning.CheckedChanged += new System.EventHandler(this.checkPrintHamtning_CheckedChanged);
            // 
            // listBoxSource
            // 
            this.listBoxSource.FormattingEnabled = true;
            this.listBoxSource.Location = new System.Drawing.Point(147, 337);
            this.listBoxSource.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSource.Name = "listBoxSource";
            this.listBoxSource.Size = new System.Drawing.Size(126, 69);
            this.listBoxSource.TabIndex = 99;
            this.listBoxSource.SelectedIndexChanged += new System.EventHandler(this.listBoxSource_SelectedIndexChanged);
            // 
            // listBoxFormat
            // 
            this.listBoxFormat.FormattingEnabled = true;
            this.listBoxFormat.Location = new System.Drawing.Point(11, 337);
            this.listBoxFormat.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFormat.Name = "listBoxFormat";
            this.listBoxFormat.Size = new System.Drawing.Size(123, 69);
            this.listBoxFormat.TabIndex = 98;
            this.listBoxFormat.SelectedIndexChanged += new System.EventHandler(this.listBoxFormat_SelectedIndexChanged);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(289, 118);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(265, 341);
            this.printPreviewControl1.TabIndex = 100;
            // 
            // textBoxPinPassword
            // 
            this.textBoxPinPassword.Location = new System.Drawing.Point(18, 145);
            this.textBoxPinPassword.Name = "textBoxPinPassword";
            this.textBoxPinPassword.Size = new System.Drawing.Size(135, 20);
            this.textBoxPinPassword.TabIndex = 101;
            this.textBoxPinPassword.UseSystemPasswordChar = true;
            this.textBoxPinPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPinPassword_KeyDown);
            // 
            // labelPinPassword
            // 
            this.labelPinPassword.AutoSize = true;
            this.labelPinPassword.Location = new System.Drawing.Point(18, 123);
            this.labelPinPassword.Name = "labelPinPassword";
            this.labelPinPassword.Size = new System.Drawing.Size(178, 13);
            this.labelPinPassword.TabIndex = 102;
            this.labelPinPassword.Text = "Fyll i lösenord för att skriva ut pinkod";
            // 
            // Printing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 459);
            this.Controls.Add(this.labelPinPassword);
            this.Controls.Add(this.textBoxPinPassword);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.listBoxSource);
            this.Controls.Add(this.listBoxFormat);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Printing";
            this.Text = "Skriva ut";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkPrintKund;
        private System.Windows.Forms.CheckBox checkPrintMaskin;
        private System.Windows.Forms.CheckBox checkPrintUppdrag;
        private System.Windows.Forms.CheckBox checkPrintHamtning;
        private System.Windows.Forms.ListBox listBoxSource;
        private System.Windows.Forms.ListBox listBoxFormat;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.TextBox textBoxPinPassword;
        private System.Windows.Forms.Label labelPinPassword;
    }
}