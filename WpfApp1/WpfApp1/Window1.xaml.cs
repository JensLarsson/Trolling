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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Team> teams = new List<Team>();
        List<FishType> fishNames = new List<FishType>();
        XML_Mediator xml;
        string folder;
        public Window1(string s)
        {
            folder = s;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            xml = new XML_Mediator(s);
            fishNames = xml.loadFishTypes();
            teams = xml.loadTeams();
            Dag1.ItemsSource = teams;
            Dag2.ItemsSource = teams;
            Dag3.ItemsSource = teams;
            this.Title += s;
            InitializeComponent();
            ComboBoxFishTypes.ItemsSource = fishNames;
            ComboBoxFishTypes.SelectedIndex = 0;
        }

        private void TeamEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow(folder, this);
            mainWin.Closed += (s, eventarg) =>
            {
                teams = xml.loadTeams();
                Dag1.ItemsSource = teams;
                Dag2.ItemsSource = teams;
                Dag3.ItemsSource = teams;
                Dag1.SelectedIndex = -1;
                Dag2.SelectedIndex = -1;
                Dag3.SelectedIndex = -1;
            };
            mainWin.ShowDialog();
        }

        private void ButtonAddFish_Click(object sender, RoutedEventArgs e)
        {
            float input;
            if (float.TryParse(FishWeightTextBox.Text, out input))
            {
                switch ((dayTabs.SelectedItem as TabItem).Header)
                {
                    case "Dag1":
                        if (Dag1.SelectedItem != null)
                        {
                            (Dag1.SelectedItem as Team).day1.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                            xml.SaveTeam(Dag1.SelectedItem as Team);
                            fishList.Items.Refresh();
                            Dag1.Items.Refresh();
                            FishWeightTextBox.Clear();
                        }
                        break;
                    case "Dag2":
                        if (Dag2.SelectedItem != null)
                        {
                            (Dag2.SelectedItem as Team).day2.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                            xml.SaveTeam(Dag2.SelectedItem as Team);
                            fishList.Items.Refresh();
                            Dag2.Items.Refresh();
                            FishWeightTextBox.Clear();
                        }
                        break;
                    case "Dag3":
                        if (Dag2.SelectedItem != null)
                        {
                            (Dag3.SelectedItem as Team).day3.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                            xml.SaveTeam(Dag3.SelectedItem as Team);
                            fishList.Items.Refresh();
                            Dag3.Items.Refresh();
                            FishWeightTextBox.Clear();
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Input Error, no fish added", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Dag1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                fishList.ItemsSource = (Dag1.SelectedItem as Team).day1;
            }
            catch { }
        }

        private void Dag2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                fishList.ItemsSource = (Dag2.SelectedItem as Team).day2;
            }
            catch { }
        }

        private void Dag3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                fishList.ItemsSource = (Dag3.SelectedItem as Team).day3;
            }
            catch { }
        }

        private void DayTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                switch ((dayTabs.SelectedItem as TabItem).Header)
                {
                    case "Dag1":
                        if (Dag1.SelectedItem != null)
                        {
                            fishList.ItemsSource = (Dag1.SelectedItem as Team).day1;
                        }
                        else
                        {
                            fishList.ItemsSource = null;
                        }
                        break;
                    case "Dag2":
                        if (Dag2.SelectedItem != null)
                        {
                            fishList.ItemsSource = (Dag2.SelectedItem as Team).day2;
                        }
                        else
                        {
                            fishList.ItemsSource = null;
                        }
                        break;
                    case "Dag3":
                        if (Dag3.SelectedItem != null)
                        {
                            fishList.ItemsSource = (Dag3.SelectedItem as Team).day3;
                        }
                        else
                        {
                            fishList.ItemsSource = null;
                        }
                        break;
                }
            }
        }

        private void ButtonRemoveFish_Click(object sender, RoutedEventArgs e)
        {
            switch ((dayTabs.SelectedItem as TabItem).Header)
            {
                case "Dag1":
                    if (Dag1.SelectedItem != null)
                    {
                        (Dag1.SelectedItem as Team).day1.RemoveAt(fishList.SelectedIndex);
                        xml.SaveTeam(Dag1.SelectedItem as Team);
                        fishList.Items.Refresh();
                        Dag1.Items.Refresh();
                    }
                    break;
                case "Dag2":
                    if (Dag2.SelectedItem != null)
                    {
                        (Dag2.SelectedItem as Team).day2.RemoveAt(fishList.SelectedIndex);
                        xml.SaveTeam(Dag2.SelectedItem as Team);
                        fishList.Items.Refresh();
                        Dag2.Items.Refresh();
                    }
                    break;
                case "Dag3":
                    if (Dag3.SelectedItem != null)
                    {
                        (Dag3.SelectedItem as Team).day3.RemoveAt(fishList.SelectedIndex);
                        xml.SaveTeam(Dag3.SelectedItem as Team);
                        fishList.Items.Refresh();
                        Dag3.Items.Refresh();
                    }
                    break;
            }
        }

        private void FishWeightTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                float input;
                if (float.TryParse(FishWeightTextBox.Text, out input))
                {
                    switch ((dayTabs.SelectedItem as TabItem).Header)
                    {
                        case "Dag1":
                            if (Dag1.SelectedItem != null)
                            {
                                (Dag1.SelectedItem as Team).day1.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                                xml.SaveTeam(Dag1.SelectedItem as Team);
                                fishList.Items.Refresh();
                                Dag1.Items.Refresh();
                                FishWeightTextBox.Clear();
                            }
                            break;
                        case "Dag2":
                            if (Dag2.SelectedItem != null)
                            {
                                (Dag2.SelectedItem as Team).day2.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                                xml.SaveTeam(Dag2.SelectedItem as Team);
                                fishList.Items.Refresh();
                                Dag2.Items.Refresh();
                                FishWeightTextBox.Clear();
                            }
                            break;
                        case "Dag3":
                            if (Dag2.SelectedItem != null)
                            {
                                (Dag3.SelectedItem as Team).day3.Add(new Fish { weight = input, fishType = fishNames[ComboBoxFishTypes.SelectedIndex] });
                                xml.SaveTeam(Dag3.SelectedItem as Team);
                                fishList.Items.Refresh();
                                Dag3.Items.Refresh();
                                FishWeightTextBox.Clear();
                            }
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Input Error, no fish added", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ButtonPrintOptions_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow prntWin = new PrintWindow(folder, teams);
            prntWin.ShowDialog();
        }

    }
}
