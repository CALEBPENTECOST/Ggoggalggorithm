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
        public Brush fillBrush { get; set; }

        public Polygon(ICollection<Point> pVertices, Brush pFillBrush)
        {
            this.vertices = pVertices;
            this.fillBrush = pFillBrush;
        }

        public Polygon(ICollection<Point> pVertices, Color pFillColor)
        {
            this.vertices = pVertices;
            this.fillBrush = new SolidBrush(pFillColor);
        }
    }
}
