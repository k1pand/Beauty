using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            //Yacheyka yacheyka = new Yacheyka();
            //list.Children.Add(yacheyka);
            using (SqlConnection connection = new SqlConnection(Conn.String))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT [Наименование товара]
                                                    ,[Главное изображение]
                                                    ,[Производитель]
                                                    ,[Активность]
                                                    ,[Цена]
                                                    ,[Описание]
                                                    FROM [dbo].[Product2] 
                                                    WHERE [Наименование товара] like '{search.Text}%'" + s, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Yacheyka products = new Yacheyka();
                        //clients.id.Content = reader[0];
                        products.name.Text = reader[0].ToString();
                        products.photo.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[1]));
                        //clients.manufactor.Content = reader[3];
                        //clients.activity.Content = reader[4];
                        products.price.Content = reader[4] + " рублей";

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
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load_data("");
        }
    }
}
