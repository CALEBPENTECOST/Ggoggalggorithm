using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenAlgorithmLib;
using System.Drawing;

namespace ImageGenAlgorithm_Self
{
    public class ImageGenAlgorithm_Self : ImageTransformer
    {
        public bool throwAway(object parameterValue)
        {
            return true;
        }

        public bool setColorStep(object parameterValue)
        {
            this.colorStepAmount = (int)parameterValue;
            return true;
        }

        public bool setSeed(object parameterValue)
        {
            this.seed = (int)parameterValue;
            return true;
        }


        private LinkedList<ParameterDelegate> testParams;
        private int x;
        private int y;
        private Point center;
        private int colorStepAmount;
        private Color currentColor;
        private int step = 0;
        private int seed = 0;
        private Random rnd;

        public ImageGenAlgorithm_Self() {
            testParams = new LinkedList<ParameterDelegate>();

            testParams.AddFirst(new ParameterDelegate("Color Step Amount", 10, typeof(int), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test String Parameter", "default value", typeof(string), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Bool Parameter", false, typeof(bool), throwAway));
            testParams.AddFirst(new ParameterDelegate("Random Seed", 0, typeof(int), setSeed));

            colorStepAmount = 10;
            currentColor = Color.Aqua;
        }

        public void LoadImage(Bitmap BaseImage)
        {
            x = (int)BaseImage.Width;
            y = (int)BaseImage.Height;
            center = new Point(x/2, y/2);
            rnd = new Random(seed);
        }

        public List<Polygon> Step(out double fitness, out int currentStep)
        {
            //Give at least one point of fitness (bigger is better for now)
            fitness = 1;
            this.step++;
            currentStep = this.step;
            fitness = this.step++;

            //background
            Point[] bgSquare = { new Point(0, 0), new Point(x, 0), new Point(x, y), new Point(0, y) };
            List<Polygon> listOfGons = new List<Polygon>();
            this.currentColor = Color.FromArgb(this.currentColor.ToArgb() + this.colorStepAmount);

            //test moving polygon
            List<Point> pulseSquare = new List<Point>();
            pulseSquare.Add(new Point((int)(center.X), (int)(center.Y)));
            pulseSquare.Add(new Point((int)(center.X + 40*Math.Cos(step)), (int)(center.Y)));
            pulseSquare.Add(new Point((int)(center.X + 40*Math.Cos(step)), (int)(center.Y + 40*Math.Cos(step))));
            pulseSquare.Add(new Point((int)(center.X), (int)(center.Y + 40*Math.Cos(step))));

            listOfGons.Add(new Polygon(bgSquare, currentColor));
            listOfGons.Add(new Polygon(pulseSquare, Color.HotPink));
            return listOfGons;
        }

        public ICollection<ParameterDelegate> getParameters()
        {
            return testParams;
        }
    }
}
