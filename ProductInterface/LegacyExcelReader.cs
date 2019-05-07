using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProductInterface
{
    class LegacyExcelReader
    {

        public List<List<string>> ReadTheSheetXls(string path)
        {
            List <List<string>> lstOutput = new List<List<string>>();
            var fileName = path; 
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";
                    //command.Parameters.AddWithValue("@MappingName", strName);
                  
              
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> row = new List<string>();
                            for (int i=0;i< reader.FieldCount; i++)
                            {
                                row.Add(reader[i].ToString());
                            }
                                                      
                            lstOutput.Add(row);
                        }
                    }


                }
            }
            return lstOutput;
        }
        

    }
}
