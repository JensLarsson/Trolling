using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Team> teams = new List<Team>();
        XML_Mediator xml;
        Image image = new Image();
        Window1 mainWin;

        public MainWindow(string folder, Window1 win)
        {
            mainWin = win;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            xml = new XML_Mediator(folder);
            teams = xml.loadTeams();
            teamList.ItemsSource = teams;
            leaderIcon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Image/p.png"));
            leaderIcon.Height = nameBlock.FontSize;
            leaderIcon.Visibility = Visibility.Hidden;

        }


        private void ButtonSaveMember_Click(object sender, RoutedEventArgs e)
        {
            if (teamList.SelectedItem != null)
            {
                Member mbr = new Member();
                mbr.Name = namn.Text;
                mbr.phoneNr = phone.Text;
                mbr.email = email.Text;
                mbr.comment = kommentar.Text;
                if ((teamList.SelectedItem as Team)._members.Count < 1)
                {
                    mbr.leader = true;
                }

                if (mbr.Name.Length > 0 && mbr.Name != null)
                {
                    (teamList.SelectedItem as Team)._members.Add(mbr);
                    membrList.Items.Refresh();
                    xml.SaveTeam(teamList.SelectedItem as Team);
                    ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Medlem måste ha namn ", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        void ClearBoxes()
        {
            namn.Clear();
            phone.Clear();
            email.Clear();
            kommentar.Clear();
        }

        private void TeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (teamList.SelectedItem != null)
            {
                membrList.ItemsSource = (teamList.SelectedItem as Team)._members;
                membrList.Items.Refresh();
                ClearBoxes();
                if ((teamList.SelectedItem as Team)._members.Count > 0)
                {
                    nameBlock.Text = (membrList.Items[0] as Member).Name;
                    telBlock.Text = (membrList.Items[0] as Member).phoneNr;
                    emailBlock.Text = (membrList.Items[0] as Member).email;
                    commentBlock.Text = (membrList.Items[0] as Member).comment;
                    if ((membrList.Items[0] as Member).leader)
                    {
                        leaderIcon.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        leaderIcon.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void MembrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (membrList.SelectedItem != null)
            {
                nameBlock.Text = (membrList.SelectedItem as Member).Name;
                telBlock.Text = (membrList.SelectedItem as Member).phoneNr;
                emailBlock.Text = (membrList.SelectedItem as Member).email;
                commentBlock.Text = (membrList.SelectedItem as Member).comment;
                if ((membrList.SelectedItem as Member).leader)
                {
                    leaderIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    leaderIcon.Visibility = Visibility.Hidden;
                }
            }
        }

        private void ButtonEditMember_Click(object sender, RoutedEventArgs e)
        {
            if (membrList.Items.Count > 0)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Är du säker? Detta kommer byta ut informationen på vald medlem med det skrivet i info fälten", "Edit Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    (membrList.SelectedItem as Member).Name = namn.Text;
                    (membrList.SelectedItem as Member).phoneNr = phone.Text;
                    (membrList.SelectedItem as Member).email = email.Text;
                    (membrList.SelectedItem as Member).comment = kommentar.Text;
                    membrList.Items.Refresh();
                    xml.SaveTeam(teamList.SelectedItem as Team);
                    nameBlock.Text = (membrList.SelectedItem as Member).Name;
                    emailBlock.Text = (membrList.SelectedItem as Member).email;
                    telBlock.Text = (membrList.SelectedItem as Member).phoneNr;
                    commentBlock.Text = (membrList.SelectedItem as Member).comment;
                    if ((membrList.SelectedItem as Member).leader)
                    {
                        leaderIcon.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        leaderIcon.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void ButtonDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (membrList.SelectedItem != null && membrList.Items.Count > 1)
            {
                (teamList.SelectedItem as Team)._members.RemoveAt(membrList.SelectedIndex);
                membrList.Items.Refresh();
                ClearBoxes();
                xml.SaveTeam(teamList.SelectedItem as Team);
            }
        }

        private void ButtonSaveTeam_Click(object sender, RoutedEventArgs e)
        {
            if (teamNamn.Text.Length > 0)
            {
                bool b = true;
                foreach (Team t in teamList.Items)
                {
                    if (t.Name == teamNamn.Text)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    Team team = new Team();
                    team.Name = teamNamn.Text;
                    team.marker = marker.Text;
                    teams.Add(team);
                    teamNamn.Clear();
                    marker.Clear();
                    teamList.Items.Refresh();
                }
            }
        }

        private void ButtonRemoveTeam_Click(object sender, RoutedEventArgs e)
        {
            if (teamList.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Är du säker? detta tar bort lagets fil från tävlingsmappen", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    xml.DeleteTeam(teamList.SelectedItem as Team);
                    teams.Remove(teamList.SelectedItem as Team);
                    teamList.Items.Refresh();
                    membrList.ItemsSource = new List<Member>();
                    membrList.Items.Refresh();
                    ClearBoxes();
                }
            }
        }

        private void ButtonMakeLeader_Click(object sender, RoutedEventArgs e)
        {
            foreach (Member member in (teamList.SelectedItem as Team)._members)
            {
                member.leader = false;
            }
            (membrList.SelectedItem as Member).leader = true;

            if (membrList.SelectedItem != null)
            {
                nameBlock.Text = (membrList.SelectedItem as Member).Name;
                telBlock.Text = (membrList.SelectedItem as Member).phoneNr;
                emailBlock.Text = (membrList.SelectedItem as Member).email;
                commentBlock.Text = (membrList.SelectedItem as Member).comment;
                if ((membrList.SelectedItem as Member).leader)
                {
                    leaderIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    leaderIcon.Visibility = Visibility.Hidden;
                }
            }
            xml.SaveTeam(teamList.SelectedItem as Team);
        }

        private void ButtonImportTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamImportWindow window = new TeamImportWindow((List<Team> t) =>
            {
                foreach (Team team in t)
                {
                    teams.Add(team);
                    teamList.Items.Refresh();
                    xml.SaveTeam(team, true);
                }
            });
            window.ShowDialog();
        }
    }
}
