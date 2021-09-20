namespace CubeCollision.Domain
{
    public class CollisionIntersection
    {
        public double Height { get; private set; }
        public double Width { get; private set; }
        public double Depth { get; private set; }

        public double XPosition { get; private set; }
        public double YPosition { get; private set; }
        public double ZPosition { get; private set; }

        public CollisionIntersection(double height, double width, double depth,
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
