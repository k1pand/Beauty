using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Beauty
{
    public partial class add_edit : Window
    {
        public add_edit()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string file_Name = "";

        private void photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog saveFile = new OpenFileDialog();
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                photo.Source = new BitmapImage(new Uri(saveFile.FileName));
                try
                {
                    File.Copy(saveFile.FileName, @".\Товары салона красоты\" + saveFile.SafeFileName, true);
                    file_Name = saveFile.SafeFileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Выбери другую фотку козел!");
                }
              
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (id.Content.ToString() != "id")
            {
                using (SqlConnection connection = new SqlConnection(Conn.String))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($@"UPDATE [dbo].[Product]
                                                        SET Title = '{name.Text}'
                                                        ,ManufacturerID = (SELECT ID from [dbo].[Manufacturer] WHERE Name = '{manufactor.Text}')
                                                        ,Cost = '{price.Text}'
                                                        ,Description='{description.Text}'
                                                        {(file_Name != "" ? @",[MainImagePath] = 'Товары салона красоты\" + file_Name + "'" : "")}
                                                        WHERE ID = {id.Content}", connection);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Сохранено");
                        MainWindow.Load_data("");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("Заполните все поля!");
                    }
                }
            }

            else
            {
                using (SqlConnection connection = new SqlConnection(Conn.String))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($@"INSERT INTO [dbo].[Product]
                                                           ([Title]
                                                           ,[Cost]
                                                           ,[Description]
                                                           ,[MainImagePath]
                                                           ,[IsActive]
                                                           ,[ManufacturerID]) 
                                                           VALUES 
                                                           ('{name.Text}'
                                                           ,'{price.Text}'
                                                           ,'{description.Text}'
                                                           {(file_Name != "" ? @",'Товары салона красоты\" + file_Name + "'" : ",'Товары салона красоты\\ava.png'")}
                                                           ,{act.SelectedIndex}
                                                           ,{(manufactor.SelectedIndex + 1).ToString()})", connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Добавлен");
                        MainWindow.Load_data("");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("Заполните все поля!");
                    }
                }
            }
            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Conn.String))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT [Name] FROM [BeautyDB].[dbo].[Manufacturer]", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        manufactor.Items.Add(reader[0].ToString());
                    }
                }
            }
        }
    }
}

