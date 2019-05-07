using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ProductInterface
{
    class Products: List<Product>
    {
        public Products Valid()
        {
            List<Product>temp = this.FindAll(x => x.IsValid == true);
            Products final = new Products();
            foreach(Product p in temp) { final.Add(p); }
            return final;
        }
        public Products Invalid()
        {
            List<Product> temp = this.FindAll(x => x.IsValid == false);
            Products final = new Products();
            foreach (Product p in temp) { final.Add(p); }
            return final;
        }

       
        public Products Merge(Products pdsOut,ColumnMap map)
        {
            // Func<string, bool> predicate1 = x => ((Product)x).mfrcode 
            //Func<string, bool> predicate2 = s => s.StartsWith("I");
            Product.ConfigureOverrides(map);
            foreach (Product p in this)
            {
                //if the catlag number matches the mfrcatalog
                if(pdsOut.Exists(x => (x.MfrCode == p.MfrCode) && (x.MfrCatalog==p.CatalogNumber)))
                {
                    p.IsValid = true;
                    Product p2 = pdsOut.Find(x => (x.MfrCode == p.MfrCode) && (x.MfrCatalog == p.CatalogNumber));
                    p.PreferredCatalogNumber = "MfrCatalog";
                    p.Merge(p2);
                }//or the cedmfrcatalog
                else if (pdsOut.Exists(x => (x.MfrCode == p.MfrCode) && (x.CEDMfrCatalog == p.CatalogNumber)))
                {
                    p.IsValid = true;
                    Product p2 = pdsOut.Find(x => (x.MfrCode == p.MfrCode) && (x.CEDMfrCatalog == p.CatalogNumber));
                    p.PreferredCatalogNumber = "CEDMfrCatalog";
                    p.Merge(p2);
                }//or the localcatalog_key
                else if (pdsOut.Exists(x => (x.MfrCode == p.MfrCode) && (x.LocalCatalog_Key == p.CatalogNumber)))
                {
                    p.IsValid = true;
                    Product p2 = pdsOut.Find(x => (x.MfrCode == p.MfrCode) && (x.LocalCatalog_Key == p.CatalogNumber));
                    p.PreferredCatalogNumber = "LocalCatalog_Key";
                    p.Merge(p2);
                }
                else
                {
                    p.IsValid = false;
                }


            }
           
            return this;


        }
        public Products LoadSheet(List<List<string>> sheet,ColumnMap map)
        {
           
            Products result = new Products();
            bool dataRow = false;
            foreach (List<string> row in sheet)
            { 
                //first time assume it's not a data row (still header info) and check
                if (dataRow == false) {
                    if (sheet.IndexOf(row) < map.headerRow) { continue; }
                    else { dataRow = true; }
                }
                if (dataRow == true)
                {

                    Product p = new Product();
                    foreach (ColumnMapItem mi in map.Items)
                    {
                        p.SetValueByPropertyName(mi.DataEntityName, row[mi.ColumnNumber - 1]);
                    }
                    result.Add(p);
                }
               
            }
            return result;
        }
        public List<List<string>> FlattenProduct(string template)
        {

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(template);
            }
            catch
            {
                Exception ex = new Exception("Invalid XML on Label Output Template");
                throw ex;
            }
            
            XmlNodeList xmlTemplateItem = doc.DocumentElement.SelectNodes("/xml/LabelPrint/LabelTemplate/Item");
            List<TemplateItem> lstTemplateItem = new List<TemplateItem>();
            //translate xml into Template Item object for each property, if the corresponding atribute is not present insert blank string
            foreach (XmlNode i in xmlTemplateItem)
            {
                TemplateItem ti = new ProductInterface.TemplateItem();
                ti.type = (i.Attributes["type"] != null) ? i.Attributes["type"].InnerText : "";
                ti.tagname = (i.Attributes["tagname"] != null) ? i.Attributes["tagname"].InnerText : "";
                ti.data = (i.Attributes["data"] != null) ? i.Attributes["data"].InnerText : "";
                ti.location = (i.Attributes["location"] != null) ? i.Attributes["location"].InnerText : "";
                ti.source = (i.Attributes["source"] != null) ? i.Attributes["source"].InnerText : "";
                ti.value = (i.Attributes["value"] != null) ? i.Attributes["value"].InnerText : "";
                ti.flip = (i.Attributes["flip"] != null) ? i.Attributes["flip"].InnerText : "";
                lstTemplateItem.Add(ti);
            }

            List<List<string>> lstFlatList = new List<List<string>>();

           

            foreach (Product p in this)
            {
                List<string> flatProduct = new List<string>();
                //for every template item
                foreach (TemplateItem ti in lstTemplateItem)
                {
                    //if the data attribute is not blank
                    if(ti.data!="")
                    {
                        string tempData = ti.data;

                        //do a replace for what's inside the curly braces.  If what's inside the curly braces is not valid, it will be omitted
                        while(tempData.Contains('{'))
                        {
                            int openbrace = tempData.IndexOf('{');
                            int closebrace = tempData.IndexOf('}');
                            string insideWithBraces = tempData.Substring(openbrace, closebrace - openbrace+1);
                            string insideWithoutBraces = insideWithBraces.Substring(1, insideWithBraces.Length - 2);
                            string replacementValue = p.GetValueByPropertyName(insideWithoutBraces);
                            //This is to create a placeholder to let the string have an indication that there was a failed attempt
                            if(replacementValue == "") { replacementValue = "*x*"; }
                            tempData = tempData.Replace(insideWithBraces, replacementValue);
                        }
                        //int orStartIndex = 0;
                        int orLength = 0;

                        while(tempData.Contains("||"))
                        {
                            // int orSeperator = tempData.IndexOf("||");
                            orLength = tempData.IndexOf("||");
                            string part = tempData.Substring(0, orLength);
                            //if there was a failed attempt, shift to the next part of the or
                            if (part.Contains("*x*")&&tempData.Length>(orLength+2))
                            {
                                tempData = tempData.Substring(orLength + 2);
                                continue;
                            }
                            else
                            {
                                tempData = part;
                                break;
                            }

                        }
                        if (tempData.Contains("*x*"))
                        {
                            tempData = "";
                        }
                       // tempData.Replace("*x*", "");

                        flatProduct.Add(tempData);
                    }
                    else
                    {
                        if (ti.type != "image" || ti.location != "template") { flatProduct.Add(""); }
                    }



                }
               
                //flatProduct.Add(p.ProductName);
                //flatProduct.Add(p.Min + "/" + p.Max);
                //flatProduct.Add(p.BinLocation);
                //flatProduct.Add(p.MfrCode + " " + p.CatalogNumber);
                //flatProduct.Add(p.ThumbnailUrl);
                //flatProduct.Add(p.MfrCode + " " + p.CatalogNumber);

                lstFlatList.Add(flatProduct);
            }
            return lstFlatList;

        }

        public List<List<string>> FlattenProductMfrCat()
        {
            List<List<string>> lstFlatList = new List<List<string>>();



            foreach (Product p in this)
            {
                List<string> flatProduct = new List<string>();
                flatProduct.Add(p.MfrCode);
                flatProduct.Add(p.CatalogNumber);
                lstFlatList.Add(flatProduct);
            }
            return lstFlatList;
        }
    }
}
