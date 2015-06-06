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
    }
}
