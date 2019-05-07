using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Validation;
using System.IO;
using System.Text.RegularExpressions;


namespace ProductInterface
{
    class ExcelReader
    {
        WorkbookPart wb;
        public List<List<string>> ReadTheSheetXlsx(string path)
        {
            List<List<string>> results = new List<List<string>>();
            try
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(path, false))
                {
                    wb = doc.WorkbookPart;
                    string sID = wb.Workbook.Descendants<Sheet>().First().Id;
                    WorksheetPart worksheetPart = (WorksheetPart)wb.GetPartById(sID);

                    //WorksheetPart worksheetPart = wb.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();


                    int colcount = 0;
                    foreach (Row r in sheetData.Elements<Row>())
                    {
                        List<string> lstRow = new List<string>();
                        int colIndex = 0;
                        foreach (Cell c in r.Elements<Cell>())
                        {//what happens is that blank cells are being omittd from the collection, when  thy should be counted
                           int? cellIndex=GetColumnIndexFromName(GetColumnName(c.CellReference));
                            if(cellIndex != null)
                            {                               
                                if(colIndex<cellIndex) //if the next cell is less than the object, that means we skipped some
                                {
                                    do
                                    {
                                        lstRow.Add(""); colIndex++;
                                    }
                                    while (colIndex < cellIndex);  
                                }
                                lstRow.Add(GetTextFromCell(c)); 
                            }
                            colIndex++;                          
                        }
                        if (results.Count == 0) { colcount = lstRow.Count; }//the first time, set th colcount to know how many cols to expect every time
                        if (lstRow.Count < colcount)
                        {
                            do
                            {
                                lstRow.Add(""); colIndex++;
                            }
                            while (lstRow.Count < colcount);
                        }
                        results.Add(lstRow);
                    }



                }
            }
            catch
            {
                Exception ex = new Exception("I think your Excel file is open.  Please close the file and run again");
                throw ex;
            }
            return results;
        }

       
        /// <summary>
        /// Determine is file is xls, xlsx or invalid
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        private string GetTextFromCell(Cell c)
        {
            string text = "";

            //in case it's not a string
            text = c.CellValue.Text;
          
            if (c.DataType != null)
            {
                if (c.DataType == CellValues.SharedString)
                {
                    int id = -1;

                    if (Int32.TryParse(c.InnerText, out id))
                    {
                        SharedStringItem item = GetSharedStringItemById(wb, id);

                        if (item.Text != null)
                        {
                            text = item.Text.Text;
                        }
                        else if (item.InnerText != null)
                        {
                            text = item.InnerText;
                        }
                        else if (item.InnerXml != null)
                        {
                            text = item.InnerXml;
                        }
                    }
                }
            }
            return text;
        }
        private SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        private int? GetColumnIndexFromName(string columnName)
        {
            int? columnIndex = null;

            string[] colLetters = Regex.Split(columnName, "([A-Z]+)");
            colLetters = colLetters.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            if (colLetters.Count() <= 2)
            {
                int index = 0;
                foreach (string col in colLetters)
                {
                    List<char> col1 = colLetters.ElementAt(index).ToCharArray().ToList();
                    int? indexValue = Letters.IndexOf(col1.ElementAt(index));

                    if (indexValue != -1)
                    {
                        // The first letter of a two digit column needs some extra calculations
                        if (index == 0 && colLetters.Count() == 2)
                        {
                            columnIndex = columnIndex == null ? (indexValue + 1) * 26 : columnIndex + ((indexValue + 1) * 26);
                        }
                        else
                        {
                            columnIndex = columnIndex == null ? indexValue : columnIndex + indexValue;
                        }
                    }

                    index++;
                }
            }

            return columnIndex;
        }

        private static List<char> Letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        private string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);

            return match.Value;
        }

    }
}
