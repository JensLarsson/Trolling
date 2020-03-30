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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Yes, this is an even worse mess than the rest of this program.
    /// </summary>
    public partial class PrintWindow : Window
    {
        XML_Mediator xml;
        List<Team> teams;
        Team[] teamArray;
        Info info;
        public PrintWindow(string s, List<Team> teamList)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            xml = new XML_Mediator(s);
            teams = teamList;
            try
            {
                info = xml.loadInfo();
            }
            catch
            {
                info = new Info();
            }
            if (info.headerText != "")
            {
                HeaderText.Text = info.headerText;
            }
            teamChoise.ItemsSource = teams;
            teamChoise.SelectedIndex = 0;
            teamDay.SelectedIndex = 0;
        }

        private void PrintAds(XGraphics gfx, PdfPage page, Double yPadding)
        {
            double maxHeight = 100;
            double maxWidth = 300;
            XPoint point = new XPoint(page.Width - 4, yPadding);
            foreach (string s in info.advertiserPaths)
            {
                XImage image = XImage.FromFile(Directory.GetCurrentDirectory()+s);
                double scale;
                if (image.Height >= image.Width)
                {
                    scale = maxHeight / image.Height;
                }
                else
                {
                    scale = maxWidth / image.Width;
                }
                
                point.X = page.Width - image.Width * scale - 4;
                gfx.DrawImage(image, point.X, point.Y, image.Width*scale, image.Height * scale);
                point.Y += image.Height * scale;
            }
        }

        //Skriver ut alla lag i positionsordning
        private void ButtonStartPrint_Click(object sender, RoutedEventArgs e)
        {
            teams = teams.OrderByDescending(x => x.totalScore).ToList();
            teamArray = teams.ToArray();
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            XImage image = XImage.FromFile(Directory.GetCurrentDirectory() + info.headerPath);
            PdfPage temp = new PdfDocument().AddPage();
            double scale = (temp.Width - 10) / image.Width;
            int pages;
            if ((bool)printFish.IsChecked)
            {
                double d = (temp.Height - (image.Height * scale + 5) - 10) / (8.5 * 18); //only used for the rowCount int
                int rowCount = (int)d;
                pages = (int)Math.Ceiling(teams.Count / (float)rowCount);
            }
            else
            {

                double d = (temp.Height - (image.Height * scale + 5) - 10) / 20; //only used for the rowCount int
                int teamsOnPage = (int)d;
                pages = (int)Math.Ceiling(teams.Count / (float)teamsOnPage);
            }

            for (int pageIndex = 0; pageIndex < pages; pageIndex++)
            {
                // Create an empty page
                PdfPage page = document.AddPage(); ;
                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);
                double thirdWidth = page.Width / 3;
                double horizontal = 4;
                double vertical = 4;
                double verticalSpacing = 2;

                XFont font = new XFont("Verdana", 16, XFontStyle.Bold);

                gfx.DrawImage(image, horizontal, vertical, image.Width * scale, image.Height * scale);
                vertical += image.Height * scale + 5;

                gfx.DrawString(HeaderText.Text, font, XBrushes.Black,
                                new XRect(80, image.Height * scale / 2 - 4, page.Width, page.Height),
                                XStringFormat.TopLeft);
                PrintAds(gfx, page, vertical + 4);
                if ((bool)printFish.IsChecked) //This loop is super slow for some reason
                {
                    double d = (page.Height - (image.Height * scale + 5) - 10) / (8.5 * 18); //only used for the rowCount int
                    int teamsOnPage = (int)d;
                    for (int Index = 0; Index < teamsOnPage; Index++)
                    {
                        int teamIndex = pageIndex * teamsOnPage + Index;
                        if (teamIndex >= teams.Count)
                        {
                            break;
                        }
                        // Create a font
                        font = new XFont("Verdana", 15, XFontStyle.Bold);
                        // Draw the text
                        gfx.DrawString($"{teamIndex + 1} {teams[teamIndex].Name}: {teams[teamIndex].totalScore.ToString()} poäng", font, XBrushes.Black,
                          new XRect(horizontal, vertical, page.Width, page.Height),
                          XStringFormat.TopLeft);

                        vertical += font.Size + verticalSpacing;        //new row


                        string dayName = "Dag ";
                        font = new XFont("Verdana", 15, XFontStyle.Underline);


                        for (int i = 0; i < 3; i++)
                        {
                            gfx.DrawString(dayName + (i + 1).ToString(), font, XBrushes.Black,
                                new XRect(horizontal + thirdWidth * i, vertical, page.Width, page.Height),
                                XStringFormat.TopLeft);

                        }
                        font = new XFont("Verdana", 15, XFontStyle.Regular);

                        vertical += font.Size + verticalSpacing;        //new row
                        for (int i = 0; i < 6; i++)
                        {
                            try
                            {
                                gfx.DrawString(teamArray[teamIndex].day1[i].displayString, font, XBrushes.Black,
                                    new XRect(horizontal + thirdWidth * 0, vertical, page.Width, page.Height),
                                    XStringFormat.TopLeft);
                            }
                            catch { }
                            try
                            {
                                gfx.DrawString(teamArray[teamIndex].day2[i].displayString, font, XBrushes.Black,
                                new XRect(horizontal + thirdWidth * 1, vertical, page.Width, page.Height),
                                XStringFormat.TopLeft);
                            }
                            catch { }
                            try
                            {
                                gfx.DrawString(teamArray[teamIndex].day3[i].displayString, font, XBrushes.Black,
                                new XRect(horizontal + thirdWidth * 2, vertical, page.Width, page.Height),
                                XStringFormat.TopLeft);
                            }
                            catch { }

                            vertical += font.Size + verticalSpacing; //new row
                        }
                        vertical += font.Size + verticalSpacing; //new row
                    }


                }
                else
                {
                    // Create a font
                    font = new XFont("Verdana", 15, XFontStyle.Bold);
                    double d = (page.Height - (image.Height * scale + 5) - 10) / (font.Size + verticalSpacing + 2); //only used for the rowCount int
                    int rowCount = (int)d;

                    for (int Index = 0; Index < rowCount; Index++)
                    {
                        int teamIndex = pageIndex * rowCount + Index;
                        if (teamIndex >= teams.Count)
                        {
                            break;
                        }
                        // Draw the text
                        gfx.DrawString($"{teamIndex + 1} {teams[teamIndex].Name}: {teams[teamIndex].totalScore.ToString()} poäng", font, XBrushes.Black,
                          new XRect(horizontal, vertical, page.Width, page.Height),
                          XStringFormat.TopLeft);

                        vertical += font.Size + verticalSpacing + 2;        //new row
                    }
                }
            }
            // Save the document...
            string filename = "Resultat.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        //Skriver ut info om alla lag
        private void PrintTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            XPen pen = new XPen(XColors.Black, 1);

            PdfPage page = null;
            XGraphics gfx = null;
            double width, halfWidth = 0; ;


            int pages = (int)Math.Ceiling(teams.Count / 17.0f);

            for (int pageIndex = 0; pageIndex < pages; pageIndex++)
            {
                double horizontal = 15;
                double vertical = 10;
                double verticalSpacing = 2;
                if (pageIndex % 2 == 0)
                {
                    page = document.AddPage();
                    // Get an XGraphics object for drawing
                    gfx = XGraphics.FromPdfPage(page);
                    width = page.Width;
                    page.Width = page.Height;
                    page.Height = width;
                    gfx.DrawLine(pen, new XPoint(page.Width / 2, 0), new XPoint(page.Width / 2, page.Height));
                    horizontal = 15;
                    halfWidth = page.Width / 2;
                }
                else
                {
                    horizontal = halfWidth + 15;
                }
                for (int i = 0; i < 17; i++)
                {
                    int index = i + pageIndex * 17;
                    if (index >= teams.Count)
                    {
                        break;
                    }
                    // Create a font
                    XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
                    Member skeppare = null;
                    foreach (Member mbr in teams[index]._members)
                    {
                        if (mbr.leader)
                        {
                            skeppare = mbr;
                        }
                    }
                    if (skeppare == null)
                    {
                        skeppare = teams[index]._members[0];
                    }
                    string header = teams[index].Name;
                    if (teams[index].marker != "")
                    {
                        header += $"   ({teams[index].marker})";
                    }
                    gfx.DrawString(header, font, XBrushes.Black,
                             new XRect(horizontal, vertical, page.Width, page.Height),
                             XStringFormat.TopLeft);
                    vertical += font.Size + verticalSpacing; //new row
                    font = new XFont("Verdana", 12, XFontStyle.Regular);

                    if ((bool)printPersonalInf.IsChecked)
                    {
                        gfx.DrawString($"Skeppare: {skeppare.Name} | {skeppare.phoneNr} | {skeppare.email}", font, XBrushes.Black,
                            new XRect(horizontal, vertical, page.Width, page.Height),
                            XStringFormat.TopLeft);
                    }
                    else
                    {

                        gfx.DrawString($"Skeppare: {skeppare.Name} | ", font, XBrushes.Black,
                                 new XRect(horizontal, vertical, page.Width, page.Height),
                                 XStringFormat.TopLeft);
                    }
                    vertical += font.Size * 1.5 + verticalSpacing; //new row
                }
            }
            

            // Save the document...
            string filename = "Laglista.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        //Skriver ut kvitto
        private void DayPrint_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument document = new PdfDocument();
            XPen pen = new XPen(XColors.Black, 1);

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 16, XFontStyle.Bold);
            double xPos = 5, yPos = 5;

            XImage image = XImage.FromFile(Directory.GetCurrentDirectory() + info.headerPath);
            double scale = (page.Width - 10) / image.Width;
            gfx.DrawImage(image, xPos, yPos, image.Width * scale, image.Height * scale);

            gfx.DrawString(HeaderText.Text, font, XBrushes.Black,
                            new XRect(80, image.Height * scale / 2 - 4, page.Width, page.Height),
                            XStringFormat.TopLeft);

            xPos = 10;
            yPos += image.Height * scale + 5; //Text after image starts here

            Team team = teamChoise.SelectedValue as Team;
            gfx.DrawString($"{team.Name} {teamDay.SelectedValue}: ", font, XBrushes.Black,
                            new XRect(xPos, yPos, page.Width, page.Height),
                            XStringFormat.TopLeft);
            yPos += font.Size + 5;
            font = new XFont("Verdana", 15, XFontStyle.Regular);

            List<Fish> fishes = new List<Fish>();
            switch (teamDay.SelectedValue)
            {
                case "Dag 1":
                    fishes = team.day1;
                    break;
                case "Dag 2":
                    fishes = team.day2;
                    break;
                case "Dag 3":
                    fishes = team.day3;
                    break;
            }
            for (int i = 0; i < fishes.Count; i++)
            {
                gfx.DrawString($"{fishes[i].displayString} ", font, XBrushes.Black,
                            new XRect(xPos, yPos, page.Width, page.Height),
                            XStringFormat.TopLeft);
                yPos += font.Size + 2;
            }
            yPos = page.Height - 100;

            gfx.DrawString($"Datum: ", font, XBrushes.Black,
                        new XRect(xPos, yPos, page.Width, page.Height),
                        XStringFormat.TopLeft);
            yPos += font.Size + 3;
            gfx.DrawLine(pen, new XPoint(xPos, yPos), new XPoint(page.Width - 20, yPos));
            yPos += 15;
            gfx.DrawString($"Signatur: ", font, XBrushes.Black,
                        new XRect(xPos, yPos, page.Width, page.Height),
                        XStringFormat.TopLeft);
            yPos += font.Size + 3;
            gfx.DrawLine(pen, new XPoint(xPos, yPos), new XPoint(page.Width - 20, yPos));


            //End
            string filename = "Kvitto.pdf";
            document.Save(filename);
            Process.Start(filename);

        }

        private void HeaderText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                info.headerText = HeaderText.Text;
                xml.saveInfo(info);
                Keyboard.ClearFocus();
            }
        }

        private void Button_ChangeHeader(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == true)
            {
                string s = openFileDialog.FileName;
                info.headerPath = s.Replace(Directory.GetCurrentDirectory(), "");
                xml.saveInfo(info);
            }
        }

        private void Button_SponsorButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == true)
            {
                info.advertiserPaths = new List<string>();
                foreach (String file in openFileDialog.FileNames)
                {
                    info.advertiserPaths.Add(file.Replace(Directory.GetCurrentDirectory(), ""));
                }
                xml.saveInfo(info);
            }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            XL_Mediator xlMediator = new XL_Mediator();
            xlMediator.CreateResultPage(teams,info.headerText);
        }
    }
}
