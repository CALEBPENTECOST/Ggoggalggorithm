using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenAlgorithmGUI
{
    public partial class Control_Panel : Form
    {
        Image previewImage = Properties.Resources.hoodoo;
        string sourceFileName;

        public Control_Panel()
        {
            InitializeComponent();

            //Lets set the picturebox real quick
            refreshPreviewImage();
        }

        private void refreshPreviewImage()
        {
            pictureBox_imgPreview.Image = previewImage;
        }

        private void button_openFile_Click(object sender, EventArgs e)
        {
            //We want to open a new file!

            //Lets first show the dialog and make sure all is ok
            if(openFileDialog_openSourceImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //We got a file by the looks of it. Lets open it!

                previewImage = Image.FromFile(openFileDialog_openSourceImage.FileName);

                //File open all okay, it seems.
                refreshPreviewImage();
                button_openFile.Text = openFileDialog_openSourceImage.FileName;
                sourceFileName = openFileDialog_openSourceImage.FileName;
            }
        }
    }
}
