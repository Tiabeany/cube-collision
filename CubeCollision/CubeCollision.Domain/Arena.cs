using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeCollision.Domain
{
    public class Arena
    {
        public Cube FirstCube { get; private set; }
        public Cube SecondCube { get; private set; }

        public Arena(Cube firstCube, Cube secondCube)
        {
            FirstCube = firstCube;
            SecondCube = secondCube;
        }

        public bool AreCubesCollided()
        {
            var xDistanceBetweenCubesCenters = FirstCube.XPosition - SecondCube.XPosition;
            var firstCubeHalfHeight = FirstCube.Height * 0.5;
            var secondCubeHalfHeight = SecondCube.Height * 0.5;

            var xGapBetweenCubes = GetAxisGapBetweenCubes(xDistanceBetweenCubesCenters, firstCubeHalfHeight, secondCubeHalfHeight);

            var yDistanceBetweenCubesCenters = FirstCube.YPosition - SecondCube.YPosition;
            var firstCubeHalfWidth = FirstCube.Width * 0.5;
            var secondCubeHalfWidth = SecondCube.Width * 0.5;

            var yGapBetweenCubes = GetAxisGapBetweenCubes(yDistanceBetweenCubesCenters, firstCubeHalfWidth, secondCubeHalfWidth);

            var zDistanceBetweenCubesCenters = FirstCube.ZPosition - SecondCube.ZPosition;
            var firstCubeHalfDepth = FirstCube.Depth * 0.5;
            var secondCubeHalfDepth = SecondCube.Depth * 0.5;

            var zGapBetweenCubes = GetAxisGapBetweenCubes(zDistanceBetweenCubesCenters, firstCubeHalfDepth, secondCubeHalfDepth);

            return xGapBetweenCubes < 0 || yGapBetweenCubes < 0 || zGapBetweenCubes < 0;
        }

        private double GetAxisGapBetweenCubes(double axisDistanceBetweenCubesCenters, double firstCubeVertixHalfSize, 
            double secondCubeVertixHalfSize)
        {
            return axisDistanceBetweenCubesCenters - firstCubeVertixHalfSize - secondCubeVertixHalfSize;
        }

        public CollisionIntersection GetCollisionIntersection()
        {
            

            var collisionHeight = FirstCube.XPosition - SecondCube.XPosition;
            var collisionWidth = FirstCube.YPosition - SecondCube.YPosition;
            var collisionDepth = FirstCube.ZPosition - SecondCube.ZPosition;

            var collisionXPosition = collisionHeight / 2;
            var collisionYPosition = collisionWidth / 2;
            var collisionZPosition = collisionDepth / 2;

            return new CollisionIntersection(collisionHeight, collisionWidth, collisionDepth,
                collisionXPosition, collisionYPosition, collisionZPosition);
        }
    }
}
