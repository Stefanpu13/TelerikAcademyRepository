using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock:Block
    {
        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft) { }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> explosionChunks = new List<GameObject>();
            if (this.IsDestroyed)
            {
                for (int row = this.TopLeft.Row - 1; row < this.TopLeft.Row + 1; row++)
                {
                    for (int col = this.TopLeft.Col - 1; col < this.TopLeft.Col - 1; col++)
                    {
                        TrailObject blockChunk = new TrailObject(new MatrixCoords(row-2, col-2),
                            new char[,]{{'A'}},7);
                        
                        explosionChunks.Add(blockChunk);
                    }
                }
            }

            return explosionChunks;
        }
    }
}
