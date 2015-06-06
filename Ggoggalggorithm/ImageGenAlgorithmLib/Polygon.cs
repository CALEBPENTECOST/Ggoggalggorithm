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
        public ICollection<Point> vertices { get; set; }
        public Color baseColor { get; set; }

        public IEnumerator<Point> GetEnumerator()
        {
            return this.vertices.GetEnumerator();
        }

        public Polygon(ICollection<Point> pVertices, Color pBaseColor)
        {
            this.vertices = pVertices;
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
            this.vertices = new LinkedList<Point>();
            this.baseColor = Color.Aquamarine;
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

        public static ICollection<Polygon> generateTransformSteps(Polygon start, Polygon end, int numSteps)
        {
            int curStep = 1;
            float numStepsFloat = (float)numSteps;
            LinkedList<Polygon> stepList = new LinkedList<Polygon>();
            stepList.AddFirst(start);

            int extraPoints = end.vertices.Count - start.vertices.Count;
            while (extraPoints > 0)
            {
                //add extra points to start of polygon.
                start.vertices.Add(start.vertices.ElementAt(start.vertices.Count - 1));
            }

            while (curStep < numSteps)
            {
                float amount = ((float)curStep) / numStepsFloat;
                Polygon step = new Polygon();
                for (int i = 0; 0 < start.vertices.Count; i++)
                {
                    step.vertices.Add(stepPoint(start.vertices.ElementAt(i), end.vertices.ElementAt(i), amount));
                }
                step.baseColor = stepColor(start.baseColor, end.baseColor, amount);
            }
            //This step removes additional points if the new poly has fewer.
            stepList.AddLast(end);
            return stepList;
        }
    }
}
