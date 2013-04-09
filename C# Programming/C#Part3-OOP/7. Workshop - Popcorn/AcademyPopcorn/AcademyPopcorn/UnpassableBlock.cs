using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 8. 
    class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassableBlock";
        public UnpassableBlock(MatrixCoords upperLeft) : base(upperLeft) 
        {

        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}
