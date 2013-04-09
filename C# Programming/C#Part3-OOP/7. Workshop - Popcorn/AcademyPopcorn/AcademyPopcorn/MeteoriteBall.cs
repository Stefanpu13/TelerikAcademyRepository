using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //6. Add a MeteoriteBall class that inherits Ball and has a trail.
    class MeteoriteBall:Ball
    {
        List<TrailObject> trail;
        TrailObject MeteoriteTrail;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) :
            base(topLeft, speed) 
        {
          
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trail = new List<GameObject>();
            trail.Add(new TrailObject(base.topLeft, new char[,] { { '*' } }, 3));

            return trail;
        }
        
    }
}
