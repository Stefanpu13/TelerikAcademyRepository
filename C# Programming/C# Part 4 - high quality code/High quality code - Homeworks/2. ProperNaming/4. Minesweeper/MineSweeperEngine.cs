using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class MinesweeperEngine
    {
        public static void Run() 
        {
            //GameBoard minesweeperBoard = new GameBoard();
            GameInitializer minesweeperInitializer = new GameInitializer();
            //GameInitializer.PerformNewGameInitialization(minesweeperBoard);
            GameBoard board = minesweeperInitializer.GameBoard;
            // TODO: delete test printing
            DrawBoard(board.UnderlyingBoard);
            DrawBoard(board.DisplayedBoard);
            Console.WriteLine(minesweeperInitializer.Metrics);

            // Play Game
        }

        // <summary>
        /// Draws the board to be displayed.
        /// </summary>
        /// <param name="board">A two dimensional char array representing the board to be
        /// displayed.</param>
        private static void DrawBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < boardRows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < boardColumns; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static void PlayGame(GameInitializer initializer, GameBoard board) 
        {
            CommandHelper commandHelper = new CommandHelper();
            GamePlay gameplay = new GamePlay();
            TopScores topScores = new TopScores();
            string command = commandHelper.ReadCommand();
            int boardRows = board.BoardRows;
            int boardColumns = board.BoardColumns;

            if (commandHelper.CommandIsValid(command))
            {
                if (commandHelper.IsValidOpenFieldCommand(command, boardRows, boardColumns,
                    out initializer.Metrics.Row, out initializer.Metrics.Column))
                {
                    switch (command)
                    {
                        case "top":
                            //DisplayRankings(topScorers);
                            topScores.DisplayRankings();
                            break;
                        case "restart":
                            // TODO: call initializer restart method.
                            initializer.PerformRestartedGameInitialization();
                            break;
                        case "exit":
                            Console.WriteLine("Bye!");
                            break;
                        case "turn":
                            // TODO: extract "MakeTurn" method.
                            gameplay.MakeTurn(initializer, board);
                            break;
                        default:
                            Console.WriteLine("\nOops! Unvalid command!\n");
                            break;
                    }

                    if (initializer.Metrics.MineIsBlown)
                    {
                        DrawBoard(board.UnderlyingBoard);
                        Console.Write("\nHrrrrrr!You died. You opened {0} fields. "
                            ,initializer.Metrics.OpenedEmptyFields);
                        Console.Write("Enter your name: ");

                        //TODO: read name and place in topscorers list - move to different method
                        // Create Scorers Class(!!!?) where to add and display top scorers.
                        string name = Console.ReadLine();
                        Score finalScore = new Score(name,initializer.Metrics.OpenedEmptyFields);

                        topScores.Add(finalScore);
                        topScores.DisplayRankings();

                      
                        // Game reinitialisation TODO: move to different method/part of the program. 
                        //displayedBoard = CreateBoard('?');
                        //underlyingBoard = PlaceMines();
                        //openedEmptyFields = 0;
                        //mineIsBlown = false;
                        //newGameIsStarted = true;
                    }

                    //if (allMinesFound)
                    //{
                    //    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    //    DrawBoard(underlyingBoard);
                    //    Console.WriteLine("Daj si imeto, batka: ");
                    //    string name = Console.ReadLine();
                    //    Score totalPoints = new Score(name, openedEmptyFields);
                    //    topScorers.Add(totalPoints);
                    //    DisplayRankings(topScorers);

                    //    // Game reinitialisation TODO: move to different method/part of the program. 
                    //    displayedBoard = CreateBoard('?');
                    //    underlyingBoard = PlaceMines();
                    //    openedEmptyFields = 0;
                    //    allMinesFound = false;
                    //    newGameIsStarted = true;
                    //}

                }
            }

        }

        
    }
}
