using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class CommandHelper
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

        public bool IsValidOpenFieldCommand(string command, int boardRows, int boardColumns, out int row, out int column)
        {
            string[] fieldCoordinates = command.Split(' ');
            //int row;
            //int column;

            if (FieldCoordinatesAreValidIntegers(fieldCoordinates, out row, out column) &&
                FieldCoordinatesAreInBoard(row, column, boardRows,boardColumns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FieldCoordinatesAreInBoard(int row, int column, int boardRows,int boardColumns)
        {
            if ((row <= boardRows && column <= boardColumns) &&
                (row >= 0 && column >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FieldCoordinatesAreValidIntegers(string[] fieldCoordinates, out int row, out int column)
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
}
