using ImageGenAlgorithmLib;
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
    public partial class AlgorithmStepForm : Form
    {

        ImageTransformer _theAlgorithm;
        Control_Panel _owner;

        Bitmap _genImage;



        double _currentFitness = -1;
        int _currentStep = 0;

        int currentStep
        {
            get{return _currentStep;}
            set { _currentStep = value; toolStripStatusLabel_step.Text = stepString + _currentStep.ToString(); }
        }

        double currentFitness
        {
            get { return _currentFitness; }
            set { _currentFitness = value; toolStripStatusLabel_fitness.Text = fitnessString + _currentFitness.ToString(); }
        }

        const string stepString = "Current Step: ";
        const string fitnessString = "Current Fitness: ";








        public AlgorithmStepForm(Control_Panel owner, ImageTransformer alg)
        {
            InitializeComponent();

            //Set up owning stuffs
            _theAlgorithm = alg;
            _owner = owner;

            

            _genImage = new Bitmap(_owner.previewImage.Size.Width, _owner.previewImage.Size.Height);

            //Set up picture box...
            //pictureBox_genImage.Size = _owner.previewImage.Size;
            //pictureBox_genImage.BackColor = Color.Black;
            pictureBox_genImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox_genImage.Image = _genImage;

            refreshGUI(new List<ImageGenAlgorithmLib.Polygon>(), 0, 0);

            backgroundWorker_stepProcessor.WorkerReportsProgress = true;
            backgroundWorker_stepProcessor.ProgressChanged += backgroundWorker_stepProcessor_ProgressChanged;


        }



        private void AlgorithmStepForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            //TODO Kill all threads, if I have any
            _owner.Close();
        }



        private void refreshGUI(ICollection<Polygon> stepOutput, double fitness, int cs)
        {
            //Update the step
            currentStep = cs;

            //We only need to draw if the fitness is better
            if (fitness > currentFitness)
            {
                //Fitness is better!
                currentFitness = fitness;

                //Draw the new image
                drawGeneratedImage(stepOutput);
            }

        }



        SolidBrush solidBlack = new SolidBrush(Color.Black);
        
        

        private void drawGeneratedImage(ICollection<Polygon> stepOutput)
        {
            //Take our picture box and draw on it
            using (Graphics g = Graphics.FromImage(_genImage))
            {
                //Draw it all black
                g.FillRectangle(solidBlack, pictureBox_genImage.DisplayRectangle);

                //Now we should draw each polygon
                foreach(var poly in stepOutput)
                {
                    g.FillPolygon(new SolidBrush(poly.baseColor), poly.vertices.ToArray());
                }

            }

            pictureBox_genImage.Image = _genImage;
        }


        private void button_stepOnce_Click(object sender, EventArgs e)
        {
            //Set the stepmode and step
            _currentStepMode = StepMode.ONCE;
            backgroundWorker_stepProcessor.RunWorkerAsync();


            
        }



        private void button_nextBest_Click(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            //A stop simply tells the background worker to safely stop
            backgroundWorker_stepProcessor.CancelAsync();
        }

        private enum StepMode
        {
            NONE,
            ONCE,
            NEXTBEST,
            CONTINUAL
        }

        private class StepState
        {
            public double fitnessState;
            public int stepState;
            public ICollection<ImageGenAlgorithmLib.Polygon> polygonState;
            public StepState(double f, int s, ICollection<ImageGenAlgorithmLib.Polygon> p)
            {
                fitnessState = f;
                stepState = s;
                polygonState = p;
            }
        }

        private StepMode _currentStepMode = StepMode.NONE;
        private void backgroundWorker_stepProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            //When the background worker is told to work, it will start stepping and drawing

            //Or behavior is determined by the step mode
            switch (_currentStepMode)
            {
                case StepMode.NONE:
                    //Do nothing
                    break;
                case StepMode.ONCE:
                    //Do one step

                    //Tell the algorithm to step
                    double fitness;
                    int cs;
                    var stepOutput = _theAlgorithm.Step(out fitness, out cs);

                    //And report the progress
                    backgroundWorker_stepProcessor.ReportProgress(0, new StepState(fitness, cs, stepOutput));



                    break;
                case StepMode.NEXTBEST:
                    //Go continually, but then stop once a better fit is found
                    break;
                case StepMode.CONTINUAL:
                    //Go continually, and only stop when cancelled
                    break;
                default:
                    //Do nothing
                    break;
            }

            //We should only get here when we are done performing steps
        }


        void backgroundWorker_stepProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //This basically gets called whenever we are ready to update the GUI
            var state = e.UserState as StepState;

            //Now we refresh the GUI
            refreshGUI(state.polygonState, state.fitnessState, state.stepState);
        }


        
    }
}
