using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Exsammen_S_2
{
    internal class Books
    {
        List<Books> Book = new List<Books>(0);

        public Books()
        {
        }

        public Books(string forfatter, string titel, string udgiver, int udgivelsesår, int antal_Eksemplarer, int iSBN)
        {
            Forfatter = forfatter;
            Titel = titel;
            Udgiver = udgiver;
            Udgivelsesår = udgivelsesår;
            Antal_Eksemplarer = antal_Eksemplarer;
            ISBN = iSBN;
        }

        public string Forfatter { get; set; }
        public string Titel { get; set; }
        public string Udgiver { get; set; }
        public int Udgivelsesår { get; set; }
        public int Antal_Eksemplarer { get; set; }
        public int ISBN { get; set; }



        public void Bruger(Books book)
        {
            int i = 0;

            if (i != book.Antal_Eksemplarer)
            {

            }

        }
    }
}
