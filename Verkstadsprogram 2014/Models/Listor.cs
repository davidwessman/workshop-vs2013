using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkstadsprogram_2014
{
    public class Listor
    {
        public int ID { get; set; }
        public string category { get; set; } 
        public string string1 { get; set; }                       
        public bool bool1 { get; set; }
        public Listor(int ID, string category, string string1)
        {
            this.ID = ID;
            this.category = category;
            this.string1 = string1;
            this.bool1 = false;
        }
        public Listor(string category, string string1)
        {
            this.category = category;
            this.string1 = string1;
            this.bool1 = false;            
            this.ID = Add();
        }
             
        public int Add()
        {
            int ID = 99999;
            if(!checkExist())
                ID = Databas.addList(this);
            return ID;
        }
        public void Update()
        {
            if (checkExist())
                Databas.updateList(this);
        }
        public void Remove()
        {
            Databas.removeList(this);
        }
         
        public static void Save()
        {
            List<Listor> arbeten = new List<Listor>();
            foreach(Arbete a in Variables.arbeteLista)
            {
                arbeten.Add(new Listor("arbete", a.name));
            }            
            Databas.saveLists(Variables.brandLista);
            Databas.saveLists(Variables.typeList);
            Databas.saveLists(Variables.reparatorLista);            
        }        
        public static void Load()
        {
            Variables.arbeteLista = new List<Arbete>();
            foreach(Listor a in Read("arbete"))
            {
                Variables.arbeteLista.Add(new Arbete(a.string1));
            }
            Variables.brandLista = Read("brand");
            Variables.reparatorLista = Read("reparator");
            Variables.typeList = Read("type");
        }
        public static List<Listor> Read(string category) //brand, type, arbete, reparator
        {
            return Databas.getLists(category);
        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(string1))
                return string1;
            
            else
                return category;
        }
        public bool checkExist()
        {
            Listor check = Databas.searchList(this.category, this.string1);
            return this.Equals(check);
        }
        public bool Equals(Listor compare)
        {
            return (compare != null && this.category == compare.category && this.string1 == compare.string1);
        }
        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;
            Listor lista = obj as Listor;
            return this.Equals(lista);
        }

    }
}
