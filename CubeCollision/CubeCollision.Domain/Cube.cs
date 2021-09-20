using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeCollision.Domain
{
    public class Cube
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Depth { get; private set; }

        public double XPosition { get; private set; }
        public double YPosition { get; private set; }
        public double ZPosition { get; private set; }

        public Cube(int height, int width, int depth,
            double xPosition, double yPosition, double zPosition)
        {
            Height = height;
            Width = width;
            Depth = depth;
            XPosition = xPosition;
            YPosition = yPosition;
            ZPosition = zPosition;
        }
    }
}
