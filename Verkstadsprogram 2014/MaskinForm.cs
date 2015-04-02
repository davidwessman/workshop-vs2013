using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Views;

namespace Verkstadsprogram_2014
{
    public partial class MaskinForm : UserControl
    {
        public Customer customer;
        public Maskin maskin;
        Modell model;
        List<Modell> models;        
        public event EventHandler MachineUpdated;
        public event EventHandler MachineRemoved;
        public event EventHandler Model;
        bool loaded;
        bool maskinChange;        
        
        public MaskinForm()
        {
            InitializeComponent();
            this.maskin = new Maskin();
            this.customer = new Customer();
            this.listBoxBrand.DataSource = Variables.brandLista;
            this.listBoxSort.DataSource = Variables.typeList;
            listBoxBrand.SelectedIndex = -1;
            listBoxSort.SelectedIndex = -1;
        }       
        private void clearMaskin()
        {
            listBoxBrand.SelectedIndex = -1;
            listBoxSort.SelectedIndex = -1;
            textBoxPYear.Clear();
            textBoxSerialNbr.Clear();
            textBoxLatestService.Clear();
            textBoxVinterforvarad.Clear();
            textBoxProductNbr.Clear();
            textBoxProductNbr.AutoCompleteCustomSource.Clear();
            textBoxMInlagd.Clear();
            textBoxModell.Clear();
            textBoxPinkod.Clear();
            textBoxMotorNr.Clear();
            textBoxAggregatNbr.Clear();            
        }
        private void showMachine()
        {
            if (maskin != null)
            {                
                checkMachineChanged();
                loaded = false;
                clearMaskin();
                listBoxBrand.Text = maskin.brand;
                listBoxSort.Text = maskin.type;
                textBoxSerialNbr.Text = maskin.serialNbr;
                textBoxProductNbr.Text = maskin.productNbr;
                textBoxPYear.Text = maskin.productionYear;
                listBoxModell.Text = maskin.modell;
                textBoxMotorNr.Text = maskin.motorNr;

                if (listBoxModell.Text == null)
                {                    
                    listBoxModell.Text = maskin.modell;                   
                }
                textBoxMInlagd.Text = maskin.inlagd.ToString();
                bool show = !maskin.latestService.Date.Equals(Variables.notChosen);
                labelService.Visible = show;
                textBoxLatestService.Visible = show;
                textBoxLatestService.Text = maskin.latestService.ToString();

                show = false;
                if (maskin.vinterforvaring)
                {
                    textBoxVinterforvarad.Text = "Ja";
                    show = true;
                }
                labelVinteforvarad.Visible = show;
                textBoxVinterforvarad.Visible = show;
            }
        }
        private void saveMachine()
        {
            if (maskin != null)
            {
                maskin.brand = listBoxBrand.Text;
                maskin.type = listBoxSort.Text;
                maskin.modell = listBoxModell.Text;
                maskin.serialNbr = textBoxSerialNbr.Text;
                maskin.productionYear = textBoxPYear.Text;
                maskin.productNbr = textBoxProductNbr.Text;
                maskin.motorNr = textBoxMotorNr.Text;
                if (!String.IsNullOrEmpty(textBoxPinkod.Text))
                { 
                    maskin.setPinCode(textBoxPinkod.Text);                                        
                }                  
                if (!String.IsNullOrEmpty(textBoxModell.Text))
                {
                    maskin.modell = textBoxModell.Text;
                    model = new Modell(maskin.modell, maskin.brand, maskin.type);
                    listBoxModell.SelectedIndex = -1;
                }
                else if (listBoxModell.SelectedIndex > -1)
                {
                    model = (Modell)listBoxModell.SelectedItem;
                }
                if (model != null)
                {
                    string text = textBoxProductNbr.Text.Trim();
                    if (!String.IsNullOrEmpty(text))
                        model.AddProductNbr(text);                    
                    text = textBoxMotorNr.Text.Trim();
                    if (!String.IsNullOrEmpty(text))
                        model.AddMotorNbr(text);
                    model.Update();
                }
            }
        }
        private void checkMachineChanged()
        {

            if (maskinChange && loaded)
            {
                DialogResult result1 = MessageBox.Show(maskin.ToString() + " ändrades, vill du spara?",
                "Spara",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    saveMachine();
                    MachineUpdated(maskin, new EventArgs());
                    MessageBox.Show("Sparades");
                }
            }
        }        
        private void buttonSave_Click(object sender, EventArgs e)
        {            
            saveMachine();
            if(this.MachineUpdated != null)
            {
                loaded = false;
                Maskin_Change(false);
                this.MachineUpdated(maskin, new EventArgs());
            }
        }       
        private void Maskin_Changed(object sender, EventArgs e)
        {
            Maskin_Change(true);
        }
        private void Maskin_Change(bool check)
        {
            maskinChange = check;
            radioButtonMaskinChange.Checked = check;
            buttonSaveNewMachine.Visible = check;
        }        
        private void listBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSort.SelectedIndex > -1 && listBoxBrand.SelectedIndex > -1)
            {
                models = Modell.FindModels(listBoxBrand.Text, listBoxSort.Text);
                listBoxModell.DataSource = models;                
            }
            else
            {
                models = null;
                listBoxModell.DataSource = models;
            }
            bool aggregat = (listBoxSort.Text.Equals("Åkgräsklippare") || listBoxSort.Text.Equals("Traktorklippare"));
            bool robot = listBoxSort.Text.Equals("Robotgräsklippare");
            bool motornr = !robot;
            textBoxAggregatNbr.Visible = aggregat;
            labelAggregatnr.Visible = aggregat;
            labelPinkod.Visible = robot;
            PinTable.Visible = robot;
            labelMotor.Visible = motornr;
            textBoxMotorNr.Visible = motornr;
            
            Maskin_Change(true);
        }                        
        public void showMachine(Maskin maskin)
        {
            checkMachineChanged();
            loaded = false;
            this.maskin = maskin;
            showMachine();
            loaded = true;
            Maskin_Change(false);
            if (String.IsNullOrWhiteSpace(maskin.maskinID))
                buttonRemove.Visible = false;
            else
            {
                buttonRemove.Visible = true;
            }
        }        
        private void listBoxModell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxModell.SelectedIndex > -1)
            {
                model = (Modell)listBoxModell.SelectedItem;
                foreach (String a in model.productNbrs)
                {
                    textBoxProductNbr.AutoCompleteCustomSource.Add(a);
                }
                foreach (String a in model.motorNbrs)
                {
                    textBoxMotorNr.AutoCompleteCustomSource.Add(a);
                }
                if(Model != null)
                    Model(model, new EventArgs());
            }
            Maskin_Change(true);
        }
        private void buttonPincode_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(maskin);
            form.Show();
        }
        public Modell modelC
        { get { return this.model; } }
        private void textBoxModell_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(textBoxModell.Text) && listBoxBrand.SelectedIndex > -1  && listBoxSort.SelectedIndex > -1)
            {
                model = new Modell(textBoxModell.Text, listBoxBrand.Text, listBoxSort.Text);
                string check = model.ToString();
                model.Update();
                models = Modell.FindModels(listBoxBrand.Text, listBoxSort.Text);                
                listBoxModell.DataSource = models;
                int index = listBoxModell.FindString(check);                
                if (index > -1)
                    listBoxModell.SetSelected(index, true);
                textBoxModell.Clear();                
            }

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (customer != null && maskin != null)
            {
                DialogResult result1 = MessageBox.Show("Vill du radera " + maskin.ToString() + ", samt alla uppdrag associerade med maskinen?",
                "Ta bort",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    maskin.Remove();
                    if (MachineRemoved != null)
                        MachineRemoved(this, new EventArgs());
                    this.showMachine(new Maskin());
                }
            }
        }
    }
}
