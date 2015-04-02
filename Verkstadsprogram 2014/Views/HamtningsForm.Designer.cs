namespace Verkstadsprogram_2014.Views
{
    partial class HamtningsForm
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
            System.Windows.Forms.Label brandLabel;
            System.Windows.Forms.Label kommentarLabel;
            System.Windows.Forms.Label maskinLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HamtningsForm));
            this.hamtningDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxModell = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.listBoxSort = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxBrand = new System.Windows.Forms.ListBox();
            this.buttonPincode = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxPinkod = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxVinterforvaring = new System.Windows.Forms.CheckBox();
            this.listBoxModell = new System.Windows.Forms.ListBox();
            this.richTextBoxKommentar = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxBestamd = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMaskiner = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonView = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.buttonNewHamtning = new System.Windows.Forms.Button();
            this.checkBoxHamtad = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPostnr = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.textBoxPostnummer = new System.Windows.Forms.TextBox();
            this.labelHamtningSearch = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonHämtad = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            brandLabel = new System.Windows.Forms.Label();
            kommentarLabel = new System.Windows.Forms.Label();
            maskinLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // brandLabel
            // 
            brandLabel.AutoSize = true;
            brandLabel.Location = new System.Drawing.Point(3, 93);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new System.Drawing.Size(40, 13);
            brandLabel.TabIndex = 5;
            brandLabel.Text = "Märke:";
            // 
            // kommentarLabel
            // 
            kommentarLabel.AutoSize = true;
            kommentarLabel.Location = new System.Drawing.Point(3, 260);
            kommentarLabel.Name = "kommentarLabel";
            kommentarLabel.Size = new System.Drawing.Size(63, 13);
            kommentarLabel.TabIndex = 15;
            kommentarLabel.Text = "Kommentar:";
            // 
            // maskinLabel
            // 
            maskinLabel.AutoSize = true;
            maskinLabel.Location = new System.Drawing.Point(3, 38);
            maskinLabel.Name = "maskinLabel";
            maskinLabel.Size = new System.Drawing.Size(41, 13);
            maskinLabel.TabIndex = 21;
            maskinLabel.Text = "Maskin";
            // 
            // hamtningDateTimePicker
            // 
            this.hamtningDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hamtningDateTimePicker.Location = new System.Drawing.Point(55, 9);
            this.hamtningDateTimePicker.Name = "hamtningDateTimePicker";
            this.hamtningDateTimePicker.Size = new System.Drawing.Size(135, 20);
            this.hamtningDateTimePicker.TabIndex = 7;
            this.hamtningDateTimePicker.ValueChanged += new System.EventHandler(this.hamtningDateTimePicker_ValueChanged);
            // 
            // textBoxModell
            // 
            this.textBoxModell.Location = new System.Drawing.Point(119, 217);
            this.textBoxModell.Name = "textBoxModell";
            this.textBoxModell.Size = new System.Drawing.Size(142, 20);
            this.textBoxModell.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Modell:";
            // 
            // listBoxSort
            // 
            this.listBoxSort.FormattingEnabled = true;
            this.listBoxSort.Location = new System.Drawing.Point(119, 132);
            this.listBoxSort.Name = "listBoxSort";
            this.listBoxSort.Size = new System.Drawing.Size(142, 30);
            this.listBoxSort.TabIndex = 2;
            this.listBoxSort.SelectedIndexChanged += new System.EventHandler(this.listBoxBrand_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Sort:";
            // 
            // listBoxBrand
            // 
            this.listBoxBrand.FormattingEnabled = true;
            this.listBoxBrand.Location = new System.Drawing.Point(119, 96);
            this.listBoxBrand.Name = "listBoxBrand";
            this.listBoxBrand.Size = new System.Drawing.Size(142, 30);
            this.listBoxBrand.TabIndex = 1;
            this.listBoxBrand.SelectedIndexChanged += new System.EventHandler(this.listBoxBrand_SelectedIndexChanged);
            // 
            // buttonPincode
            // 
            this.buttonPincode.Location = new System.Drawing.Point(55, 3);
            this.buttonPincode.Name = "buttonPincode";
            this.buttonPincode.Size = new System.Drawing.Size(86, 21);
            this.buttonPincode.TabIndex = 94;
            this.buttonPincode.Text = "Visa pinkod";
            this.buttonPincode.UseVisualStyleBackColor = true;
            this.buttonPincode.Click += new System.EventHandler(this.buttonPincode_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 323);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 93;
            this.label32.Text = "Pinkod:";
            // 
            // textBoxPinkod
            // 
            this.textBoxPinkod.Location = new System.Drawing.Point(3, 3);
            this.textBoxPinkod.Name = "textBoxPinkod";
            this.textBoxPinkod.PasswordChar = '*';
            this.textBoxPinkod.Size = new System.Drawing.Size(46, 20);
            this.textBoxPinkod.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkBoxVinterforvaring, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxModell, 1, 4);
            this.tableLayoutPanel1.Controls.Add(brandLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label32, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxModell, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPanel1.Controls.Add(kommentarLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxKommentar, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 10);
            this.tableLayoutPanel1.Controls.Add(maskinLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.listBoxBrand, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonNewHamtning, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHamtad, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelPostnr, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSearch, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPostnummer, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelHamtningSearch, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxVinterforvaring
            // 
            this.checkBoxVinterforvaring.Checked = true;
            this.checkBoxVinterforvaring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVinterforvaring.Location = new System.Drawing.Point(3, 3);
            this.checkBoxVinterforvaring.Name = "checkBoxVinterforvaring";
            this.checkBoxVinterforvaring.Size = new System.Drawing.Size(108, 24);
            this.checkBoxVinterforvaring.TabIndex = 100;
            this.checkBoxVinterforvaring.Text = "Vinterförvaring?";
            this.checkBoxVinterforvaring.UseVisualStyleBackColor = true;
            // 
            // listBoxModell
            // 
            this.listBoxModell.FormattingEnabled = true;
            this.listBoxModell.Location = new System.Drawing.Point(119, 168);
            this.listBoxModell.Name = "listBoxModell";
            this.listBoxModell.Size = new System.Drawing.Size(142, 43);
            this.listBoxModell.TabIndex = 3;
            // 
            // richTextBoxKommentar
            // 
            this.richTextBoxKommentar.Location = new System.Drawing.Point(119, 263);
            this.richTextBoxKommentar.Name = "richTextBoxKommentar";
            this.richTextBoxKommentar.Size = new System.Drawing.Size(142, 57);
            this.richTextBoxKommentar.TabIndex = 5;
            this.richTextBoxKommentar.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Hämtning";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.checkBoxBestamd, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.hamtningDateTimePicker, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(119, 359);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(193, 39);
            this.tableLayoutPanel3.TabIndex = 102;
            // 
            // checkBoxBestamd
            // 
            this.checkBoxBestamd.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxBestamd.Location = new System.Drawing.Point(3, 3);
            this.checkBoxBestamd.Name = "checkBoxBestamd";
            this.checkBoxBestamd.Size = new System.Drawing.Size(46, 33);
            this.checkBoxBestamd.TabIndex = 101;
            this.checkBoxBestamd.Text = "Bestäm";
            this.checkBoxBestamd.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxBestamd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.listBoxMaskiner, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(119, 41);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(237, 49);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // listBoxMaskiner
            // 
            this.listBoxMaskiner.FormattingEnabled = true;
            this.listBoxMaskiner.Location = new System.Drawing.Point(3, 3);
            this.listBoxMaskiner.Name = "listBoxMaskiner";
            this.listBoxMaskiner.Size = new System.Drawing.Size(142, 43);
            this.listBoxMaskiner.TabIndex = 0;
            this.listBoxMaskiner.SelectedIndexChanged += new System.EventHandler(this.listBoxMaskiner_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.radioButtonView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonNew, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(151, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(83, 43);
            this.tableLayoutPanel2.TabIndex = 98;
            // 
            // radioButtonView
            // 
            this.radioButtonView.AutoSize = true;
            this.radioButtonView.Checked = true;
            this.radioButtonView.Location = new System.Drawing.Point(3, 3);
            this.radioButtonView.Name = "radioButtonView";
            this.radioButtonView.Size = new System.Drawing.Size(78, 17);
            this.radioButtonView.TabIndex = 1;
            this.radioButtonView.TabStop = true;
            this.radioButtonView.Text = "Välj maskin";
            this.radioButtonView.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(3, 26);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(74, 17);
            this.radioButtonNew.TabIndex = 0;
            this.radioButtonNew.Text = "Ny maskin";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
            // 
            // buttonNewHamtning
            // 
            this.buttonNewHamtning.Location = new System.Drawing.Point(119, 3);
            this.buttonNewHamtning.Name = "buttonNewHamtning";
            this.buttonNewHamtning.Size = new System.Drawing.Size(85, 32);
            this.buttonNewHamtning.TabIndex = 103;
            this.buttonNewHamtning.Text = "Ny hämtning";
            this.buttonNewHamtning.UseVisualStyleBackColor = true;
            this.buttonNewHamtning.Visible = false;
            this.buttonNewHamtning.Click += new System.EventHandler(this.buttonNewHamtning_Click);
            // 
            // checkBoxHamtad
            // 
            this.checkBoxHamtad.AutoSize = true;
            this.checkBoxHamtad.Enabled = false;
            this.checkBoxHamtad.Location = new System.Drawing.Point(119, 404);
            this.checkBoxHamtad.Name = "checkBoxHamtad";
            this.checkBoxHamtad.Size = new System.Drawing.Size(63, 17);
            this.checkBoxHamtad.TabIndex = 104;
            this.checkBoxHamtad.Text = "Hämtad";
            this.checkBoxHamtad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Redan hämtad?";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.buttonPincode, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxPinkod, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(119, 326);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(144, 27);
            this.tableLayoutPanel5.TabIndex = 108;
            // 
            // labelPostnr
            // 
            this.labelPostnr.AutoSize = true;
            this.labelPostnr.Location = new System.Drawing.Point(3, 240);
            this.labelPostnr.Name = "labelPostnr";
            this.labelPostnr.Size = new System.Drawing.Size(65, 13);
            this.labelPostnr.TabIndex = 101;
            this.labelPostnr.Text = "Postnummer";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 476);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 32);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Spara";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.Location = new System.Drawing.Point(119, 427);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Size = new System.Drawing.Size(180, 43);
            this.listBoxSearch.TabIndex = 63;
            this.listBoxSearch.Visible = false;
            this.listBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostnummerSearch_PostnummerSelected);
            // 
            // textBoxPostnummer
            // 
            this.textBoxPostnummer.Location = new System.Drawing.Point(119, 243);
            this.textBoxPostnummer.Name = "textBoxPostnummer";
            this.textBoxPostnummer.Size = new System.Drawing.Size(141, 20);
            this.textBoxPostnummer.TabIndex = 62;
            this.textBoxPostnummer.TextChanged += new System.EventHandler(this.textBoxPostnummer_TextChanged);
            this.textBoxPostnummer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostnummerSearch_PostnummerSelected);
            // 
            // labelHamtningSearch
            // 
            this.labelHamtningSearch.AutoSize = true;
            this.labelHamtningSearch.Location = new System.Drawing.Point(3, 424);
            this.labelHamtningSearch.Name = "labelHamtningSearch";
            this.labelHamtningSearch.Size = new System.Drawing.Size(110, 13);
            this.labelHamtningSearch.TabIndex = 109;
            this.labelHamtningSearch.Text = "Planerade hämtningar";
            this.labelHamtningSearch.Visible = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.buttonRemove, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonHämtad, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonPrint, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(119, 514);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(228, 38);
            this.tableLayoutPanel6.TabIndex = 110;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(155, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(70, 32);
            this.buttonRemove.TabIndex = 108;
            this.buttonRemove.Text = "Ta bort";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Visible = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonHämtad
            // 
            this.buttonHämtad.Location = new System.Drawing.Point(3, 3);
            this.buttonHämtad.Name = "buttonHämtad";
            this.buttonHämtad.Size = new System.Drawing.Size(70, 32);
            this.buttonHämtad.TabIndex = 107;
            this.buttonHämtad.Text = "Hämtad";
            this.buttonHämtad.UseVisualStyleBackColor = true;
            this.buttonHämtad.Click += new System.EventHandler(this.buttonHämtad_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(79, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(70, 32);
            this.buttonPrint.TabIndex = 106;
            this.buttonPrint.Text = "Skriv ut";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // HamtningsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(364, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HamtningsForm";
            this.Text = "Hämtning";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker hamtningDateTimePicker;
        private System.Windows.Forms.TextBox textBoxModell;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox listBoxSort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBoxBrand;
        private System.Windows.Forms.Button buttonPincode;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxPinkod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxModell;
        private System.Windows.Forms.RichTextBox richTextBoxKommentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListBox listBoxMaskiner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonView;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.CheckBox checkBoxVinterforvaring;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.TextBox textBoxPostnummer;
        private System.Windows.Forms.Label labelPostnr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBoxBestamd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonNewHamtning;
        private System.Windows.Forms.CheckBox checkBoxHamtad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonHämtad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelHamtningSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button buttonRemove;
    }
}