namespace Verkstadsprogram_2014
{
    partial class ArbetaUppdrag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbetaUppdrag));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMaskin = new System.Windows.Forms.RadioButton();
            this.radioButtonKund = new System.Windows.Forms.RadioButton();
            this.radioButtonUppdrag = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.uppdragShow1 = new Verkstadsprogram_2014.UppdragForm();
            this.customerShow = new Verkstadsprogram_2014.CustomerForm();
            this.maskinShow1 = new Verkstadsprogram_2014.MaskinForm();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.radioButtonMaskin, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonKund, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonUppdrag, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(43, 48);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(198, 28);
            this.tableLayoutPanel3.TabIndex = 85;
            // 
            // radioButtonMaskin
            // 
            this.radioButtonMaskin.AutoSize = true;
            this.radioButtonMaskin.Location = new System.Drawing.Point(56, 2);
            this.radioButtonMaskin.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonMaskin.Name = "radioButtonMaskin";
            this.radioButtonMaskin.Size = new System.Drawing.Size(59, 17);
            this.radioButtonMaskin.TabIndex = 1;
            this.radioButtonMaskin.Text = "Maskin";
            this.radioButtonMaskin.UseVisualStyleBackColor = true;
            this.radioButtonMaskin.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonKund
            // 
            this.radioButtonKund.AutoSize = true;
            this.radioButtonKund.Location = new System.Drawing.Point(2, 2);
            this.radioButtonKund.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonKund.Name = "radioButtonKund";
            this.radioButtonKund.Size = new System.Drawing.Size(50, 17);
            this.radioButtonKund.TabIndex = 0;
            this.radioButtonKund.Text = "Kund";
            this.radioButtonKund.UseVisualStyleBackColor = true;
            this.radioButtonKund.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonUppdrag
            // 
            this.radioButtonUppdrag.AutoSize = true;
            this.radioButtonUppdrag.Checked = true;
            this.radioButtonUppdrag.Location = new System.Drawing.Point(119, 2);
            this.radioButtonUppdrag.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonUppdrag.Name = "radioButtonUppdrag";
            this.radioButtonUppdrag.Size = new System.Drawing.Size(66, 17);
            this.radioButtonUppdrag.TabIndex = 1;
            this.radioButtonUppdrag.TabStop = true;
            this.radioButtonUppdrag.Text = "Uppdrag";
            this.radioButtonUppdrag.UseVisualStyleBackColor = true;
            this.radioButtonUppdrag.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
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
            // uppdragShow1
            // 
            this.uppdragShow1.AutoSize = true;
            this.uppdragShow1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uppdragShow1.Location = new System.Drawing.Point(43, 70);
            this.uppdragShow1.Margin = new System.Windows.Forms.Padding(4);
            this.uppdragShow1.modelC = null;
            this.uppdragShow1.Name = "uppdragShow1";
            this.uppdragShow1.Size = new System.Drawing.Size(647, 423);
            this.uppdragShow1.TabIndex = 90;
            this.uppdragShow1.UppdragUpdated += new System.EventHandler(this.uppdragShow1_UppdragUpdated);
            // 
            // customerShow
            // 
            this.customerShow.AutoSize = true;
            this.customerShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customerShow.Location = new System.Drawing.Point(43, 70);
            this.customerShow.Margin = new System.Windows.Forms.Padding(4);
            this.customerShow.Name = "customerShow";
            this.customerShow.Size = new System.Drawing.Size(226, 395);
            this.customerShow.TabIndex = 89;
            this.customerShow.CustomerUpdated += new System.EventHandler(this.customerShow_CustomerUpdated);
            // 
            // maskinShow1
            // 
            this.maskinShow1.Location = new System.Drawing.Point(43, 70);
            this.maskinShow1.Margin = new System.Windows.Forms.Padding(2);
            this.maskinShow1.Name = "maskinShow1";
            this.maskinShow1.Size = new System.Drawing.Size(251, 455);
            this.maskinShow1.TabIndex = 88;
            this.maskinShow1.Visible = false;
            this.maskinShow1.MachineUpdated += new System.EventHandler(this.maskinShow1_MachineUpdated);
            this.maskinShow1.Model += new System.EventHandler(this.maskinShow_Model);
            // 
            // ArbetaUppdrag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1256, 626);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uppdragShow1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.customerShow);
            this.Controls.Add(this.maskinShow1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArbetaUppdrag";
            this.Text = "Visa uppdrag";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioButtonMaskin;
        private System.Windows.Forms.RadioButton radioButtonKund;
        private Verkstadsprogram_2014.MaskinForm maskinShow1;
        private Verkstadsprogram_2014.CustomerForm customerShow;
        private Verkstadsprogram_2014.UppdragForm uppdragShow1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButtonUppdrag;        
    }
}