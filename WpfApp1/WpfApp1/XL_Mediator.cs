using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryFileFormat;
using System.IO;
using System.Diagnostics;

namespace WpfApp1
{
    class XL_Mediator
    {

        public void CreateResultPage(List<Team> teamList, string title)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + $"/Spreadsheets/"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + $"/Spreadsheets/");
            }
            string fileName = "";
            if (title != "")
            {
                fileName = Directory.GetCurrentDirectory() + $"/Spreadsheets/{title}.xls";
            }
            else
            {
                fileName = Directory.GetCurrentDirectory() + $"/Spreadsheets/sheet.xls";
            }
            string extension = ".xls";

            int count = 0;
            while (File.Exists(fileName))
            {
                if (count == 0)
                    fileName = fileName.Replace(extension, "(" + ++count + ")" + extension);
                else
                    fileName = fileName.Replace("(" + count + ")" + extension, "(" + ++count + ")" + extension);
            }
            Workbook workbook = new Workbook();
            Worksheet[] workSheets = new Worksheet[] {
                new Worksheet("Day1"),
                new Worksheet("Day2"),
                new Worksheet("Day3")
            };
            for (int i = 0; i < workSheets.Length; i++)
            {
                workSheets[i].Cells[0, 0] = new Cell("Lagnamn");
                workSheets[i].Cells[0, 1] = new Cell("Poäng");
                workSheets[i].Cells[0, 2] = new Cell("Fisk 1");
                workSheets[i].Cells[0, 3] = new Cell("Fisk 2");
                workSheets[i].Cells[0, 4] = new Cell("Fisk 3");
                workSheets[i].Cells[0, 5] = new Cell("Fisk 4");
                workSheets[i].Cells[0, 6] = new Cell("Fisk 5");
                workSheets[i].Cells[0, 7] = new Cell("Fisk 6");
                workSheets[i].Cells.ColumnWidth[0, 1] = 4000;
                for (int j = 0; j < teamList.Count; j++)
                {
                    workSheets[i].Cells[j + 2, 0] = new Cell(teamList[j].Name);
                }
            }
            for (int j = 0; j < teamList.Count; j++)
            {
                workSheets[0].Cells[j + 2, 1] = new Cell(teamList[j].Day1.ToString());
                workSheets[1].Cells[j + 2, 1] = new Cell(teamList[j].Day2.ToString());
                workSheets[2].Cells[j + 2, 1] = new Cell(teamList[j].Day3.ToString());
                for (int i = 0; i < teamList[j].day1.Count; i++)
                {
                    workSheets[0].Cells[j + 2, i + 2] = new Cell(teamList[j].day1[i].weight.ToString());
                }
                for (int i = 0; i < teamList[j].day2.Count; i++)
                {
                    workSheets[1].Cells[j + 2, i + 2] = new Cell(teamList[j].day2[i].weight.ToString());
                }
                for (int i = 0; i < teamList[j].day3.Count; i++)
                {
                    workSheets[2].Cells[j + 2, i + 2] = new Cell(teamList[j].day3[i].weight.ToString());
                }
            }
            workbook.Worksheets.Add(workSheets[0]);
            workbook.Worksheets.Add(workSheets[1]);
            workbook.Worksheets.Add(workSheets[2]);

            Worksheet workSheet = new Worksheet("Laglista");
            workSheet.Cells[0, 0] = new Cell("Lag");
            workSheet.Cells[0, 1] = new Cell("Namn");
            workSheet.Cells[0, 2] = new Cell("Tel-nr");
            workSheet.Cells[0, 3] = new Cell("Email");
            workSheet.Cells[0, 4] = new Cell("Kommentar");
            workSheet.Cells.ColumnWidth[0, 3] = 4000;
            int rad = 2;
            for (int i = 0; i < teamList.Count; i++)
            {
                workSheet.Cells[rad, 0] = new Cell(teamList[i].Name);
                for (int j = 0; j < teamList[i]._members.Count; j++)
                {
                    workSheet.Cells[rad, 1] = new Cell(teamList[i]._members[j].Name);
                    workSheet.Cells[rad, 2] = new Cell(teamList[i]._members[j].phoneNr.ToString());
                    workSheet.Cells[rad, 3] = new Cell(teamList[i]._members[j].email);
                    workSheet.Cells[rad, 4] = new Cell(teamList[i]._members[j].comment);
                    rad++;
                }
                rad++;
            }
            workbook.Worksheets.Add(workSheet);
            workbook.Save(fileName);
            Process.Start(fileName);
        }
        //public void CreateTeamList(List<Team> teamList)
        //{
        //    string file = Directory.GetCurrentDirectory() + $"/Spreadsheets/Laglista.xls";
        //    Workbook workbook = new Workbook();
        //    Worksheet workSheet = new Worksheet("Laglista");
        //    for (int i = 0; i < teamList.Count; i++)
        //    {

        //    }
        //    workbook.Save(file);
        //    Process.Start(file);
        //}
    }
}
