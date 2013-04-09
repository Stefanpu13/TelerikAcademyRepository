using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task  8: 
    class UnstoppableBall:Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed) :
            base(topLeft, speed) { }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
        //    base.RespondToCollision(collisionData);
        //}

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" ||
                otherCollisionGroupString == "unpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {            
            if (CanCollideWith(collisionData.hitObjectsCollisionGroupStrings.Last()))
            {
                base.RespondToCollision(collisionData);
            } 
        }
    }
}
