using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace ProductInterface
{
    class ProductDataLayer
    {
        // static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Use for Generic Keyword Search for a particular PC and Account
        /// </summary>
        /// <param name="pcnum"></param>
        /// <param name="acctnum"></param>
        /// <param name="keywords"></param>
        /// <returns>Json String</returns>
       

        
        /// <summary>
        /// Use to return only the 1 product for a particular PC and Account
        /// </summary>
        /// <param name="pcnum"></param>
        /// <param name="acctnum"></param>
        /// <param name="mfr"></param>
        /// <param name="cat"></param>
        /// <returns>Json String</returns>
       
        
        
        /// <summary>
        /// Use to return only the products specified for a particular PC and Account
        /// </summary>
        /// <param name="pcnum"></param>
        /// <param name="acctnum"></param>
        /// <param name="lstProduct"></param>
        /// <returns></returns>
        public string GetProductDetailsForListAsJson(string pcnum, string acctnum,Products lstProduct,int intPageSize, int intPageNumber)
        {
            HttpWebRequest httpWebRequest;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

            httpWebRequest = (HttpWebRequest)WebRequest.Create("https://search.myced.com/api/search/advanced");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            string result;
            try
            {
                Stream srequest = httpWebRequest.GetRequestStream();
                using (StreamWriter sw = new StreamWriter(srequest))
                {
                    string strQuery = DevelopQueryStringFromProductList(lstProduct);
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        AccountNumber = acctnum,
                        LocationNumber = pcnum,
                        Query = strQuery,
                        IncludeFacets = false,
                        IncludePricing = true,
                        Facets =
                        new Dictionary<string, object>()
                        {
                        { "UNSPSC",
                            new List<string>() { }
                        }
                        },
                        Paging = new Dictionary<string, int>()
                    {
                        {"PageNumber",intPageNumber },
                        {"PageSize",intPageSize }
                    }
                    });

                    sw.Write(json);
                    sw.Flush();
                    sw.Close();
                }
                srequest.Close();
                System.Threading.Thread.Sleep(500);   
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream sresponse = httpResponse.GetResponseStream();
                using (StreamReader sr = new StreamReader(sresponse))
                {
                    result = sr.ReadToEnd();

                }
               
                sresponse.Close();
            }
            catch
            {
                Exception ex = new Exception("Having trouble connecting to online product data");
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Private use for developing query on list of products
        /// </summary>
        /// <param name="lstProduct"></param>
        /// <returns></returns>
        private string DevelopQueryStringFromProductList(Products lstProduct)
        {
            string result = "";
            foreach(Product p in lstProduct)
            {
                result += "((CEDMfrCode: \"" + p.MfrCode + "\" OR LocalMfrCode_Key: \"" + p.MfrCode + "\") AND (CEDMfrCatalog:\"" + p.CatalogNumber + "\" OR MfrCatalog:\"" + p.CatalogNumber + "\" OR LocalCatalog_Key:\"" + p.CatalogNumber + "\"))";
                if (p != lstProduct.Last()) { result += " OR "; }
            }
            return result;
        }
       
        /// <summary>
        /// Use to convert Search API Json to a List of Proucts
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Products object</returns>
        public Products JsonToProductList(string json){
            int length = json.Length;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            
            jss.MaxJsonLength = 10000000;
            dynamic item = jss.Deserialize<object>(json);
            Products lstProduct = new Products();

            int intTotalCount= item["TotalCount"];
            

            for (int i = 0; i < intTotalCount;i++)
            {

                Dictionary<string, object> p;
                Dictionary<string, object> price;
                try
                {
                    p = item["Products"][i]["Product"];
                    price = item["Products"][i]["Price"];
                }
                catch (Exception ex)
                {
                   // throw ex;
                    return lstProduct;
                    //Exception ex = new Exception("No products were retuned from the system");
                    //throw ex;
                }


                Product result = new Product();
               
                result.CEDMfrCode = (p.ContainsKey("CEDMfrCode")) ? p["CEDMfrCode"].ToString() : "";
                result.MfrCatalog = (p.ContainsKey("MfrCatalog")) ? p["MfrCatalog"].ToString() : "";
                result.CEDMfrCatalog = (p.ContainsKey("CEDMfrCatalog")) ? p["CEDMfrCatalog"].ToString() : "";
                result.LocalMfrCode_Key = (p.ContainsKey("LocalMfrCode_Key")) ? p["LocalMfrCode_Key"].ToString() : "";
                result.LocalCatalog_Key = (p.ContainsKey("LocalCatalog_Key")) ? p["LocalCatalog_Key"].ToString() : "";
                result.FullTechDescription = (p.ContainsKey("FulltechDescription")) ? p["FulltechDescription"].ToString() : "";
                result.MfrLongDescription = (p.ContainsKey("MfrLongDescription")) ? p["MfrLongDescription"].ToString() : "";
                result.MfrShortDescription = (p.ContainsKey("MfrShortDescription")) ? p["MfrShortDescription"].ToString() : "";
                result.ThumbnailUrl = (p.ContainsKey("ThumbnailURL")) ? p["ThumbnailURL"].ToString() : "";
                result.ProductName = (p.ContainsKey("ProductName")) ? p["ProductName"].ToString() : "";
                result.StockCode = (p.ContainsKey("StockIndicator_Key")) ? p["StockIndicator_Key"].ToString() : "";
                result.Upc = (p.ContainsKey("UPC")) ? p["UPC"].ToString() : "";
                result.ImageUrl = (p.ContainsKey("LargeImageURL")) ? p["LargeImageURL"].ToString() : "";
                result.SpecificationSheet = (p.ContainsKey("SpecificationURL")) ? p["SpecificationURL"].ToString() : "";
                result.Unspsc = (p.ContainsKey("UNSPSC")) ? p["UNSPSC"].ToString() : "";
                result.Price = (price.ContainsKey("Price")) ? price["Price"].ToString() : "";
                result.PriceUom = (price.ContainsKey("PriceUom")&&price["PriceUom"]!=null) ? price["PriceUom"].ToString() : "";
                result.PriceSource = (price.ContainsKey("PriceSource")&&(price["PriceSource"]!=null)) ? price["PriceSource"].ToString() : "";
                result.UniqueProductID_Key = (p.ContainsKey("UniqueProductID_Key")) ? p["UniqueProductID_Key"].ToString() : "";
                result.CEDProductID_Key = (p.ContainsKey("CEDProductID_Key")) ? p["CEDProductID_Key"].ToString() : "";
                result.LocalProductID_Key = (p.ContainsKey("LocalProductID_Key")) ? p["LocalProductID_Key"].ToString() : "";
                result.CusPartNum = (p.ContainsKey("CustomerPartNumber_Key")) ? p["CustomerPartNumber_Key"].ToString() : "";
                result.CusPartDesc = (p.ContainsKey("CustomerPartDescription")) ? p["CustomerPartDescription"].ToString() : "";
                result.CartonQuantity = (price.ContainsKey("CartonQuantity") && price["CartonQuantity"] != null) ? price["CartonQuantity"].ToString() : "";
                result.SalesMinOrderQuantity = (price.ContainsKey("SalesMinOrderQuantity") && price["SalesMinOrderQuantity"] != null) ? price["SalesMinOrderQuantity"].ToString() : "";
                result.SoldInMultiples = (price.ContainsKey("SoldInMultiples") && price["SoldInMultiples"] != null) ? price["SoldInMultiples"].ToString() : "";
                result.AverageLeadTime = (price.ContainsKey("AverageLeadTime") && price["AverageLeadTime"] != null) ? price["AverageLeadTime"].ToString() : "";
                result.QuantityOnHand = (price.ContainsKey("QuantityOnHand") && price["QuantityOnHand"] != null) ? price["QuantityOnHand"].ToString() : "";
                lstProduct.Add(result);
            }
            return lstProduct;
        }

        /// <summary>
        /// For Use with SSL authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
