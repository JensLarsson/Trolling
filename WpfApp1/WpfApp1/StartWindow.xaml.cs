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
                folderName.Text = "";
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

        private void CloneButton_Click(object sender, RoutedEventArgs e)
        {
            if (lista.SelectedItem != null && folderName.Text != "")
            {
                string source = Directory.GetCurrentDirectory() + "/Teams/" + lista.SelectedItem.ToString() + "/";
                string target = Directory.GetCurrentDirectory() + "/Teams/" + folderName.Text + "/";
                Copy(source, target);
                folderName.Text = "";
                GetFolders();
            }
        }

        public void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(System.IO.Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}