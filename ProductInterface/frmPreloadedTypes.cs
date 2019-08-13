using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductInterface
{
    public partial class frmPreloadedTypes : Form
    {
        public frmPreloadedTypes()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Save()
        {
            return true;
        }

        private void frmPreloadedTypes_Load(object sender, EventArgs e)
        {
            DAL db = new ProductInterface.DAL();
            Dictionary<string, bool> inputs = db.SelectPreconfiguredInputs();
            Dictionary<string, bool> outputs = db.SelectPreconfiguredOutputs();

            foreach (var i in inputs)
            {
                switch (i.Key)
                {
                    case "InputVMI":
                        chkInputVMI.Checked = !i.Value;
                        break;
                    case "InputVMIImage":
                        chkInputVMIImage.Checked = !i.Value;
                        break;
                    case "InputMfrCat":
                        chkInputMfrCat.Checked = !i.Value;
                        break;
                    case "InputCEDXls":
                        chkInputCEDXls.Checked = !i.Value;
                        break;
                    case "InputCED001":
                        chkInputCED001.Checked = !i.Value;
                        break;
                    case "InputCEDHotSheet":
                        chkInputCEDHotSheet.Checked = !i.Value;
                        break;
                    default:
                        break;


                }
            }

            foreach (var j in outputs)
                switch (j.Key)
                {
                    case "OutputAvery5160":
                        chkOutput5160.Checked = !j.Value;
                        break;
                    case "OutputAvery5162":
                        chkOutput5162.Checked = !j.Value;
                        break;
                    case "OutputPanduit2x3Sheets":
                        chkOutput2x3Sheet.Checked = !j.Value;
                        break;
                    case "OutputPanduit2x3SheetsMinimal":
                        chkOutput2x3MinSheet.Checked = !j.Value;
                        break;
                    case "OutputPanduit1x3Sheets":
                        chkOutput1x3Sheet.Checked = !j.Value;
                        break;
                    case "OutputPanduit1x2Sheets":
                        chkOutput1x2Sheet.Checked = !j.Value;
                        break;
                    case "OutputPanduit2x3Spool":
                        chkOutput2x3Spool.Checked = !j.Value;
                        break;
                    case "OutputPanduit2x3SpoolMinimal":
                        chkOutput2x3MinSpool.Checked = !j.Value;
                        break;
                    case "OutputPanduit1x3Spool":
                        chkOutput1x3Spool.Checked = !j.Value;
                        break;
                    case "OutputPanduit1x2Spool":
                        chkOutput1x2Spool.Checked = !j.Value;
                        break;
                    case "OutputDymo1x3Spool":
                        chkOutputDymo1x3.Checked = !j.Value;
                        break;
                    case "OutputAvery5162Image":
                        chkOutput5162Image.Checked = !j.Value;
                        break;
                    default:
                        break;


                }


        }


        private void chkOutput_Click(object sender, EventArgs e)
        {
            DAL db = new DAL();
            CheckBox snd = (CheckBox)sender;
            switch (snd.Name)
            {
                case "chkOutput5160":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputAvery5160", !snd.Checked);
                    break;
                case "chkOutput5162":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputAvery5162", !snd.Checked);
                    break;
                case "chkOutput2x3Sheet":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit2x3Sheets", !snd.Checked);
                    break;
                case "chkOutput2x3MinSheet":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit2x3SheetsMinimal", !snd.Checked);
                    break;
                case "chkOutput1x3Sheet":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit1x3Sheets", !snd.Checked);
                    break;
                case "chkOutput1x2Sheet":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit1x2Sheets", !snd.Checked);
                    break;
                case "chkOutput2x3Spool":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit2x3Spool", !snd.Checked);
                    break;
                case "chkOutput2x3MinSpool":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit2x3SpoolMinimal", !snd.Checked);
                    break;
                case "chkOutput1x3Spool":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit1x3Spool", !snd.Checked);
                    break;
                case "chkOutput1x2Spool":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputPanduit1x2Spool", !snd.Checked);
                    break;
                case "chkOutputDymo1x3":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputDymo1x3Spool", !snd.Checked);
                    break;
                case "chkOutput5162Image":
                    db.UpdateVisibilityOfPreconfiguredOutput("OutputAvery5162Image", !snd.Checked);
                    break;
                default:
                    break;

            }

        }
        private void chkInput_Click(object sender, EventArgs e)
        {
            DAL db = new DAL();
            CheckBox snd = (CheckBox)sender;
            switch (snd.Name)
            {
                case "chkInputVMI":
                    db.UpdateVisibilityOfPreconfiguredInput("InputVMI", !snd.Checked);
                    break;
                case "chkInputVMIImage":
                    db.UpdateVisibilityOfPreconfiguredInput("InputVMIImage", !snd.Checked);
                    break;
                case "chkInputMfrCat":
                    db.UpdateVisibilityOfPreconfiguredInput("InputMfrCat", !snd.Checked);
                    break;
                case "chkInputCEDXls":
                    db.UpdateVisibilityOfPreconfiguredInput("InputCEDXls", !snd.Checked);
                    break;
                case "chkInputCED001":
                    db.UpdateVisibilityOfPreconfiguredInput("InputCED001", !snd.Checked);
                    break;
                case "chkInputCEDHotSheet":
                    db.UpdateVisibilityOfPreconfiguredInput("InputCEDHotSheet", !snd.Checked);
                    break;
                default:
                    break;


            }
        }
    }
}
