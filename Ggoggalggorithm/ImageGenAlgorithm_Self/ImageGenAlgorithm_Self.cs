using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenAlgorithmLib;
using System.Drawing;

namespace ImageGenAlgorithm_Self
{
    class ImageGenAlgorithm_Self : ImageTransformer
    {
        public bool throwAway(object parameterValue)
        {
            return true;
        }

        private LinkedList<ParameterDelegate> testParams;
        private int x;
        private int y;
        private int step = 0;

        public ImageGenAlgorithm_Self() {
            testParams = new LinkedList<ParameterDelegate>();

            testParams.AddFirst(new ParameterDelegate("Test String Parameter", "default value", typeof(string), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Bool Parameter", false, typeof(bool), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Integer Parameter", 99, typeof(int), throwAway));
        }

        public void LoadImage(Image BaseImage)
        {
            x = (int)BaseImage.HorizontalResolution;
            y = (int)BaseImage.VerticalResolution;
        }

        public ICollection<Polygon> Step(out double fitness, out int currentStep)
        {
            fitness = 0.0;
            this.step++;
            currentStep = this.step;

            Point[] square = { new Point(0, 0), new Point(x, 0), new Point(x, y), new Point(0, y) };
            LinkedList<Polygon> listOfGons = new LinkedList<Polygon>();
            listOfGons.AddFirst(new Polygon(square, Color.Aqua));
            return listOfGons;
        }

        public ICollection<ParameterDelegate> submitParameters()
        {
            return testParams;
        }
    }
}
