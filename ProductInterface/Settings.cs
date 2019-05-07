using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Net;

namespace ProductInterface
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        string defaultImagePath = "Images\\ced_web.jpg";
        string savedImagePath = "";
        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
               // RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\CEDLabelPrint", false);
                RegReader rr = new RegReader(@"Software\CED\CEDLabelPrint");
                savedImagePath = rr.Read("logo", defaultImagePath);
                pictureBox1.Image = Image.FromFile(savedImagePath);
                txtPCNum.Text = rr.Read("PCNum");
                if (txtPCNum.Text == "") { txtPCNum.Text = GetPCNumberFromIPAddress(GetIPAddress()); }
                txtAcctNum.Text = rr.Read("AcctNum");
                decimal tempX = 0;
                Decimal.TryParse(rr.Read("OffsetX", "0"), out tempX);
                numOffsetX.Value = tempX;
                decimal tempY = 0;
                Decimal.TryParse(rr.Read("OffsetY", "0"), out tempY);
                numOffsetY.Value = tempY;
                bool tempRetrieve = true;
                Boolean.TryParse(rr.Read("RetrieveAddlData","True").ToString(), out tempRetrieve);
                chkAddlDataRetrieve.Checked = tempRetrieve;
                //if the first check is not checked, disable the second checkbox
                if(tempRetrieve==false){chkAddlDataRequire.Enabled = false;}
                else { chkAddlDataRequire.Enabled = true; }
                bool tempRequire = false;
                Boolean.TryParse(rr.Read("RequireAddlData","False"), out tempRequire);
                chkAddlDataRequire.Checked = tempRequire;
            }
            catch
            {
                Exception ex = new Exception("Trouble reading registry");
                throw;
            }
        }
       
        private Boolean SaveSettings()
        {
            if(ValidateInput())
            {
                try
                {
                    RegReader rr = new RegReader(@"Software\CED\CEDLabelPrint");
                    rr.Add("logo", savedImagePath);
                    rr.Add("PCNum", txtPCNum.Text.Trim());
                    rr.Add("AcctNum", txtAcctNum.Text.Trim());
                    rr.Add("OffsetX", numOffsetX.Value.ToString());
                    rr.Add("OffsetY", numOffsetY.Value.ToString());
                    rr.Add("RetrieveAddlData", chkAddlDataRetrieve.Checked.ToString());
                    rr.Add("RequireAddlData", chkAddlDataRequire.Checked.ToString());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }
        //To handle users that close with the x
        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            bool success=SaveSettings();
            if(!success)
            {
                e.Cancel = true;
            }
        }
        //to handle users that click the button
        private void btnClose_Click(object sender, EventArgs e)
        {
            bool success=SaveSettings();
            if (success)
            {
                this.Close();
            }
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
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
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
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
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetIPAddress()
        {
            try
            {
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    // IPHostEntry IP = Dns.GetHostEntry(Dns.GetHostName());
                    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && ip.ToString().Substring(0, 2) == "10")
                        {
                            return ip.ToString();
                        }
                    }
                }
            }
            catch { return ""; }
            return "";
           
           
           
        }
        private string GetPCNumberFromIPAddress(string strIpAddress)
        {
            if(strIpAddress =="") { return ""; }
            string[] split = strIpAddress.Split('.');
            string secondOctet = split[1];
            string thirdOctet = split[2];
            string trimmedSecondOctet = secondOctet;
            if (secondOctet.Length > 2)
            {
                trimmedSecondOctet = secondOctet.Substring(secondOctet.Length - 2, 2);
            }
            string trimmedThirdOctet = thirdOctet;
            if (thirdOctet.Length > 2)
            {
                trimmedThirdOctet = thirdOctet.Substring(thirdOctet.Length - 2, 2);
            }
            string paddedSecondOctet = trimmedSecondOctet.PadLeft(2, '0');
            string paddedThirdOctet = trimmedThirdOctet.PadLeft(2, '0');
            string PCNumber = paddedSecondOctet + paddedThirdOctet;
            return PCNumber;
        }

        private Boolean ValidateInput()
        {
            bool blnValidOverall = true;
            bool blnValidPC = false;//assume invalid
            int tempPCNum = 0;
            if (txtPCNum.Text.Length == 4 && Int32.TryParse(txtPCNum.Text, out tempPCNum))
            {
                blnValidPC = true;
            }
            bool blnValidAcct = false; 
            int tempAcctNum = 0;
            if(txtAcctNum.Text.Length == 5 && Int32.TryParse(txtAcctNum.Text,out tempAcctNum))
            {
                blnValidAcct = true;

            }
            //now go through and see what's invalid and respond to it
            if(blnValidPC==false)
            {
                lblValPC.Visible = true;
                blnValidOverall = false;
            }
            if(blnValidAcct==false)
            {
                lblValAcct.Visible = true;
                blnValidOverall = false;

            }
            return blnValidOverall;


        }

        

        private void txtAcctNum_Enter(object sender, EventArgs e)
        {
            lblValAcct.Visible = false;
        }

        private void txtPCNum_Enter(object sender, EventArgs e)
        {
            lblValPC.Visible = false;
        }

        private void chkAddlDataRetrieve_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAddlDataRetrieve.Checked==true)
            {
                chkAddlDataRequire.Enabled = true;
            }
            else
            {
                chkAddlDataRequire.Checked = false;
                chkAddlDataRequire.Enabled = false;
                
            }
        }

        private void productManualContainsAdditionalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CED\\InstructionsLabelPrinter.docx";
            System.Diagnostics.Process.Start(fullPath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string theImagePath = savedImagePath;
            frmImages im = new frmImages();
            im.ShowDialog();
            if(im.blnHasFile==true)
            {
                savedImagePath = im.imgFile;
            }
            Image img = Image.FromFile(savedImagePath);
            pictureBox1.Image = img;
        }
    }
}
