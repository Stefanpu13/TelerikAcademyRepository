namespace MinesSweeper
{
    using System;

    public class GamePlay
    {
        private static char CountAdjacentMines(char[,] underlyingBoard, int currentRow, int currentCol)
        {
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

        public void MakeTurn(ref GameMetrics metrics, ref GameBoard board)
        {
            if (board.UnderlyingBoard[metrics.Row, metrics.Column] != '*')
            {
                if (board.UnderlyingBoard[metrics.Row, metrics.Column] == '-')
                {
                    this.OpenField(ref board, metrics.Row, metrics.Column);
                    metrics.OpenedEmptyFields++;
                    metrics.IsFirstTurn = false;
                }
                if (metrics.TotalEmptyFields == metrics.OpenedEmptyFields)
                {
                    metrics.AllMinesFound = true;
                }
            }
            else
            {
                if (metrics.IsFirstTurn)
                {
                    this.GuaranteeSaveFirstTurn(ref metrics, ref board);
                    this.OpenField(ref board, metrics.Row, metrics.Column);
                    metrics.OpenedEmptyFields++;

                    metrics.IsFirstTurn = false;
                }
                else
                {
                    metrics.MineIsBlown = true;
                }
            }
        }

        public bool CheckIsGameFinished(GameMetrics metrics, GameBoard board, TopScores topScores)
        {
            if (metrics.MineIsBlown)
            {
                return true;
            }

            if (metrics.AllMinesFound)
            {
                return true;
            }

            return false;
        }

        public void ExecuteCommand(GameInitializer initializer, ref GameMetrics metrics,
            GameBoard board, TopScores topScores, string command)
        {
            switch (command)
            {
                case "top":
                    topScores.DisplayRankings();
                    break;
                case "restart":
                    initializer.PerformRestartedGameInitialization(ref metrics, ref board);
                    break;
                case "exit":
                    metrics.GameIsExited = true;
                    Console.WriteLine("Bye!");
                    break;
                case "turn":
                    this.MakeTurn(ref metrics, ref board);
                    break;
                default:
                    Console.WriteLine("\nOops! Unvalid command!\n");
                    break;
            }
        }

        private GameBoard OpenField(ref GameBoard board, int row, int column)
        {
            char adjacentMines = CountAdjacentMines(board.UnderlyingBoard, row, column);
            board.UnderlyingBoard[row, column] = adjacentMines;
            board.DisplayedBoard[row, column] = adjacentMines;

            return board;
        }

        private void GuaranteeSaveFirstTurn(ref GameMetrics metrics, ref GameBoard board)
        {
            // See: http://www.techuser.net/mineclick.html for first click behaviour

            int boardRows = board.BoardRows;
            int boardColumns = board.BoardColumns;
            int currentRow = metrics.Row;
            int currentColumn = metrics.Column;

            for (int row = 0; row < boardRows; row++)
            {
                for (int column = 0; column < boardColumns; column++)
                {
                    if ((row != currentRow || column != currentColumn) &&
                        board.UnderlyingBoard[row, column] != '*')
                    {
                        board.UnderlyingBoard[row, column] = '*';
                        board.UnderlyingBoard[currentRow, currentColumn] = '-';
                        return;
                    }
                }
            }
        }
    }
}
