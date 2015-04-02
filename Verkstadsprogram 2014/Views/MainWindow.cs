using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Verkstadsprogram_2014.Controllers;
using Verkstadsprogram_2014.Models;
using Verkstadsprogram_2014.Views;



namespace Verkstadsprogram_2014
{
    public partial class MainWindow : Form
    {

        BindingList<Customer> kunder = new BindingList<Customer>();
        BindingList<Customer> searchCustomer = new BindingList<Customer>();                
        public string mode;             
        Display waitingParts;
        DateTime idag;
        Customer customer;

        public MainWindow()
        {
            InitializeComponent();            
            //mode = Databas.loadMode();
            idag = DateTime.Now;
            this.searchCustomer1.CustomerFound += searchCustomer1_CustomerFound;
            Variables.mode = Mode.Load();
        }
        
        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerView form = new CustomerView();                        
            form.Show();
        }        
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
                       
        }                
        private void MainWindow_Activated(object sender, EventArgs e)
        {           
            listBoxOrder.DataSource = Reservdel.getAllOrder();
            kunder = Customer.getCustomers(false);
            listBoxWaitingParts.DataSource = Display.PartsOrder();            
        }             
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.Show();
        }      
        private void buttonAllCustomers_Click(object sender, EventArgs e)
        {
            AllCustomers form = new AllCustomers();
            form.Show();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Listor.Load();            
            listBoxOrder.DataSource = Reservdel.getAllOrder();
            kunder = Customer.getCustomers(false);
            listBoxWaitingParts.DataSource = Display.PartsOrder();
        }
        //private string veckodag(DateTime dag)
        //{
        //    var culture = new System.Globalization.CultureInfo("sv-SE");
        //    return FirstLetterToUpper(culture.DateTimeFormat.GetDayName(dag.DayOfWeek));
        //}
        //public string FirstLetterToUpper(string str)
        //{
        //    if (str == null)
        //        return null;

        //    if (str.Length > 1)
        //        return char.ToUpper(str[0]) + str.Substring(1);

        //    return str.ToUpper();
        //}

        
        private void buttonVerkstad_Click(object sender, EventArgs e)
        {
            Verkstad form = new Verkstad();
            form.Show();
        }
        private void listBoxWaitingParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter  && listBoxWaitingParts.SelectedIndex > -1)
            {
                waitingParts = (Display)listBoxWaitingParts.SelectedItem;
                listBoxParts.DataSource = waitingParts.uppdrag.orderdelar;                
            }
        }

        private void buttonVinterForvaring_Click(object sender, EventArgs e)
        {
            VinterforvaringForm form = new VinterforvaringForm();
            form.Show();
        }        
        private void searchCustomer1_CustomerFound(object sender,EventArgs e)
        {
            customer = searchCustomer1.customer;
            if(radioButtonDetail.Checked)
            {
                DetailedView form = new DetailedView(customer);
                form.Show();
            }
            else if(radioButtonMachine.Checked)
            {
                CustomerView form = new CustomerView(customer,true);
                form.Show();
            }
        }
        
    }

    public static class Variables
    {
        public static Mode mode = new Mode("production", 1, "Produktion");         
        public static List<Arbete> arbeteLista = new List<Arbete>();        
        public static List<Listor> brandLista = new List<Listor>();
        public static List<Listor> typeList = new List<Listor>();
        public static List<Listor> reparatorLista = new List<Listor>();
        public static DateTime notChosen = new DateTime(2011, 11, 11);


    }

    
}
