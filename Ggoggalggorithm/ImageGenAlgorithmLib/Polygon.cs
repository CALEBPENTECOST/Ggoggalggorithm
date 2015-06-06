using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageGenAlgorithmLib
{
    public class Polygon
    {
        public List<Point> vertices { get; set; }
        public Color baseColor { get; set; }

        public IEnumerator<Point> GetEnumerator()
        {
            return this.vertices.GetEnumerator();
        }

        public Polygon(ICollection<Point> pVertices, Color pBaseColor)
        {
            this.vertices = pVertices.ToList();
            this.baseColor = pBaseColor;
        }

        public Polygon(Polygon p)
        {
            //Deep copy.
            this.vertices = p.vertices.Select(ep => new Point(ep.X, ep.Y)).ToList();
            this.baseColor = Color.FromArgb(p.baseColor.ToArgb());
        }

        public Polygon()
        {
            this.vertices = new List<Point>();
            this.baseColor = Color.Aquamarine;
        }

        private static Point copyPoint(Point a)
        {
            //deep copy
            return new Point(a.X, a.Y);
        }

        private static Point stepPoint(Point start, Point end, float amount)
        {
            float inverse = 1.0f - amount;
            return new Point(
                (int)(inverse * (float)start.X + amount * (float)end.X),
                (int)(inverse * (float)start.Y + amount * (float)end.Y)
                );
        }

        private static Color stepColor(Color start, Color end, float amount)
        {
            float inverse = 1.0f - amount;

            int A = (int)(inverse * (float)start.A + amount * (float)end.A);
            int R = (int)(inverse * (float)start.R + amount * (float)end.R);
            int G = (int)(inverse * (float)start.G + amount * (float)end.G);
            int B = (int)(inverse * (float)start.B + amount * (float)end.B);

            return Color.FromArgb(A, R, G, B);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="numSteps"></param>
        /// <returns>Iterator of size numSteps+2 of which each item is a frame in transformation of start to end, inclusive.</returns>
        public static System.Collections.IEnumerator transformIterator(Polygon start, Polygon end, int numSteps)
        {
            
            yield return start;

            //Insert duplicate points if the target polygon has more points than the source polygon
            int extraPoints = end.vertices.Count - start.vertices.Count;
            List<Point> st = start.vertices.ToList();
            for (int i = 0; i < extraPoints; i++)
            {
                int indexToDouble = i % start.vertices.Count;
                st.Insert(indexToDouble, copyPoint(st.ElementAt(indexToDouble)));
            }
            start.vertices = st;

            //Rotate the list around until we find the best-fitting version.
            //This helps prevent polygons from self-intersecting and other yuckiness.
            start.vertices = start.getBestFitRotation(end.vertices);

            float numStepsFloat = (float)numSteps;
            for (int curStep = 1; curStep < numSteps; curStep++)
                {
                    float amount = ((float)curStep) / numStepsFloat;
                    Polygon step = new Polygon();
                    for (int i = 0; 0 < start.vertices.Count; i++)
                    {
                        step.vertices.Add(stepPoint(start.vertices.ElementAt(i), end.vertices.ElementAt(i), amount));
                    }
                    step.baseColor = stepColor(start.baseColor, end.baseColor, amount);
                    yield return step;
                }
            //This step removes additional points if the new poly has fewer. Points will naturally converge, so this should be pretty seamless.
            yield return end;
        }

        public List<Point> getBestFitRotation(List<Point> toMatch)
        {
            List<Point> bestFound = this.vertices;
            double bestScore = getMatchScore(bestFound, toMatch);

            for (int i = 1; i < this.vertices.Count; i++)
            {
                List<Point> rotated = this.getRotation(i);
                double testScore = getMatchScore(rotated, toMatch);
                if (bestScore < testScore)
                {
                    bestFound = rotated;
                    bestScore = testScore;
                }
            }
            return bestFound;
        }

        //There is probably a better way to do this.
        public List<Point> getRotation(int amount)
        {
            List<Point> ret = new List<Point>(this.vertices);
            //Move head to tail if positive rotate
            for (int i = 0; i < amount; i++)
            {
                Point head = ret.ElementAt(0);
                ret.Remove(head);
                ret.Add(head);
            }
            //Move tail to head if negative rotate
            for (int i = 0; i > amount; i++)
            {
                Point tail = ret.ElementAt(ret.Count-1);
                ret.Remove(tail);
                ret.Insert(0, tail);
            }
            return ret;
        }

        private static double getMatchScore(List<Point> aList, List<Point> bList)
        {
            if (aList.Count != bList.Count)
            {
                throw new ArgumentException("aList and bList must be of the same length.");
            }
            return aList.Zip(bList, (a, b) => Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.X, 2)).Sum();
        }
    }
}
