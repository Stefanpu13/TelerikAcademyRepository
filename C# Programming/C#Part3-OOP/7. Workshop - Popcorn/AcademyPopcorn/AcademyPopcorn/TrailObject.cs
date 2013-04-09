using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject:GameObject
    {
        //Static field that will count each call to "Update" method.
        //Note: Each looping in "while(true){...}" cycle in "Engine.Run()" method
        //represents a turn. At each turn a single call to "Update()" is made
        static int turnCounter = 0;
        int lifeTime;
        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime) :
            base(topLeft, body) 
        {
            this.lifeTime = lifeTime;
        }

        public int LifeTime
        {
            get
            {
                return this.lifeTime;
            }
            set
            {
                this.lifeTime = value;
            }
        }

        public override void Update()
        {
            if (turnCounter == lifeTime)
            {
                this.IsDestroyed = true;
                turnCounter = 0;
            }
            turnCounter++;
        }
    }
}
