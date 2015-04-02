using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;


namespace Verkstadsprogram_2014
{
    public class Uppdrag
    {
        #region Attribut
        [System.ComponentModel.DisplayName("UppdragsID")]
        public string uppdragID { get; set; }
        [System.ComponentModel.DisplayName("MaskinID")]
        public string maskinID { get; set; }        
        [System.ComponentModel.DisplayName("Reparationsspec.")]
        public string reparationSpec { get; set; }
        [System.ComponentModel.DisplayName("Besked")]
        public string besked { get; set; }       
        [System.ComponentModel.DisplayName("Startat")]
        public bool startat { get; set; }
        [System.ComponentModel.DisplayName("Övrigt")]
        public string ovrigt { get; set; }
        [System.ComponentModel.DisplayName("Klar")]
        public bool klar { get; set; }
        [System.ComponentModel.DisplayName("Fakturerad")]
        public bool faktura { get; set; }
        [System.ComponentModel.DisplayName("Fakturanr.")]
        public string fakturanummer { get; set; }
        [System.ComponentModel.DisplayName("Reparatör")]
        public string reparator { get; set; }
        [System.ComponentModel.DisplayName("Kommentar")]
        public string kommentar { get; set; }
        [System.ComponentModel.DisplayName("Arbete påbörjat")]
        public DateTime arbeteStart { get; set; }
        [System.ComponentModel.DisplayName("Arbete klart")]
        public DateTime arbeteKlart { get; set; }
        [System.ComponentModel.DisplayName("Inlämnad")]
        public DateTime inlagd { get; set; }
        [System.ComponentModel.DisplayName("Färdig")]
        public DateTime deadline { get; set; }        
        [System.ComponentModel.DisplayName("Hylla")]
        public string hylla { get; set; }
        [System.ComponentModel.DisplayName("Plan")]
        public int plan { get; set; }
        public List<Del> reservdelar { get; set; }
        public List<Del> orderdelar { get; set; }
        public TimeSpan arbetstid { get; set; }
        public List<String> inlamnat { get; set; }        
        public bool utlamnad { get; set; }
        public DateTime utlamnadDate { get; set; }
        public List<Arbete> arbete { get; set; }        
        #endregion
        #region Konstruktorer
        public Uppdrag(Maskin maskin,List<Arbete> arbete,string reparationSpec, string besked,DateTime deadline,string ovrigt, string hylla, string plan,List<String> inlamnat)            
        {
            this.uppdragID = maskin.maskinID + "-" + maskin.uppdrag.Count.ToString().PadLeft(2, '0');
            this.maskinID = maskin.maskinID;            
            this.inlagd = DateTime.Now;
            this.arbete = arbete;
            this.reparationSpec = reparationSpec;
            this.besked = besked;
            this.deadline = deadline;
            this.ovrigt = ovrigt;
            this.startat = false;
            this.arbeteStart = Variables.notChosen;
            this.reservdelar = new List<Del>();
            this.orderdelar = new List<Del>();
            this.klar = false;
            this.arbeteKlart = Variables.notChosen;
            this.reparator = String.Empty;
            this.arbetstid = new TimeSpan(0, 0, 0);
            this.kommentar = String.Empty;
            this.faktura = false;
            this.fakturanummer = String.Empty;
            this.hylla = String.Empty;
            this.plan = 0;
            this.inlamnat = inlamnat;
            this.utlamnad = false;
            this.utlamnadDate = Variables.notChosen;
        }
        
        public Uppdrag(string uppdragID, string maskinID,DateTime inlagd, string arbete, string arbeteDone, string reparationSpec, string besked,DateTime deadline,
                       string ovrigt, bool startat, DateTime arbeteStart,string reservdelar, string order, bool klar,DateTime arbeteKlart, string reparator, int arbetstid,
                       string kommentar, bool faktura, string fakturaNr,string hylla, int plan, string inlamnat, bool utlamnad, DateTime utlamnadDate)
        {
            this.uppdragID = uppdragID;
            this.maskinID = maskinID;
            this.inlagd = inlagd;            
            this.arbete = Arbete.Get(arbete, arbeteDone);            
            this.reparationSpec = reparationSpec;            
            this.besked = besked;
            this.deadline = deadline;
            this.ovrigt = ovrigt;
            this.startat = startat;
            this.arbeteStart = arbeteStart;
            this.reservdelar = Del.reservdelar(reservdelar); ;            
            this.orderdelar = Del.reservdelar(order);            
            this.klar = klar;
            this.arbeteKlart = arbeteKlart;
            this.reparator = reparator;
            this.arbetstid = new TimeSpan(0, arbetstid, 0);
            this.kommentar = kommentar;
            this.faktura = faktura;
            this.fakturanummer = fakturaNr;
            this.hylla = hylla;
            this.plan = plan;
            this.inlamnat = inlamnat.Split(';').ToList<String>();
            this.utlamnad = utlamnad;
            this.utlamnadDate = utlamnadDate;
        }
        public Uppdrag()
        {
            this.uppdragID = String.Empty;
            this.maskinID = String.Empty;
            this.inlagd = Variables.notChosen;
            this.arbete = new List<Arbete>();            
            this.reparationSpec = String.Empty;
            this.besked = String.Empty; 
            this.deadline = Variables.notChosen;
            this.ovrigt = String.Empty; 
            this.startat = false;
            this.arbeteStart = Variables.notChosen;
            this.reservdelar = new List<Del>();
            this.orderdelar = new List<Del>();
            this.klar = false;
            this.arbeteKlart = Variables.notChosen;
            this.reparator = String.Empty;
            this.arbetstid = new TimeSpan(0, 0, 0);
            this.kommentar = String.Empty;
            this.faktura = false;
            this.fakturanummer = String.Empty;
            this.hylla = String.Empty; ;
            this.plan = 0;
            this.inlamnat = new List<String>();
            this.utlamnad = false;
            this.utlamnadDate = Variables.notChosen;
        }
        #endregion
        #region Metoder
        public void Add()
        {            
            Databas.addUppdrag(this);
        }
        public void Update()
        {            
            Databas.updateUppdrag(this);
        }
        public void Remove()
        {
            Databas.removeUppdrag(this);
        }
        public string ArbeteSpara(bool done)
        {
            string result = String.Empty;
            foreach(Arbete a in arbete)
            {
                if(a.done == done)
                {
                    result += a.name + "€";                    
                }
            }
            return result;
        }        
        public string ReservdelarSpara
        {
            get
            {
                return Del.ReservdelarSpara(reservdelar);
            }
        }
        public string OrderdelarSpara
        {
            get
            {
                return Del.ReservdelarSpara(orderdelar);
            }
        }
        public string Inlamnad
        {
            get
            {
                return this.inlagd.ToString("dd'/'MM'/'yyyy");
            }
        }
        public string Deadline
        {
            get
            {
                return this.deadline.ToString("dd'/'MM'/'yyyy");
            }
        }
        public int Arbetstid
        {
            get { return (int)arbetstid.TotalMinutes; }
        }
        public string Inlamnat()
        {
            string result = String.Empty;
            foreach(String a in inlamnat)
            {
                result += a + ";";
            }
            return result;
        }
        public string printWork()
        {
            string uppdragets = String.Empty;
            if (arbete.Contains(new Arbete("Vinterförvaring",false)) || arbete.Contains(new Arbete("Vinteförvaring",true)))
                uppdragets = "Vinterförvaring";
            else if (arbete.Contains(new Arbete("Service", false)) || arbete.Contains(new Arbete("Service", true)))            
                uppdragets = "Service";            
            else if (arbete.Contains(new Arbete("Reparation", false)) || arbete.Contains(new Arbete("Reparation", true)))            
                uppdragets = "Reparation";            
            else if (arbete.Contains(new Arbete("Felsökning",false)) || arbete.Contains(new Arbete("Felsökning",true)))            
                uppdragets = "Felsökning";            
            else
            {
                uppdragets = "Oklart";
            }
            return uppdragets;
        }
        public string Display
        {
            get
            {
                if (string.IsNullOrEmpty(uppdragID))
                    return "Nytt uppdrag";
                string uppdrag = uppdragID.Substring(uppdragID.Length - 2);

                string datum = this.inlagd.ToString("dd'/'MM'/'yy");
                return this.printWork() + " (" + datum + ")";
            }
        }
        #endregion
        public bool Equals(Uppdrag obj)
        {
            return (obj != null && obj.uppdragID.Equals(this.uppdragID) && obj.maskinID.Equals(this.maskinID) && obj.printWork().Equals(this.printWork()));
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(uppdragID))
                return "Nytt uppdrag";
            string uppdrag = uppdragID.Substring(uppdragID.Length - 2);
            
            string datum = this.inlagd.ToString("MM/yy");
            return uppdrag + " - " + this.printWork() + " (" + datum+")";
        }        
        public static Uppdrag Find(string uppdragID)
        {
            return Databas.getUppdrag(uppdragID);
        }

        public static void export()
        {
            List<Uppdrag> list = Databas.getAllUppdrag();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                FolderBrowserDialog f = new FolderBrowserDialog();
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = f.SelectedPath + "\\works.xml";
                    if (!File.Exists(path))
                    {
                        XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8);
                        xml.WriteStartElement("works");
                        xml.WriteEndElement();
                        xml.Close();
                    }
                    xDoc.Load(path);
                    XmlNode xNode = xDoc.SelectSingleNode("works");
                    xNode.RemoveAll();

                    foreach (Uppdrag p in list)
                    {
                        XmlNode xMain, xSub;
                        xMain = xDoc.CreateElement("work");

                        (xSub = xDoc.CreateElement("id")).InnerText = p.uppdragID;
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("machine_id")).InnerText = p.maskinID;
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("created")).InnerText = p.inlagd.ToShortDateString();
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("work_activity")).InnerText = p.arbete.ToString();
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("repair_comment")).InnerText = p.reparationSpec;
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("notice")).InnerText = p.besked;
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("finish_date")).InnerText = p.deadline.ToShortDateString();
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("work_started")).InnerText = p.startat.ToString();
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("work_start_date")).InnerText = p.arbeteStart.ToShortDateString();
                        xMain.AppendChild(xSub);

                        (xSub = xDoc.CreateElement("spare_parts")).InnerText = p.reservdelar.ToString();
                        xMain.AppendChild(xSub);

                        xDoc.DocumentElement.AppendChild(xMain);
                    }
                    xDoc.Save(path);
                }
            }
            catch (SystemException ex) { System.Windows.Forms.MessageBox.Show(ex.ToString(), "Fel - sparning", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
    public struct Arbete
    {
        public string name;
        public bool done;

        public Arbete(string name,bool done)
        {
            this.name = name;
            this.done = done;
        }
        public Arbete(string name)
        {
            this.name = name;
            this.done = false;
        }
        public static List<Arbete> Get(string arbete,string done)
        {
            List<Arbete> arbeten = new List<Arbete>();
            if (!String.IsNullOrEmpty(arbete))
            {
                string[] splitt = arbete.Split('€');
                foreach (String a in splitt)
                {
                    if (!String.IsNullOrWhiteSpace(a))
                        arbeten.Add(new Arbete(a, false));
                }
            }
            if(!String.IsNullOrEmpty(done))
            {
                string []splitt = done.Split('€');
                foreach (String a in splitt)
                {
                    if (!String.IsNullOrWhiteSpace(a))
                        arbeten.Add(new Arbete(a, true));
                }
            }
            
            return arbeten;
        }
        public void Save()
        {
            Listor a = new Listor("arbete", this.name);            
        }
        public override string ToString()
        {
            return (done) ? name + " - färdig" : name;
        }
        public bool Equals(Arbete arbetet)
        {
            return (arbetet.name.Equals(this.name));
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Arbete))
                return false;
            Arbete arbetet = (Arbete)obj;
            return this.Equals(arbetet);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
