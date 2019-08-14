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
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        XML_Mediator xml;
        List<Team> teams;
        public PrintWindow(string s, List<Team> teamList)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            xml = new XML_Mediator(s);
            teams = teamList;
        }

        private void ButtonStartPrint_Click(object sender, RoutedEventArgs e)
        {
            teams = teams.OrderByDescending(x => x.totalScore).ToList();
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            int pages;
            if ((bool)printFish.IsChecked)
            {
                pages = (int)Math.Ceiling(teams.Count / 5.0f);
            }
            else
            {
                pages = (int)Math.Ceiling(teams.Count / 40.0f);
            }

            for (int pageIndex = 0; pageIndex < pages; pageIndex++)
            {
                // Create an empty page
                PdfPage page = document.AddPage(); ;
                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);
                double thirdWidth = page.Width / 3;
                double horizontal = 10;
                double vertical = 10;
                double verticalSpacing = 2;

                for (int Index = 0; Index < 5; Index++)
                {
                    int teamIndex = pageIndex * 5 + Index;
                    if (teamIndex >= teams.Count)
                    {
                        break;
                    }
                    // Create a font
                    XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
                    // Draw the text
                    gfx.DrawString($"{teamIndex + 1} {teams[teamIndex].Name}: {teams[teamIndex].totalScore.ToString()} poäng", font, XBrushes.Black,
                      new XRect(horizontal, vertical, page.Width, page.Height),
                      XStringFormat.TopLeft);

                    vertical += font.Size + verticalSpacing;        //new row

                    if ((bool)printFish.IsChecked)
                    {

                        string dayName = "Dag ";
                        font = new XFont("Verdana", 15, XFontStyle.Underline);
                        // Draw the text


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
                                gfx.DrawString(teams[teamIndex].day1[i].displayString, font, XBrushes.Black,
                                    new XRect(horizontal + thirdWidth * 0, vertical, page.Width, page.Height),
                                    XStringFormat.TopLeft);
                            }
                            catch { }
                            try
                            {
                                gfx.DrawString(teams[teamIndex].day2[i].displayString, font, XBrushes.Black,
                                new XRect(horizontal + thirdWidth * 1, vertical, page.Width, page.Height),
                                XStringFormat.TopLeft);
                            }
                            catch { }
                            try
                            {
                                gfx.DrawString(teams[teamIndex].day3[i].displayString, font, XBrushes.Black,
                                new XRect(horizontal + thirdWidth * 2, vertical, page.Width, page.Height),
                                XStringFormat.TopLeft);
                            }
                            catch { }

                            vertical += font.Size + verticalSpacing; //new row
                        }
                    }
                    vertical += font.Size + verticalSpacing; //new row

                }
            }
            // Save the document...
            string filename = "Resultat.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

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
    }
}
