﻿using System.Collections.Generic;
using Xunit;

namespace CubeCollision.Domain.Test
{
    public class ArenaTest
    {
        [Fact]
        public void AreCubesCollided_CollidedCubes_ReturnsTrue()
        {
            var cube1 = new Cube(10, 10, 10, 100, 100, 100);
            var cube2 = new Cube(10, 10, 10, 95, 95, 95);
            var arena = new Arena(cube1, cube2);
            Assert.True(arena.AreCubesCollided());
        }

        [Fact]
        public void AreCubesCollided_NotCollidedCubes_ReturnsFalse()
        {
            var cube1 = new Cube(10, 10, 10, 100, 100, 100);
            var cube2 = new Cube(10, 10, 10, 0, 0, 0);
            var arena = new Arena(cube1, cube2);
            Assert.False(arena.AreCubesCollided());
        }

        [Fact]
        public void GetCollisionIntersection_NotCollidedCubes_ReturnsZeroPropertiesCollisionIntersection()
        {
            var cube1 = new Cube(10, 10, 10, 100, 100, 100);
            var cube2 = new Cube(10, 10, 10, 0, 0, 0);
            var arena = new Arena(cube1, cube2);
        }

        [Fact]
        public void GetCollisionIntersection_CollidedCubes_ReturnsCollisionIntersection()
        {
            var cube1 = new Cube(10, 10, 10, 100, 100, 100);
            var cube2 = new Cube(10, 10, 10, 95, 95, 95);
            var arena = new Arena(cube1, cube2);
        }
    }
}
