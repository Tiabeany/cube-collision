using CubeCollision.API.Models;
using CubeCollision.Application.Services.Interfaces;
using CubeCollision.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubeCollision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubeCollisionController : ControllerBase
    {
        private readonly ICubeCollisionService _cubeCollisionService;

        public CubeCollisionController(ICubeCollisionService cubeCollisionService)
        {
            _cubeCollisionService = cubeCollisionService;
        }

        [HttpPost]
        public void PostArena([FromBody] ArenaBindingModel arena)
        {
            _cubeCollisionService.SetArena(arena.FirstCube, arena.SecondCube);
        }

        [HttpGet]
        public ActionResult<CollisionIntersection> GetCollisionIntersection(int index)
        {
            return _cubeCollisionService.GetCubeCollisionIntersectionByIndex(index);
        }
    }
}
