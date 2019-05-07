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

namespace ProductInterface
{
    public partial class frmImages : Form
    {
        public frmImages()
        {
            InitializeComponent();
        }
        public bool blnHasFile;
        public string imgFile;
        public string imgDesc;

        private void frmImages_Load(object sender, EventArgs e)
        {
            string[] myImageFileNames = Directory.GetFiles("Images");
            for (int i = 0; i < myImageFileNames.Length; i++)
            {
                myImageFileNames[i] = myImageFileNames[i].Replace("Images\\", "");
                myImageFileNames[i] = myImageFileNames[i].Replace(".jpg", "");
                listBox1.Items.Add(myImageFileNames[i]);
            }

        }

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            blnHasFile = false;
            this.Close();
        }

        private void btnUseThis_Click(object sender, EventArgs e)
        {
            blnHasFile = true;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            imgDesc = listBox1.SelectedItem.ToString();
            string relImage = "Images\\" + imgDesc + ".jpg";
            if (File.Exists(relImage))
            {
                //imgFile = Path.GetFullPath(relImage);//for full path save
                imgFile = relImage;
                pictureBox1.Image = Image.FromFile(imgFile);
            }
        }
    }
}
