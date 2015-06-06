﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Image;
using System.Windows.Shapes.Polygon;

namespace GenAlgorithmGUI
{
        //We want to always keep track of our source image

        //We want to keep track of all our necessary generated images

        //We need a method to load everything

        //We need a method to perform the next step

        //We need a class that represents a child of the algorithm


    interface ImageTransformer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseImage">The input image.</param>
        /// <param name="?"></param>
        public void ImageTransformer(System.Drawing.Image BaseImage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Fitness">How close to finished the transformer believes itself to be. Should return between 0 and 1, with 1 being complete and 0 being a really crappy solution.</param>
        /// <param name="currentStep">Returns how many times the Step function has been called.</param>
        /// <returns></returns>
        public ICollection<System.Windows.Shapes.Polygon> Step(out double Fitness, out int currentStep);


    }
}
