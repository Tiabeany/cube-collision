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
            var xGapBetweenCubes = GetAxisGapBetweenCubes(FirstCube.XPosition, SecondCube.XPosition,
                FirstCube.Height, SecondCube.Height);

            var yGapBetweenCubes = GetAxisGapBetweenCubes(FirstCube.YPosition, SecondCube.YPosition,
                FirstCube.Width, SecondCube.Width);

            var zGapBetweenCubes = GetAxisGapBetweenCubes(FirstCube.ZPosition, SecondCube.ZPosition,
                FirstCube.Depth, SecondCube.Depth);

            return xGapBetweenCubes < 0 || yGapBetweenCubes < 0 || zGapBetweenCubes < 0;
        }

        private double GetAxisGapBetweenCubes(
            double firstCubeAxisPosition, double secondCubeAxisPosition, double firstCubeVertixSize, 
            double secondCubeVertixSize)
        {
            var axisDistanceBetweenCubesCenters = firstCubeAxisPosition - secondCubeAxisPosition;
            var firstCubeVertixHalfSize = firstCubeVertixSize * 0.5;
            var secondCubeVertixHalfSize = secondCubeVertixSize * 0.5;
            return axisDistanceBetweenCubesCenters - firstCubeVertixHalfSize - secondCubeVertixHalfSize;
        }

        public CollisionIntersection GetCollisionIntersection()
        {
            if (AreCubesCollided())
            {
                var collisionHeight = Math.Abs(GetAxisGapBetweenCubes(FirstCube.XPosition, SecondCube.XPosition,
                FirstCube.Height, SecondCube.Height));

                var collisionWidth = Math.Abs(GetAxisGapBetweenCubes(FirstCube.YPosition, SecondCube.YPosition,
                FirstCube.Width, SecondCube.Width));

                var collisionDepth = Math.Abs(GetAxisGapBetweenCubes(FirstCube.ZPosition, SecondCube.ZPosition,
                FirstCube.Depth, SecondCube.Depth));

                double collisionXPosition = GetCollisionAxisPosition(FirstCube.XPosition, SecondCube.XPosition, collisionHeight);

                double collisionYPosition = GetCollisionAxisPosition(FirstCube.YPosition, SecondCube.YPosition, collisionWidth);

                double collisionZPosition = GetCollisionAxisPosition(FirstCube.YPosition, SecondCube.YPosition, collisionWidth);

                return new CollisionIntersection(collisionHeight, collisionWidth, collisionDepth,
                    collisionXPosition, collisionYPosition, collisionZPosition);
            }

            return new CollisionIntersection(0, 0, 0, 0, 0, 0);
        }

        private double GetCollisionAxisPosition(double firstCubeAxisPosition, double secondCubeAxisPosition, 
            double collisionVertexSize)
        {
            double collisionXPosition;

            if (firstCubeAxisPosition < secondCubeAxisPosition)
            {
                collisionXPosition = firstCubeAxisPosition + (collisionVertexSize * 0.5);
            }
            else
            {
                collisionXPosition = secondCubeAxisPosition + (collisionVertexSize * 0.5);
            }

            return collisionXPosition;
        }
    }
}
