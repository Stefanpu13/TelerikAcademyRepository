using System;
using System.Collections.Generic;

namespace MinesSweeper
{
	public class Mine
	{
		

		static void Main()
		{
			string command = string.Empty;
			char[,] board = CreateBoard();
            char[,] boardWithMines = PlaceMines();
            
			int openedEmptyFields = 0;
			bool mineIsBlown = false;
			List<Score> topScorers= new List<Score>(6);
			int row = 0;
			int column = 0;
			bool newGameIsStarted = true;
			const int totalEmptyFields = 35;
			bool allMinesFound = false;

            // Playing the game
			do
			{
				if (newGameIsStarted)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					DrawBoard(board);
					newGameIsStarted = false;
				}

				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();

                // TODO: Command validation. To be placed in different method/class - 
                // "ValidadeCommand"
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= board.GetLength(0) && column <= board.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						DisplayRankings(topScorers);
						break;
					case "restart":
						board = CreateBoard();
						boardWithMines = PlaceMines();
						DrawBoard(board);
						mineIsBlown = false;
						newGameIsStarted = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (boardWithMines[row, column] != '*')
						{
							if (boardWithMines[row, column] == '-')
							{
								MakeTurn(board, boardWithMines, row, column);
								openedEmptyFields++;
							}
							if (totalEmptyFields == openedEmptyFields)
							{
								allMinesFound = true;
							}
							else
							{
								DrawBoard(board);
							}
						}
						else
						{
							mineIsBlown = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}

				if (mineIsBlown)
				{
					DrawBoard(boardWithMines);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", openedEmptyFields);

                    //TODO: read name and place in topscorers list - move to different method
                    // Create Scorers Class(!!!?) where to add and display top scorers.
					string name = Console.ReadLine();
					Score finalScore = new Score(name, openedEmptyFields);
					if (topScorers.Count < 5)
					{
                        topScorers.Add(finalScore);
					}
					else
					{
						for (int i = 0; i < topScorers.Count; i++)
						{
                            if (topScorers[i].Points < finalScore.Points)
							{
                                topScorers.Insert(i, finalScore);
								topScorers.RemoveAt(topScorers.Count - 1);
								break;
							}
						}
					}
                    // TODO: sort Scorers - move to different method.
					topScorers.Sort((Score scoreOne, Score scoreTwo) =>
                        scoreTwo.Name.CompareTo(scoreOne.Name));
					topScorers.Sort((Score scoreOne, Score scoreTwo) =>
                        scoreTwo.Points.CompareTo(scoreOne.Points));
					DisplayRankings(topScorers);

                    // Game reinitialisation TODO: move to different method/part of the program. 
					board = CreateBoard();
					boardWithMines = PlaceMines();
					openedEmptyFields = 0;
					mineIsBlown = false;
					newGameIsStarted = true;
				}

				if (allMinesFound)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					DrawBoard(boardWithMines);
					Console.WriteLine("Daj si imeto, batka: ");
					string name = Console.ReadLine();
					Score totalPoints = new Score(name, openedEmptyFields);
					topScorers.Add(totalPoints);
					DisplayRankings(topScorers);

                    // Game reinitialisation TODO: move to different method/part of the program. 
					board = CreateBoard();
					boardWithMines = PlaceMines();
					openedEmptyFields = 0;
					allMinesFound = false;
					newGameIsStarted = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void DisplayRankings(List<Score> scores)
		{
			Console.WriteLine("\nTo4KI:");
			if (scores.Count > 0)
			{
				for (int i = 0; i < scores.Count; i++)
				{
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, scores[i].Name, scores[i].Points);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void MakeTurn(char[,] board,
			char[,] boardWithMines, int row, int column)
		{
			char adjacentMines = CountAdjacentMines(boardWithMines, row, column);
            boardWithMines[row, column] = adjacentMines;
			board[row, column] = adjacentMines;
		}

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

		private static char[,] CreateBoard()
		{
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
			{
                for (int col = 0; col < boardColumns; col++)
				{
					board[row, col] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceMines()
		{
            // TODO: This code initialises empty board. Place it in different method - 
            // CreateEmptyBoard. "PlaceMines" should take board as parameter!!?
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];

			for (int row = 0; row < boardRows; row++)
			{
                for (int column = 0; column < boardColumns; column++)
				{
                    board[row, column] = '-';
				}
			}

            // TODO: move this code in different method  - GenerateMinePositions
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

			foreach (int minePosition in mines)
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
				board[mineRow, mineColumn - 1] = '*';
			}

			return board;
		}

		private static char CountAdjacentMines(char[,] board, int currentRow, int currentCol)
		{
            // TODO: chexk adjacent spelling
			int adjacentMinesCount = 0;
			int boardRows = board.GetLength(0);
			int boardColumns = board.GetLength(1);

			if (currentRow - 1 >= 0)
			{
				if (board[currentRow - 1, currentCol] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			if (currentRow + 1 < boardRows)
			{
				if (board[currentRow + 1, currentCol] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			if (currentCol - 1 >= 0)
			{
				if (board[currentRow, currentCol - 1] == '*')
				{ 
					adjacentMinesCount++;
				}
			}
			if (currentCol + 1 < boardColumns)
			{
				if (board[currentRow, currentCol + 1] == '*')
				{ 
					adjacentMinesCount++;
				}
			}
			if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
			{
				if (board[currentRow - 1, currentCol - 1] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			if ((currentRow - 1 >= 0) && (currentCol + 1 < boardColumns))
			{
				if (board[currentRow - 1, currentCol + 1] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			if ((currentRow + 1 < boardRows) && (currentCol - 1 >= 0))
			{
				if (board[currentRow + 1, currentCol - 1] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			if ((currentRow + 1 < boardRows) && (currentCol + 1 < boardColumns))
			{
				if (board[currentRow + 1, currentCol + 1] == '*')
				{ 
					adjacentMinesCount++; 
				}
			}
			return char.Parse(adjacentMinesCount.ToString());
		}

        //public static bool newGameStarted { get; set; }
    }
}
