using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Exsammen_S_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private protected Gamecontroller GC = new Gamecontroller();


        public MainWindow()
        {
            InitializeComponent();






        }





        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {


        }

        public string Bruger_info()
        {
            string Brugeren = $"{Bruger_input}";
            return Brugeren;
        }

        



    }
}
