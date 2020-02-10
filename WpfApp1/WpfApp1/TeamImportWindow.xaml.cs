using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TeamImportWindow.xaml
    /// </summary>
    public partial class TeamImportWindow : Window
    {
        List<Team> teams;
        Action<List<Team>> action;
        public TeamImportWindow(Action<List<Team>> ac)
        {
            action = ac;
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
        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                if (teams == null)
                {
                    XML_Mediator xml = new XML_Mediator(lista.SelectedItem.ToString());
                    teams = xml.loadTeams();
                    ArrayList itemsList = new ArrayList();
                    for (int i = 0; i < teams.Count; i++)
                    {
                        itemsList.Add(teams[i].Name);
                    }
                    lista.ItemsSource = itemsList;
                    lista.Items.Refresh();
                    lista.SelectionMode = SelectionMode.Multiple;
                    importButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            List<Team> t = new List<Team>();
            foreach (var item in lista.SelectedItems)
            {
                t.Add(teams[lista.Items.IndexOf(item)]);
            }
            action(t);
            this.Close();
        }
    }
}
