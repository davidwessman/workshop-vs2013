using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014
{
    public partial class Settings : Form
    {
        List<Modell> models;
        Listor brand;
        Listor showBrand;
        Listor type;
        Listor showType;
        //Listor arbete;
        Modell modell;
        Reservdel reservdel;
        Mode setup;
        Mode mode;
        Postnummer postnummer;

        List<Mode> modes;
           
       // List<Reservdel> reservdelar;
        public Settings()
        {
            InitializeComponent();
            textBoxSort.GotFocus += textBoxSearch_GotFocus;
            textBoxSort.LostFocus += textBoxSearch_LostFocus;
            textBoxBrand.GotFocus += textBoxSearch_GotFocus;
            textBoxBrand.LostFocus += textBoxSearch_LostFocus;
            textBoxModell.GotFocus += textBoxSearch_GotFocus;
            textBoxModell.LostFocus += textBoxSearch_LostFocus;
            //arbete = null;
            //reservdelar = null;

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            loadModeList();
            if (setup != null)
                textBoxMode.Text = setup.text;

            listBoxBrand.DataSource = Variables.brandLista;
            listBoxSort.DataSource = Variables.typeList;
            listBoxPostnummer.DataSource = Postnummer.getAll();            
        }
        private void modeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonReadXML_Click(object sender, EventArgs e)
        {
            if (listBoxXML.SelectedIndex > -1)
            {
                Read(listBoxXML.Text,checkBoxKlar.Checked,checkBoxFaktura.Checked,checkBoxHämta.Checked);
                MessageBox.Show("Klar");
            }
        }
        private void Read(string sort,bool klar,bool faktura, bool utlamnad)
        {

            string path = "";
            try
            {
                OpenFileDialog pathen = new OpenFileDialog();
                pathen.Filter = "XML-files (.xml)|*.xml|All Files (*.*)|*.*";
                pathen.FilterIndex = 0;
                if (pathen.ShowDialog() == DialogResult.OK)
                {
                    path = pathen.FileName;
                }

                if (File.Exists(path))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(path);
                    int total = xDoc.SelectNodes(sort + "/Kund").Count;
                    int iterate = 1;                   
                    foreach (XmlNode xNode in xDoc.SelectNodes(sort + "/Kund"))
                    {                        
                        label1.Text = iterate++.ToString() + " / " + total.ToString();                        
                        label1.Refresh();
                        Customer kund = new Customer();
                        Maskin maskin = new Maskin();
                        Uppdrag uppdrag = new Uppdrag();
                        DateTime nu = DateTime.Now;
                        List<string> elementlista = new List<string>();
                        for (int i = 0; i < xNode.ChildNodes.Count; i++)
                        {
                            elementlista.Add((xNode.ChildNodes.Item(i).Name));
                        }

                        #region Inläsning av Kunduppgifter + konversion av Postnummer
                        if (elementlista.Contains("Namn"))
                        {
                            string[] nameSplit = xNode.SelectSingleNode("Namn").InnerText.Split(null);
                            kund.firstNamn = nameSplit[0];
                            for (int i = 1; i < nameSplit.Count(); i++)
                            {
                                kund.lastNamn += nameSplit[i];
                            }
                        }
                        if (elementlista.Contains("Telefonnummer"))
                        {
                            kund.phone = xNode.SelectSingleNode("Telefonnummer").InnerText;
                        }
                        if (elementlista.Contains("Adress"))
                        {
                            kund.LeveransAdress1 = xNode.SelectSingleNode("Adress").InnerText;
                        }
                        if (elementlista.Contains("Postnr"))
                        {
                            kund.LeveransPostnr = xNode.SelectSingleNode("Postnr").InnerText;                            
                        }

                        if (elementlista.Contains("Postort"))
                        {
                            kund.LeveransPostort = xNode.SelectSingleNode("Postort").InnerText;
                        }                        
                        if (elementlista.Contains("E-post"))
                        {
                            kund.epost = xNode.SelectSingleNode("E-post").InnerText;
                        }
                        if (elementlista.Contains("DInlämning"))
                            kund.inlagd = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("DInlämning").InnerText));
                        Postnummer postnr = new Postnummer(kund.LeveransPostnr,kund.LeveransPostort);
                        postnr.Add();                        
                        kund.aktuell = false;

                        kund.customerID = "";
                        string year = nu.ToString("''y");
                        if (elementlista.Contains("Kundnummer"))
                        {
                            kund.customerID = xNode.SelectSingleNode("Kundnummer").InnerText;
                            Customer search = Customer.Find(kund.customerID);
                            if (search != null)
                            {
                                kund = search;
                            }
                        }
                        if (String.IsNullOrWhiteSpace(kund.customerID))
                        {
                            kund.customerID = year + "-" + Variables.mode.kundnummer.ToString("D3");
                        }
                        #endregion

                        #region Allt annat                        
                        if (elementlista.Contains("DInlämning"))
                        {
                            uppdrag.inlagd = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("DInlämning").InnerText));
                            kund.inlagd = uppdrag.inlagd;
                            maskin.inlagd = uppdrag.inlagd;
                        }
                        if (elementlista.Contains("DFärdig"))
                            uppdrag.deadline = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("DFärdig").InnerText));
                        if (elementlista.Contains("LBesked"))
                            uppdrag.besked = xNode.SelectSingleNode("LBesked").InnerText;
                        if (elementlista.Contains("Märke"))
                            maskin.brand = xNode.SelectSingleNode("Märke").InnerText;
                        if (elementlista.Contains("Maskin"))
                        {
                            if (xNode.SelectSingleNode("Maskin").InnerText == "Rotorklippare")
                            {
                                maskin.type = "Rotorgräsklippare";
                            }
                            else
                            {
                                maskin.type = xNode.SelectSingleNode("Maskin").InnerText;
                            }
                        }
                        if (elementlista.Contains("Tvättning") && xNode.SelectSingleNode("Tvättning").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Tvättning", klar));
                        if (elementlista.Contains("Felsökning") && xNode.SelectSingleNode("Felsökning").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Felsökning", klar));
                        if (elementlista.Contains("KBesked") && xNode.SelectSingleNode("KBesked").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Offert", klar));
                        if (elementlista.Contains("Service") && xNode.SelectSingleNode("Service").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Service", klar));
                        if (elementlista.Contains("Reparation") && xNode.SelectSingleNode("Reparation").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Reparation", klar));
                        if (elementlista.Contains("Utkörning") && xNode.SelectSingleNode("Utkörning").InnerText.Contains("True"))
                            uppdrag.arbete.Add(new Arbete("Utkörning", klar));
                        if (elementlista.Contains("Övrigt"))
                            uppdrag.ovrigt = xNode.SelectSingleNode("Övrigt").InnerText;
                        //if (elementlista.Contains("Reservdelar"))
                        //    uppdrag.reservdelar = xNode.SelectSingleNode("Reservdelar").InnerText;
                        if (elementlista.Contains("Reparatör"))
                            uppdrag.reparator = xNode.SelectSingleNode("Reparatör").InnerText;
                        if (elementlista.Contains("Kommentar"))
                            uppdrag.kommentar = xNode.SelectSingleNode("Kommentar").InnerText;
                        if (elementlista.Contains("Faktura"))
                            uppdrag.faktura = xNode.SelectSingleNode("Faktura").InnerText.Contains("Klar");
                        if (elementlista.Contains("Klar"))
                            uppdrag.klar = xNode.SelectSingleNode("Klar").InnerText.Contains("Klar");
                        if (elementlista.Contains("Serienummer"))
                            maskin.serialNbr = xNode.SelectSingleNode("Serienummer").InnerText;
                        if (elementlista.Contains("Hylla"))
                            uppdrag.hylla = xNode.SelectSingleNode("Hylla").InnerText;
                        if (elementlista.Contains("Hyllplan"))
                            uppdrag.plan = Convert.ToInt32(xNode.SelectSingleNode("Hyllplan").InnerText);


                        #endregion
                        uppdrag.plan = 0;
                        if (klar)
                            uppdrag.klar = true;
                        uppdrag.startat = uppdrag.klar;
                        kund.aktuell = !uppdrag.klar;
                        maskin.vinterforvaring = sort.Equals("VinterFörvaring");
                        if (faktura)
                            uppdrag.faktura = true;
                        if (utlamnad)
                            uppdrag.utlamnad = true;

                        if (uppdrag.inlamnat == null)
                        {
                            uppdrag.inlagd = nu;
                            kund.inlagd = nu;
                            maskin.inlagd = nu;
                        }
                        uppdrag.arbeteStart = uppdrag.inlagd;
                        uppdrag.arbeteKlart = uppdrag.inlagd;
                        uppdrag.deadline = uppdrag.inlagd;
                        maskin.productNbr = String.Empty;
                        elementlista.Clear();
                        kund.Add();
                        kund.Load();
                        if (sort != "Kunder")
                        {
                            kund.AddMachine(maskin);
                            maskin.Load(0);
                            maskin.AddUppdrag(uppdrag);
                        }


                    }
                }
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Fel - vid inläsning av XML-filen: " + path, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void buttonStandard_Click(object sender, EventArgs e)
        {
            
            Variables.typeList.Add(new Listor("type","Rotorgräsklippare"));
            Variables.typeList.Add(new Listor("type","Robotgräsklippare"));
            Variables.typeList.Add(new Listor("type","Åkgräsklippare"));
            Variables.typeList.Add(new Listor("type","Motorsåg"));
            Variables.typeList.Add(new Listor("type","Häcksax"));
            Variables.typeList.Add(new Listor("type","Röjsåg"));
            Variables.typeList.Add(new Listor("type", "Trimmer"));
            Variables.typeList.Add(new Listor("type","Lövblås"));
            Variables.typeList.Add(new Listor("type","Jordfräs"));
            Variables.typeList.Add(new Listor("type","Annat"));            

            Variables.arbeteLista.Add(new Arbete("Felsökning"));
            Variables.arbeteLista.Add(new Arbete("Hämtning"));
            Variables.arbeteLista.Add(new Arbete("Reparation"));
            Variables.arbeteLista.Add(new Arbete("Service"));
            Variables.arbeteLista.Add(new Arbete("Tvättning"));
            Variables.arbeteLista.Add(new Arbete("Utkörning"));
            Variables.arbeteLista.Add(new Arbete("Vinterförvaring"));
            Variables.arbeteLista.Add(new Arbete("Offert"));
            foreach (Arbete a in Variables.arbeteLista)
                a.Save();

            Variables.brandLista.Add(new Listor("brand","Klippo"));
            Variables.brandLista.Add(new Listor("brand","Husqvarna"));
            Variables.brandLista.Add(new Listor("brand","AL-KO"));
            Variables.brandLista.Add(new Listor("brand","Jonsered"));
            Variables.brandLista.Add(new Listor("brand","Hitachi"));
            Variables.brandLista.Add(new Listor("brand","Stiga"));
            Variables.brandLista.Add(new Listor("brand","Partner"));
            Variables.brandLista.Add(new Listor("brand","Tanaka"));
            Variables.brandLista.Add(new Listor("brand","Gardena"));
            Variables.brandLista.Add(new Listor("brand","Viking"));
            Variables.brandLista.Add(new Listor("brand","Wolf-Garten"));
            Variables.brandLista.Add(new Listor("brand","Övrigt"));

            Variables.reparatorLista.Add(new Listor("reparator","Magnus"));
            Variables.reparatorLista.Add(new Listor("reparator","Mirko"));
            Variables.reparatorLista.Add(new Listor("reparator","Kaj"));
            Variables.reparatorLista.Add(new Listor("reparator","David"));
            Variables.reparatorLista.Add(new Listor("reparator","Armondas"));

            listBoxBrand.DataSource = null;
            listBoxBrand.DataSource = Variables.brandLista;
            listBoxSort.DataSource = null;
            listBoxSort.DataSource = Variables.typeList;            
        }
        
        private void listBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSort.SelectedIndex > -1 && listBoxBrand.SelectedIndex > -1)
            {
                brand = listBoxBrand.SelectedItem as Listor;
                type = listBoxSort.SelectedItem as Listor;
                models = Modell.FindModels(listBoxBrand.Text, listBoxSort.Text);
                listBoxModell.DataSource = models;
            }
            else
            {
                models = null;
                listBoxModell.DataSource = models;
            }
        }

        private void listBoxModell_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxReservdelar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxReservdelar.SelectedIndex > -1)
            {
                reservdel = (Reservdel)listBoxReservdelar.SelectedItem;
                textBoxBarcode.Text = reservdel.barcode;
                textBoxName.Text = reservdel.name;
                textBoxArtikelNr.Text = reservdel.artikelNr;
                checkBox1.Checked = reservdel.orderDel;
            }
        }        

        private void textBoxSort_KeyDown(object sender, KeyEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(txtBox.Text))
            {                
                if(showType == null)
                {
                    showType = new Listor("type", txtBox.Text);
                    if(!showType.checkExist())
                    {
                        Variables.typeList.Add(new Listor("type", txtBox.Text));
                        showType.Add();
                        listBoxSort.DataSource = null;
                        listBoxSort.DataSource = Variables.typeList;
                    }
                    else
                    {
                        MessageBox.Show("Finns redan en motsvarande");
                        int index = listBoxSort.FindString(showType.ToString());
                        if (index > -1 && index < listBoxSort.Items.Count)
                            listBoxSort.SetSelected(index, true);
                        textBoxSort.Text = "Lägg till.";
                    }                    
                }
                else
                {
                    showType.string1 = txtBox.Text;
                    showType.Add();
                    Variables.typeList.Add(showType);
                    textBoxSort.Text = "Lägg till.";
                    listBoxSort.DataSource = null;
                    listBoxSort.DataSource = Variables.typeList;
                }
            }
        }

        private void listBoxSort_KeyDown(object sender, KeyEventArgs e)
        {
            var listBox = sender as ListBox;
            if (e.KeyCode == Keys.Back && listBox.SelectedIndex > -1)
            {
                showType = (Listor)listBox.SelectedItem;
                Variables.typeList.Remove(showType);
                showType.Remove();
                listBox.DataSource = null;
                listBox.DataSource = Variables.typeList;
                textBoxSort.Text = showType.string1;
            }
        }
        private void listBoxBrand_KeyDown(object sender, KeyEventArgs e)
        {
            var listBox = sender as ListBox;
            if (e.KeyCode == Keys.Back && listBox.SelectedIndex > -1)
            {
                showBrand = (Listor)listBox.SelectedItem;
                Variables.brandLista.Remove(showBrand);
                showBrand.Remove();
                listBox.DataSource = null;
                listBox.DataSource = Variables.brandLista;
                textBoxBrand.Text = showBrand.string1;
            }
        }
        private void textBoxBrand_KeyDown(object sender, KeyEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(txtBox.Text))
            {
                if (showBrand == null)
                {
                    showBrand = new Listor("brand", txtBox.Text);
                    if (!showBrand.checkExist())
                    {
                        Variables.brandLista.Add(new Listor("brand", txtBox.Text));
                        showBrand.Add();
                        listBoxBrand.DataSource = null;
                        listBoxBrand.DataSource = Variables.brandLista;
                    }
                    else
                    {
                        MessageBox.Show("Finns redan en motsvarande");
                    }
                }
                else
                {

                    showBrand.string1 = txtBox.Text;
                    showBrand.Add();
                    Variables.brandLista.Add(showBrand);
                    listBoxBrand.Text = "Lägg till.";
                    listBoxBrand.DataSource = null;
                    listBoxBrand.DataSource = Variables.brandLista;
                }
                showBrand = null;
            }
        }

        private void listBoxModell_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void textBoxModell_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void textBoxSearch_GotFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == "Lägg till.")
            {
                tbox.Text = "";
                tbox.ForeColor = Color.Black;
            }
        }
        private void textBoxSearch_LostFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == "")
            {
                tbox.Text = "Lägg till.";
                tbox.ForeColor = Color.Gray;
            }
        }

        private void listBoxSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxSettings.SelectedIndex > -1)
            {
                mode = listBoxSettings.SelectedItem as Mode;
                modeTextBox.Text = mode.mode;
                numericUpDownKundnr.Value = mode.kundnummer;
                textTextBox.Text = mode.text;
            }
        }
        private void buttonNewMode_Click(object sender, EventArgs e)
        {
            if(mode != null)
            {
                mode.ChangeMode();
            }
        }

        private void buttonSaveMode_Click(object sender, EventArgs e)
        {
           if(listBoxSettings.SelectedIndex > -1)
           {
               mode = listBoxSettings.SelectedItem as Mode;
               mode.text = textTextBox.Text;
               mode.kundnummer = (int)numericUpDownKundnr.Value;
               mode.Update();
               loadModeList();
           }
        }

        private void buttonRemoveMode_Click(object sender, EventArgs e)
        {
           if(listBoxSettings.SelectedIndex > -1)
           {
               mode = listBoxSettings.SelectedItem as Mode;
               if (mode != null)
               {
                   mode.Remove();
                   MessageBox.Show("Remove: " + mode.mode);
               }

               loadModeList();
           }
        }
        private void loadModeList()
        {
            modes = Mode.getModes();
            if (modes.Count > 0)
            {
                foreach (Mode a in modes)
                    if (a.mode.Equals("mode"))
                    {
                        setup = a;
                    }
                modes.Remove(setup);
            }
            listBoxSettings.DataSource = modes;
        }

        private void listBoxPostnummer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxPostnummer.SelectedIndex > -1)
            {
                postnummer = listBoxPostnummer.SelectedItem as Postnummer;
                textBoxPostnummer.Text = postnummer.postnummer;
                textBoxPostort.Text = postnummer.ort;
            }
            else
            {
                textBoxPostort.Clear();
                textBoxPostort.Clear();
            }
        }

        private void buttonPostnummerSave_Click(object sender, EventArgs e)
        {
            if (listBoxPostnummer.SelectedIndex > -1)
            {
                postnummer = listBoxPostnummer.SelectedItem as Postnummer;
                postnummer.postnummer = textBoxPostnummer.Text;
                postnummer.ort = textBoxPostort.Text;
                postnummer.Update();
            }
            else if (!String.IsNullOrEmpty(textBoxPostnummer.Text) && !String.IsNullOrEmpty(textBoxPostort.Text))
            {
                postnummer = new Postnummer(textBoxPostnummer.Text, textBoxPostort.Text);
                postnummer.Add();
                textBoxPostnummer.Enabled = false;
            }
            listBoxPostnummer.DataSource = Postnummer.getAll();
        }

        private void buttonPostnummerRemove_Click(object sender, EventArgs e)
        {
            if (listBoxPostnummer.SelectedIndex > -1)
            {
                postnummer = listBoxPostnummer.SelectedItem as Postnummer;
                postnummer.Remove();
            }
            listBoxPostnummer.DataSource = Postnummer.getAll();
        }

        private void buttonPostnummerNew_Click(object sender, EventArgs e)
        {
            listBoxPostnummer.SelectedIndex = -1;
            textBoxPostnummer.Enabled = true;
            textBoxPostnummerSearch.Clear();
            textBoxPostnummer.Clear();
            textBoxPostort.Clear();
        }
        private void postnummerSearch(object sender, EventArgs e)
        {
            string text = textBoxPostnummerSearch.Text;
            if (!String.IsNullOrEmpty(text))
            {
                listBoxPostnummer.DataSource = Postnummer.search(text as string);
            }
            else
            {
                listBoxPostnummer.DataSource = Postnummer.getAll();
            }

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {            
                Customer.export();
                Hamtning.export();
                Maskin.export();
                Uppdrag.export();
                Postnummer.export();                 
        }
    }
        
}
