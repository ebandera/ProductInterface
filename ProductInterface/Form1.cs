using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LabelPrintInterface;
using System.Diagnostics;
using System.Drawing.Printing;


namespace ProductInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        
        string strFilePath = "";
        string strInputPath = "";
        string strOutputPath = "";
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                progressBar1.Maximum = 5;
                progressBar1.Step = 1;
                progressBar1.PerformStep();
                RegReader rr = new RegReader(@"Software\CED\CEDLabelPrint");
                if(!rr.Test("PCNum")||!rr.Test("AcctNum"))
                {
                    MessageBox.Show("Looks like you haven't configured your PC and Account yet.  The account is required to determine customer specific information like customer part numbers or pricing.  If you won't need that, then just fill in the COD account and that will work fine.");
                    Settings s = new Settings();
                    s.ShowDialog();
                }
                string rrPCNum = rr.Read("PCNum");
                string rrAcctNum = rr.Read("AcctNum");
                int rrOffsetX = 0;
                Int32.TryParse(rr.Read("OffsetX", "0"), out rrOffsetX);
                int rrOffsetY = 0;
                Int32.TryParse(rr.Read("OffsetY", "0"), out rrOffsetY);
                bool rrRetrieveAddlData = true;
                Boolean.TryParse(rr.Read("RetrieveAddlData", "True"), out rrRetrieveAddlData);
                bool rrRequireAddlData = false;
                Boolean.TryParse(rr.Read("RequireAddlData", "False"), out rrRequireAddlData);




                //read the sheet to a list
                //====================================================================

                DAL dataLayer = new ProductInterface.DAL();
                ColumnMaps maps = new ColumnMaps();
                maps.LoadXMLFromString(dataLayer.GetMapsByName(cboMappings.SelectedItem.ToString()));
                string fileType= GetFileTypeFromExtensionAndTemplate(Path.GetExtension(strFilePath),maps);
                List<List<string>> lstSheet = new List<List<string>>();

                if (fileType=="xL")
                {
                    ExcelReader r = new ExcelReader();
                    lstSheet = r.ReadTheSheetXlsx(strFilePath);
                }
                else if (fileType=="csv")
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, ",");
                }
                else if (fileType=="tabDelimited")
                {
                    TextReader r = new ProductInterface.TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, "\t");
                }
                else if(fileType=="legacyXL")
                {
                    LegacyExcelReader r = new LegacyExcelReader();
                    lstSheet = r.ReadTheSheetXls(strFilePath);
                }
                else if(fileType=="fixedWidth")
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadFixedWidth(strFilePath, maps.maps[0].fixedWidth);//this second variable reads the column layout from the xml

                }
                else
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, ",");
                }

                progressBar1.PerformStep();

                // List<List<string>> lstSheet = r.ReadTheSheet(strFilePath);
                //validate sheet and turn into Products Object
                Products ps = new Products();
               
               
               

                //develop logic to determine file type

                if (maps.ValidateSheet(lstSheet))//when validating the sheet also, the active map is determined
                {
                    ps = ps.LoadSheet(lstSheet, maps.GetActiveMap());
                }
                else
                {
                    Exception ex = new Exception("Invalid Input Mapping.  Likely headers in the data file don't match the mapping file.");
                    throw ex;
                }
                if (rrRetrieveAddlData== true)
                {
                    //send the list of products to the API getting back json
                    ProductDataLayer data = new ProductDataLayer();
                    int tempCount = 0;
                    int pageCount = 1;
                    Products lstAPIResult = new Products();
                    do
                    {
                        string results = data.GetProductDetailsForListAsJson(rr.Read("PCNum"), rr.Read("AcctNum"), ps,100,pageCount);
                        //put the results into it's own list of products
                        Products tempAPIResult = data.JsonToProductList(results);
                        //counts how many products in this set
                        tempCount = tempAPIResult.Count;
                        //adds them to the main list
                        lstAPIResult.AddRange(tempAPIResult);
                        //Merge the lists - essentially providing API data to the initial list map is required to determine overrides
                       
                        pageCount++;
                        
                    } while (tempCount > 0); //this does run requests until a 0 product return happens
                    //then merges the existing products with the list
                    ps.Merge(lstAPIResult, maps.GetActiveMap());
                }
                progressBar1.PerformStep();         

                Products pdsToPrint;
                if (rrRequireAddlData == true)
                {
                    pdsToPrint = ps.Valid();
                    TextReader tr = new TextReader();
                    tr.WriteProducts(ps.Invalid().FlattenProductMfrCat(), ",");
                }
                else
                {
                    pdsToPrint = ps;

                }
                progressBar1.PerformStep();
                string outboundTemplate = dataLayer.GetOutputByName(cboOutput.SelectedItem.ToString());
                outboundTemplate = TemplateItem.ReplaceXMLLogoTemplateValue(outboundTemplate, rr.Read("logo","Images\\ced_web.jpg"));
                
                try
                {
                    rr.Add("InputFormat", cboMappings.SelectedItem.ToString());
                    rr.Add("OutputFormat", cboOutput.SelectedItem.ToString());
                    string printerName;
                    LabelPrint lp = new LabelPrint(outboundTemplate, pdsToPrint.FlattenProduct(outboundTemplate), rrOffsetX, rrOffsetY);
                    if (!rr.Test("PrinterName"))
                    {
                        printerName = lp.Print(true);
                    }
                    else
                    {
                        printerName= rr.Read("PrinterName");
                        PrintDocument pd = lp.GetPrintDocument(printerName);
                        printerName = lp.Print(true, pd);
                    }
                    rr.Add("PrinterName", printerName);



                    progressBar1.PerformStep();
                    MessageBox.Show("Done");
                    progressBar1.Value = 0;
                }
                catch
                {
                    Exception ex = new Exception("Most Likely a problem with your Label Output Template.");
                    throw ex;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            try
            {
                DAL dataLayer = new DAL();
                List<string> lstMappings = dataLayer.GetListOfMappings();
                cboMappings.Items.Clear();
                foreach (string map in lstMappings)
                {
                    cboMappings.Items.Add(map);
                }
                if (lstMappings.Count > 0) { cboMappings.SelectedIndex = 0; }

                List<string> lstOutput = dataLayer.GetListOfOutputs();
                cboOutput.Items.Clear();
                foreach (string label in lstOutput)
                {

                    cboOutput.Items.Add(label);

                }
                if (lstOutput.Count > 0) { cboOutput.SelectedIndex = 0; }
                RegReader rr = new RegReader(@"Software\CED\CEDLabelPrint");
                cboMappings.SelectedIndex = GetIndexForValue(cboMappings, rr.Read("InputFormat"));
                cboOutput.SelectedIndex = GetIndexForValue(cboOutput, rr.Read("OutputFormat"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Problem Connecting");
                if (MessageBox.Show("Do you want me to automatically install the database engine?", "Install?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("AccessDatabaseEngine.exe");
                }
                this.Close();
            }
        }


        private void btnLoadFile_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Excel Files|*.xlsx|Excel 2003 Files|*.xls|CSV File|*.csv|Tab Delimited|*.txt|All Files|*.*";
            openFileDialog1.Title = "Upload File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFilePath = openFileDialog1.FileName;
                txtFileName.Text = Path.GetFileName(strFilePath);
            }
        }

      

        private void addInputFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            
                openFileDialog1.Filter = "xml File|*.xml";
                openFileDialog1.Title = "Upload Input Template";
                string filename = "blank";
                string filepath = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    filename = Path.GetFileNameWithoutExtension(filepath);
                    DAL datalayer = new DAL();
                    string xmlData = File.ReadAllText(filepath);
                    datalayer.InsertMaps(filename, xmlData);
                    Reload();
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBarcodeFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "xml File|*.xml";
                openFileDialog1.Title = "Upload Output Format";
                string filename = "blank";
                string filepath = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    filename = Path.GetFileNameWithoutExtension(filepath);
                    DAL datalayer = new DAL();
                    string xmlData = File.ReadAllText(filepath);
                    datalayer.InsertOutput(filename, xmlData);
                    Reload();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btnDelInput_Click(object sender, EventArgs e)
        {
            try
            {


                DAL datalayer = new DAL();
                // string xmlData = File.ReadAllText(filepath);
                if (MessageBox.Show("Are You sure you want to delete " + cboMappings.SelectedItem.ToString() + " from your Map List?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datalayer.DeleteMaps(cboMappings.SelectedItem.ToString());
                }

                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelOutput_Click(object sender, EventArgs e)
        {
            try
            {
                DAL datalayer = new DAL();
                // string xmlData = File.ReadAllText(filepath);
                if (MessageBox.Show("Are You sure you want to delete " + cboOutput.SelectedItem.ToString() + " from your Output Templates?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    datalayer.DeleteOutput(cboOutput.SelectedItem.ToString());
                }

                Reload();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void settingsAndConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();
            Reload();
        }
        private int GetIndexForValue(ComboBox c,string value)
        {
            int index = 0;
            int counter = 0;
            foreach(Object o in c.Items)
            {
                if (o.ToString() == value)
                {
                    index = counter;
                }
                counter++;

            }
            return index;
        }

        private void productManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CED\\InstructionsLabelPrinter.docx";
            System.Diagnostics.Process.Start(fullPath);
        }
        private string GetFileTypeFromExtensionAndTemplate(string ext,ColumnMaps maps)
        {
            string extension = Path.GetExtension(strFilePath);
            string strResultingFileType = "xL";
            if (extension == ".xlsx") { strResultingFileType = "xL"; }
            else if (extension == ".csv") { strResultingFileType = "csv"; }
           
            else if (extension == ".xls") { strResultingFileType = "legacyXL"; }
            else if (extension == "") { Exception ex = new Exception("Please browse to the correct data file"); throw ex; }
            else  //this should cover all .txt files, and all different extensions.  In this case, the map is the boss, and there should only be 1 per file
            {
                string fileType = maps.maps[0].fileType;
                switch (fileType)
                {
                    case "tabDemited":
                        strResultingFileType = "tabDelimited";
                        break;
                    case "csv":
                        strResultingFileType = "csv";
                        break;
                    case "fixedWidth":
                        strResultingFileType = "fixedWidth";
                        break;
                    default:
                        strResultingFileType = "tabDelimited";
                        break;
                 }
            }
            return strResultingFileType;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                progressBar1.Maximum = 5;
                progressBar1.Step = 1;
                progressBar1.PerformStep();
                RegReader rr = new RegReader(@"Software\CED\CEDLabelPrint");
                if (!rr.Test("PCNum") || !rr.Test("AcctNum"))
                {
                    MessageBox.Show("Looks like you haven't configured your PC and Account yet.  The account is required to determine customer specific information like customer part numbers or pricing.  If you won't need that, then just fill in the COD account and that will work fine.");
                    Settings s = new Settings();
                    s.ShowDialog();
                }
                string rrPCNum = rr.Read("PCNum");
                string rrAcctNum = rr.Read("AcctNum");
                int rrOffsetX = 0;
                Int32.TryParse(rr.Read("OffsetX", "0"), out rrOffsetX);
                int rrOffsetY = 0;
                Int32.TryParse(rr.Read("OffsetY", "0"), out rrOffsetY);
                bool rrRetrieveAddlData = true;
                Boolean.TryParse(rr.Read("RetrieveAddlData", "True"), out rrRetrieveAddlData);
                bool rrRequireAddlData = false;
                Boolean.TryParse(rr.Read("RequireAddlData", "False"), out rrRequireAddlData);




                //read the sheet to a list
                //====================================================================

                DAL dataLayer = new ProductInterface.DAL();
                ColumnMaps maps = new ColumnMaps();
                maps.LoadXMLFromString(dataLayer.GetMapsByName(cboMappings.SelectedItem.ToString()));
                string fileType = GetFileTypeFromExtensionAndTemplate(Path.GetExtension(strFilePath), maps);
                List<List<string>> lstSheet = new List<List<string>>();

                if (fileType == "xL")
                {
                    ExcelReader r = new ExcelReader();
                    lstSheet = r.ReadTheSheetXlsx(strFilePath);
                }
                else if (fileType == "csv")
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, ",");
                }
                else if (fileType == "tabDelimited")
                {
                    TextReader r = new ProductInterface.TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, "\t");
                }
                else if (fileType == "legacyXL")
                {
                    LegacyExcelReader r = new LegacyExcelReader();
                    lstSheet = r.ReadTheSheetXls(strFilePath);
                }
                else if (fileType == "fixedWidth")
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadFixedWidth(strFilePath, maps.maps[0].fixedWidth);//this second variable reads the column layout from the xml

                }
                else
                {
                    TextReader r = new TextReader();
                    lstSheet = r.ReadTheSheet(strFilePath, ",");
                }



                // List<List<string>> lstSheet = r.ReadTheSheet(strFilePath);
                //validate sheet and turn into Products Object
                Products ps = new Products();




                //develop logic to determine file type

                if (maps.ValidateSheet(lstSheet))//when validating the sheet also, the active map is determined
                {
                    ps = ps.LoadSheet(lstSheet, maps.GetActiveMap());
                }
                else
                {
                    Exception ex = new Exception("Invalid Input Mapping.  Likely headers in the data file don't match the mapping file.");
                    throw ex;
                }
                if (rrRetrieveAddlData == true)
                {
                    //send the list of products to the API getting back json
                    ProductDataLayer data = new ProductDataLayer();
                    int tempCount = 0;
                    int pageCount = 1;
                    Products lstAPIResult = new Products();
                    do
                    {
                        string results = data.GetProductDetailsForListAsJson(rr.Read("PCNum"), rr.Read("AcctNum"), ps, 100, pageCount);
                        //put the results into it's own list of products
                        Products tempAPIResult = data.JsonToProductList(results);
                        //counts how many products in this set
                        tempCount = tempAPIResult.Count;
                        //adds them to the main list
                        lstAPIResult.AddRange(tempAPIResult);
                        //Merge the lists - essentially providing API data to the initial list map is required to determine overrides

                        pageCount++;

                    } while (tempCount > 0); //this does run requests until a 0 product return happens
                                             //then merges the existing products with the list
                                             //ps.Merge(lstAPIResult, maps.GetActiveMap());
                    TextReader tr = new TextReader();
                    tr.WriteProducts(ps.FlattenProductCustom(), ",");
                }


               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

