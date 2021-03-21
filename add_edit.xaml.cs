using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Beauty
{
    /// <summary>
    /// Логика взаимодействия для add_edit.xaml
    /// </summary>
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
    }
}
