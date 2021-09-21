using CubeCollision.API.Models;
using CubeCollision.Application.Services.Interfaces;
using CubeCollision.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult PostArena([FromBody] ArenaBindingModel arena)
        {
            try
            {
                _cubeCollisionService.SetArena(arena.FirstCube, arena.SecondCube);
                return StatusCode(200);
            }
            catch (ValidationException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<CollisionIntersection> GetCollisionIntersection(int index)
        {
            return _cubeCollisionService.GetCubeCollisionIntersectionByIndex(index);
        }
    }
}
