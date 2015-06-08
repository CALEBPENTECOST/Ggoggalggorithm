using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace ImageGenAlgorithm_Vector
{
    class GenAlgorithm_Vector : ImageGenAlgorithmLib.ImageTransformer
    {



        public class VectorPolygon
        {
            //A vector polygon needs to 
            public VectorPolygon(GenAlgorithm_Vector owner)
            {
                _owner = owner;
            }
            //A vector polygon has an origin point
            int origin_x, origin_y;

            //A vector polygon has a list vector magnitues
            List<double> vectorMagnitudes;

            //A vetor polygon has a list of vector angles (as a percent of 0 to 2pi)
            List<double> vectorAnglePercent;

            //A vector polygon needs a way to determine all of its indices

            //A vector polygon needs to know how to reproduce

            //A vector polygon needs to know how to mutate

            internal GenAlgorithm_Vector _owner { get; set; }
        }



        public void LoadImage(Image BaseImage)
        {
            throw new NotImplementedException();
        }

        public List<ImageGenAlgorithmLib.Polygon> Step(out double fitness, out int currentStep)
        {
            throw new NotImplementedException();
        }

        public ICollection<ImageGenAlgorithmLib.ParameterDelegate> getParameters()
        {
            throw new NotImplementedException();
        }
    }
}
