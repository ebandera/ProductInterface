using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductInterface
{
    class ColumnMaps
    {
        public List<ColumnMap> maps = new List<ColumnMap>();
        string validMapId;

        public ColumnMap GetActiveMap()
        {
            foreach(ColumnMap m in maps)
            {
                if (m.id == validMapId) { return m; }
            }
            return null;
        }
        public void LoadXMLFromFilePath(string path)
        {
            XmlDocument doc = new XmlDocument();
            //this one load the document from the path
            doc.Load(path);
            LoadXML(doc);
        }

        public void LoadXMLFromString(string strData)
        {
            XmlDocument doc = new XmlDocument();
            //this one loads the document from string
            try
            {
                doc.LoadXml(strData);
            }
            catch
            {
                Exception ex = new Exception("Invalid Input Map.  Is that file empty or formatted incorrectly?");
                throw ex;
            }
            LoadXML(doc);
        }

        private void LoadXML(XmlDocument doc)
        {
            XmlNodeList Templates = doc.DocumentElement.SelectNodes("/xml/ColumnMap");
            foreach (XmlNode t in Templates)
            {
                ColumnMap map = new ColumnMap();
                map.name = t.Attributes["name"].InnerText;
                map.description = t.Attributes["description"].InnerText;
                map.id = t.Attributes["id"].InnerText;
                string tempHeaderRow = (t.Attributes["headerRow"] != null) ? t.Attributes["headerRow"].InnerText : "1";
                string tempValidateHeader = (t.Attributes["validateHeader"] != null) ? t.Attributes["validateHeader"].InnerText : "true";
                map.fileType = (t.Attributes["fileType"] != null) ? t.Attributes["fileType"].InnerText : "any";
                map.fixedWidth = (t.Attributes["fixedWidth"] != null) ? t.Attributes["fixedWidth"].InnerText : "";
                Int32.TryParse(tempHeaderRow, out map.headerRow);
                Boolean.TryParse(tempValidateHeader, out map.validateHeader);

                XmlNodeList cols = t.SelectNodes("ColumnMapItem");
                foreach (XmlNode node in cols)
                {
                    int columnNumber = 0;
                    if (Int32.TryParse(node.Attributes["columnNumber"].InnerText, out columnNumber))
                    {
                        string header = (node.Attributes["headerValue"] != null) ? node.Attributes["headerValue"].InnerText : "";
                        string ovMode = (node.Attributes["overrideMode"] != null) ? node.Attributes["overrideMode"].InnerText : "";
                        string dataitem = node.InnerText;
                        map.Items.Add(new ColumnMapItem(columnNumber, header, ovMode, dataitem));


                    }


                }
                maps.Add(map);
            }
        }
        public bool ValidateSheet(List<List<string>> grid)
        {
            bool mapResult=true;
            foreach (ColumnMap map in maps)
            {
                mapResult = true;
                if (map.validateHeader == false) { validMapId = map.id; break; }
                foreach (ColumnMapItem col in map.Items)
                {
                    //basically every item has to match
                    if (grid[map.headerRow-1][col.ColumnNumber - 1] != col.HeaderValue)
                    {
                        mapResult = false;break;
                    }
                }
                if (mapResult == true) { validMapId = map.id; break; }

            }
            return mapResult;


        }
    }
    class ColumnMap
    {
       
        public List<ColumnMapItem> Items = new List<ColumnMapItem>();
        public string name;
        public string description;
        public string id;
        public int headerRow = 1;
        public bool validateHeader = true;
        public string fileType = "any";
        public string fixedWidth = "";
      //  public bool overrides = false;
        //public int GetColNumberFromDataItem(string dataItem)
        //{
        //    return Items.Find(x => x.DataEntityName == dataItem).ColumnNumber;
          
        //}

        public ColumnMapItem GetMapItemByDataEntityName(string dataItem)
        {
            return Items.Find(x => x.DataEntityName == dataItem);
        }

    }
    class ColumnMapItem
    {
        public ColumnMapItem(int colNum,string header, string overRdMode,string dataitem)
        {
            ColumnNumber = colNum;
            HeaderValue = header;
            DataEntityName = dataitem;
            if(overRdMode.ToLower()=="true")
            {
                OverRideMode = true;
            }
        }
        public int ColumnNumber;
        public string HeaderValue;
        public string DataEntityName;
        public bool OverRideMode=false;
       
    }
   
}
