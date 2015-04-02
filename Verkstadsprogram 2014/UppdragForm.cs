using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014
{
    public partial class UppdragForm : UserControl
    {
        public Uppdrag uppdrag;
        bool loaded;
        public Modell model;
        public bool uppdragNew;
        bool suggestReservdel;                
        bool uppdragChange;
        public event EventHandler UppdragUpdated;
        public event EventHandler UppdragRemoved;
        public UppdragForm()
        {
            InitializeComponent();
            LoadForm();
            
        }
        public UppdragForm(Uppdrag uppdrag)
        {
            InitializeComponent();
            LoadForm();            
        }
        private void LoadForm()
        {
            clearUppdrag();
            listBoxReparator.DataSource = Variables.reparatorLista;
            listBoxReparator.SelectedIndex = -1;            
        }        
                
        private void textBoxInlamnat_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(textBoxInlamnat.Text))
            {
                if (!listBoxInlamnat.Items.Contains(textBoxInlamnat.Text))
                    listBoxInlamnat.Items.Add(textBoxInlamnat.Text);
                textBoxInlamnat.ResetText();
            }
            if (e.KeyCode == Keys.Back && listBoxInlamnat.SelectedIndex > -1)
            {
                string a = (string)listBoxInlamnat.SelectedItem;
                listBoxInlamnat.Items.Remove(a);
                textBoxInlamnat.Text = a;
            }               
        }
        public void showUppdrag(Uppdrag uppdrag)
        {
            checkUppdragChanged();
            Uppdrag_Change(false);            
            loaded = false;
            this.uppdrag = uppdrag;            
            showUppdrag();
            loaded = true;
            tableUppdrag2.Visible = true;
            buttonRemove.Visible = true;

        }
        public void newUppdrag(Uppdrag uppdrag)
        {
            checkUppdragChanged();
            Uppdrag_Change(false);
            loaded = false;
            this.uppdrag = uppdrag;
            showUppdrag();
            uppdragNew = true;
            tableUppdrag2.Visible = false;
            buttonRemove.Visible = false;
        }
        private void showUppdrag()
        {
            checkUppdragChanged();
            clearUppdrag();
            if (uppdrag != null)
            {
                loaded = false;                
                
                foreach(Arbete a in uppdrag.arbete)
                {
                    AddArbete(a);
                }

                richTextBoxRepSpec.Text = uppdrag.reparationSpec;
                richTextBoxOvrigt.Text = uppdrag.ovrigt;
                listBoxBesked.Text = uppdrag.besked;
                checkBoxKlar.Checked = uppdrag.klar;
                checkBoxUtlamnad.Checked = uppdrag.utlamnad;
                checkBoxStarted.Checked = uppdrag.startat;

                inlagdDateTimePicker.Value = (uppdrag.inlagd.Equals(Variables.notChosen)) ? DateTime.Now : uppdrag.inlagd;
                deadlineDateTimePicker.Value = (uppdrag.deadline.Equals(Variables.notChosen)) ? DateTime.Now : uppdrag.deadline;
                arbeteStartDateTimePicker.Value = (uppdrag.startat && !uppdrag.arbeteStart.Equals(Variables.notChosen)) ?  uppdrag.arbeteStart : DateTime.Now;
                arbeteKlartDateTimePicker.Value = (uppdrag.klar && !uppdrag.arbeteKlart.Equals(Variables.notChosen)) ?  uppdrag.arbeteKlart : DateTime.Now;
                UtlamnadDateTimePicker.Value = (uppdrag.utlamnad && !uppdrag.utlamnadDate.Equals(Variables.notChosen)) ? uppdrag.utlamnadDate : DateTime.Now;                            
                
                listBoxHylla.Text = uppdrag.hylla;
                numericUpDownPlan.Value = uppdrag.plan;
                checkBoxFaktura.Checked = uppdrag.faktura;
                textBoxFakturaNummer.Text = uppdrag.fakturanummer;
                richTextBoxKommentar.Text = uppdrag.kommentar;
                listBoxReparator.Text = uppdrag.reparator;
                reservdelarForm.Ladda(uppdrag.reservdelar, uppdrag.orderdelar);
                
                if (uppdrag.arbetstid != null)
                {
                    ArbetstidH.Value = uppdrag.arbetstid.Hours;
                    ArbetstidMin.Value = uppdrag.arbetstid.Minutes;
                }
                foreach (String a in uppdrag.inlamnat)
                {
                    if (!String.IsNullOrWhiteSpace(a) && !listBoxInlamnat.Items.Contains(a))
                        listBoxInlamnat.Items.Add(a);
                }
                loadSuggestReservdelar();   
            }
            Uppdrag_Change(false);
            loaded = true;
        }
        private void saveUppdrag()
        {
            uppdrag.inlagd = inlagdDateTimePicker.Value;
            uppdrag.arbete.Clear();
            foreach(Arbete a in listBoxArbeteVald.Items)
            {
                uppdrag.arbete.Add(a);
            }
            uppdrag.reparationSpec = richTextBoxRepSpec.Text;
            uppdrag.besked = listBoxBesked.Text;
            uppdrag.deadline = deadlineDateTimePicker.Value;
            uppdrag.ovrigt = richTextBoxOvrigt.Text;
            uppdrag.startat = checkBoxStarted.Checked;
            uppdrag.arbeteStart = arbeteStartDateTimePicker.Value;
            uppdrag.reservdelar = reservdelarForm.reservdelslista;
            uppdrag.orderdelar = reservdelarForm.orderlista;
            uppdrag.klar = checkBoxKlar.Checked;
            uppdrag.arbeteKlart = arbeteKlartDateTimePicker.Value;
            uppdrag.reparator = listBoxReparator.Text;
            uppdrag.arbetstid = new TimeSpan((int)ArbetstidH.Value, (int)ArbetstidMin.Value, 0);
            uppdrag.kommentar = richTextBoxKommentar.Text;
            uppdrag.faktura = checkBoxFaktura.Checked;
            uppdrag.fakturanummer = textBoxFakturaNummer.Text;
            uppdrag.hylla = listBoxHylla.Text;
            uppdrag.plan = (int)numericUpDownPlan.Value;
            foreach(String a in listBoxInlamnat.Items)
            {
                if (!uppdrag.inlamnat.Contains(a))
                    uppdrag.inlamnat.Add(a);
            }
            uppdrag.utlamnad = checkBoxUtlamnad.Checked;
            uppdrag.utlamnadDate = UtlamnadDateTimePicker.Value;
            
                        
            if (uppdrag.orderdelar.Count > 0)
                foreach (Del a in uppdrag.orderdelar)
                {                
                        a.reservdel.orderDel = true;                        
                        a.reservdel.Update();                
                    if (model != null)
                    {
                        model.AddReservdel(a.reservdel);
                    }
                }
            if (uppdrag.reservdelar.Count > 0)
                foreach (Del a in uppdrag.reservdelar)
                {                                    
                    if (model != null)                
                        model.AddReservdel(a.reservdel);                
                }            
        }
        private void checkUppdragChanged()
        {
            if (uppdragChange && uppdrag != null && loaded)
            {
                DialogResult result1 = MessageBox.Show(uppdrag.ToString() + " ändrades, vill du spara?",
                "Spara",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    saveUppdrag();
                    uppdrag.Update();
                    MessageBox.Show("Sparades");

                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.UppdragUpdated != null)
            {
                loaded = false;
                saveUppdrag();
                Uppdrag_Change(false);
                if (model != null)
                    model.Update();
                this.UppdragUpdated(this, new EventArgs());                
            }
        }
        private void checkBoxStarted_CheckedChanged(object sender, EventArgs e)
        {
            arbeteStartDateTimePicker.Enabled = checkBoxStarted.Checked;
            Uppdrag_Change(true);
        }
        private void checkBoxKlar_CheckedChanged(object sender, EventArgs e)
        {
            arbeteKlartDateTimePicker.Enabled = checkBoxKlar.Checked;
            Uppdrag_Change(true);
        }
        private void Uppdrag_Changed(object sender, EventArgs e)
        {
            Uppdrag_Change(true);
        }
        private void Uppdrag_Change(bool check)
        {
            uppdragChange = check;
            radioButtonUppdragChanged.Checked = check;
            buttonSaveNewUppdrag.Visible = check;
        }           
        private void ArbetstidMin_ValueChanged(object sender, EventArgs e)
        {
            if (ArbetstidMin.Value == 60)
            {
                ArbetstidH.Value += 1;
                ArbetstidMin.Value = 0;
            }
            Uppdrag_Change(true);
        }
        private void ArbetstidH_ValueChanged(object sender, EventArgs e)
        {
            Uppdrag_Change(true);
        }        
        public Modell modelC
        {
            get { return this.model; }
            set { this.model = value; }
        }
        private void clearUppdrag() 
        {           
            listBoxArbete.Items.Clear();
            listBoxArbeteVald.Items.Clear();
            foreach (Arbete a in Variables.arbeteLista)
            {
                listBoxArbete.Items.Add(a);
            }            
            richTextBoxRepSpec.Clear();
            richTextBoxOvrigt.Clear();
            listBoxBesked.SelectedIndex = -1;
            listBoxReparator.SelectedIndex = -1;
            reservdelarForm.Clear();            
            inlagdDateTimePicker.Value = DateTime.Now;
            deadlineDateTimePicker.Value = DateTime.Now;
            arbeteKlartDateTimePicker.Value = DateTime.Now;
            arbeteStartDateTimePicker.Value = DateTime.Now;
            checkBoxFaktura.Checked = false;
            checkBoxKlar.Checked = false;
            checkBoxStarted.Checked = false;
            listBoxHylla.SelectedIndex = -1;
            numericUpDownPlan.Value = 0;
            textBoxFakturaNummer.Clear();
            UtlamnadDateTimePicker.Value = DateTime.Now;
            textBoxFakturaNummer.Clear();
            ArbetstidH.Value = 0;
            ArbetstidMin.Value = 0;            
            listBoxInlamnat.Items.Clear();
            textBoxInlamnat.ResetText();
        }
        private void reservdelarForm_Change(object sender, EventArgs e)
        {
            Uppdrag_Change(true);
        }
        private void listBoxArbete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBoxArbete.SelectedIndex > -1)
            {
                Arbete arbete = (Arbete)listBoxArbete.SelectedItem;
                AddArbete(arbete);                
                if(arbete.name.Equals("Reparation"))
                {
                    labelRepSpec.Visible = true;
                    richTextBoxRepSpec.Visible = true;
                }
            }
        }
        private void AddArbete(Arbete a)
        {
            if (!listBoxArbeteVald.Items.Contains(a))
            {
                listBoxArbeteVald.SelectedIndex = -1;
                listBoxArbeteVald.Items.Add(a);
                listBoxArbete.Items.Remove(a);
                if (listBoxArbete.Items.Count > 0)
                    listBoxArbete.SelectedIndex = 0;

                Uppdrag_Change(true);
            }
        }
        private void RemoveArbete(Arbete a)
        {
            if (listBoxArbeteVald.Items.Contains(a))
            {
                listBoxArbete.SelectedIndex = -1;
                if(!listBoxArbete.Items.Contains(a))
                    listBoxArbete.Items.Add(a);
                listBoxArbeteVald.Items.Remove(a);
                if (listBoxArbeteVald.Items.Count > 0)
                    listBoxArbeteVald.SelectedIndex = 0;
                Uppdrag_Change(true);
            }
        }
        private void listBoxArbeteVald_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && listBoxArbeteVald.SelectedIndex > -1)
            {
                Arbete arbetet = (Arbete)listBoxArbeteVald.SelectedItem;
                arbetet.done = false;
                RemoveArbete(arbetet);
                if(arbetet.name == "Reparation")
                {
                    labelRepSpec.Visible = false;
                    richTextBoxRepSpec.Visible = false;
                }
                Uppdrag_Change(true);
            }
            if (e.KeyCode == Keys.Enter && listBoxArbeteVald.SelectedIndex > -1)
            {
                Arbete arbete = (Arbete)listBoxArbeteVald.SelectedItem;
                arbete.done = !arbete.done;
                RemoveArbete(arbete);
                AddArbete(arbete);
                int index = listBoxArbeteVald.FindString(arbete.ToString());
                listBoxArbeteVald.Select();
                listBoxArbete.SelectedIndex = -1;
                if (index > -1)
                    listBoxArbeteVald.SetSelected(index, true);
                Uppdrag_Change(true);
            }
        }
        private void checkBoxUtlamnad_CheckedChanged(object sender, EventArgs e)
        {
            UtlamnadDateTimePicker.Enabled = checkBoxUtlamnad.Checked;
            Uppdrag_Change(true);
        }
        public void SuggestReservdelar(bool check)
        {
            suggestReservdel = check;
            labelSuggestReservdelar.Visible = suggestReservdel;
            listBoxSuggestReservdelar.Visible = suggestReservdel;
            loadSuggestReservdelar();
        }
        private void loadSuggestReservdelar()
        {
            if (suggestReservdel && model != null)
            {
                List<Reservdel> search = new List<Reservdel>();
                search = model.reservdelar;
                foreach (Reservdel a in search)
                {
                    if(!listBoxSuggestReservdelar.Items.Contains(a))
                        listBoxSuggestReservdelar.Items.Add(a);
                }
            }
            else
            {
                listBoxSuggestReservdelar.Items.Clear();
            }
        }
        private void listBoxSuggestReservdelar_KeyDown(object sender, KeyEventArgs e)
        {
            if(listBoxSuggestReservdelar.SelectedIndex > -1)
            {
                Reservdel reserv = listBoxSuggestReservdelar.SelectedItem as Reservdel;
                reservdelarForm.AddDel(reserv);
                listBoxSuggestReservdelar.ClearSelected();                
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(uppdrag != null)
            {
                DialogResult result1 = MessageBox.Show("Vill du radera " + uppdrag.ToString() + "?",
               "Ta bort",
               MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    uppdrag.Remove();
                    if (UppdragRemoved != null)
                        UppdragRemoved(this, new EventArgs());
                    this.clearUppdrag();
                }
            }
        }
    }
}
