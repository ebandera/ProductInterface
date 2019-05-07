using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductInterface
{
    class TemplateItem
    {
        public string type;
        public string tagname;
        public string data;
        public string location;
        public string source;
        public string value;
        public string flip;

        public static string ReplaceXMLLogoTemplateValue(string strXML,string strLogoPath)
        {

            XmlDocument doc = new XmlDocument();
            //this one loads the document from string
            try
            {
                doc.LoadXml(strXML);
            }
            catch
            {
                Exception ex = new Exception("Invalid Input Map.  Is that file empty or formatted incorrectly?");
                throw ex;
            }
        
            
            XmlNodeList LogoParameter = doc.DocumentElement.SelectNodes("/xml/LabelPrint/LabelTemplate/Item[@value='{logo}']");

            XmlNodeList xmlTemplateItem = doc.DocumentElement.SelectNodes("/xml/LabelPrint/LabelTemplate/Item");
            foreach (XmlNode p in LogoParameter)  //Should be one of these, but if they use the logo twice, so be it
            {
                if (p.Attributes["value"].Value != null)
                {
                    p.Attributes["value"].Value = strLogoPath.Replace("\\","\\\\");
                }
                if(p.Attributes["source"].Value != null)
                {
                    p.Attributes["source"].Value = "filesystem";
                }
                else
                {
                    XmlAttribute source = doc.CreateAttribute("source");
                    source.InnerText = "filesystem";
                    p.AppendChild(source);
                }
                
               
            }
            return doc.OuterXml;
        }
        
       
    }
    
}
