using CubeCollision.Domain;
using System.Collections.Generic;

namespace CubeCollision.Application.Repositories.Interfaces
{
    public interface IArenaRepository
    {
        void InsertArena(Arena arena);
        Arena GetArena(int index);
        IEnumerable<Arena> GetAllArenas();
    }
}
