namespace Verkstadsprogram_2014
{
    partial class VinterforvaringListBox
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
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.listBoxPostnr = new System.Windows.Forms.ListBox();
            this.listBoxVinter = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDate
            // 
            this.textBoxDate.Enabled = false;
            this.textBoxDate.Location = new System.Drawing.Point(3, 3);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(285, 20);
            this.textBoxDate.TabIndex = 57;
            // 
            // listBoxPostnr
            // 
            this.listBoxPostnr.FormattingEnabled = true;
            this.listBoxPostnr.Location = new System.Drawing.Point(3, 221);
            this.listBoxPostnr.Name = "listBoxPostnr";
            this.listBoxPostnr.Size = new System.Drawing.Size(285, 82);
            this.listBoxPostnr.TabIndex = 56;
            this.listBoxPostnr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxPostnr_KeyDown);
            // 
            // listBoxVinter
            // 
            this.listBoxVinter.FormattingEnabled = true;
            this.listBoxVinter.Location = new System.Drawing.Point(3, 29);
            this.listBoxVinter.Name = "listBoxVinter";
            this.listBoxVinter.Size = new System.Drawing.Size(285, 186);
            this.listBoxVinter.TabIndex = 55;
            this.listBoxVinter.SelectedIndexChanged += new System.EventHandler(this.listBoxVinter_SelectedIndexChanged);
            this.listBoxVinter.DoubleClick += new System.EventHandler(this.listBoxVinter_DoubleClick);
            this.listBoxVinter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxVinter_KeyDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAdd.Location = new System.Drawing.Point(80, 384);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(130, 23);
            this.buttonAdd.TabIndex = 59;
            this.buttonAdd.Text = "Lägg till hämtning";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Visible = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(3, 309);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(285, 20);
            this.textBoxSearch.TabIndex = 60;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.Search_Postnummer);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Postnummer_Keydown);
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.Location = new System.Drawing.Point(3, 335);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Size = new System.Drawing.Size(285, 43);
            this.listBoxSearch.TabIndex = 61;
            this.listBoxSearch.Visible = false;
            this.listBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Postnummer);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.listBoxSearch, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSearch, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxVinter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxPostnr, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 410);
            this.tableLayoutPanel1.TabIndex = 62;
            // 
            // VinterforvaringListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VinterforvaringListBox";
            this.Size = new System.Drawing.Size(297, 416);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.ListBox listBoxPostnr;
        private System.Windows.Forms.ListBox listBoxVinter;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
