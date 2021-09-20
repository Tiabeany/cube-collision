using CubeCollision.Application.Repositories.Interfaces;
using CubeCollision.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeCollision.Infrastructure.Repositories
{
    public class ArenaRepository : IArenaRepository
    {
        private readonly IDictionary<int, Arena> _arenas;

        public ArenaRepository(IDictionary<int, Arena> arenas)
        {
            _arenas = arenas;
        }

        public IEnumerable<Arena> GetAllArenas()
        {
            return _arenas.Select(a => a.Value);
        }

        public Arena GetArena(int index)
        {
            _arenas.TryGetValue(index, out var arena);
            return arena;
        }

        public void InsertArena(Arena arena)
        {
            var index = _arenas.Keys.Count + 1;
            _arenas.Add(index, arena);
        }
    }
}
