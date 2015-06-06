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

        LinkedList<ParameterDelegate> testParams;

        public ImageGenAlgorithm_Self() {
            testParams = new LinkedList<ParameterDelegate>();

            testParams.AddFirst(new ParameterDelegate("Test String Parameter", "default value", typeof(string), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Bool Parameter", false, typeof(bool), throwAway));
            testParams.AddFirst(new ParameterDelegate("Test Integer Parameter", 99, typeof(int), throwAway));
        }

        public void ImageTransformer(Image BaseImage)
        {
            throw new NotImplementedException();
        }

        public ICollection<System.Windows.Shapes.Polygon> Step(out double Fitness, out int currentStep)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParameterDelegate> submitParameters()
        {
            return testParams;
        }
    }
}
