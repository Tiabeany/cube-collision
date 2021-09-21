using CubeCollision.Domain;

namespace CubeCollision.API.Models
{
    public class ArenaBindingModel
    {
        public Cube FirstCube { get; set; }
        public Cube SecondCube { get; set; }
    }
}
