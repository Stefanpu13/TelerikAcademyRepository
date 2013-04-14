namespace MinesSweeper
{
    using System;
    using System.Collections.Generic;

    public class GameInitializer
    {
        private List<int> minesPositions;

        public void PerformRestartedGameInitialization(ref GameMetrics metrics, ref GameBoard board)
        {
            metrics = new GameMetrics(false);
            this.InitializeBoards(false, metrics, board);
        }

        public void PerformNewGameInitialization(ref GameMetrics metrics, ref GameBoard board)
        {
            board = new GameBoard();
            metrics = new GameMetrics(true);
            this.InitializeBoards(true, metrics, board);
        }

        private void InitializeBoards(bool newGameIsStarted, GameMetrics metrics, GameBoard board)
        {
            board.DisplayedBoard = this.InitializeDisplayedBoard(board.BoardRows, board.BoardColumns);
            board.UnderlyingBoard =
                    this.InitializeUnderlyingBoard(board.BoardRows, board.BoardColumns);

            if (newGameIsStarted)
            {
                this.minesPositions = this.GenerateMinesPositions(metrics);
            }
            this.PlaceMines(board);
        }

        /// <summary>
        /// Fills the underlying board with hyphens '-'.
        /// </summary>
        /// <returns>A two dimensional array of hyphens.</returns>
        private char[,] InitializeUnderlyingBoard(int boardRows, int boardColumns)
        {
            return this.CreateBoard('-', boardRows, boardColumns);
        }

        /// <summary>
        /// Filles the diaplyed board with question marks - '?'.
        /// </summary>
        /// <returns>A two dimensional array of question marks.</returns>
        private char[,] InitializeDisplayedBoard(int boardRows, int boardColumns)
        {
            return this.CreateBoard('?', boardRows, boardColumns);
        }

        /// <summary>
        /// Fills a game board with specified field symbol. If the field symbol is question mark
        /// - '?' this is the displayed board. If the symbol is '-' this is the underlying board.
        /// </summary>
        /// <returns>Two dimensional array representing the game board.</returns>
        private char[,] CreateBoard(char fieldSymbol, int boardRows, int boardColumns)
        {
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

        private List<int> GenerateMinesPositions(GameMetrics metrics)
        {
            List<int> mines = new List<int>();

            while (mines.Count < metrics.TotalMines)
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
        private void PlaceMines(GameBoard board)
        {
            int boardColumns = board.BoardColumns;

            foreach (int minePosition in this.minesPositions)
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
                board.UnderlyingBoard[mineRow, mineColumn - 1] = '*';
            }
        }
    }
}
