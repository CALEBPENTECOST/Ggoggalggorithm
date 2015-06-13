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
        protected const int MINIMUM_POLYGONS = 5; //Ten thousand
        protected const int MINIMUM_POINTS = 3; //3 at least
        protected const int MAXIMUM_POINTS = 15; //only 15 for now
        protected const int MAXIMUM_CHILDREN = 5; //Includes the mother, so only 4 possible children
        protected const int MIN_PERCENT = 1;
        protected int MAX_PERCENT = 100;
        protected int MAX_POINT_MAG = 250; 
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
        Bitmap _theImage;
        int _currentFitness = 0;
        int _currentStep = 0;

        //POLYGON VALUES
        protected int alivePolygons = 0;
        protected int POLYGON_ALPHA = 128;






        //A constructor
        public GenAlgorithm_Vector()
        {
            testParams = new List<ParameterDelegate>();

            Random r = new Random();

            //Random Generator Seed
            testParams.Add(new ParameterDelegate("Random Seed", r.Next().ToString(), typeof(string), pd_setSeed));

            //Polygon settings
            testParams.Add(new ParameterDelegate("Maximum # of polygons", 100, typeof(int), pd_setMaxPolygons));
            testParams.Add(new ParameterDelegate("Maximum # of points per polygon", 5, typeof(int), pd_setMaxPoints));

            //Mutation/Reproduction settings
            testParams.Add(new ParameterDelegate("New Polygon Rate (%)", 2, typeof(int), pd_setNewPolyRate));
            testParams.Add(new ParameterDelegate("Remove Polygon Rate (%)", 3, typeof(int), pd_setRemovePolyRate));
            testParams.Add(new ParameterDelegate("Add Point Rate (%)", 2, typeof(int), pd_setAddPointRate));
            testParams.Add(new ParameterDelegate("Remove Point Rate (%)", 3, typeof(int), pd_setRemovePointRate));

            testParams.Add(new ParameterDelegate("Polygon Mutation Rate (color)", 5, typeof(int), pd_setPolyColorMutationRate));
            testParams.Add(new ParameterDelegate("Color Mutation amount (red)", 1, typeof(int), pd_setColorMutationRed));
            testParams.Add(new ParameterDelegate("Color Mutation amount (green)", 1, typeof(int), pd_setColorMutationGreen));
            testParams.Add(new ParameterDelegate("Color Mutation amount (blue)", 1, typeof(int), pd_setColorMutationBlue));

            testParams.Add(new ParameterDelegate("Point Mutation Rate (magnitude)", 10, typeof(int), pd_setPointMutationRateMag));
            testParams.Add(new ParameterDelegate("Point Mutation Rate (angle)", 10, typeof(int), pd_setPointMutationRateAng));
            testParams.Add(new ParameterDelegate("Magnitude Mutation amount (% max)", 2, typeof(int), pd_setPointMutationAmountMag));
            testParams.Add(new ParameterDelegate("Angle Mutation amount (% max)", 2, typeof(int), pd_setPointMutationAmountAng));

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
            if (paramValue < MINIMUM_POINTS)
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


            //More than min plygons
            if (paramValue < MINIMUM_POLYGONS)
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

        //A list of contenders
        protected List<List<VectorPolygon>> allChildren;
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

            //A copy constructor
            public VectorPolygon(VectorPolygon cpy)
            {
                this.copyFrom(cpy);               
            }

            private void copyFrom(VectorPolygon cpy)
            {
                _owner = cpy._owner;

                //Either way, remove all of the mags and percents
                origin_x = cpy.origin_x;
                origin_y = cpy.origin_y;
                polygonColor = cpy.polygonColor;

                vectorMagnitudes = new List<double>(cpy.vectorMagnitudes);
                vectorAnglePercents = new List<double>(cpy.vectorAnglePercents);
                numPoints = cpy.numPoints;

                //Add to the polycount if we arent a null poly
                if (!vectorPolyOff())
                    _owner.alivePolygons++;
            }

            ~VectorPolygon()
            {
                //The destructor resets the polygon ot the off position
                resetState(false);
            }

            //A vector polygon has an origin point
            int origin_x, origin_y;

            //It also has a color
            Color polygonColor;

            //A vector polygon has a list vector magnitues
            List<double> vectorMagnitudes = new List<double>();

            //A vetor polygon has a list of vector angles (as a percent of 0 to 2pi)
            List<double> vectorAnglePercents = new List<double>();

            //A vector algorithm knows how many points it has
            protected int numPoints = 0;

            //The owner of this polygon
            internal GenAlgorithm_Vector _owner { get; set; }

            //A vector polygon needs to know how to turn on or off
            public void resetState(bool show)
            {
                //Either way, remove all of the mags and percents
                origin_x = 0;
                origin_y = 0;
                polygonColor = Color.FromArgb(128, 0, 0, 0);

                //Only add/remove to the count depending on if we existed beforehand
                bool wasOff = false;
                if (vectorPolyOff())
                {
                    wasOff = true;
                }

                //clear everything, kill the alive polygon
                numPoints = 0;
                vectorMagnitudes = new List<double>(new double[_owner.polyMaxPoints]);
                vectorAnglePercents = new List<double>(new double[_owner.polyMaxPoints]);

                //We cleared, if this poly was alive then subtract the count
                if(!wasOff)
                    _owner.alivePolygons--;

                //Now, are we going to show this polygon?
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
                            numPoints++;
                            vectorMagnitudes.Add(_owner.r.NextDouble() * _owner.MAX_POINT_MAG);
                            vectorAnglePercents.Add(_owner.r.NextDouble() * 100);
                        }
                        else
                        {
                            
                            //add a boring point
                            vectorMagnitudes.Add(0);
                            vectorAnglePercents.Add(0);
                        }
                    }

                    //We also add an alive polygon (if we werent alive before
                    if(wasOff)
                        _owner.alivePolygons++;
                }
                else
                {
                    //Do nothing. Its not like we are going to make a polygon to kill immediately
                }
            }

            //Are we a dead polygon?
            public bool vectorPolyOff()
            {
                return numPoints == 0;
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
                    var angle = Math.Cos((Math.PI * 2) * (vectorAnglePercents[i] / _owner.MAX_PERCENT));
                    var translation = (vectorMagnitudes[i] * angle);
                    int newX = (int)( translation+ currentX);
                    int newY = (int)((vectorMagnitudes[i] * Math.Sin((Math.PI * 2) * (vectorAnglePercents[i] / _owner.MAX_PERCENT))) + currentY);

                    points.Add(new System.Drawing.Point(newX, newY));

                    //And set our "current" values to continue the process later
                    currentX = newX;
                    currentY = newY;
                }

                //Return the list we created
                return points;
                
            }

            //A vector polygon needs to know how to reproduce?

            //A vector polygon needs to know how to mutate
            public void mutateSelf()
            {
                //First, lets remove any points
                for (int i = 0; i < _owner.polyMaxPoints; i++)
                {
                    //if the point has content...
                    if (vectorMagnitudes[i] != 0)
                    {
                        if (_owner.r.Next(100) < _owner.polyRemovePointRate)
                        {
                            //remove this point
                            vectorMagnitudes[i] = 0;
                            vectorAnglePercents[i] = 0;
                            numPoints--;
                            break;
                            
                        }
                    }
                }

                //Now lets add points
                for (int i = 0; i < _owner.polyMaxPoints; i++)
                {
                    //if the point has no content...
                    if (vectorMagnitudes[i] == 0)
                    {
                        if (_owner.r.Next(100) < _owner.polyAddPointRate || numPoints <= 0)
                        {
                            //We need to add a point
                            vectorMagnitudes[i] =(_owner.r.NextDouble() * _owner.MAX_POINT_MAG);
                            vectorAnglePercents[i] =(_owner.r.NextDouble() * 100);
                            numPoints++;
                            break;
                        }
                    }
                }

                

                //Now lets mutate the remaining points
                for (int i = 0; i < _owner.polyMaxPoints; i++)
                {
                    //If the point has content...
                    if (vectorMagnitudes[i] == 0)
                    {
                        //Have a chance to change mag
                        if (_owner.r.Next(100) < _owner.pointMutationRateMag)
                        {
                            //Change by plus or minus the amount
                            vectorMagnitudes[i] += (_owner.r.Next(100) > 50) ? _owner.pointMutationAmountMag : -_owner.pointMutationAmountMag;
                        }
                        //Have a chance to change angle
                        if (_owner.r.Next(100) < _owner.pointMutationRateAng)
                        {
                            vectorAnglePercents[i] += (_owner.r.Next(100) > 50) ? _owner.pointMutationAmountAng : -_owner.pointMutationAmountAng;
                        }
                        
                    }
                }

                //Change our color?
                if (!vectorPolyOff())
                {
                    if (_owner.r.Next(100) < _owner.pointMutationRateColor)
                    {
                        int colorSelect = _owner.r.Next(100);
                        bool addAmount = _owner.r.Next(100) > 50;
                        if (colorSelect < 33)
                            //do red
                            polygonColor = Color.FromArgb(polygonColor.A, Math.Min(255,Math.Max(0, polygonColor.R + (addAmount ? _owner.pointMutationAmountRed : -_owner.pointMutationAmountRed))), polygonColor.G, polygonColor.B);
                        else if (colorSelect > 66)
                            //do blue
                            polygonColor = Color.FromArgb(polygonColor.A, polygonColor.R, polygonColor.G, Math.Min(255,Math.Max(0, polygonColor.B + (addAmount ? _owner.pointMutationAmountBlue : -_owner.pointMutationAmountBlue))));
                        else
                            //do green
                            polygonColor = Color.FromArgb(polygonColor.A, polygonColor.R, Math.Min(255,Math.Max(0, polygonColor.G + (addAmount ? _owner.pointMutationAmountGreen : -_owner.pointMutationAmountGreen))), polygonColor.B);
                    }
                }
            }


            //A vector polygon needs to know how to get a polygon list version of itself
            internal Polygon getPolygon()
            {
                //Are we a real polygon?
                if (vectorPolyOff())
                {
                    //Instead return null
                    Polygon pi = new Polygon();
                    pi.Ignore = true;
                    return pi;
                }
                //Get a list of points
                var points = getAllPoints();

                Polygon p = new Polygon();
                p.vertices = points;
                p.baseColor = polygonColor;

                return p;
            }
        }


        private void mutateChild(List<VectorPolygon> child)
        {
            
            //remove polygons?
            //Have a chance to remove a poly
            for(int i = 0; i < child.Count; i++)
            {
                //Only if the poly has content
                if (!child[i].vectorPolyOff())
                {
                    if (r.Next(100) < polyRemovePolyRate)
                    {
                        child[i].resetState(false);
                        break;
                    }
                }
            }
            //Add polygons?
            for (int i = 0; i < child.Count; i++)
            {
                //Only if the poly has no content
                if (child[i].vectorPolyOff())
                {
                    if (r.Next(100) < polyCreatePolyRate)
                    {
                        child[i].resetState(true);
                        break;
                    }
                }
            }

            //Now let each polygon mutate itself
            for (int i = 0; i < child.Count; i++)
            {
                //Only let alive polys mutate...
                if (!child[i].vectorPolyOff())
                {
                    //Tell this poly to mutate
                    child[i].mutateSelf();
                }
            }
        }



        public void LoadImage(Bitmap BaseImage)
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
                allChildren = new List<List<VectorPolygon>>();
                for(int i = 0; i < MAXIMUM_CHILDREN; i++)
                    allChildren.Add(null);

                List<VectorPolygon> newMotherPolygons = new List<VectorPolygon>();
                for (int i = 0; i < polyMaxPolygons; i++)
                {
                    newMotherPolygons.Add(new VectorPolygon(this));
                }
                allChildren[0] = newMotherPolygons;

                

                //Finally, lock the parameters
                paramsLocked = true;
            }
            //Time to start processing
            _currentStep++;
            _currentFitness = _currentStep;

            //Perform reproduction on winners?
            //Right now, the winner simply copies itself everywhere
            winnerReproduces();


            //Perform mutation on children
            mutateAllChildren();



            List<List<Polygon>> polys = new List<List<Polygon>>();
            //Convert all children's poly lists into real polygons
            turnChildrenIntoPolyCollections(polys);
            
            int bestFit = ImageGenAlgorithmLib.Common.indexOfBestFit(_theImage, polys, out fitness, 4, 18);

            //We now have our best fit

            //Make it #1
            allChildren[0] = allChildren[bestFit];

            //Return the best fit list of polygons
            return polys[bestFit];
        }

        private void turnChildrenIntoPolyCollections(List<List<Polygon>> polys)
        {
            foreach (var v in allChildren)
            {
                List<Polygon> ps = new List<Polygon>();
                foreach (var vp in v)
                {
                    ps.Add(vp.getPolygon());
                }

                polys.Add(ps);
            }
        }

        private void mutateAllChildren()
        {
            for (int i = 1; i < allChildren.Count; i++)
            {
                mutateChild(allChildren[i]);
            }
        }

        private void winnerReproduces()
        {
            for (int i = 1; i < allChildren.Count; i++)
            {
                List<VectorPolygon> newPolygons = new List<VectorPolygon>();
                foreach (var poly in allChildren[0])
                {
                    newPolygons.Add(new VectorPolygon(poly));
                }
                allChildren[i] = newPolygons;
            }
        }



        public ICollection<ImageGenAlgorithmLib.ParameterDelegate> getParameters()
        {
            return testParams;
        }

    }
}
