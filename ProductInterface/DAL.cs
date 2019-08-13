using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProductInterface
{
    class DAL
    {
        private string GetConnectionString()
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CED\\LabelPrintData.accdb";

            //return "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = LabelPrintData.accdb; Persist Security Info = False";
            return "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + fullPath + "; Persist Security Info = False";
        }
        public string GetMapsByName(string strName)
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();

            }
            catch
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }

            OleDbCommand command = new OleDbCommand("Select Data from InputMapping where MappingName=@MappingName and IsDeleted=0", conn);
             command.Parameters.AddWithValue("@MappingName", strName);
            string strData = "";
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    strData += reader["data"];
                }
            }

            conn.Close();
            return strData;
        }
        public string GetOutputByName(string strName)
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();

            }
            catch
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }

            OleDbCommand command = new OleDbCommand("Select Data from OutputFormat where OutputName=@OutputName and IsDeleted=0", conn);
            command.Parameters.AddWithValue("@OutputName", strName);
            string strData = "";
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    strData += reader["data"];
                }
            }

            conn.Close();
            return strData;
        }

        public List<string> GetListOfMappings()
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();
               
            }
            catch 
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }
          

            OleDbCommand command = new OleDbCommand("Select MappingName from InputMapping where IsDeleted=false Order By ID", conn);
           // command.Parameters.AddWithValue("@MappingName", strName);
           
            List<string> lstMapping = new List<string>();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()==true)
                {
                    lstMapping.Add(reader["MappingName"].ToString());
                }
            }

            conn.Close();
            return lstMapping;
        }

        public int InsertMaps(string strName, string strXml)
        {
            
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            string stmt = "INSERT INTO InputMapping(MappingName,Data,IsDeleted) VALUES(@name,@data,@isDeleted)";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            cmd.Parameters.AddWithValue("@name", strName);
            cmd.Parameters.AddWithValue("@data", strXml);
            cmd.Parameters.AddWithValue("@isDeleted", false);
            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;
           


        }
        public int DeleteMaps(string strName)
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string stmt = "Update InputMapping set IsDeleted=true where MappingName=@name";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@name", strName);
           
            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;

        }
        public int InsertOutput(string strName, string strXml)
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            string stmt = "INSERT INTO OutputFormat(OutputName,Data,IsDeleted) VALUES(@name,@data,@isDeleted)";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            cmd.Parameters.AddWithValue("@name", strName);
            cmd.Parameters.AddWithValue("@data", strXml);
            cmd.Parameters.AddWithValue("@isDeleted", 0);
            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;
        }
        public int DeleteOutput(string strName)
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string stmt = "Update OutputFormat set IsDeleted=true where OutputName=@name";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@name", strName);
          
            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;
        }
        public List<string> GetListOfOutputs()
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();

            }
            catch
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }

            OleDbCommand command = new OleDbCommand("Select OutputName from OutputFormat where IsDeleted=false Order By ID", conn);
            // command.Parameters.AddWithValue("@MappingName", strName);
            
            List<string> lstOutput = new List<string>();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read() == true)
                {
                    lstOutput.Add(reader["OutputName"].ToString());
                }
            }

            conn.Close();
            return lstOutput;
        }

        public int UpdateVisibilityOfPreconfiguredInput(string strPreloadId,bool isDeleted)
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string stmt = "Update InputMapping set IsDeleted=@isDeleted where PreloadId=@preloadid";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@preloadid", strPreloadId);

            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;
        }

        public int UpdateVisibilityOfPreconfiguredOutput(string strPreloadId,bool isDeleted)
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string stmt = "Update OutputFormat set IsDeleted=@isDeleted where PreloadId=@preloadid";
            OleDbCommand cmd = new OleDbCommand(stmt, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@preloadid", strPreloadId);

            int intRecordsChanged = cmd.ExecuteNonQuery();
            conn.Close();
            return intRecordsChanged;
        }

        public Dictionary<string,bool> SelectPreconfiguredInputs()
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();

            }
            catch
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }

            OleDbCommand command = new OleDbCommand("Select PreloadId,IsDeleted from InputMapping where IsPreload=true", conn);
            // command.Parameters.AddWithValue("@MappingName", strName);

            Dictionary<string, bool> output = new Dictionary<string, bool>();
           // List<string> lstOutput = new List<string>();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read() == true)
                {
                    int i = reader.GetOrdinal("IsDeleted");
                    output.Add(reader["PreloadId"].ToString(), reader.GetBoolean(i));
                  
                   
                }
            }

            conn.Close();
            return output;
        }

        public Dictionary<string, bool> SelectPreconfiguredOutputs()
        {
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();

            }
            catch
            {
                Exception ex = new Exception("There was an error opening the database.  Most likely this is caused by the issue: \n 'microsoft.ace.oledb.12.0' provider is not registered on the local machine' \n Make sure that it is installed.  Use the following dialog if needed.");
                throw ex;
            }

            OleDbCommand command = new OleDbCommand("Select PreloadId,IsDeleted from OutputFormat where IsPreload=true", conn);
            // command.Parameters.AddWithValue("@MappingName", strName);

            Dictionary<string, bool> output = new Dictionary<string, bool>();
            // List<string> lstOutput = new List<string>();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read() == true)
                {
                    int i = reader.GetOrdinal("IsDeleted");
                    output.Add(reader["PreloadId"].ToString(), reader.GetBoolean(i));


                }
            }

            conn.Close();
            return output;
        }
    }
}
