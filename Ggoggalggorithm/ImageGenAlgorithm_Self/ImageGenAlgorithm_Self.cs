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

        private LinkedList<ParameterDelegate> testParams;
        private int x;
        private int y;
        private int colorStepAmount;
        private Color currentColor;
        private int step = 0;

        public ImageGenAlgorithm_Self() {
            testParams = new LinkedList<ParameterDelegate>();

            testParams.AddFirst(new ParameterDelegate("Color Step Amount", 10, typeof(int), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test String Parameter", "default value", typeof(string), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Bool Parameter", false, typeof(bool), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Integer Parameter", 99, typeof(int), throwAway));

            colorStepAmount = 10;
            currentColor = Color.Aqua;
        }

        public void LoadImage(Image BaseImage)
        {
            x = (int)BaseImage.Width;
            y = (int)BaseImage.Height;
        }

        public List<Polygon> Step(out double fitness, out int currentStep)
        {
            //Give at least one point of fitness (bigger is better for now)
            fitness = 1;
            this.step++;
            currentStep = this.step;

            Point[] square = { new Point(0, 0), new Point(x, 0), new Point(x, y), new Point(0, y) };
            List<Polygon> listOfGons = new List<Polygon>();
            listOfGons.Add(new Polygon(square, Color.FromArgb(this.currentColor.ToArgb() + this.colorStepAmount)));
            return listOfGons;
        }

        public ICollection<ParameterDelegate> getParameters()
        {
            return testParams;
        }
    }
}
