using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class Initializer
    {
        public static void InitializeBoards(GameBoard gameBoard) 
        {
            gameBoard.DisplayedBoard = InitializeDisplayedBoard();
            gameBoard.UnderlyingBoard = InitializeUnderlyingBoard();
        }

        private static char[,] InitializeUnderlyingBoard()
        {
            return CreateBoard('-');
        }

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
    }
}
