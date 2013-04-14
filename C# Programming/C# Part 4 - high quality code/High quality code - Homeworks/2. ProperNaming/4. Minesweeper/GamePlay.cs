using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class GamePlay
    {
        private GameBoard OpenField(GameBoard board, int row, int column)
        {
            char adjacentMines = CountAdjacentMines(board.UnderlyingBoard, row, column);
            board.UnderlyingBoard[row, column] = adjacentMines;
            board.DisplayedBoard[row, column] = adjacentMines;

            return board;
        }

        private static char CountAdjacentMines(char[,]underlyingBoard, int currentRow, int currentCol)
        {
            // TODO: chexk adjacent spelling
            int adjacentMinesCount = 0;
            int boardRows = underlyingBoard.GetLength(0);
            int boardColumns = underlyingBoard.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (underlyingBoard[currentRow - 1, currentCol] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (currentRow + 1 < boardRows)
            {
                if (underlyingBoard[currentRow + 1, currentCol] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (currentCol - 1 >= 0)
            {
                if (underlyingBoard[currentRow, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (currentCol + 1 < boardColumns)
            {
                if (underlyingBoard[currentRow, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (underlyingBoard[currentRow - 1, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentCol + 1 < boardColumns))
            {
                if (underlyingBoard[currentRow - 1, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((currentRow + 1 < boardRows) && (currentCol - 1 >= 0))
            {
                if (underlyingBoard[currentRow + 1, currentCol - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((currentRow + 1 < boardRows) && (currentCol + 1 < boardColumns))
            {
                if (underlyingBoard[currentRow + 1, currentCol + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }

            return char.Parse(adjacentMinesCount.ToString());
        }

        public void MakeTurn(GameInitializer initializer, GameBoard board)
        {

            if (board.UnderlyingBoard[initializer.Metrics.Row, initializer.Metrics.Column] != '*')
            {
                if (board.UnderlyingBoard[initializer.Metrics.Row, initializer.Metrics.Column] != '*')
                {
                    this.OpenField(board, initializer.Metrics.Row, initializer.Metrics.Column);
                    initializer.Metrics.OpenedEmptyFields++;
                }
                if (initializer.Metrics.TotalEmptyFields == initializer.Metrics.OpenedEmptyFields)
                {
                    initializer.Metrics.AllMinesFound = true;
                }
                else
                {
                    //DrawBoard(displayedBoard);
                }
            }
            else
            {
                initializer.Metrics.MineIsBlown = true;
            }
        }
    }
}
