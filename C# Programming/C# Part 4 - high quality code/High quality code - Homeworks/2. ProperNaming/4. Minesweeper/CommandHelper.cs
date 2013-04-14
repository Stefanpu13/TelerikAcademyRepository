namespace MinesSweeper
{
    using System;

    public class CommandHelper
    {
        public string ReadCommand()
        {
            string command = Console.ReadLine().Trim();
            return command;
        }

        public bool CommandIsValid(string command)
        {
            return command.Length >= 3;
        }

        public bool IsValidOpenFieldCommand(string command, int boardRows, int boardColumns)
        {
            string[] fieldCoordinates =
                command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int row;
            int column;

            if (this.FieldCoordinatesAreValidIntegers(fieldCoordinates, out row, out column))
            {
                if (this.FieldCoordinatesAreInBoard(row, column, boardRows, boardColumns))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int[] ParseCommand(string command) 
        {
            string[] fieldCoordinates = command.Split(' ');
            int row = int.Parse(fieldCoordinates[0]);
            int column = int.Parse(fieldCoordinates[1]);

            int[] coordinates = new[] { row, column };

            return coordinates;
        }

        public string ConvertCommandToTurn(GameMetrics metrics, string command) 
        {
            int[] coordinates = this.ParseCommand(command);
            metrics.Row = coordinates[0];
            metrics.Column = coordinates[1];
            command = "turn";

            return command;
        }

        private bool FieldCoordinatesAreValidIntegers(string[] fieldCoordinates,
            out int row, out int column)
        {
            row = -1;
            column = -1;

            if (fieldCoordinates.Length != 2)
            {
                return false;
            }
            else
            {
                if (int.TryParse(fieldCoordinates[0], out row) &
                  int.TryParse(fieldCoordinates[1], out column))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool FieldCoordinatesAreInBoard(int row, int column, int boardRows, int boardColumns)
        {
            if ((row < boardRows && column < boardColumns) &&
                (row >= 0 && column >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
