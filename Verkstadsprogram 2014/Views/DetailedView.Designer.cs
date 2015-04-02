namespace Verkstadsprogram_2014
{
    partial class DetailedView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedView));
            this.checkBoxAktuellUppdrag = new System.Windows.Forms.CheckBox();
            this.listBoxMaskiner = new System.Windows.Forms.ListBox();
            this.listBoxUppdrag = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMaskin = new System.Windows.Forms.RadioButton();
            this.radioButtonKund = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonUppdragShow = new System.Windows.Forms.RadioButton();
            this.radioButtonUppdragNew = new System.Windows.Forms.RadioButton();
            this.maskinNewShow = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMaskinNew = new System.Windows.Forms.RadioButton();
            this.radioButtonMaskinShow = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.searchCustomer1 = new Verkstadsprogram_2014.SearchCustomer();
            this.uppdragShow1 = new Verkstadsprogram_2014.UppdragForm();
            this.customerShow = new Verkstadsprogram_2014.CustomerForm();
            this.maskinShow1 = new Verkstadsprogram_2014.MaskinForm();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.maskinNewShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAktuellUppdrag
            // 
            this.checkBoxAktuellUppdrag.AutoSize = true;
            this.checkBoxAktuellUppdrag.Location = new System.Drawing.Point(511, 73);
            this.checkBoxAktuellUppdrag.Name = "checkBoxAktuellUppdrag";
            this.checkBoxAktuellUppdrag.Size = new System.Drawing.Size(141, 17);
            this.checkBoxAktuellUppdrag.TabIndex = 22;
            this.checkBoxAktuellUppdrag.Text = "Endast aktuella uppdrag";
            this.checkBoxAktuellUppdrag.UseVisualStyleBackColor = true;
            // 
            // listBoxMaskiner
            // 
            this.listBoxMaskiner.FormattingEnabled = true;
            this.listBoxMaskiner.Location = new System.Drawing.Point(43, 73);
            this.listBoxMaskiner.Name = "listBoxMaskiner";
            this.listBoxMaskiner.Size = new System.Drawing.Size(244, 56);
            this.listBoxMaskiner.TabIndex = 0;
            this.listBoxMaskiner.SelectedIndexChanged += new System.EventHandler(this.listBoxMaskiner_SelectedIndexChanged);
            // 
            // listBoxUppdrag
            // 
            this.listBoxUppdrag.FormattingEnabled = true;
            this.listBoxUppdrag.Location = new System.Drawing.Point(329, 73);
            this.listBoxUppdrag.Name = "listBoxUppdrag";
            this.listBoxUppdrag.Size = new System.Drawing.Size(176, 56);
            this.listBoxUppdrag.TabIndex = 2;
            this.listBoxUppdrag.SelectedIndexChanged += new System.EventHandler(this.listBoxUppdrag_SelectedIndexChanged);
            this.listBoxUppdrag.DataSourceChanged += new System.EventHandler(this.listBoxUppdrag_DataSourceChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.radioButtonMaskin, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonKund, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(43, 48);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(132, 20);
            this.tableLayoutPanel3.TabIndex = 85;
            // 
            // radioButtonMaskin
            // 
            this.radioButtonMaskin.AutoSize = true;
            this.radioButtonMaskin.Location = new System.Drawing.Point(68, 2);
            this.radioButtonMaskin.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMaskin.Name = "radioButtonMaskin";
            this.radioButtonMaskin.Size = new System.Drawing.Size(59, 16);
            this.radioButtonMaskin.TabIndex = 1;
            this.radioButtonMaskin.Text = "Maskin";
            this.radioButtonMaskin.UseVisualStyleBackColor = true;
            this.radioButtonMaskin.CheckedChanged += new System.EventHandler(this.radioButtonMaskin_CheckedChanged);
            // 
            // radioButtonKund
            // 
            this.radioButtonKund.AutoSize = true;
            this.radioButtonKund.Checked = true;
            this.radioButtonKund.Location = new System.Drawing.Point(2, 2);
            this.radioButtonKund.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonKund.Name = "radioButtonKund";
            this.radioButtonKund.Size = new System.Drawing.Size(50, 16);
            this.radioButtonKund.TabIndex = 0;
            this.radioButtonKund.TabStop = true;
            this.radioButtonKund.Text = "Kund";
            this.radioButtonKund.UseVisualStyleBackColor = true;
            this.radioButtonKund.CheckedChanged += new System.EventHandler(this.radioButtonKund_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonUppdragShow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonUppdragNew, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(512, 97);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(117, 31);
            this.tableLayoutPanel1.TabIndex = 91;
            // 
            // radioButtonUppdragShow
            // 
            this.radioButtonUppdragShow.AutoSize = true;
            this.radioButtonUppdragShow.Location = new System.Drawing.Point(3, 3);
            this.radioButtonUppdragShow.Name = "radioButtonUppdragShow";
            this.radioButtonUppdragShow.Size = new System.Drawing.Size(45, 17);
            this.radioButtonUppdragShow.TabIndex = 0;
            this.radioButtonUppdragShow.Text = "Visa";
            this.radioButtonUppdragShow.UseVisualStyleBackColor = true;
            this.radioButtonUppdragShow.CheckedChanged += new System.EventHandler(this.radioButtonUppdrag_CheckedChanged);
            // 
            // radioButtonUppdragNew
            // 
            this.radioButtonUppdragNew.AutoSize = true;
            this.radioButtonUppdragNew.Location = new System.Drawing.Point(61, 3);
            this.radioButtonUppdragNew.Name = "radioButtonUppdragNew";
            this.radioButtonUppdragNew.Size = new System.Drawing.Size(38, 17);
            this.radioButtonUppdragNew.TabIndex = 0;
            this.radioButtonUppdragNew.Text = "Ny";
            this.radioButtonUppdragNew.UseVisualStyleBackColor = true;
            this.radioButtonUppdragNew.CheckedChanged += new System.EventHandler(this.radioButtonUppdrag_CheckedChanged);
            // 
            // maskinNewShow
            // 
            this.maskinNewShow.ColumnCount = 2;
            this.maskinNewShow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.maskinNewShow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.maskinNewShow.Controls.Add(this.radioButtonMaskinNew, 1, 0);
            this.maskinNewShow.Controls.Add(this.radioButtonMaskinShow, 0, 0);
            this.maskinNewShow.Location = new System.Drawing.Point(138, 134);
            this.maskinNewShow.Name = "maskinNewShow";
            this.maskinNewShow.RowCount = 1;
            this.maskinNewShow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.maskinNewShow.Size = new System.Drawing.Size(110, 26);
            this.maskinNewShow.TabIndex = 92;
            this.maskinNewShow.Visible = false;
            // 
            // radioButtonMaskinNew
            // 
            this.radioButtonMaskinNew.AutoSize = true;
            this.radioButtonMaskinNew.Location = new System.Drawing.Point(58, 3);
            this.radioButtonMaskinNew.Name = "radioButtonMaskinNew";
            this.radioButtonMaskinNew.Size = new System.Drawing.Size(38, 17);
            this.radioButtonMaskinNew.TabIndex = 0;
            this.radioButtonMaskinNew.Text = "Ny";
            this.radioButtonMaskinNew.UseVisualStyleBackColor = true;
            this.radioButtonMaskinNew.CheckedChanged += new System.EventHandler(this.radioButtonMaskinNew_CheckedChanged);
            // 
            // radioButtonMaskinShow
            // 
            this.radioButtonMaskinShow.AutoSize = true;
            this.radioButtonMaskinShow.Location = new System.Drawing.Point(3, 3);
            this.radioButtonMaskinShow.Name = "radioButtonMaskinShow";
            this.radioButtonMaskinShow.Size = new System.Drawing.Size(45, 17);
            this.radioButtonMaskinShow.TabIndex = 0;
            this.radioButtonMaskinShow.Text = "Visa";
            this.radioButtonMaskinShow.UseVisualStyleBackColor = true;
            this.radioButtonMaskinShow.CheckedChanged += new System.EventHandler(this.radioButtonMaskinNew_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(687, 563);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 29);
            this.button2.TabIndex = 95;
            this.button2.Text = "Skriv ut";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchCustomer1
            // 
            this.searchCustomer1.AutoSize = true;
            this.searchCustomer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchCustomer1.Location = new System.Drawing.Point(329, 41);
            this.searchCustomer1.Margin = new System.Windows.Forms.Padding(4);
            this.searchCustomer1.Name = "searchCustomer1";
            this.searchCustomer1.Size = new System.Drawing.Size(179, 27);
            this.searchCustomer1.TabIndex = 93;
            this.searchCustomer1.CustomerFound += new System.EventHandler(this.searchCustomer1_CustomerFound);
            // 
            // uppdragShow1
            // 
            this.uppdragShow1.AutoSize = true;
            this.uppdragShow1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uppdragShow1.Location = new System.Drawing.Point(329, 134);
            this.uppdragShow1.Margin = new System.Windows.Forms.Padding(4);
            this.uppdragShow1.modelC = null;
            this.uppdragShow1.Name = "uppdragShow1";
            this.uppdragShow1.Size = new System.Drawing.Size(647, 423);
            this.uppdragShow1.TabIndex = 90;
            this.uppdragShow1.UppdragUpdated += new System.EventHandler(this.uppdragShow1_UppdragUpdated);
            this.uppdragShow1.UppdragRemoved += new System.EventHandler(this.uppdragShow1_UppdragRemoved);
            // 
            // customerShow
            // 
            this.customerShow.AutoSize = true;
            this.customerShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customerShow.Location = new System.Drawing.Point(46, 134);
            this.customerShow.Margin = new System.Windows.Forms.Padding(4);
            this.customerShow.Name = "customerShow";
            this.customerShow.Size = new System.Drawing.Size(226, 395);
            this.customerShow.TabIndex = 89;
            this.customerShow.CustomerUpdated += new System.EventHandler(this.customerShow_CustomerUpdated);
            this.customerShow.CustomerRemoved += new System.EventHandler(this.customerShow_CustomerRemoved);
            // 
            // maskinShow1
            // 
            this.maskinShow1.Location = new System.Drawing.Point(43, 137);
            this.maskinShow1.Margin = new System.Windows.Forms.Padding(2);
            this.maskinShow1.Name = "maskinShow1";
            this.maskinShow1.Size = new System.Drawing.Size(251, 455);
            this.maskinShow1.TabIndex = 88;
            this.maskinShow1.Visible = false;
            this.maskinShow1.MachineUpdated += new System.EventHandler(this.maskinShow1_MachineUpdated);
            this.maskinShow1.MachineRemoved += new System.EventHandler(this.maskinShow1_MachineRemoved);
            this.maskinShow1.Model += new System.EventHandler(this.maskinShow_Model);
            // 
            // DetailedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1256, 626);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchCustomer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uppdragShow1);
            this.Controls.Add(this.listBoxMaskiner);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.listBoxUppdrag);
            this.Controls.Add(this.checkBoxAktuellUppdrag);
            this.Controls.Add(this.customerShow);
            this.Controls.Add(this.maskinNewShow);
            this.Controls.Add(this.maskinShow1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetailedView";
            this.Text = "Visa uppdrag";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.maskinNewShow.ResumeLayout(false);
            this.maskinNewShow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAktuellUppdrag;
        private System.Windows.Forms.ListBox listBoxMaskiner;
        private System.Windows.Forms.ListBox listBoxUppdrag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioButtonMaskin;
        private System.Windows.Forms.RadioButton radioButtonKund;
        private Verkstadsprogram_2014.MaskinForm maskinShow1;
        private Verkstadsprogram_2014.CustomerForm customerShow;
        private Verkstadsprogram_2014.UppdragForm uppdragShow1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonUppdragShow;
        private System.Windows.Forms.RadioButton radioButtonUppdragNew;
        private System.Windows.Forms.TableLayoutPanel maskinNewShow;
        private System.Windows.Forms.RadioButton radioButtonMaskinNew;
        private System.Windows.Forms.RadioButton radioButtonMaskinShow;
        private SearchCustomer searchCustomer1;
        private System.Windows.Forms.Button button2;        
    }
}