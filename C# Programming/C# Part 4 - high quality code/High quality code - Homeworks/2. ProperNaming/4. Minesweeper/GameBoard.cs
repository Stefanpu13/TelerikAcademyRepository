namespace MinesSweeper
{
    using System;

    public class GameBoard
    {
        private char[,] underlyingBoard;
        private char[,] displayedBoard;

        public char[,] UnderlyingBoard
        {
            get
            {
                return this.underlyingBoard;
            }
            set
            {
                this.underlyingBoard = value;
            }
        }

        public char[,] DisplayedBoard
        {
            get
            {
                return this.displayedBoard;
            }
            set
            {
                this.displayedBoard = value;
            }
        }

        public int BoardRows 
        { 
            get 
            {
                return 5;
            } 
        }

        public int BoardColumns
        {
            get
            {
                return 10;
            }
        }

        public void DrawBoard(char[,] board)
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
