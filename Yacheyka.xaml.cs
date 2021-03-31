using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Beauty
{

    public partial class Yacheyka : UserControl
    {

        public static string[] linkPhoto = new string[] { };

        public Yacheyka()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow;

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            add_edit open = new add_edit();
            open.id.Content = id.Content;
            open.name.Text = name.Text;
            open.price.Text = (string)price.Content;
            open.photo.Source = photo.Source;
            open.manufactor.Text = (string)manufactor.Content;
            open.Check.IsChecked = Check.IsChecked;
            open.description.Text = description.Text;
            open.MainWindow = MainWindow;
            MainWindow.Hide();
            open.ShowDialog();
        }
    }
}

