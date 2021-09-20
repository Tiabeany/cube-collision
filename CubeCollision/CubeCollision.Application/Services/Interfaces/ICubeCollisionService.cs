using CubeCollision.Domain;
using System.Collections.Generic;

namespace CubeCollision.Application.Services.Interfaces
{
    public interface ICubeCollisionService
    {
        void SetArena(Cube firstCube, Cube secondCube);
        CollisionIntersection GetCubeCollisionIntersectionByIndex(int index);
        IEnumerable<CollisionIntersection> GetAllCubeCollisionIntersections();
    }
}
