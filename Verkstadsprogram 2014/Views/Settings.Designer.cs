namespace Verkstadsprogram_2014
{
    partial class Settings
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
            System.Windows.Forms.Label modeLabel;
            System.Windows.Forms.Label kundnummerLabel;
            System.Windows.Forms.Label textLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.listBoxBrand = new System.Windows.Forms.ListBox();
            this.listBoxSort = new System.Windows.Forms.ListBox();
            this.listBoxModell = new System.Windows.Forms.ListBox();
            this.modeTextBox = new System.Windows.Forms.TextBox();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.buttonReadXML = new System.Windows.Forms.Button();
            this.listBoxXML = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStandard = new System.Windows.Forms.Button();
            this.listBoxProductNbr = new System.Windows.Forms.ListBox();
            this.listBoxReservdelar = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxArtikelNr = new System.Windows.Forms.TextBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxModell = new System.Windows.Forms.TextBox();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxSort = new System.Windows.Forms.TextBox();
            this.listBoxSettings = new System.Windows.Forms.ListBox();
            this.textBoxMode = new System.Windows.Forms.TextBox();
            this.numericUpDownKundnr = new System.Windows.Forms.NumericUpDown();
            this.buttonNewMode = new System.Windows.Forms.Button();
            this.checkBoxKlar = new System.Windows.Forms.CheckBox();
            this.checkBoxFaktura = new System.Windows.Forms.CheckBox();
            this.checkBoxHämta = new System.Windows.Forms.CheckBox();
            this.buttonSaveMode = new System.Windows.Forms.Button();
            this.buttonPostnummerSave = new System.Windows.Forms.Button();
            this.buttonPostnummerNew = new System.Windows.Forms.Button();
            this.listBoxPostnummer = new System.Windows.Forms.ListBox();
            this.textBoxPostnummer = new System.Windows.Forms.TextBox();
            this.textBoxPostort = new System.Windows.Forms.TextBox();
            this.buttonRemoveMode = new System.Windows.Forms.Button();
            this.buttonPostnummerRemove = new System.Windows.Forms.Button();
            this.textBoxPostnummerSearch = new System.Windows.Forms.TextBox();
            modeLabel = new System.Windows.Forms.Label();
            kundnummerLabel = new System.Windows.Forms.Label();
            textLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKundnr)).BeginInit();
            this.SuspendLayout();
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Location = new System.Drawing.Point(11, 493);
            modeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new System.Drawing.Size(34, 13);
            modeLabel.TabIndex = 4;
            modeLabel.Text = "Läge:";
            // 
            // kundnummerLabel
            // 
            kundnummerLabel.AutoSize = true;
            kundnummerLabel.Location = new System.Drawing.Point(11, 516);
            kundnummerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            kundnummerLabel.Name = "kundnummerLabel";
            kundnummerLabel.Size = new System.Drawing.Size(77, 13);
            kundnummerLabel.TabIndex = 6;
            kundnummerLabel.Text = "Nästa kundnr.:";
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new System.Drawing.Point(11, 537);
            textLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new System.Drawing.Size(46, 13);
            textLabel.TabIndex = 8;
            textLabel.Text = "Ev. text:";
            // 
            // listBoxBrand
            // 
            this.listBoxBrand.FormattingEnabled = true;
            this.listBoxBrand.Location = new System.Drawing.Point(237, 30);
            this.listBoxBrand.Name = "listBoxBrand";
            this.listBoxBrand.Size = new System.Drawing.Size(193, 95);
            this.listBoxBrand.Sorted = true;
            this.listBoxBrand.TabIndex = 13;
            this.listBoxBrand.SelectedIndexChanged += new System.EventHandler(this.listBoxBrand_SelectedIndexChanged);
            this.listBoxBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxBrand_KeyDown);
            // 
            // listBoxSort
            // 
            this.listBoxSort.FormattingEnabled = true;
            this.listBoxSort.Location = new System.Drawing.Point(3, 30);
            this.listBoxSort.Name = "listBoxSort";
            this.listBoxSort.Size = new System.Drawing.Size(193, 95);
            this.listBoxSort.TabIndex = 19;
            this.listBoxSort.SelectedIndexChanged += new System.EventHandler(this.listBoxBrand_SelectedIndexChanged);
            this.listBoxSort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSort_KeyDown);
            // 
            // listBoxModell
            // 
            this.listBoxModell.FormattingEnabled = true;
            this.listBoxModell.Location = new System.Drawing.Point(471, 30);
            this.listBoxModell.Name = "listBoxModell";
            this.listBoxModell.Size = new System.Drawing.Size(193, 95);
            this.listBoxModell.TabIndex = 12;
            // 
            // modeTextBox
            // 
            this.modeTextBox.Enabled = false;
            this.modeTextBox.Location = new System.Drawing.Point(89, 493);
            this.modeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.modeTextBox.Name = "modeTextBox";
            this.modeTextBox.Size = new System.Drawing.Size(78, 20);
            this.modeTextBox.TabIndex = 5;
            this.modeTextBox.TextChanged += new System.EventHandler(this.modeTextBox_TextChanged);
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(89, 537);
            this.textTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(78, 20);
            this.textTextBox.TabIndex = 9;
            // 
            // buttonReadXML
            // 
            this.buttonReadXML.Location = new System.Drawing.Point(1103, 116);
            this.buttonReadXML.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadXML.Name = "buttonReadXML";
            this.buttonReadXML.Size = new System.Drawing.Size(91, 28);
            this.buttonReadXML.TabIndex = 10;
            this.buttonReadXML.Text = "Läs in XML";
            this.buttonReadXML.UseVisualStyleBackColor = true;
            this.buttonReadXML.Click += new System.EventHandler(this.buttonReadXML_Click);
            // 
            // listBoxXML
            // 
            this.listBoxXML.FormattingEnabled = true;
            this.listBoxXML.Items.AddRange(new object[] {
            "Kunder",
            "Allt",
            "VinterFörvaring"});
            this.listBoxXML.Location = new System.Drawing.Point(1103, 60);
            this.listBoxXML.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxXML.Name = "listBoxXML";
            this.listBoxXML.Size = new System.Drawing.Size(89, 43);
            this.listBoxXML.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 14;
            // 
            // buttonStandard
            // 
            this.buttonStandard.Location = new System.Drawing.Point(1103, 25);
            this.buttonStandard.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStandard.Name = "buttonStandard";
            this.buttonStandard.Size = new System.Drawing.Size(75, 24);
            this.buttonStandard.TabIndex = 15;
            this.buttonStandard.Text = "Standard";
            this.buttonStandard.UseVisualStyleBackColor = true;
            this.buttonStandard.Click += new System.EventHandler(this.buttonStandard_Click);
            // 
            // listBoxProductNbr
            // 
            this.listBoxProductNbr.FormattingEnabled = true;
            this.listBoxProductNbr.Location = new System.Drawing.Point(3, 131);
            this.listBoxProductNbr.Name = "listBoxProductNbr";
            this.listBoxProductNbr.Size = new System.Drawing.Size(193, 95);
            this.listBoxProductNbr.TabIndex = 16;
            // 
            // listBoxReservdelar
            // 
            this.listBoxReservdelar.FormattingEnabled = true;
            this.listBoxReservdelar.Location = new System.Drawing.Point(237, 131);
            this.listBoxReservdelar.Name = "listBoxReservdelar";
            this.listBoxReservdelar.Size = new System.Drawing.Size(193, 95);
            this.listBoxReservdelar.TabIndex = 17;
            this.listBoxReservdelar.SelectedIndexChanged += new System.EventHandler(this.listBoxReservdelar_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.button2, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.textBoxArtikelNr, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBoxBarcode, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.textBoxName, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.checkBox1, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.radioButton2, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(471, 131);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(247, 163);
            this.tableLayoutPanel5.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(68, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Spara";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Slut:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artikelnr:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Streckkod:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Namn:";
            // 
            // textBoxArtikelNr
            // 
            this.textBoxArtikelNr.Location = new System.Drawing.Point(68, 26);
            this.textBoxArtikelNr.Name = "textBoxArtikelNr";
            this.textBoxArtikelNr.Size = new System.Drawing.Size(153, 20);
            this.textBoxArtikelNr.TabIndex = 4;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(68, 52);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(153, 20);
            this.textBoxBarcode.TabIndex = 4;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(68, 78);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(153, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(68, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Markerad = slut";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Visa";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(68, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(38, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ny";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.textBoxModell, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxBrand, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSort, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxSort, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.listBoxBrand, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.listBoxModell, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.listBoxReservdelar, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.listBoxProductNbr, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 2, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(992, 407);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // textBoxModell
            // 
            this.textBoxModell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxModell.ForeColor = System.Drawing.Color.Gray;
            this.textBoxModell.Location = new System.Drawing.Point(470, 2);
            this.textBoxModell.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxModell.Name = "textBoxModell";
            this.textBoxModell.Size = new System.Drawing.Size(230, 23);
            this.textBoxModell.TabIndex = 83;
            this.textBoxModell.Text = "Lägg till.";
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBrand.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBrand.Location = new System.Drawing.Point(236, 2);
            this.textBoxBrand.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(230, 23);
            this.textBoxBrand.TabIndex = 82;
            this.textBoxBrand.Text = "Lägg till.";
            this.textBoxBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBrand_KeyDown);
            // 
            // textBoxSort
            // 
            this.textBoxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSort.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSort.Location = new System.Drawing.Point(2, 2);
            this.textBoxSort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSort.Name = "textBoxSort";
            this.textBoxSort.Size = new System.Drawing.Size(230, 23);
            this.textBoxSort.TabIndex = 82;
            this.textBoxSort.Text = "Lägg till.";
            this.textBoxSort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSort_KeyDown);
            // 
            // listBoxSettings
            // 
            this.listBoxSettings.FormattingEnabled = true;
            this.listBoxSettings.Location = new System.Drawing.Point(14, 425);
            this.listBoxSettings.Name = "listBoxSettings";
            this.listBoxSettings.Size = new System.Drawing.Size(116, 56);
            this.listBoxSettings.TabIndex = 20;
            this.listBoxSettings.SelectedIndexChanged += new System.EventHandler(this.listBoxSettings_SelectedIndexChanged);
            // 
            // textBoxMode
            // 
            this.textBoxMode.Location = new System.Drawing.Point(135, 425);
            this.textBoxMode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMode.Name = "textBoxMode";
            this.textBoxMode.Size = new System.Drawing.Size(78, 20);
            this.textBoxMode.TabIndex = 21;
            // 
            // numericUpDownKundnr
            // 
            this.numericUpDownKundnr.Location = new System.Drawing.Point(89, 516);
            this.numericUpDownKundnr.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownKundnr.Name = "numericUpDownKundnr";
            this.numericUpDownKundnr.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownKundnr.TabIndex = 22;
            // 
            // buttonNewMode
            // 
            this.buttonNewMode.Location = new System.Drawing.Point(138, 458);
            this.buttonNewMode.Name = "buttonNewMode";
            this.buttonNewMode.Size = new System.Drawing.Size(75, 23);
            this.buttonNewMode.TabIndex = 23;
            this.buttonNewMode.Text = "Byt läge";
            this.buttonNewMode.UseVisualStyleBackColor = true;
            this.buttonNewMode.Click += new System.EventHandler(this.buttonNewMode_Click);
            // 
            // checkBoxKlar
            // 
            this.checkBoxKlar.AutoSize = true;
            this.checkBoxKlar.Location = new System.Drawing.Point(1103, 150);
            this.checkBoxKlar.Name = "checkBoxKlar";
            this.checkBoxKlar.Size = new System.Drawing.Size(107, 17);
            this.checkBoxKlar.TabIndex = 24;
            this.checkBoxKlar.Text = "Sätt alla till KLAR";
            this.checkBoxKlar.UseVisualStyleBackColor = true;
            // 
            // checkBoxFaktura
            // 
            this.checkBoxFaktura.AutoSize = true;
            this.checkBoxFaktura.Location = new System.Drawing.Point(1103, 173);
            this.checkBoxFaktura.Name = "checkBoxFaktura";
            this.checkBoxFaktura.Size = new System.Drawing.Size(74, 17);
            this.checkBoxFaktura.TabIndex = 25;
            this.checkBoxFaktura.Text = "Fakturerat";
            this.checkBoxFaktura.UseVisualStyleBackColor = true;
            // 
            // checkBoxHämta
            // 
            this.checkBoxHämta.AutoSize = true;
            this.checkBoxHämta.Location = new System.Drawing.Point(1103, 195);
            this.checkBoxHämta.Name = "checkBoxHämta";
            this.checkBoxHämta.Size = new System.Drawing.Size(60, 17);
            this.checkBoxHämta.TabIndex = 26;
            this.checkBoxHämta.Text = "Hämtat";
            this.checkBoxHämta.UseVisualStyleBackColor = true;
            // 
            // buttonSaveMode
            // 
            this.buttonSaveMode.Location = new System.Drawing.Point(12, 562);
            this.buttonSaveMode.Name = "buttonSaveMode";
            this.buttonSaveMode.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveMode.TabIndex = 27;
            this.buttonSaveMode.Text = "Spara";
            this.buttonSaveMode.UseVisualStyleBackColor = true;
            this.buttonSaveMode.Click += new System.EventHandler(this.buttonSaveMode_Click);
            // 
            // buttonPostnummerSave
            // 
            this.buttonPostnummerSave.Location = new System.Drawing.Point(249, 555);
            this.buttonPostnummerSave.Name = "buttonPostnummerSave";
            this.buttonPostnummerSave.Size = new System.Drawing.Size(75, 23);
            this.buttonPostnummerSave.TabIndex = 36;
            this.buttonPostnummerSave.Text = "Spara";
            this.buttonPostnummerSave.UseVisualStyleBackColor = true;
            this.buttonPostnummerSave.Click += new System.EventHandler(this.buttonPostnummerSave_Click);
            // 
            // buttonPostnummerNew
            // 
            this.buttonPostnummerNew.Location = new System.Drawing.Point(248, 507);
            this.buttonPostnummerNew.Name = "buttonPostnummerNew";
            this.buttonPostnummerNew.Size = new System.Drawing.Size(53, 23);
            this.buttonPostnummerNew.TabIndex = 35;
            this.buttonPostnummerNew.Text = "Nytt";
            this.buttonPostnummerNew.UseVisualStyleBackColor = true;
            this.buttonPostnummerNew.Click += new System.EventHandler(this.buttonPostnummerNew_Click);
            // 
            // listBoxPostnummer
            // 
            this.listBoxPostnummer.FormattingEnabled = true;
            this.listBoxPostnummer.Location = new System.Drawing.Point(248, 448);
            this.listBoxPostnummer.Name = "listBoxPostnummer";
            this.listBoxPostnummer.Size = new System.Drawing.Size(168, 56);
            this.listBoxPostnummer.TabIndex = 32;
            this.listBoxPostnummer.SelectedIndexChanged += new System.EventHandler(this.listBoxPostnummer_SelectedIndexChanged);
            // 
            // textBoxPostnummer
            // 
            this.textBoxPostnummer.Enabled = false;
            this.textBoxPostnummer.Location = new System.Drawing.Point(323, 509);
            this.textBoxPostnummer.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPostnummer.Name = "textBoxPostnummer";
            this.textBoxPostnummer.Size = new System.Drawing.Size(78, 20);
            this.textBoxPostnummer.TabIndex = 28;
            // 
            // textBoxPostort
            // 
            this.textBoxPostort.Location = new System.Drawing.Point(323, 530);
            this.textBoxPostort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPostort.Name = "textBoxPostort";
            this.textBoxPostort.Size = new System.Drawing.Size(78, 20);
            this.textBoxPostort.TabIndex = 31;
            // 
            // buttonRemoveMode
            // 
            this.buttonRemoveMode.Location = new System.Drawing.Point(93, 562);
            this.buttonRemoveMode.Name = "buttonRemoveMode";
            this.buttonRemoveMode.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveMode.TabIndex = 37;
            this.buttonRemoveMode.Text = "Ta bort";
            this.buttonRemoveMode.UseVisualStyleBackColor = true;
            this.buttonRemoveMode.Click += new System.EventHandler(this.buttonRemoveMode_Click);
            // 
            // buttonPostnummerRemove
            // 
            this.buttonPostnummerRemove.Location = new System.Drawing.Point(326, 555);
            this.buttonPostnummerRemove.Name = "buttonPostnummerRemove";
            this.buttonPostnummerRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonPostnummerRemove.TabIndex = 38;
            this.buttonPostnummerRemove.Text = "Ta bort";
            this.buttonPostnummerRemove.UseVisualStyleBackColor = true;
            this.buttonPostnummerRemove.Click += new System.EventHandler(this.buttonPostnummerRemove_Click);
            // 
            // textBoxPostnummerSearch
            // 
            this.textBoxPostnummerSearch.Location = new System.Drawing.Point(248, 424);
            this.textBoxPostnummerSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPostnummerSearch.Name = "textBoxPostnummerSearch";
            this.textBoxPostnummerSearch.Size = new System.Drawing.Size(78, 20);
            this.textBoxPostnummerSearch.TabIndex = 39;
            this.textBoxPostnummerSearch.TextChanged += new System.EventHandler(this.postnummerSearch);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 637);
            this.Controls.Add(this.textBoxPostnummerSearch);
            this.Controls.Add(this.buttonPostnummerRemove);
            this.Controls.Add(this.buttonRemoveMode);
            this.Controls.Add(this.buttonPostnummerSave);
            this.Controls.Add(this.buttonPostnummerNew);
            this.Controls.Add(this.listBoxPostnummer);
            this.Controls.Add(this.textBoxPostnummer);
            this.Controls.Add(this.textBoxPostort);
            this.Controls.Add(this.buttonSaveMode);
            this.Controls.Add(this.checkBoxHämta);
            this.Controls.Add(this.checkBoxFaktura);
            this.Controls.Add(this.checkBoxKlar);
            this.Controls.Add(this.buttonNewMode);
            this.Controls.Add(this.numericUpDownKundnr);
            this.Controls.Add(this.textBoxMode);
            this.Controls.Add(this.listBoxSettings);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.buttonStandard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxXML);
            this.Controls.Add(this.buttonReadXML);
            this.Controls.Add(modeLabel);
            this.Controls.Add(this.modeTextBox);
            this.Controls.Add(kundnummerLabel);
            this.Controls.Add(textLabel);
            this.Controls.Add(this.textTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Inställningar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKundnr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxModell;
        private System.Windows.Forms.ListBox listBoxSort;
        private System.Windows.Forms.ListBox listBoxBrand;
        private System.Windows.Forms.TextBox modeTextBox;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.Button buttonReadXML;
        private System.Windows.Forms.ListBox listBoxXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStandard;
        private System.Windows.Forms.ListBox listBoxProductNbr;
        private System.Windows.Forms.ListBox listBoxReservdelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxArtikelNr;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxModell;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxSort;
        private System.Windows.Forms.ListBox listBoxSettings;
        private System.Windows.Forms.TextBox textBoxMode;
        private System.Windows.Forms.NumericUpDown numericUpDownKundnr;
        private System.Windows.Forms.Button buttonNewMode;
        private System.Windows.Forms.CheckBox checkBoxKlar;
        private System.Windows.Forms.CheckBox checkBoxFaktura;
        private System.Windows.Forms.CheckBox checkBoxHämta;
        private System.Windows.Forms.Button buttonSaveMode;
        private System.Windows.Forms.Button buttonPostnummerSave;
        private System.Windows.Forms.Button buttonPostnummerNew;
        private System.Windows.Forms.ListBox listBoxPostnummer;
        private System.Windows.Forms.TextBox textBoxPostnummer;
        private System.Windows.Forms.TextBox textBoxPostort;
        private System.Windows.Forms.Button buttonRemoveMode;
        private System.Windows.Forms.Button buttonPostnummerRemove;
        private System.Windows.Forms.TextBox textBoxPostnummerSearch;

    }
}