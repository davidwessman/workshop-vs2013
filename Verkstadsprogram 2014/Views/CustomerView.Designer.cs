namespace Verkstadsprogram_2014
{
    partial class CustomerView
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
            this.uppdragForm1 = new Verkstadsprogram_2014.UppdragForm();
            this.maskinForm1 = new Verkstadsprogram_2014.MaskinForm();
            this.customerForm = new Verkstadsprogram_2014.CustomerForm();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableMaskinChoice = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMaskiner = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMachineChoose = new System.Windows.Forms.RadioButton();
            this.radioButtonMachineNew = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableMaskinChoice.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uppdragForm1
            // 
            this.uppdragForm1.AutoSize = true;
            this.uppdragForm1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uppdragForm1.Location = new System.Drawing.Point(529, 20);
            this.uppdragForm1.modelC = null;
            this.uppdragForm1.Name = "uppdragForm1";
            this.uppdragForm1.Size = new System.Drawing.Size(647, 423);
            this.uppdragForm1.TabIndex = 18;
            this.uppdragForm1.Visible = false;
            this.uppdragForm1.UppdragUpdated += new System.EventHandler(this.uppdragForm1_UppdragUpdated);
            // 
            // maskinForm1
            // 
            this.maskinForm1.AutoSize = true;
            this.maskinForm1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskinForm1.Location = new System.Drawing.Point(2, 60);
            this.maskinForm1.Margin = new System.Windows.Forms.Padding(2);
            this.maskinForm1.Name = "maskinForm1";
            this.maskinForm1.Size = new System.Drawing.Size(238, 309);
            this.maskinForm1.TabIndex = 17;
            this.maskinForm1.Visible = false;
            this.maskinForm1.MachineUpdated += new System.EventHandler(this.maskinForm1_MachineUpdated);
            // 
            // customerForm
            // 
            this.customerForm.AutoSize = true;
            this.customerForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customerForm.Location = new System.Drawing.Point(27, 12);
            this.customerForm.Name = "customerForm";
            this.customerForm.Size = new System.Drawing.Size(226, 395);
            this.customerForm.TabIndex = 16;
            this.customerForm.CustomerUpdated += new System.EventHandler(this.customerForm_CustomerUpdated);
            this.customerForm.CustomerRemoved += new System.EventHandler(this.customerForm_CustomerRemoved);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(27, 413);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(91, 30);
            this.buttonPrint.TabIndex = 19;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.maskinForm1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableMaskinChoice, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(277, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 371);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableMaskinChoice
            // 
            this.tableMaskinChoice.AutoSize = true;
            this.tableMaskinChoice.ColumnCount = 2;
            this.tableMaskinChoice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMaskinChoice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMaskinChoice.Controls.Add(this.listBoxMaskiner, 0, 0);
            this.tableMaskinChoice.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableMaskinChoice.Location = new System.Drawing.Point(3, 3);
            this.tableMaskinChoice.Name = "tableMaskinChoice";
            this.tableMaskinChoice.RowCount = 1;
            this.tableMaskinChoice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableMaskinChoice.Size = new System.Drawing.Size(183, 52);
            this.tableMaskinChoice.TabIndex = 18;
            this.tableMaskinChoice.Visible = false;
            // 
            // listBoxMaskiner
            // 
            this.listBoxMaskiner.FormattingEnabled = true;
            this.listBoxMaskiner.Location = new System.Drawing.Point(3, 3);
            this.listBoxMaskiner.Name = "listBoxMaskiner";
            this.listBoxMaskiner.Size = new System.Drawing.Size(120, 43);
            this.listBoxMaskiner.TabIndex = 18;
            this.listBoxMaskiner.SelectedIndexChanged += new System.EventHandler(this.listBoxMaskiner_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.radioButtonMachineChoose, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonMachineNew, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(129, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(51, 46);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // radioButtonMachineChoose
            // 
            this.radioButtonMachineChoose.AutoSize = true;
            this.radioButtonMachineChoose.Checked = true;
            this.radioButtonMachineChoose.Location = new System.Drawing.Point(3, 3);
            this.radioButtonMachineChoose.Name = "radioButtonMachineChoose";
            this.radioButtonMachineChoose.Size = new System.Drawing.Size(45, 17);
            this.radioButtonMachineChoose.TabIndex = 0;
            this.radioButtonMachineChoose.TabStop = true;
            this.radioButtonMachineChoose.Text = "Visa";
            this.radioButtonMachineChoose.UseVisualStyleBackColor = true;
            this.radioButtonMachineChoose.CheckedChanged += new System.EventHandler(this.radioButtonMachineChoose_CheckedChanged);
            // 
            // radioButtonMachineNew
            // 
            this.radioButtonMachineNew.AutoSize = true;
            this.radioButtonMachineNew.Location = new System.Drawing.Point(3, 26);
            this.radioButtonMachineNew.Name = "radioButtonMachineNew";
            this.radioButtonMachineNew.Size = new System.Drawing.Size(38, 17);
            this.radioButtonMachineNew.TabIndex = 1;
            this.radioButtonMachineNew.Text = "Ny";
            this.radioButtonMachineNew.UseVisualStyleBackColor = true;
            this.radioButtonMachineNew.CheckedChanged += new System.EventHandler(this.radioButtonMachineChoose_CheckedChanged);
            // 
            // CustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1011, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.uppdragForm1);
            this.Controls.Add(this.customerForm);
            this.Name = "CustomerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kund";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerView_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableMaskinChoice.ResumeLayout(false);
            this.tableMaskinChoice.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Verkstadsprogram_2014.CustomerForm customerForm;
        private MaskinForm maskinForm1;
        private UppdragForm uppdragForm1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableMaskinChoice;
        private System.Windows.Forms.ListBox listBoxMaskiner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonMachineChoose;
        private System.Windows.Forms.RadioButton radioButtonMachineNew;
    }
}