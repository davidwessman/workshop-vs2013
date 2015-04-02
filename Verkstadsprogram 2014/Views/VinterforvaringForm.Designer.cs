namespace Verkstadsprogram_2014
{
    partial class VinterforvaringForm
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
            this.dateE = new System.Windows.Forms.DateTimePicker();
            this.textBoxPostnummer = new System.Windows.Forms.TextBox();
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.checkOnlyActive = new System.Windows.Forms.CheckBox();
            this.dataHamtningar = new System.Windows.Forms.DataGridView();
            this.searchCustomer1 = new Verkstadsprogram_2014.SearchCustomer();
            this.vinterforvaring3 = new Verkstadsprogram_2014.VinterforvaringListBox();
            this.vinterforvaring2 = new Verkstadsprogram_2014.VinterforvaringListBox();
            this.vinterforvaring1 = new Verkstadsprogram_2014.VinterforvaringListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filterNotBestamd = new System.Windows.Forms.RadioButton();
            this.FilterNotHamtad = new System.Windows.Forms.RadioButton();
            this.FilterHamtad = new System.Windows.Forms.RadioButton();
            this.FilterAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataHamtningar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateE
            // 
            this.dateE.Location = new System.Drawing.Point(30, 196);
            this.dateE.Name = "dateE";
            this.dateE.Size = new System.Drawing.Size(178, 20);
            this.dateE.TabIndex = 52;
            this.dateE.ValueChanged += new System.EventHandler(this.dateE_ValueChanged);
            // 
            // textBoxPostnummer
            // 
            this.textBoxPostnummer.Location = new System.Drawing.Point(800, 26);
            this.textBoxPostnummer.Name = "textBoxPostnummer";
            this.textBoxPostnummer.Size = new System.Drawing.Size(107, 20);
            this.textBoxPostnummer.TabIndex = 64;
            this.textBoxPostnummer.TextChanged += new System.EventHandler(this.textBoxPostnummer_TextChanged);
            this.textBoxPostnummer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSearch_KeyDown);
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.Location = new System.Drawing.Point(800, 52);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Size = new System.Drawing.Size(107, 43);
            this.listBoxSearch.TabIndex = 65;
            this.listBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSearch_KeyDown);
            // 
            // checkOnlyActive
            // 
            this.checkOnlyActive.AutoSize = true;
            this.checkOnlyActive.Location = new System.Drawing.Point(30, 223);
            this.checkOnlyActive.Name = "checkOnlyActive";
            this.checkOnlyActive.Size = new System.Drawing.Size(203, 17);
            this.checkOnlyActive.TabIndex = 66;
            this.checkOnlyActive.Text = "Endast aktuella dagar (30 dagar fram)";
            this.checkOnlyActive.UseVisualStyleBackColor = true;
            this.checkOnlyActive.CheckedChanged += new System.EventHandler(this.checkOnlyActive_CheckedChanged);
            // 
            // dataHamtningar
            // 
            this.dataHamtningar.AllowUserToAddRows = false;
            this.dataHamtningar.AllowUserToDeleteRows = false;
            this.dataHamtningar.AllowUserToOrderColumns = true;
            this.dataHamtningar.AllowUserToResizeRows = false;
            this.dataHamtningar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dataHamtningar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataHamtningar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHamtningar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataHamtningar.Location = new System.Drawing.Point(214, 26);
            this.dataHamtningar.MultiSelect = false;
            this.dataHamtningar.Name = "dataHamtningar";
            this.dataHamtningar.ReadOnly = true;
            this.dataHamtningar.RowHeadersVisible = false;
            this.dataHamtningar.Size = new System.Drawing.Size(580, 176);
            this.dataHamtningar.TabIndex = 67;
            this.dataHamtningar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataHamtningar_CellDoubleClick);
            this.dataHamtningar.CurrentCellChanged += new System.EventHandler(this.dataHamtningar_CurrentCellChanged);
            this.dataHamtningar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataHamtningar_KeyDown);
            // 
            // searchCustomer1
            // 
            this.searchCustomer1.AutoSize = true;
            this.searchCustomer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchCustomer1.Location = new System.Drawing.Point(0, 26);
            this.searchCustomer1.Name = "searchCustomer1";
            this.searchCustomer1.Size = new System.Drawing.Size(179, 27);
            this.searchCustomer1.TabIndex = 57;
            this.searchCustomer1.CustomerFound += new System.EventHandler(this.searchCustomer1_CustomerFound);
            // 
            // vinterforvaring3
            // 
            this.vinterforvaring3.AutoSize = true;
            this.vinterforvaring3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vinterforvaring3.Location = new System.Drawing.Point(610, 236);
            this.vinterforvaring3.Margin = new System.Windows.Forms.Padding(4);
            this.vinterforvaring3.Name = "vinterforvaring3";
            this.vinterforvaring3.Size = new System.Drawing.Size(297, 338);
            this.vinterforvaring3.TabIndex = 55;
            this.vinterforvaring3.Uppdatera += new System.EventHandler(this.vinterforvaring_Uppdatera);
            // 
            // vinterforvaring2
            // 
            this.vinterforvaring2.AutoSize = true;
            this.vinterforvaring2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vinterforvaring2.Location = new System.Drawing.Point(305, 236);
            this.vinterforvaring2.Margin = new System.Windows.Forms.Padding(4);
            this.vinterforvaring2.Name = "vinterforvaring2";
            this.vinterforvaring2.Size = new System.Drawing.Size(297, 338);
            this.vinterforvaring2.TabIndex = 54;
            this.vinterforvaring2.Uppdatera += new System.EventHandler(this.vinterforvaring_Uppdatera);
            // 
            // vinterforvaring1
            // 
            this.vinterforvaring1.AutoSize = true;
            this.vinterforvaring1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vinterforvaring1.Location = new System.Drawing.Point(0, 236);
            this.vinterforvaring1.Margin = new System.Windows.Forms.Padding(4);
            this.vinterforvaring1.Name = "vinterforvaring1";
            this.vinterforvaring1.Size = new System.Drawing.Size(297, 338);
            this.vinterforvaring1.TabIndex = 53;
            this.vinterforvaring1.Uppdatera += new System.EventHandler(this.vinterforvaring_Uppdatera);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.filterNotBestamd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilterNotHamtad, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilterHamtad, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilterAll, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(214, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 23);
            this.tableLayoutPanel1.TabIndex = 68;
            // 
            // filterNotBestamd
            // 
            this.filterNotBestamd.AutoSize = true;
            this.filterNotBestamd.Checked = true;
            this.filterNotBestamd.Location = new System.Drawing.Point(3, 3);
            this.filterNotBestamd.Name = "filterNotBestamd";
            this.filterNotBestamd.Size = new System.Drawing.Size(83, 17);
            this.filterNotBestamd.TabIndex = 0;
            this.filterNotBestamd.TabStop = true;
            this.filterNotBestamd.Text = "Ej bestämda";
            this.filterNotBestamd.UseVisualStyleBackColor = true;
            this.filterNotBestamd.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // FilterNotHamtad
            // 
            this.FilterNotHamtad.AutoSize = true;
            this.FilterNotHamtad.Location = new System.Drawing.Point(92, 3);
            this.FilterNotHamtad.Name = "FilterNotHamtad";
            this.FilterNotHamtad.Size = new System.Drawing.Size(78, 17);
            this.FilterNotHamtad.TabIndex = 0;
            this.FilterNotHamtad.Text = "Ej hämtade";
            this.FilterNotHamtad.UseVisualStyleBackColor = true;
            this.FilterNotHamtad.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // FilterHamtad
            // 
            this.FilterHamtad.AutoSize = true;
            this.FilterHamtad.Location = new System.Drawing.Point(176, 3);
            this.FilterHamtad.Name = "FilterHamtad";
            this.FilterHamtad.Size = new System.Drawing.Size(68, 17);
            this.FilterHamtad.TabIndex = 0;
            this.FilterHamtad.Text = "Hämtade";
            this.FilterHamtad.UseVisualStyleBackColor = true;
            this.FilterHamtad.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // FilterAll
            // 
            this.FilterAll.AutoSize = true;
            this.FilterAll.Location = new System.Drawing.Point(250, 3);
            this.FilterAll.Name = "FilterAll";
            this.FilterAll.Size = new System.Drawing.Size(42, 17);
            this.FilterAll.TabIndex = 0;
            this.FilterAll.Text = "Alla";
            this.FilterAll.UseVisualStyleBackColor = true;
            this.FilterAll.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // VinterforvaringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 578);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataHamtningar);
            this.Controls.Add(this.checkOnlyActive);
            this.Controls.Add(this.textBoxPostnummer);
            this.Controls.Add(this.listBoxSearch);
            this.Controls.Add(this.searchCustomer1);
            this.Controls.Add(this.vinterforvaring3);
            this.Controls.Add(this.vinterforvaring2);
            this.Controls.Add(this.vinterforvaring1);
            this.Controls.Add(this.dateE);
            this.Name = "VinterforvaringForm";
            this.Text = "Vinterförvaring - Hämtning";
            this.Activated += new System.EventHandler(this.VinterforvaringForm_Activated);
            this.Deactivate += new System.EventHandler(this.VinterforvaringForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VinterforvaringForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataHamtningar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateE;
        private VinterforvaringListBox vinterforvaring1;
        private VinterforvaringListBox vinterforvaring2;
        private VinterforvaringListBox vinterforvaring3;
        private SearchCustomer searchCustomer1;
        private System.Windows.Forms.TextBox textBoxPostnummer;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.CheckBox checkOnlyActive;
        private System.Windows.Forms.DataGridView dataHamtningar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton filterNotBestamd;
        private System.Windows.Forms.RadioButton FilterNotHamtad;
        private System.Windows.Forms.RadioButton FilterHamtad;
        private System.Windows.Forms.RadioButton FilterAll;
    }
}