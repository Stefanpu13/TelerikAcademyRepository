namespace MinesSweeper
{
    using System;

    public class MinesweeperEngine
    {
        public static void Run()
        {
            bool gameIsExited = false;
            TopScores topScores = new TopScores();

            do
            {
                GameBoard board = new GameBoard();
                GameMetrics metrics = new GameMetrics(true);
                GameInitializer initializer = new GameInitializer();

                initializer.PerformNewGameInitialization(ref metrics, ref board);

                Messages.PrintGreetingMessage();
                Messages.PrintInstructions();
                board.DrawBoard(board.DisplayedBoard);

                PlayGame(initializer, metrics, board, topScores);
                gameIsExited = metrics.GameIsExited;
            } while (!gameIsExited);
        }

        /// <summary>
        /// Draws the underlying or the displayed board depending on state of the game.
        /// If game is finished underlying board is printed, else the displayed board is printed.
        /// </summary>
        /// <param name="board">The "Board" object whose boards are going to be printed.</param>
        /// <param name="gameFinished">Determines if the game is finished or not.</param>
        private static void DrawBoard(GameBoard board, bool gameFinished)
        {
            if (gameFinished)
            {
                board.DrawBoard(board.UnderlyingBoard);
            }
            else
            {
                board.DrawBoard(board.DisplayedBoard);
            }
        }

        private static void PlayGame(GameInitializer initializer, GameMetrics metrics,
            GameBoard board, TopScores topScores)
        {
            CommandHelper commandHelper = new CommandHelper();
            GamePlay gameplay = new GamePlay();

            int boardRows = board.BoardRows;
            int boardColumns = board.BoardColumns;
            string command = string.Empty;
            bool gameIsFinished = false;

            do
            {
                command = commandHelper.ReadCommand();

                if (commandHelper.CommandIsValid(command))
                {
                    if (commandHelper.IsValidOpenFieldCommand(command, boardRows, boardColumns))
                    {
                        command = commandHelper.ConvertCommandToTurn(metrics, command);
                    }
                }

                gameplay.ExecuteCommand(initializer, ref metrics, board, topScores, command);
                gameIsFinished = gameplay.CheckIsGameFinished(metrics, board, topScores);

                if (!metrics.GameIsExited)
                {
                    if (metrics.MineIsBlown)
                    {
                        Messages.PrintYouDiedMessage(metrics);

                        Console.Write("Enter your name: ");
                        string name = Console.ReadLine();

                        Score finalScore = new Score(name, metrics.OpenedEmptyFields);
                        topScores.Add(finalScore);
                        topScores.DisplayRankings();
                    }

                    else if (metrics.AllMinesFound)
                    {
                        Messages.PrintYouOpenedAllFieldsMessage();

                        Console.Write("Enter your name: ");
                        string name = Console.ReadLine();

                        Score finalScore = new Score(name, metrics.OpenedEmptyFields);
                        topScores.Add(finalScore);
                        topScores.DisplayRankings();
                    }

                    DrawBoard(board, gameIsFinished);
                }
            } while (!metrics.AllMinesFound && !metrics.MineIsBlown && command != "exit");
        }
    }
}
