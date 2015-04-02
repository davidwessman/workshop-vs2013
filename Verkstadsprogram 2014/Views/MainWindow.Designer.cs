namespace Verkstadsprogram_2014
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonAllCustomers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonNewCustomer = new System.Windows.Forms.Button();
            this.buttonVerkstad = new System.Windows.Forms.Button();
            this.listBoxOrder = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMachine = new System.Windows.Forms.RadioButton();
            this.radioButtonDetail = new System.Windows.Forms.RadioButton();
            this.listBoxWaitingParts = new System.Windows.Forms.ListBox();
            this.listBoxParts = new System.Windows.Forms.ListBox();
            this.buttonVinterForvaring = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchDeadline1 = new Verkstadsprogram_2014.SearchDeadline();
            this.searchCustomer1 = new Verkstadsprogram_2014.SearchCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(225, 190);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(97, 31);
            this.buttonSettings.TabIndex = 23;
            this.buttonSettings.Text = "Inställningar";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonAllCustomers
            // 
            this.buttonAllCustomers.Location = new System.Drawing.Point(12, 190);
            this.buttonAllCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAllCustomers.Name = "buttonAllCustomers";
            this.buttonAllCustomers.Size = new System.Drawing.Size(102, 31);
            this.buttonAllCustomers.TabIndex = 26;
            this.buttonAllCustomers.Text = "Visa kunder";
            this.buttonAllCustomers.UseVisualStyleBackColor = true;
            this.buttonAllCustomers.Click += new System.EventHandler(this.buttonAllCustomers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(625, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // buttonNewCustomer
            // 
            this.buttonNewCustomer.Location = new System.Drawing.Point(12, 230);
            this.buttonNewCustomer.Name = "buttonNewCustomer";
            this.buttonNewCustomer.Size = new System.Drawing.Size(102, 31);
            this.buttonNewCustomer.TabIndex = 36;
            this.buttonNewCustomer.Text = "Ny kund";
            this.buttonNewCustomer.UseVisualStyleBackColor = true;
            this.buttonNewCustomer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
            // 
            // buttonVerkstad
            // 
            this.buttonVerkstad.Location = new System.Drawing.Point(118, 190);
            this.buttonVerkstad.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVerkstad.Name = "buttonVerkstad";
            this.buttonVerkstad.Size = new System.Drawing.Size(102, 31);
            this.buttonVerkstad.TabIndex = 37;
            this.buttonVerkstad.Text = "Verkstad";
            this.buttonVerkstad.UseVisualStyleBackColor = true;
            this.buttonVerkstad.Click += new System.EventHandler(this.buttonVerkstad_Click);
            // 
            // listBoxOrder
            // 
            this.listBoxOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOrder.FormattingEnabled = true;
            this.listBoxOrder.ItemHeight = 16;
            this.listBoxOrder.Location = new System.Drawing.Point(14, 434);
            this.listBoxOrder.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxOrder.Name = "listBoxOrder";
            this.listBoxOrder.Size = new System.Drawing.Size(276, 20);
            this.listBoxOrder.TabIndex = 38;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tableLayoutPanel2.Controls.Add(this.radioButtonMachine, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonDetail, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 267);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 23);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // radioButtonMachine
            // 
            this.radioButtonMachine.AutoSize = true;
            this.radioButtonMachine.Location = new System.Drawing.Point(96, 3);
            this.radioButtonMachine.Name = "radioButtonMachine";
            this.radioButtonMachine.Size = new System.Drawing.Size(86, 17);
            this.radioButtonMachine.TabIndex = 1;
            this.radioButtonMachine.Text = "Nytt uppdrag";
            this.radioButtonMachine.UseVisualStyleBackColor = true;
            // 
            // radioButtonDetail
            // 
            this.radioButtonDetail.AutoSize = true;
            this.radioButtonDetail.Checked = true;
            this.radioButtonDetail.Location = new System.Drawing.Point(3, 3);
            this.radioButtonDetail.Name = "radioButtonDetail";
            this.radioButtonDetail.Size = new System.Drawing.Size(87, 17);
            this.radioButtonDetail.TabIndex = 0;
            this.radioButtonDetail.TabStop = true;
            this.radioButtonDetail.Text = "Detaljerad vy";
            this.radioButtonDetail.UseVisualStyleBackColor = true;
            // 
            // listBoxWaitingParts
            // 
            this.listBoxWaitingParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxWaitingParts.FormattingEnabled = true;
            this.listBoxWaitingParts.Location = new System.Drawing.Point(12, 501);
            this.listBoxWaitingParts.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxWaitingParts.Name = "listBoxWaitingParts";
            this.listBoxWaitingParts.Size = new System.Drawing.Size(311, 43);
            this.listBoxWaitingParts.TabIndex = 40;
            this.listBoxWaitingParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxWaitingParts_KeyDown);
            // 
            // listBoxParts
            // 
            this.listBoxParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxParts.FormattingEnabled = true;
            this.listBoxParts.Location = new System.Drawing.Point(12, 570);
            this.listBoxParts.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxParts.Name = "listBoxParts";
            this.listBoxParts.Size = new System.Drawing.Size(311, 43);
            this.listBoxParts.TabIndex = 41;
            // 
            // buttonVinterForvaring
            // 
            this.buttonVinterForvaring.Location = new System.Drawing.Point(118, 230);
            this.buttonVinterForvaring.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVinterForvaring.Name = "buttonVinterForvaring";
            this.buttonVinterForvaring.Size = new System.Drawing.Size(102, 31);
            this.buttonVinterForvaring.TabIndex = 42;
            this.buttonVinterForvaring.Text = "Vinterförvaring";
            this.buttonVinterForvaring.UseVisualStyleBackColor = true;
            this.buttonVinterForvaring.Click += new System.EventHandler(this.buttonVinterForvaring_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Delar att beställa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Väntar delar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Väntar på:";
            // 
            // searchDeadline1
            // 
            this.searchDeadline1.AutoSize = true;
            this.searchDeadline1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchDeadline1.Location = new System.Drawing.Point(340, 195);
            this.searchDeadline1.Name = "searchDeadline1";
            this.searchDeadline1.Size = new System.Drawing.Size(178, 26);
            this.searchDeadline1.TabIndex = 47;
            // 
            // searchCustomer1
            // 
            this.searchCustomer1.AutoSize = true;
            this.searchCustomer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchCustomer1.Location = new System.Drawing.Point(7, 296);
            this.searchCustomer1.Margin = new System.Windows.Forms.Padding(4);
            this.searchCustomer1.Name = "searchCustomer1";
            this.searchCustomer1.Size = new System.Drawing.Size(234, 27);
            this.searchCustomer1.TabIndex = 46;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 624);
            this.Controls.Add(this.searchDeadline1);
            this.Controls.Add(this.searchCustomer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVinterForvaring);
            this.Controls.Add(this.listBoxParts);
            this.Controls.Add(this.listBoxWaitingParts);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.listBoxOrder);
            this.Controls.Add(this.buttonVerkstad);
            this.Controls.Add(this.buttonNewCustomer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAllCustomers);
            this.Controls.Add(this.buttonSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Gräsklipparservice - Kontor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonAllCustomers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonNewCustomer;
        private System.Windows.Forms.Button buttonVerkstad;
        private System.Windows.Forms.ListBox listBoxOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonMachine;
        private System.Windows.Forms.RadioButton radioButtonDetail;
        private System.Windows.Forms.ListBox listBoxWaitingParts;
        private System.Windows.Forms.ListBox listBoxParts;
        private System.Windows.Forms.Button buttonVinterForvaring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SearchDeadline searchDeadline1;
        private SearchCustomer searchCustomer1;
    }
}

