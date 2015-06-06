using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        //void ImageTransformer(System.Drawing.Image BaseImage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Fitness">How close to finished the transformer believes itself to be. Should return between 0 and 1, with 1 being complete and 0 being a really crappy solution.</param>
        /// <param name="currentStep">Returns how many times the Step function has been called.</param>
        /// <returns></returns>
        //ICollection<System.Windows.Shapes.Polygon> Step(out double Fitness, out int currentStep);

        /// <summary>
        /// Configurable weights, etc, should be handled with ParameterDelegates.
        /// </summary>
        /// <returns></returns>
       // public ICollection<ParameterDelegate> submitParameters();

       // public class ParameterDelegate
       // {
       //     public string name { get; private set; }
       //     public object value { get; set; }
       //     public Type type { get; private set; }
       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name="parameterValue">The value to send to the ImageTransformer instance.</param>
       //     /// <returns>True if the value was accepted.</returns>
       //     public delegate bool commitParameter(object parameterValue);
       //     private commitParameter opToPerform { get; private set; }
       //
       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name="pName">Name of the parameter. Visible to user in GUI.</param>
       //     /// <param name="pValue">Default value of the parameter.</param>
       //     /// <param name="pType">Expected type of the parameter. GUI uses this to create the correct control.</param>
       //     /// <param name="pOpToPerform">The delegate that attempts to set the value on the ImageTransformer instance. Returns false if the value is outside accepted parameters.</param>
       //     public ParameterDelegate(string pName, object pValue, Type pType, commitParameter pOpToPerform)
       //     {
       //         this.name = pName;
       //         this.value = pValue;
       //         this.type = pType;
       //         this.opToPerform = pOpToPerform;
       //     }
       //
       //     public bool commit(object pValue)
       //     {
       //         this.value = pValue;
       //         return opToPerform(value);
       //     }
       //
       //     public bool commit()
       //     {
       //         return opToPerform(value);
       //     }
       // }
    }
}
