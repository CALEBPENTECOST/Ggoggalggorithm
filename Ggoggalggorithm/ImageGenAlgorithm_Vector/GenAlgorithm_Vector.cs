using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using ImageGenAlgorithmLib;


namespace ImageGenAlgorithm_Vector
{
    public class GenAlgorithm_Vector : ImageGenAlgorithmLib.ImageTransformer
    {

        //Some constant values
        protected const int MAXIMUM_POLYGONS = 10000; //Ten thousand
        protected const int MAXIMUM_POINTS = 15; //only 15 for now
        protected const int MIN_PERCENT = 1;
        protected int MAX_PERCENT = 100;
        protected int MAX_POINT_MAG = 500; 
        protected int MAX_POINT_ANG = 360; //2pi


        //Our parameters
        public List<ParameterDelegate> testParams { get; set; }
        //Lock parameters after the first step
        bool paramsLocked = false;
        //The random number generator
        protected Random r;

        //IMAGE PARAMETERS
        int _width;
        int _height;
        Image _theImage;
        int _currentFitness = 0;
        int _currentStep = 0;

        //POLYGON VALUES
        protected int alivePolygons = 0;
        protected int POLYGON_ALPHA = 50;






        //A constructor
        public GenAlgorithm_Vector()
        {
            testParams = new List<ParameterDelegate>();

            Random r = new Random();

            //Random Generator Seed
            testParams.Add(new ParameterDelegate("Random Seed", r.Next().ToString(), typeof(string), pd_setSeed));

            //Polygon settings
            testParams.Add(new ParameterDelegate("Maximum # of polygons", 500, typeof(int), pd_setMaxPolygons));
            testParams.Add(new ParameterDelegate("Maximum # of points per polygon", 7, typeof(int), pd_setMaxPoints));

            //Mutation/Reproduction settings
            testParams.Add(new ParameterDelegate("New Polygon Rate (%)", 30, typeof(int), pd_setNewPolyRate));
            testParams.Add(new ParameterDelegate("Remove Polygon Rate (%)", 5, typeof(int), pd_setRemovePolyRate));
            testParams.Add(new ParameterDelegate("Add Point Rate (%)", 30, typeof(int), pd_setAddPointRate));
            testParams.Add(new ParameterDelegate("Remove Point Rate (%)", 5, typeof(int), pd_setRemovePointRate));

            testParams.Add(new ParameterDelegate("Polygon Mutation Rate (color)", 10, typeof(int), pd_setPolyColorMutationRate));
            testParams.Add(new ParameterDelegate("Color Mutation amount (red %)", 5, typeof(int), pd_setColorMutationRed));
            testParams.Add(new ParameterDelegate("Color Mutation amount (green %)", 5, typeof(int), pd_setColorMutationGreen));
            testParams.Add(new ParameterDelegate("Color Mutation amount (blue %)", 5, typeof(int), pd_setColorMutationBlue));

            testParams.Add(new ParameterDelegate("Point Mutation Rate (magnitude)", 5, typeof(int), pd_setPointMutationRateMag));
            testParams.Add(new ParameterDelegate("Point Mutation Rate (angle)", 5, typeof(int), pd_setPointMutationRateAng));
            testParams.Add(new ParameterDelegate("Magnitude Mutation amount (% max)", 5, typeof(int), pd_setPointMutationAmountMag));
            testParams.Add(new ParameterDelegate("Angle Mutation amount (% max)", 5, typeof(int), pd_setPointMutationAmountAng));

            //New polygon settings
            testParams.Add(new ParameterDelegate("# Points in new Polygon", 5, typeof(int), pd_setNumPointsNewPoly));

        }


        #region Parameter Delegates
        private bool pd_setNumPointsNewPoly(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //greater than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;

            //Less than 15 (for now)
            if (paramValue > MAXIMUM_POINTS)
                return false;

            //Else, lets use it
            numPointsNewPoly = paramValue;

            return true;
            
        }

        private bool pd_setPointMutationAmountAng(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT%
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationAmountAng = paramValue;
            return true;
        }

        private bool pd_setPointMutationAmountMag(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT%
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationAmountMag = paramValue;
            return true;
        }

        private bool pd_setPointMutationRateAng(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT%
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationRateAng = paramValue;
            return true;
        }

        private bool pd_setPointMutationRateMag(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT%
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationRateMag = paramValue;
            return true;
        }

        private bool pd_setColorMutationBlue(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;


            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationAmountBlue = paramValue;
            return true;
        }

        private bool pd_setColorMutationGreen(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationAmountGreen = paramValue;
            return true;
        }

        private bool pd_setColorMutationRed(object parameterValue)
        {
            if (paramsLocked)
                return false;
            //Get the value
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationAmountRed = paramValue;
            return true;
        }

        private bool pd_setPolyColorMutationRate(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            pointMutationRateColor = paramValue;
            return true;
        }

        private bool pd_setRemovePointRate(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            polyRemovePointRate = paramValue;
            return true;
        }

        private bool pd_setAddPointRate(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            polyAddPointRate = paramValue;
            return true;
        }

        private bool pd_setRemovePolyRate(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            polyRemovePolyRate = paramValue;
            return true;
        }

        private bool pd_setNewPolyRate(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;


            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than MAX_PERCENT
            if (paramValue > MAX_PERCENT)
                return false;

            //use it
            polyCreatePolyRate = paramValue;
            return true;
        }

        private bool pd_setMaxPoints(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;

            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than 100
            if (paramValue > MAXIMUM_POINTS)
                return false;

            //use it
            polyMaxPoints = paramValue;
            return true;
        }

        private bool pd_setMaxPolygons(object parameterValue)
        {
            if (paramsLocked)
                return false;
            int paramValue = (int)parameterValue;


            //More than MIN_PERCENT
            if (paramValue < MIN_PERCENT)
                return false;
            //Less than 100
            if (paramValue > MAXIMUM_POLYGONS)
                return false;

            //use it
            polyMaxPolygons = paramValue;
            return true;


        }

        private bool pd_setSeed(object parameterValue)
        {
            if (paramsLocked)
                return false;
            string paramValue = (string)parameterValue;

            r = new Random(paramValue.GetHashCode());
            return true;
        }
#endregion Parameter Delegates

        //A list of polygons
        protected List<VectorPolygon> allPolygons;
        protected int pointMutationAmountAng;
        protected int numPointsNewPoly;
        protected int pointMutationAmountMag;
        protected int pointMutationRateAng;
        protected int pointMutationRateMag;
        protected int pointMutationAmountBlue;
        protected int pointMutationAmountGreen;
        protected int pointMutationAmountRed;
        protected int pointMutationRateColor;
        protected int polyRemovePointRate;
        protected int polyAddPointRate;
        protected int polyRemovePolyRate;
        protected int polyCreatePolyRate;
        protected int polyMaxPoints;
        protected int polyMaxPolygons;


        public class VectorPolygon
        {
            //A vector polygon needs to be created and know its owner
            public VectorPolygon(GenAlgorithm_Vector owner)
            {
                _owner = owner;

                //Also reset myself?
                this.resetState(false);
            }
            //A vector polygon has an origin point
            int origin_x, origin_y;

            //It also has a color
            Color polygonColor;

            //A vector polygon has a list vector magnitues
            List<double> vectorMagnitudes = new List<double>();

            //A vetor polygon has a list of vector angles (as a percent of 0 to 2pi)
            List<double> vectorAnglePercent = new List<double>();

            //A vector polygon needs to know how to turn on or off
            public void resetState(bool show)
            {
                //Either way, remove all of the mags and percents
                origin_x = 0;
                origin_y = 0;
                polygonColor = Color.Black;

                vectorMagnitudes.Clear();
                vectorAnglePercent.Clear();
                _owner.alivePolygons--;

                if(show || _owner.alivePolygons <= 0)
                {
                    //We need to create a new polygon!
                    //Give a random origin within the bounds of the image
                    origin_x = _owner.r.Next(_owner._theImage.Width);
                    origin_y = _owner.r.Next(_owner._theImage.Height);

                    //And a random color to start
                    polygonColor = Color.FromArgb(_owner.POLYGON_ALPHA, _owner.r.Next(255), _owner.r.Next(255), _owner.r.Next(255));

                    //Create a set of points and mags
                    int currentNumPoints = 0;
                    for (int i = 0; i < _owner.polyMaxPoints; i++)
                    {
                        //Add a new point with contents?
                        if (currentNumPoints < _owner.numPointsNewPoly)
                        {
                            currentNumPoints++;
                            vectorMagnitudes.Add(_owner.r.NextDouble() * _owner.MAX_POINT_MAG);
                            vectorAnglePercent.Add(_owner.r.NextDouble() * 100);
                        }
                        else
                        {
                            //add a boring point
                            vectorMagnitudes.Add(0);
                            vectorAnglePercent.Add(0);
                        }
                    }
                }
                else
                {
                    //Do nothing. Its not like we are going to make a polygon to kill immediately
                }
            }

            //Are we a dead polygon?
            public bool vectorOff()
            {
                return vectorMagnitudes.Count == 0;
            }

            //A vector polygon needs a way to determine all of its indices
            public List<System.Drawing.Point> getAllPoints()
            {
                List<System.Drawing.Point> points = new List<System.Drawing.Point>();
                //We need to iterate through all of the points...
                //Note that the origin point isnt an actual point, jsut the start of how we genreate points
                int currentX = origin_x;
                int currentY = origin_y;


                for(int i = 0; i < vectorMagnitudes.Count; i++)
                {
                    //We need to calculate the new x and the new y
                    var angle = Math.Cos((Math.PI * 2) * (vectorAnglePercent[i] / _owner.MAX_PERCENT));
                    var translation = (vectorMagnitudes[i] * angle);
                    int newX = (int)( translation+ currentX);
                    int newY = (int)((vectorMagnitudes[i] * Math.Sin((Math.PI * 2) * (vectorAnglePercent[i] / _owner.MAX_PERCENT))) + currentY);

                    points.Add(new System.Drawing.Point(newX, newY));

                    //And set our "current" values to continue the process later
                    currentX = newX;
                    currentY = newY;
                }

                //Return the list we created
                return points;
                
            }

            //A vector polygon needs to know how to reproduce

            //A vector polygon needs to know how to mutate

            internal GenAlgorithm_Vector _owner { get; set; }

            //A vector polygon needs to know how to get a polygon list version of itself
            internal Polygon getPolygon()
            {
                //Get a list of points
                var points = getAllPoints();

                Polygon p = new Polygon();
                p.vertices = points;

                return p;
            }
        }



        public void LoadImage(Image BaseImage)
        {
            if (paramsLocked)
                return;

            _width = (int)BaseImage.Width;
            _height = (int)BaseImage.Height;
            _theImage = BaseImage;
        }

        public List<ImageGenAlgorithmLib.Polygon> Step(out double fitness, out int currentStep)
        {
            fitness = _currentFitness;
            currentStep = _currentStep;
            //Do we have an image?
            if (_theImage == null)
                return null;

            //First time actions?
            if (!paramsLocked)
            {
                allPolygons = new List<VectorPolygon>();
                //On the first step, we need to create a polygon (minimum 1 required)
                allPolygons.Add(new VectorPolygon(this));

                //Finally, lock the parameters
                paramsLocked = true;
            }
            //Time to start processing
            _currentStep++;
            _currentFitness = _currentStep;

            //Perform reproduction on winners

            //Add polygons?

            //Remove Polygons?

            //Perform mutation on remaining

            //Return the best fit
            List<Polygon> polys = new List<Polygon>();
            polys.Add(allPolygons[0].getPolygon());
            return polys;
        }

        public ICollection<ImageGenAlgorithmLib.ParameterDelegate> getParameters()
        {
            return testParams;
        }

    }
}
