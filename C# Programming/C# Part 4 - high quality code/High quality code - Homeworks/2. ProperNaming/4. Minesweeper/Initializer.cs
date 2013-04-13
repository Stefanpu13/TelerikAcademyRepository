using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class Initializer
    {
        public static void PerformInitialization(GameBoard gameBoard) 
        {
            InitializeBoards(gameBoard);
            PlaceMines(gameBoard);
        }

        /// <summary>
        /// Initializes the underlying and the displayed boards of the "GameBoard" object.
        /// </summary>
        /// <param name="gameBoard">The object whose boards are initilized.</param>
        private static void InitializeBoards(GameBoard gameBoard) 
        {
            gameBoard.DisplayedBoard = InitializeDisplayedBoard();
            gameBoard.UnderlyingBoard = InitializeUnderlyingBoard();
        }

        /// <summary>
        /// Fills the underlying board with hyphens '-'.
        /// </summary>
        /// <returns>A two dimensional array of hyphens.</returns>
        private static char[,] InitializeUnderlyingBoard()
        {
            return CreateBoard('-');
        }

        /// <summary>
        /// Filles the diaplyed board with question marks - '?'.
        /// </summary>
        /// <returns>A two dimensional array of question marks.</returns>
        private static char[,] InitializeDisplayedBoard()
        {
            return CreateBoard('?');
        }

        /// <summary>
        /// Fills a game board with specified field symbol. If the field symbol is question mark
        /// - '?' this is the displayed board. If the symbol is '-' this is the underlying board.
        /// </summary>
        /// <returns>Two dimensional array representing the game board.</returns>
        private static char[,] CreateBoard(char fieldSymbol)
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = fieldSymbol;
                }
            }
            return board;
        }

        private static List<int> GenerateMinesPositions()
        {
            List<int> mines = new List<int>();
            // TODO: replace 15 with varialbe minesCount/totalMines
            while (mines.Count < 15)
            {
                Random minePositionGenerator = new Random();
                int minePosition = minePositionGenerator.Next(50);
                if (!mines.Contains(minePosition))
                {
                    mines.Add(minePosition);
                }
            }
            return mines;
        }

        /// <summary>
        /// Randomly places 15 mines in the underlying board.
        /// </summary>
        /// <returns>A two dimensional array representing the underlying board.</returns>
        private static void PlaceMines(GameBoard gameBoard)
        {
            int boardColumns = gameBoard.BoardColumns;
            List<int> minePositions = GenerateMinesPositions();

            foreach (int minePosition in minePositions)
            {
                int mineRow = (minePosition / boardColumns);
                int mineColumn = (minePosition % boardColumns);
                if (mineColumn == 0 && minePosition != 0)
                {
                    mineRow--;
                    mineColumn = boardColumns;
                }
                else
                {
                    mineColumn++;
                }
                gameBoard.UnderlyingBoard[mineRow, mineColumn - 1] = '*';
            }
        }
    }
}
