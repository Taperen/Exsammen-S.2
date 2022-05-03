using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Exsammen_S_2
{
    internal class Books
    {
        public Books()
        {
        }

        public Books(int id, string forfatter, string titel, string udgiver, int udgivelsesår, int antal_Eksemplarer, int iSBN, string user)
        {
            Id = id;
            Forfatter = forfatter;
            Titel = titel;
            Udgiver = udgiver;
            Udgivelsesår = udgivelsesår;
            Antal_Eksemplarer = antal_Eksemplarer;
            ISBN = iSBN;
            User = user;
        }

        public int Id { get; set; }
        public string Forfatter { get; set; }
        public string Titel { get; set; }
        public string Udgiver { get; set; }

        public int Udgivelsesår { get; set; }
        public int Antal_Eksemplarer { get; set; }
        public int ISBN { get; set; }
        public string User { get; set; }
        internal List<Books> Book1 { get; set; } = new List<Books>(0);

        public void Bruger(Books book)
        {
            int i = 0;

            if (i != book.Antal_Eksemplarer)
            {
                
            }
            else if (i == book.Antal_Eksemplarer)
            {

            }
            else
            {

            }



        }



    }
}
