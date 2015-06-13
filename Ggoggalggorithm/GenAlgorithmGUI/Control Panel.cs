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
        public Bitmap previewImage = Properties.Resources.hoodoo;
        public string sourceFileName;

        //Parameter list
        Dictionary<Lib.ImageTransformer, List<Lib.ParameterDelegate>> parameterListFromAlgorithm = new Dictionary<Lib.ImageTransformer,List<Lib.ParameterDelegate>>();
        Dictionary<Control, Lib.ParameterDelegate> parameterFromControl = new Dictionary<Control, ParameterDelegate>();

        AlgorithmStepForm ags;

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
            parameterListFromAlgorithm.Add(new ImageGenAlgorithm_Vector.GenAlgorithm_Vector(), new List<ParameterDelegate>());

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

                previewImage = new Bitmap(Image.FromFile(openFileDialog_openSourceImage.FileName));
                

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
                    nud.Minimum = -1000;
                    nud.Maximum = 1000;

                    nud.Value = (int)param.value;
                    parameterFromControl.Add(nud, param);
                    nud.ValueChanged += parameterChanged;
                    tableLayoutPanel_parameters.Controls.Add(nud,1,numParamsSoFar);
                }
                else
                if(t == typeof(string))
                {
                    TextBox tb = new TextBox();
                    tb.Text = (string)param.value;
                    parameterFromControl.Add(tb, param);
                    tb.TextChanged += parameterChanged;
                    tableLayoutPanel_parameters.Controls.Add(tb,1,numParamsSoFar);
                }
                else
                if(t == typeof(bool))
                {
                    CheckBox cb = new CheckBox();
                    cb.Checked = (bool)param.value;
                    parameterFromControl.Add(cb, param);
                    cb.CheckedChanged += parameterChanged;
                    tableLayoutPanel_parameters.Controls.Add(cb,1,numParamsSoFar);
                }

                numParamsSoFar++;
            }
        }

        void parameterChanged(object sender, EventArgs e)
        {
            //We need to get the correct parameter from the sender...
            Lib.ParameterDelegate theParam = parameterFromControl[sender as Control];

            //Now we set the parameter value
            if (theParam.type == typeof(int))
            {
                theParam.value = Convert.ToInt32((sender as NumericUpDown).Value);
            }
            else
                if (theParam.type == typeof(string))
                {
                    theParam.value = (sender as TextBox).Text;
                }
                else
                    if(theParam.type == typeof(bool))
                    {
                        theParam.value = (sender as CheckBox).Checked;
                    }
        }

        private void button_applyParams_Click(object sender, EventArgs e)
        {
            //When we apply, we "lock in" all of the parameters, and get ready to run the algorithm
            foreach(var v in parameterListFromAlgorithm[comboBox_algorithms.SelectedItem as ImageTransformer])
            {
                //For each parameter...
                if (!v.commit())
                {
                    //Just crash out, I dont have time for this
                    MessageBox.Show("Parameter Commit Error");
                    return;
                }
            }

            //Now that our parameters are set up, lets get ready to run the algorithm
            comboBox_algorithms.Enabled = false;
            groupBox_parameters.Enabled = false;
            //groupBox_preview.Enabled = false;
            button_openFile.Enabled = false;
            button_restoreParams.Enabled = false;
            button_applyParams.Enabled = false;

            //Now we open a new window, and set it up with the algorithm
            ImageTransformer it = comboBox_algorithms.SelectedItem as ImageTransformer;
            it.LoadImage((Bitmap)previewImage.Clone());
            ags = new AlgorithmStepForm(this, it);
            
            ags.Show();


            //TODO Make all forms close together



        }
        bool closedAgs = false;
        private void Control_Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!closedAgs)
            {
                closedAgs = true;
                if (ags != null)
                    ags.Close();
            }
        }
    }
}
