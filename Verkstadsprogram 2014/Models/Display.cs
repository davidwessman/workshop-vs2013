using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkstadsprogram_2014
{    
    public class Display
    {
        public Customer kund { get; set; }
        public Maskin maskin { get; set; }
        public Uppdrag uppdrag { get; set; }
        [System.ComponentModel.DisplayName("Datum")]
        public string datum { get; set; }
        [System.ComponentModel.DisplayName("Namn")]
        public string namn { get; set; }
        [System.ComponentModel.DisplayName("Märke")]
        public string brand { get; set; }
        [System.ComponentModel.DisplayName("Sort")]
        public string sort { get; set; }
        [System.ComponentModel.DisplayName("arbete")]
        public string work { get; set; }       
        
        public Display(Customer kund, Maskin maskin, Uppdrag uppdrag)
        {
            this.kund = kund;
            this.maskin = maskin;
            this.uppdrag = uppdrag;            
            this.datum = uppdrag.inlagd.ToString("dd'/'MM");
            this.namn = kund.firstNamn + " " + kund.lastNamn;
            this.brand = maskin.brand;
            this.sort = maskin.type;
            this.work = uppdrag.printWork();    
        }
        public static List<Display> PartsOrder()
        {
            List<Display> orderList = new List<Display>();
            List<Uppdrag> uppdrag = Databas.getUppdragSpareparts();
            foreach(Uppdrag a in uppdrag)
            {
                Maskin maskin = Databas.getMachine(a.maskinID);
                Customer kund = Databas.searchCustomerID(maskin.customerID);
                if(a != null && maskin != null && kund != null)
                {
                    orderList.Add(new Display(kund, maskin, a));
                }
            }
            return orderList;
        }
        public override string ToString()
        {
            
            string print = kund.firstNamn + " " + kund.lastNamn + " - " + maskin.type + " " + maskin.brand + " - " + uppdrag.printWork();
            return print;
        }
    }
}
