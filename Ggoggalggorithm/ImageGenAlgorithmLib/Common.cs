using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenAlgorithmLib
{
    class Common
    {
        class GgoggalggorithmException : Exception { }
        class SolutionNotFound : GgoggalggorithmException { }
        class InvalidSourceImage : GgoggalggorithmException { }




 //      public class CalebsGUINeedsTheseParameters
 //      {
 //          public string myName;
 //          public object myParameterValue;
 //          public delegate void actOnMe(object param);
 //
 //          public enum myType
 //          {
 //              mt_string = 0,
 //              mt_int = 1
 //          }
 //          private myType paramType;
 //
 //          private actOnMe ParameterOperation;
 //
 //          public CalebsGUINeedsTheseParameters(actOnMe opToPerform, myType mt)
 //          {
 //              ParameterOperation = opToPerform;
 //              paramType = mt;
 //          }
 //
 //          public void perFormAction()
 //          {
 //              ParameterOperation(myParameterValue);
 //          }
 //
 //
 //      }
 //
 //      public class ErinsClass
 //      {
 //          string x = "";
 //
 //          public void appendMe(object s)
 //          {
 //              x += s;
 //          }
 //      }
 //
 //
 //
 //      public void submitParameters()
 //      {
 //          //Make an instance of erins algorithms...
 //          ErinsClass ec = new ErinsClass();
 //
 //          //Get the first parameter....
 //          CalebsGUINeedsTheseParameters param1 = new CalebsGUINeedsTheseParameters(ec.appendMe, CalebsGUINeedsTheseParameters.myType.mt_int);
 //
 //
 //          //Put shit into my parameter
 //          param1.myParameterValue = "hurr";
 //
 //          //Lets do whatever we are supposed to with this parameter
 //          param1.perFormAction();
 //      }
    }
}



/*
 * using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenAlgorithmGUI
{
    public partial class ImageViewBox : UserControl
    {

        public enum ViewBoxType
        {
            none = 0,
            image = 1,
            polygons = 2
        }


        public ImageViewBox()
        {
            InitializeComponent();
        }

        public class CalebsGUINeedsTheseParameters<GenType>
        {
            public string myName;
            public GenType myParameterValue;
            public delegate void actOnMe<GenType>(GenType param);

            Type expectedParamType;

            private enum myType
            {
                mt_string = 0,
                mt_int = 1
            }
            public myType paramType;

            private actOnMe<GenType> ParameterOperation;

            public CalebsGUINeedsTheseParameters(actOnMe<GenType> opToPerform, myType mt)
            {
                ParameterOperation = opToPerform;
                paramType = mt;
            }

            public void perFormAction()
            {
                ParameterOperation(myParameterValue);
            }

            public Type getGenType()
            {
                return myParameterValue.GetType();
            }

            
        }

        public class ErinsClass
        {
            string x = "";

            public void appendMe(object s)
            {
                if (s is string)
                {
                    x += s;
                }
                else
                {
                    throw new Exception("poopie");
                }
            }

            public List<Type> parameterTypes()
            {
                var v = new List<Type>();

                v.Add(typeof(Int32));

                return v;
            }

            public List<T> getParams<T>()
            {
                List<T> tempList = new List<T>();

                if (typeof(T) == typeof(int))
                {
                    //Do int things
                    ((List<int>)tempList).Add(3);
                }
                else
                {
                    //strings perhaps?
                }
                return tempList;

            }
        }



        public void submitParameters()
        {
            //Make an instance of erins algorithms...
            ErinsClass ec = new ErinsClass();

            //Get the first parameter....
           //CalebsGUINeedsTheseParameters param1 = new CalebsGUINeedsTheseParameters(ec.appendMe);
            var v = ec.parameterTypes();
            foreach (var v2 in v)
            {
                ec.getParams<typeof(v2)>();
            }



            //Put shit into my parameter
            param1.myParameterValue = "hurr";

            //Lets do whatever we are supposed to with this parameter
            param1.perFormAction();
        }
    }
}

//*/
