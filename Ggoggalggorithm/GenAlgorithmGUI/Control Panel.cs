using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageGenAlgorithmLib;
using Lib = ImageGenAlgorithmLib;
using ImageGenAlgorithm_Self;
using System.IO;

namespace GenAlgorithmGUI
{
    public partial class Control_Panel : Form
    {
        //Image related goodies
        Image previewImage = Properties.Resources.hoodoo;
        string sourceFileName;

        //Parameter list
        Dictionary<Lib.ImageTransformer, List<Lib.ParameterDelegate>> parameterListFromAlgorithm = new Dictionary<Lib.ImageTransformer,List<Lib.ParameterDelegate>>();

        public Control_Panel()
        {
            InitializeComponent();

            //Lets set the picturebox real quick
            refreshPreviewImage();

            //Reset the parameter list real quick like
            resetParameterLists();

            //Reset the algorithm combobox?
            comboBox_algorithms.Items.Clear();
            comboBox_algorithms.Items.AddRange(parameterListFromAlgorithm.Keys.ToArray());
            comboBox_algorithms.SelectedIndex = 0;
           
        }

        private void resetParameterLists()
        {
            //Kill everythign in the dictionary
            parameterListFromAlgorithm = new Dictionary<Lib.ImageTransformer, List<Lib.ParameterDelegate>>();

            //Go though each algorithm
            parameterListFromAlgorithm.Add(new ImageGenAlgorithm_Self.ImageGenAlgorithm_Self(), new List<ParameterDelegate>());

            //Now lets get parameters
            foreach (var alg in parameterListFromAlgorithm.Keys)
            {
                parameterListFromAlgorithm[alg].AddRange(alg.getParameters());
            }
        }

        public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t != baseType &&
                                                  baseType.IsAssignableFrom(t));
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

        private void comboBox_algorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //We selected a new algorithm!
            
            //clear the current table
            tableLayoutPanel_parameters.Controls.Clear();
            tableLayoutPanel_parameters.RowCount = 0;

            int numParamsSoFar = 0;

            //For each of our new parameters...
            foreach(var param in parameterListFromAlgorithm[(Lib.ImageTransformer)comboBox_algorithms.SelectedItem])
            {
                //add a textbox with name
                TextBox T = new TextBox();
                T.Text = param.name;
                T.Enabled = true;
                T.ReadOnly = true;
                T.Size = new Size(((int)tableLayoutPanel_parameters.ColumnStyles[0].Width), T.Size.Height);


                tableLayoutPanel_parameters.RowCount++;
                tableLayoutPanel_parameters.Controls.Add(T, 0, numParamsSoFar);


                //Switch on the type of parameter....
                Type t = param.type;
                if(t == typeof(int))
                {
                    //do int stuff
                    NumericUpDown nud = new NumericUpDown();
                    nud.Value = (int)param.value;
                    tableLayoutPanel_parameters.Controls.Add(nud,1,numParamsSoFar);
                }
                else
                if(t == typeof(string))
                {
                    TextBox tb = new TextBox();
                    tb.Text = (string)param.value;
                    tableLayoutPanel_parameters.Controls.Add(tb,1,numParamsSoFar);
                }
                else
                if(t == typeof(bool))
                {
                    CheckBox cb = new CheckBox();
                    cb.Checked = (bool)param.value;
                    tableLayoutPanel_parameters.Controls.Add(cb,1,numParamsSoFar);
                }

                numParamsSoFar++;
            }
        }
    }
}
