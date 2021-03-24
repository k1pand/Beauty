using System;
using System.Windows;
using System.Windows.Controls;

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
            open.act.SelectedIndex = Convert.ToInt32(act.Content);
            open.description.Text = description.Text;
            open.MainWindow = MainWindow;
            open.Show();
        }
    }
}
