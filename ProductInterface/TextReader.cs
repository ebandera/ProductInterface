using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace ProductInterface
{
    class TextReader
    {
        public List<List<string>> ReadTheSheet(string path,string delimiter)
        {
           
            List<List<string>> results = new List<List<string>>();

            TextFieldParser parser = new TextFieldParser(new StreamReader(path));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(delimiter);
            string[] fields;

            while (!parser.EndOfData)
            {
                List<string> temp = new List<string>();
                fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    temp.Add(field);
                }
                results.Add(temp);
            }
              
            return results;
        }
        public void WriteProducts(List<List<string>> data, string delimiter)
        {
            string createText = "Items without additonal product support" + Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            sb.Append(createText);
            foreach(List<string>row in data)
            {
                int cellCounter = 0;
                foreach(string cell in row)
                {
                    
                    sb.Append(cell);
                    cellCounter++;
                    if(cellCounter< row.Count) { sb.Append(delimiter); }
                }
                sb.Append(Environment.NewLine);
            }
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ExcludedParts.txt"; 

            File.WriteAllText(fullPath, sb.ToString());

           
        }

        public List<List<string>> ReadFixedWidth(string path, string columnWidths)
        {
            //first deal with this column business
            string[] columns = columnWidths.Split(',');
            List<int> intColumns = new List<int>();
            for (int i = 0; i < columns.Length; i++)
            {
                int intTemp = 0;
                if (Int32.TryParse(columns[i], out intTemp))
                {
                    intColumns.Add(intTemp);
                }
            }
            //then read the file
            List<List<string>> results = new List<List<string>>();
            //using (var fileStream = File.OpenRead(path))
            using (StreamReader sr = new StreamReader(File.OpenRead(path)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int colPositionCounter = 0;
                    List<string> row = new List<string>();
                    for(int i=0;i<intColumns.Count; i++)
                    {
                        row.Add(line.Substring(colPositionCounter, intColumns[i]).Trim());
                        colPositionCounter += intColumns[i];

                    }
                    //for the last column
                    {
                        row.Add(line.Substring(colPositionCounter).Trim());
                    }
                    results.Add(row);
                }
            }
            return results;
        }
    }
}
