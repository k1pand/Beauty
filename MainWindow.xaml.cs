using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Beauty
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        internal void Load_data(string s)
        {
            list.Children.Clear();
            using (SqlConnection connection = new SqlConnection(Conn.String))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT Product.Title, 
                                                              Product.ID, 
                                                              Product.Cost, 
                                                              Product.Description, 
                                                              Product.MainImagePath, 
                                                              Product.IsActive, 
                                                              Manufacturer.Name
                                                    FROM Product INNER JOIN Manufacturer 
                                                    ON Product.ManufacturerID = Manufacturer.ID 
                                                    WHERE Product.Title like '{search.Text}%'" + s, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Yacheyka products = new Yacheyka();
                        products.name.Text = reader[0].ToString();
                        products.id.Content = reader[1];
                        products.price.Content = String.Format("{0:D}", Convert.ToInt32(reader[2]));
                        products.description.Text = reader[3].ToString();
                        products.photo.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[4].ToString().Replace(" Товары салона красоты", "Товары салона красоты")));
                        products.Check.IsChecked = Convert.ToBoolean(reader[5].ToString());
                        products.MainWindow = this;
                        products.manufactor.Content = reader[6];
                        list.Children.Add(products);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_data("");
        }

        private void list_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_edit open = new add_edit();
            open.MainWindow = this;
            open.Show();
            this.Hide();
            
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load_data("");
        }
    }
}
