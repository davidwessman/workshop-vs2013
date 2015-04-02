namespace Verkstadsprogram_2014
{
    partial class AllCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllCustomers));
            this.bNewCustomer = new System.Windows.Forms.Button();
            this.btNyArbete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchCustomer1 = new Verkstadsprogram_2014.SearchCustomer();
            this.customerForm = new Verkstadsprogram_2014.CustomerForm();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bNewCustomer
            // 
            this.bNewCustomer.Location = new System.Drawing.Point(391, 86);
            this.bNewCustomer.Name = "bNewCustomer";
            this.bNewCustomer.Size = new System.Drawing.Size(88, 35);
            this.bNewCustomer.TabIndex = 5;
            this.bNewCustomer.Text = "Ny kund";
            this.bNewCustomer.UseVisualStyleBackColor = true;
            this.bNewCustomer.Click += new System.EventHandler(this.bNewCustomer_Click);
            // 
            // btNyArbete
            // 
            this.btNyArbete.Location = new System.Drawing.Point(299, 86);
            this.btNyArbete.Name = "btNyArbete";
            this.btNyArbete.Size = new System.Drawing.Size(86, 35);
            this.btNyArbete.TabIndex = 10;
            this.btNyArbete.Text = "Nytt arbete";
            this.btNyArbete.UseVisualStyleBackColor = true;
            this.btNyArbete.Click += new System.EventHandler(this.btNyArbete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(263, 127);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(512, 319);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // searchCustomer1
            // 
            this.searchCustomer1.AutoSize = true;
            this.searchCustomer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchCustomer1.Location = new System.Drawing.Point(12, 29);
            this.searchCustomer1.Name = "searchCustomer1";
            this.searchCustomer1.Size = new System.Drawing.Size(179, 27);
            this.searchCustomer1.TabIndex = 27;
            this.searchCustomer1.CustomerFound += new System.EventHandler(this.searchCustomer1_CustomerFound);
            // 
            // customerForm
            // 
            this.customerForm.AutoSize = true;
            this.customerForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customerForm.Location = new System.Drawing.Point(12, 62);
            this.customerForm.Name = "customerForm";
            this.customerForm.Size = new System.Drawing.Size(226, 395);
            this.customerForm.TabIndex = 26;
            this.customerForm.CustomerUpdated += new System.EventHandler(this.customerForm_CustomerUpdated);
            this.customerForm.CustomerRemoved += new System.EventHandler(this.customerForm_CustomerRemoved);
            // 
            // AllCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 528);
            this.Controls.Add(this.searchCustomer1);
            this.Controls.Add(this.customerForm);
            this.Controls.Add(this.btNyArbete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bNewCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllCustomers";
            this.Text = "Gräsklipparservice - Kontor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.AllCustomers_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNewCustomer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btNyArbete;
        private Verkstadsprogram_2014.CustomerForm customerForm;
        private SearchCustomer searchCustomer1;
    }
}

