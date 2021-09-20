using CubeCollision.Application.Repositories.Interfaces;
using CubeCollision.Application.Services.Interfaces;
using CubeCollision.Application.Validators;
using CubeCollision.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CubeCollision.Application.Services
{
    public class CubeCollisionService : ICubeCollisionService
    {
        private readonly IArenaRepository _arenaRepository;

        public CubeCollisionService(IArenaRepository arenaRepository)
        {
            _arenaRepository = arenaRepository;
        }

        public void SetArena(Cube firstCube, Cube secondCube)
        {
            var firstCubeValidation = new CubeValidation().Validate(firstCube);
            var secondCubeValidation = new CubeValidation().Validate(secondCube);

            if (firstCubeValidation.IsValid && secondCubeValidation.IsValid)
            {
                var newArena = new Arena(firstCube, secondCube);
                _arenaRepository.InsertArena(newArena);
            }
            else
            {
                // throw exception?
            }
        }

        public IEnumerable<CollisionIntersection> GetAllCubeCollisionIntersections()
        {
            var allArenas = _arenaRepository.GetAllArenas();
            foreach (var arena in allArenas)
            {
                yield return arena.GetCollisionIntersection();
            }
        }

        public CollisionIntersection GetCubeCollisionIntersectionByIndex(int index)
        {
            var arena = _arenaRepository.GetArena(index);
            return arena.GetCollisionIntersection();
        }
    }
}
