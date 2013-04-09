using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            //CreateSideAndCeiling();

            //Task 1. Add ceiling and sidewalls
            //Task 9. Use unpassable block as ceiling and sidewall.
            #region
            AddCeiling(engine, startRow);

            AddSidewalls(engine, startRow, startCol);
            #endregion

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            //Task 7. test the meteorite ball.
            //Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            Ball theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);           

            engine.AddObject(theRacket);
            
            
        }

        private static void AddCeiling(Engine engine, int startRow)
        {
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling =
                    new UnpassableBlock(new MatrixCoords(startRow - 2, i));

                engine.AddObject(ceiling);
            }
        }

        private static void AddSidewalls(Engine engine, int startRow, int startCol)
        {

            //Add left wall 
            for (int i = startRow - 1; i < WorldRows; i++)
            {
                IndestructibleBlock leftSidewall =
                    new UnpassableBlock(new MatrixCoords(i, startCol - 2));

                engine.AddObject(leftSidewall);
            }

            //Add right sidewall

            for (int i = startRow - 1; i < WorldRows; i++)
            {
                IndestructibleBlock rightSidewall =
                    new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));

                engine.AddObject(rightSidewall);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //Task 5: Add instance of trail object that is destroyed after 3 turns
            TrailObject trail = new TrailObject(new MatrixCoords(WorldCols / 2, WorldRows / 2),
                new char[,] { { '/', '\\' } }, 3);
            gameEngine.AddObject(trail);

            gameEngine.Run();
        }
    }
}
