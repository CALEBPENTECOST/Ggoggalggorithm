using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenAlgorithmGUI
{
    public partial class ImageViewBox : UserControl
    {

        public enum ViewBoxType
        {
            none = 0,
            image = 1,
            polygons = 2
        }


        public ImageViewBox()
        {
            InitializeComponent();
        }

    }
}


