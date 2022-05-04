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
        private string connectionString = "Data Source=CV-BB-5322;Initial Catalog=Bog_info; Eksammen S.2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public DataSet Execute(string query)

        {
            try
            {
                DataSet resultSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(ConnectionString))))
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
            string allbookQuery = "SELECT * FROM Boog_info";

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
                string Person = (string)Bookrow["Person"];
                Books book = new Books
                {
                    Forfatter = Forfatter,
                    Titel = Titel,
                    Udgiver = Udgiver,
                    Udgivelsesår = Udgivelsesår,
                    Antal_Eksemplarer = Antal_Eksemplarer,
                    ISBN = ISBN,
                    Person = Person
                };
                AllBooks.Add(book);
            }
            return AllBooks;
        }
        public void AddNewBook(object Brugeren)
        {
            int i = 0;
            string addNewBookQuery =
                    $"INSERT INTO Boog_info (Antal_Eksemplarer)(Person)(Date) VALUES('0','{Brugeren}','{i}')";
            Execute(addNewBookQuery);
        }

        public void RemoveBook()
        {
            string RemoveABookQuery =
                    $"INSERT INTO Boog_info (Antal_Eksemplarer)(Person)(Date) VALUES('1',' ',' ')";
            Execute(RemoveABookQuery);
        }


    }
}
