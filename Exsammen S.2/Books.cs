using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Exsammen_S_2
{
    internal class Books
    {
        BogInfo info = new BogInfo();



        public Books()
        {
        }

        public Books(string forfatter, string titel, string udgiver, int udgivelsesår, int antal_Eksemplarer, int iSBN, string person)
        {
            Forfatter = forfatter;
            Titel = titel;
            Udgiver = udgiver;
            Udgivelsesår = udgivelsesår;
            Antal_Eksemplarer = antal_Eksemplarer;
            ISBN = iSBN;
            Person = person;
        }

        public string Forfatter { get; set; }
        public string Titel { get; set; }
        public string Udgiver { get; set; }

        public int Udgivelsesår { get; set; }
        public int Antal_Eksemplarer { get; set; }
        public int ISBN { get; set; }
        public string Person { get; set; }
        public object Brugeren { get; private set; }
        internal List<Books> Book { get; set; } = new List<Books>(0);

        
    }
}
