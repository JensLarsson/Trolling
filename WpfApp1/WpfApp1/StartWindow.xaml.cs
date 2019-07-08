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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            GetFolders();
        }

        void GetFolders()
        {
            string s = Directory.GetCurrentDirectory() + "/Teams";
            var directories = Directory.GetDirectories(s);
            for (int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Remove(0, s.Length + 1);
            }
            lista.ItemsSource = directories;
            lista.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (folderName.Text.Length > 0)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Teams/" + folderName.Text);
                GetFolders();
            }
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                Window1 win = new Window1(lista.SelectedItem.ToString());
                win.Show();
                this.Close();
            }
        }
    }
}