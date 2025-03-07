using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RealEstate;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection myConnection;
        List<Seller> sellers;
        public MainWindow()
        {
            InitializeComponent();
            sellers = new List<Seller>();
            
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=ads";
            myConnection = new MySqlConnection(myConnectionString);
            try
            {
                
                myConnection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = @"SELECT id, name, phone FROM sellers";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        var id = myReader.GetInt32(0);
                        var name = myReader.GetString(1);
                        var phone = myReader.GetString(2);
                        sellers.Add(new Seller(id, name, phone));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            lstvwSellers.ItemsSource = sellers;
            lstvwSellers.SelectedIndex = 0;
            stckpnlSeller.DataContext = sellers.First();
        }

        private int GetAdCount(int sellerId)
        {
            try
            {
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = @"SELECT COUNT(*) FROM `realestates` WHERE sellerId = @sellerId;";
                myCommand.Parameters.AddWithValue("@sellerId", sellerId);


                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        return myReader.GetInt32(0);
                    }
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private void lstvwSellers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stckpnlSeller.DataContext = sellers[lstvwSellers.SelectedIndex];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblAdCount.Content = GetAdCount(((Seller)lstvwSellers.SelectedItem).Id).ToString();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            myConnection.Close();
            base.OnClosing(e);
        }
    }
}