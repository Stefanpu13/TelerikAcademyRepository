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
            // TODO: delete test drawing
            DrawBoard(board.UnderlyingBoard);
            DrawBoard(board.DisplayedBoard);
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
    }
}
