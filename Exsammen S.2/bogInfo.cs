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
        MainWindow main = new MainWindow();
        private string connectionString = "Data Source=CV-BB-5322;Initial Catalog=Bog_info; Eksammen S.2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public object Brugeren { get; private set; }

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
        public void AddNewBook(object Person)
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

        public void Bruger(Books book)
        {
            int i = 0;

            if (i != book.Antal_Eksemplarer)
            {
                AddNewBook(Brugeren);
            }
            else if (i == book.Antal_Eksemplarer)
            {

            }
            else
            {

            }

        }







        public string GetAndRemove(Books book, string bookIn, string txt, string Brugeren)
        {

            if (book.Person == Brugeren && book.Titel == bookIn && book.Antal_Eksemplarer == 0)
            {
                string removebookquery = $"UPDATE [book_Table] SET Bruger = '', Copies = '1' WHERE Title = '{bookIn}'";

                Execute(removebookquery);
                return "";
            }
            else if (book.Titel == bookIn && book.Antal_Eksemplarer == 1)
            {
                try
                {
                    var sql = $@"UPDATE [Boog_info] SET Person = '{Brugeren}', Antal_Eksemplarer = '0' WHERE Titel = '{bookIn}'";



                    string insert = $"INSERT INTO [Boog_info] (Person)";

                    // dataGrid1.ItemsSource = null;
                    string select = $"SELECT (Person) FORM [Boog_info]";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(sql, connection))

                        {


                            command.Parameters.AddWithValue("@Person", bookIn);


                            connection.Open();
                            command.ExecuteNonQuery();

                            //  dataGrid1.Items.Clear();




                            //  dataGrid1.DataContext = Bind;

                        }
                    }

                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";

        }



    }
}
