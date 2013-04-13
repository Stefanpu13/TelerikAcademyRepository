using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class GameInitializer
    {
        private GameMetrics thisGameMetrics;
        private GameBoard gameBoard;
        private List<int> minesPositions;

        public GameInitializer() 
        {
            this.PerformNewGameInitialization();
        }


        public GameBoard GameBoard
        {
            get
            {
                return this.gameBoard;
            }
            set
            {
                this.gameBoard = value;
            }
        }

        public GameMetrics ThisGameMetrics
        {
            get
            {
                return this.thisGameMetrics;
            }
            set
            {
                this.thisGameMetrics = value;
            }
        }

        private void PerformNewGameInitialization() 
        {
            this.GameBoard = new GameBoard();
            this.thisGameMetrics = new GameMetrics(true);
            this.InitializeBoards(true);
        }

        public void PerformRestartedGameInitialization()
        {
            this.thisGameMetrics = new GameMetrics(false);
            this.InitializeBoards(false);
        }

        /// <summary>
        /// Initializes the underlying and the displayed boards of the "GameBoard" object.
        /// </summary>
        /// <param name="gameBoard">The object whose boards are initilized.</param>
        private void InitializeBoards(bool newGameIsStarted) 
        {
            this.gameBoard.DisplayedBoard = InitializeDisplayedBoard();

            if (newGameIsStarted)
            {
                gameBoard.UnderlyingBoard = InitializeUnderlyingBoard();
                PlaceMines();
            }
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
        private void PlaceMines()
        {
            int boardColumns = this.gameBoard.BoardColumns;
            this.minesPositions = GenerateMinesPositions();

            foreach (int minePosition in minesPositions)
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
                this.gameBoard.UnderlyingBoard[mineRow, mineColumn - 1] = '*';
            }
        }
    }
}
