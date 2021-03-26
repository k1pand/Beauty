using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Beauty
{

    public partial class Yacheyka : UserControl
    {
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

        private void Check_Loaded(object sender, RoutedEventArgs e)
        {
            if (!(bool)Check.IsChecked)
            {
                activ.Visibility = Visibility.Visible;
                //   edit.Background = new SolidColorBrush(Color.FromArgb(207,255,255);
                fon.Background = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            }
        }
    }
}
