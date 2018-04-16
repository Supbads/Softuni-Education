using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace Problem_6.EXCELlent_Knowledge
{
    class Program
    {
        static private object mMissingValue = System.Reflection.Missing.Value;

        static void Main(string[] args)
        {
            string inputDirectory = "../../sample_table.xlsx";
            string outputDirectory = "../../output_text.txt";

            List< List<string>> data = new List<List<string>>();

            var newFile = new FileInfo(inputDirectory);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                var a = xlPackage.Workbook.Worksheets[1];

                bool columnsLeftToRead = true;
                bool rowsLeftToRead = true;
                
                int i = 1;
                int j = 1;

                List<string> currentColumn = new List<string>();

                while (columnsLeftToRead || rowsLeftToRead)
                {
                    var currentCell = a.Cells[i, j].Value;

                    if (!columnsLeftToRead && currentCell == null)
                    {
                        rowsLeftToRead = false;
                        continue;
                    }
                    if (currentCell == null)
                    {
                        columnsLeftToRead = false;
                        i++;
                        j = 1;
                        data.Add(currentColumn);
                        currentColumn = new List<string>();
                        continue;
                    }

                    currentColumn.Add(currentCell.ToString());

                    columnsLeftToRead = true;
                    //rowsLeftToRead = true; //nice on the brain but heuristically irrelevant
                    j++;
                }

                //xlPackage.Save();
            }


            foreach (var row in data)
            {
                File.AppendAllText(outputDirectory, string.Join("|", row) + "|\r\n");

                //Console.WriteLine(string.Join("|", row));
            }


        }
    }
}
