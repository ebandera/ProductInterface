using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInterface
{
    class Product
    {
        public Product() { }
        public Product(string mfrCode, string catalogNum)
        {
            this._strMfrCode = mfrCode;
            this._strCatalogNumber = catalogNum;
        }
        private string _strFullTechDescription = "";
        private string _strMfrLongDescription = "";
        private string _strMfrShortDescription = "";
        private string _strProductName = "";
        private string _strStockCode = "";
        private string _strImageUrl = "";
        private string _strThumbnailUrl = "";
        private string _strUnspsc = "";
        private string _strUpc = "";
        private string _strMfrCode = "";
        private string _strCatalogNumber = "";
        private string _strCedMfrCatalog = "";
        private string _strLocalCatalog_Key = "";
        private string _strMfrCatalog = "";
        private string _strSpecificationSheet = "";
        private string _strPrice = "";
        private string _strPriceUom = "";
        private string _strPriceSource = "";
        private string _strCEDProductID_Key = "";
        private string _strUniqueProductID_Key = "";
        private string _strMin = "";
        private string _strMax = "";
        private string _strBinLocation = "";
        private string _strCusPartNum = "";
        private string _strCusPartDesc = "";
        private string _strVendorNum = "";
        private string _strItemNum = "";
        private string _strFlex1 = "";
        private string _strFlex2 = "";
        private string _strFlex3 = "";
        private string _strFlex4 = "";
        private string _strCartonQuantity = "";
        private string _strSalesMinOrderQuantity = "";
        private string _strSoldInMultiples = "";
        private string _strAverageLeadTime = "";
        private string _strQuantityOnHand = "";
        private bool _blnIsValid = false;
        private string _strPreferredCatalogNumber = "MfrCatalog";
        private static List<string> lstOverrideEntities = new List<string>();
        public static void ConfigureOverrides(ColumnMap map)
        {
            foreach (ColumnMapItem item in map.Items)
            {
                if (item.OverRideMode == true) { lstOverrideEntities.Add(item.DataEntityName); }
            }
        }

        private string tempFullTechDescription;
        private string tempMfrLongDescription;
        private string tempMfrShortDescription;
        private string tempProductName;
        private string tempStockCode;
        private string tempImageUrl;
        private string tempThumbnailUrl;
        private string tempUnspsc;
        private string tempUpc;
        private string tempMfrCode;
        private string tempCatalogNumber;
        private string tempMfrCatalog;
        private string tempCedMfrCatalog;
        private string tempLocalCatalog_Key;
        private string tempSpecificationSheet;
        private string tempPrice;
        private string tempPriceUom;
        private string tempPriceSource;
        private string tempCEDProductID_Key;
        private string tempUniqueProductID_Key;
        private string tempMin;
        private string tempMax;
        private string tempBinLocation;
        private string tempCusPartNum;
        private string tempCusPartDesc;
        private string tempVendorNum;
        private string tempItemNum;
        private string tempFlex1;
        private string tempFlex2;
        private string tempFlex3;
        private string tempFlex4;
        private string tempCartonQuantity = "";
        private string tempSalesMinOrderQuantity = "";
        private string tempSoldInMultiples = "";
        private string tempAverageLeadTime = "";
        private string tempQuantityOnHand = "";

        public void Merge(Product p)
        {

            //put all the current values into temporary placeholders
            tempFullTechDescription = FullTechDescription;
            tempMfrLongDescription = MfrLongDescription;
            tempMfrShortDescription = MfrShortDescription;
            tempProductName = ProductName;
            tempStockCode = StockCode;
            tempImageUrl = ImageUrl;
            tempThumbnailUrl = ThumbnailUrl;
            tempUnspsc = Unspsc;
            tempUpc = Upc;
            tempMfrCode = MfrCode;
            tempCatalogNumber = CatalogNumber;
            tempMfrCatalog = MfrCatalog;
            tempCedMfrCatalog = CEDMfrCatalog;
            tempLocalCatalog_Key = LocalCatalog_Key;
            tempSpecificationSheet = SpecificationSheet;
            tempPrice = Price;
            tempPriceSource = PriceSource;
            tempPriceUom = PriceUom;
            tempCEDProductID_Key = CEDProductID_Key;
            tempUniqueProductID_Key = UniqueProductID_Key;
            tempMin = Min;
            tempMax = Max;
            tempBinLocation = BinLocation;
            tempCusPartNum = CusPartNum;
            tempCusPartDesc = CusPartDesc;
            tempVendorNum = VendorNum;
            tempItemNum = ItemNum;
            tempFlex1 = Flex1;
            tempFlex2 = Flex2;
            tempFlex3 = Flex3;
            tempFlex4 = Flex4;
            tempCartonQuantity = CartonQuantity;
            tempSalesMinOrderQuantity = SalesMinOrderQuantity;
            tempSoldInMultiples = SoldInMultiples;
            tempAverageLeadTime = AverageLeadTime;
            tempQuantityOnHand = QuantityOnHand;


            //go ahead and default, give the pricing API the ability to overwrite the sheet properties
            //the commented lines are for reference showing that the pricing API will never have values for those
            //it is however important to have the temp records in case someone uses the overrideMode = true
            this.FullTechDescription = p.FullTechDescription;
            this.MfrLongDescription = p.MfrLongDescription;
            this.MfrShortDescription = p.MfrShortDescription;
            this.ProductName = p.ProductName;
            this.StockCode = p.StockCode;
            this.ImageUrl = p.ImageUrl;
            this.ThumbnailUrl = p.ThumbnailUrl;
            this.Unspsc = p.Unspsc;
            this.Upc = p.Upc;
            // this.MfrCode = p.MfrCode;
            this.CatalogNumber =p.CatalogNumber;
            this.MfrCatalog = p.MfrCatalog;
            this.CEDMfrCatalog = p.CEDMfrCatalog;
            this.LocalCatalog_Key = p.LocalCatalog_Key;
            this.SpecificationSheet = p.SpecificationSheet;
            this.Price = p.Price;
            this.PriceSource = p.PriceSource;
            this.PriceUom = p.PriceUom;
            this.CEDProductID_Key = p.CEDProductID_Key;
            this.UniqueProductID_Key = p.UniqueProductID_Key;
            //this.Min = p.Min;
            //this.Max = p.Max;
            //this.BinLocation = p.BinLocation;
            this.CusPartNum = p.CusPartNum;
            this.CusPartDesc = p.CusPartDesc;
            //this.VendorNum = p.VendorNum;
            //this.ItemNum = p.ItemNum;
            //this.Flex1 = p.Flex1;
            //this.Flex2 = p.Flex2;
            //this.Flex3 = p.Flex3;
            //this.Flex4 = p.Flex4;
            this.CartonQuantity = p.CartonQuantity;
            this.SalesMinOrderQuantity = p.SalesMinOrderQuantity;
            this.SoldInMultiples = p.SoldInMultiples;
            this.AverageLeadTime = p.AverageLeadTime;
            this.QuantityOnHand = p.QuantityOnHand;

            //switch it back if the original is on the list
            foreach (string dataitem in lstOverrideEntities)
            {
                string currentTempValueOriginal = GetTempValueByPropertyName(dataitem);
                string currentTempValueAPI = GetValueByPropertyName(dataitem);
                //since we're in the list of "overrides" we give preference to the sheet
                //but if the sheet is blank, don't use it
                if (currentTempValueOriginal != "")
                {
                    SetValueByPropertyName(dataitem, GetTempValueByPropertyName(dataitem));
                }
            }

        }
        //all the getters and setters
        public string FullTechDescription
        {
            get { return _strFullTechDescription; }
            set { _strFullTechDescription = value; }
        }
        public string MfrLongDescription
        {
            get { return _strMfrLongDescription; }
            set { _strMfrLongDescription = value; }
        }
        public string MfrShortDescription
        {
            get { return _strMfrShortDescription; }
            set { _strMfrShortDescription = value; }
        }
        public string ProductName
        {
            get { return _strProductName; }
            set { _strProductName = value; }
        }
        public string StockCode
        {
            get { return _strStockCode; }
            set { _strStockCode = value; }
        }
        public string ImageUrl
        {
            get { return _strImageUrl; }
            set { _strImageUrl = value; }
        }
        public string ThumbnailUrl
        {
            get { return _strThumbnailUrl; }
            set { _strThumbnailUrl = value; }
        }
        public string Unspsc
        {
            get { return _strUnspsc; }
            set { _strUnspsc = value; }
        }
        public string Upc
        {
            get { return _strUpc; }
            set { _strUpc = value; }
        }
        public string MfrCode
        {
            get { return _strMfrCode; }
            set { _strMfrCode = value; }
        }
        public string CatalogNumber
        {
            get { return GetValueByPropertyName(PreferredCatalogNumber); }
            set { SetValueByPropertyName(PreferredCatalogNumber,value); }
        }
        public string MfrCatalog
        {
            get { return _strMfrCatalog; }
            set { _strMfrCatalog = value; }

        }
        public string CEDMfrCatalog
        {
            get {return _strCedMfrCatalog; }
            set { _strCedMfrCatalog = value; }

        }
        public string LocalCatalog_Key
        {
            get { return _strLocalCatalog_Key; }
            set { _strLocalCatalog_Key = value; }
        }
        public string SpecificationSheet
        {
            get { return _strSpecificationSheet; }
            set { _strSpecificationSheet = value; }
        }
        public string Price
        {
            get { return _strPrice; }
            set { _strPrice = value; }
        }
        public string PriceUom
        {
            get { return _strPriceUom; }
            set { _strPriceUom = value; }
        }
        public string PriceSource
        {
            get { return _strPriceSource; }
            set { _strPriceSource = value; }
        }
        public string CEDProductID_Key
        {
            get { return _strCEDProductID_Key; }
            set { _strCEDProductID_Key = value; }
        }
        public string UniqueProductID_Key
        {
            get { return _strUniqueProductID_Key; }
            set { _strUniqueProductID_Key = value; }
        }
        public string Min
        {
            get { return _strMin; }
            set { _strMin = value; }
        }
        public string Max
        {
            get { return _strMax; }
            set { _strMax = value; }
        }

        public string BinLocation
        {
            get { return _strBinLocation; }
            set { _strBinLocation = value; }
        }
        
        public string CusPartNum
        {
            get { return _strCusPartNum; }
            set { _strCusPartNum = value; }
        }
        
        public string CusPartDesc
        {
            get { return _strCusPartDesc; }
            set { _strCusPartDesc = value; }
        }

        public string VendorNum
        {
            get { return _strVendorNum; }
            set
            { _strVendorNum=value;
                if(this.ItemNum.Length==5 && this.Upc=="")
                {
                    this.Upc = this.VendorNum + this.ItemNum;
                }
            }
        }
        public string ItemNum
        {
            get { return _strItemNum; }
            set { _strItemNum = value;
                if(this.VendorNum.Length==6 && this.Upc=="")
                {
                    this.Upc = this.VendorNum + this.ItemNum;
                }

            }
        }

        public string Flex1
        {
            get { return _strFlex1; }
            set { _strFlex1 = value; }
        }
        public string Flex2
        {
            get { return _strFlex2; }
            set { _strFlex2 = value; }
        }
        public string Flex3
        {
            get { return _strFlex3; }
            set { _strFlex3 = value; }
        }
        public string Flex4
        {
            get { return _strFlex4; }
            set { _strFlex4 = value; }
        }
        public string CartonQuantity
        {
            get { return _strCartonQuantity; }
            set { _strCartonQuantity = value; }
        }
        public string SalesMinOrderQuantity
        {
            get { return _strSalesMinOrderQuantity; }
            set { _strSalesMinOrderQuantity = value; }
        }
        public string SoldInMultiples
        {
            get { return _strSoldInMultiples; }
            set { _strSoldInMultiples = value; }
        }
        public string AverageLeadTime
        {
            get { return _strAverageLeadTime; }
            set { _strAverageLeadTime = value; }
        }
        public string QuantityOnHand
        {
            get { return _strQuantityOnHand; }
            set { _strQuantityOnHand = value; }
        }
        public string PreferredCatalogNumber
        {
            get { return _strPreferredCatalogNumber;}
            set { _strPreferredCatalogNumber = value; }
        }



        public Boolean IsValid
        {
            get { return _blnIsValid; }
            set { _blnIsValid = value; }
        }

        public void SetValueByPropertyName(string propertyName,string value)
        {
            switch(propertyName)
            {
                case "FullTechDescription":
                    this.FullTechDescription = value;
                    break;
                case "MfrLongDescription":
                    this.MfrLongDescription = value;
                    break;
                case "MfrShortDescription":
                    this.MfrShortDescription = value;
                    break;
                case "ProductName":
                    this.ProductName = value;
                    break;
                case "StockCode":
                    this.StockCode = value;
                    break;
                case "ImageUrl":
                    this.ImageUrl = value;
                    break;
                case "Thumbnailurl":
                    this.ThumbnailUrl = value;
                    break;
                case "Unspsc":
                    this.Unspsc = value;
                    break;
                case "Upc":
                    this.Upc = value;
                    break;
                case "MfrCode":
                    this.MfrCode = value;
                    break;
                case "CatalogNumber":
                    this.CatalogNumber = value;
                    break;
                case "MfrCatalog":
                    this.MfrCatalog = value;
                    break;
                case "CEDMfrCatalog":
                    this.CEDMfrCatalog = value;
                    break;
                case "LocalCatalog_Key":
                    this.LocalCatalog_Key = value;
                    break;
                case "SpecificationSheet":
                    this.SpecificationSheet = value;
                    break;
                case "Price":
                    this.Price = value;
                    break;
                case "PriceUom":
                    this.PriceUom = value;
                    break;
                case "PriceSource":
                    this.PriceSource = value;
                    break;
                case "CEDProductID_Key":
                    this.CEDProductID_Key = value;
                    break;
                case "UniqueProductID_Key":
                    this.UniqueProductID_Key = value;
                    break;
                case "Min":
                    this.Min = value;
                    break;
                case "Max":
                    this.Max = value;
                    break;
                case "BinLocation":
                    this.BinLocation = value;
                    break;
                case "CusPartNum":
                    this.CusPartNum = value;
                    break;
                case "CusPartDesc":
                    this.CusPartDesc = value;
                    break;
                case "VendorNum":
                    this.VendorNum = value;
                    break;
                case "ItemNum":
                    this.ItemNum = value;
                    break;
                case "Flex1":
                    this.Flex1 = value;
                    break;
                case "Flex2":
                    this.Flex2 = value;
                    break;
                case "Flex3":
                    this.Flex3 = value;
                    break;
                case "Flex4":
                    this.Flex4 = value;
                    break;
                case "CustPartNum":
                    this.CusPartNum = value;
                    break;
                case "CustPartDesc":
                    this.CusPartDesc = value;
                    break;
                case "CartonQuantity":
                    this.CartonQuantity = value;
                    break;
                case "SalesMinOrderQuantity":
                    this.SalesMinOrderQuantity = value;
                    break;
                case "SoldInMultiples":
                    this.SoldInMultiples = value;
                    break;
                case "AverageLeadTime":
                    this.AverageLeadTime = value;
                    break;
                case "QuantityOnHand":
                    this.QuantityOnHand = value;
                    break;
                default:
                    break;



            }
        }

        public string GetValueByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "FullTechDescription":
                    return this.FullTechDescription;
                case "MfrLongDescription":
                    return this.MfrLongDescription;
                case "MfrShortDescription":
                    return this.MfrShortDescription;
                case "ProductName":
                    return this.ProductName;
                case "StockCode":
                    return this.StockCode;
                case "ImageUrl":
                    return this.ImageUrl;
                case "ThumbnailUrl":
                    return this.ThumbnailUrl;
                case "Unspsc":
                    return this.Unspsc;
                case "Upc":
                    return this.Upc;
                case "MfrCode":
                    return this.MfrCode;
                case "CatalogNumber":
                    return this.CatalogNumber;
                case "MfrCatalog":
                    return this.MfrCatalog;
                case "CEDMfrCatalog":
                    return this.CEDMfrCatalog;
                case "LocalCatalog_Key":
                    return this.LocalCatalog_Key;
                case "SpecificationSheet":
                    return this.SpecificationSheet;
                case "Price":
                    return this.Price;
                case "PriceUom":
                    return this.PriceUom;
                case "PriceSource":
                    return this.PriceSource;
                case "CEDProductID_Key":
                    return this.CEDProductID_Key;
                case "UniqueProductID_Key":
                    return this.UniqueProductID_Key;
                case "Min":
                    return this.Min;
                case "Max":
                    return this.Max;
                case "BinLocation":
                    return this.BinLocation;
                case "CusPartNum":
                    return this.CusPartNum;
                case "CusPartDesc":
                    return this.CusPartDesc;
                case "VendorNum":
                    return this.VendorNum;
                case "ItemNum":
                    return this.ItemNum;
                case "Flex1":
                    return this.Flex1;
                case "Flex2":
                    return this.Flex2;
                case "Flex3":
                    return this.Flex3;
                case "Flex4":
                    return this.Flex4;
                case "CustPartNum":
                    return this.CusPartNum;
                case "CustPartDesc":
                    return this.CusPartDesc;
                case "CartonQuantity":
                    return this.CartonQuantity;
                case "SalesMinOrderQuantity":
                    return this.SalesMinOrderQuantity;
                case "SoldInMultiples":
                    return this.SoldInMultiples;
                case "AverageLeadTime":
                    return this.AverageLeadTime;
                case "QuantityOnHand":
                    return this.QuantityOnHand;

                default:
                    return "";
                    break;
            }
        }
        private string GetTempValueByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "FullTechDescription":
                    return this.tempFullTechDescription;
                case "MfrLongDescription":
                    return this.tempMfrLongDescription;
                case "MfrShortDescription":
                    return this.tempMfrShortDescription;
                case "ProductName":
                    return this.tempProductName;
                case "StockCode":
                    return this.tempStockCode;
                case "ImageUrl":
                    return this.tempImageUrl;
                case "Thumbnailurl":
                    return this.tempThumbnailUrl;
                case "Unspsc":
                    return this.tempUnspsc;
                case "Upc":
                    return this.tempUpc;
                case "MfrCode":
                    return this.tempMfrCode;
                case "CatalogNumber":
                    return this.tempCatalogNumber;
                case "MfrCatalog":
                    return this.tempMfrCatalog;
                case "CedMfrCatalog":
                    return this.tempCedMfrCatalog;
                case "LocalCatalog_Key":
                    return this.tempLocalCatalog_Key;
              
                case "SpecificationSheet":
                    return this.tempSpecificationSheet;
                case "Price":
                    return this.tempPrice;
                case "PriceUom":
                    return this.tempPriceUom;
                case "PriceSource":
                    return this.tempPriceSource;
                case "CEDProductID_Key":
                    return this.tempCEDProductID_Key;
                case "UniqueProductID_Key":
                    return this.tempUniqueProductID_Key;
                case "Min":
                    return this.tempMin;
                case "Max":
                    return this.tempMax;
                case "BinLocation":
                    return this.tempBinLocation;
                case "CusPartNum":
                    return this.tempCusPartNum;
                case "CusPartDesc":
                    return this.tempCusPartDesc;
                case "VendorNum":
                    return this.tempVendorNum;
                case "ItemNum":
                    return this.tempItemNum;
                case "Flex1":
                    return this.tempFlex1;
                case "Flex2":
                    return this.tempFlex2;
                case "Flex3":
                    return this.tempFlex3;
                case "Flex4":
                    return this.tempFlex4;
                case "CustPartNum":
                    return this.tempCusPartNum;
                case "CustPartDesc":
                    return this.tempCusPartDesc;
                case "CartonQuantity":
                    return this.tempCartonQuantity;
                case "SalesMinOrderQuantity":
                    return this.tempSalesMinOrderQuantity;
                case "SoldInMultiples":
                    return this.tempSoldInMultiples;
                case "AverageLeadTime":
                    return this.tempAverageLeadTime;
                case "QuantityOnHand":
                    return this.tempQuantityOnHand;
                default:
                    return "";
                  
            }
        }
    }
}
