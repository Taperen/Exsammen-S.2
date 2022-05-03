using System;
using System.Collections.Generic;
using System.Data;
using Exsammen_S_2;
using System.Text;
using System.Data.SqlClient;

namespace Exsammen_S_2
{
    internal class BogInfo
    {
        private string connectionString = "Data Source=CV-BB-5322;Initial Catalog=Bog_info; Eksammen_S_2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public DataSet Execute(string query)

        {
            try
            {
                DataSet resultSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
                {

                    // Open conn, execute query, close conn, wrap result in DataSet: 
                    adapter.Fill(resultSet);
                }

                return resultSet;
            }

            catch (InvalidOperationException)
            {
                throw;
            }
        }


        public List<Books> GetBooks()
        {
            List<Books> AllBooks = new List<Books>(0);
            string allbookQuery = "SELECT * FROM Bog_info";

            // Perform query and save result in variable:
            DataSet resultSet = Execute(allbookQuery);

            // Get the first table of the data set, and save in variable:
            DataTable BookTable = resultSet.Tables[0];

            // Iterate through the rows of the table, and extract the data,

            // and create a new person object each time, and add that to the list of persons.
            foreach (DataRow Bookrow in BookTable.Rows)
            {
                string Forfatter = (string)Bookrow["Forfatter"];
                string Titel = (string)Bookrow["Titel"];
                string Udgiver = (string)Bookrow["Udgiver"];
                int Udgivelsesår = (int)Bookrow["Udgivelsesår"];
                int Antal_Eksemplarer = (int)Bookrow["Antal_Eksemplarer"];
                int ISBN = (int)Bookrow["ISBN"];
                Books book = new Books();
                book.Forfatter = Forfatter;
                book.Titel = Titel;
                book.Udgiver = Udgiver;
                book.Udgivelsesår = Udgivelsesår;
                book.Antal_Eksemplarer = Antal_Eksemplarer;
                book.ISBN = ISBN;
                AllBooks.Add(book);
            }
            return AllBooks;
        }
        public void AddNewBook(BogInfo book)
        {
            string addNewBookQuery =
                    $"INSERT INTO Bog_info (name) VALUES(' ',' ',' ')";
            Execute(addNewBookQuery);
        }

        public void RemoveBook()
        {
            string RemoveABookQuery =
                    $"INSERT INTO Bog_info (name) VALUES(' ',' ',' ')";
            Execute(RemoveABookQuery);
        }


    }
}
