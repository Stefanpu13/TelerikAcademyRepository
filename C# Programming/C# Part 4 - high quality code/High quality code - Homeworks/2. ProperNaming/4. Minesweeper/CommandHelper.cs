using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class Command
    {
        private GameMetrics metrics;

        public GameMetrics Metrics
        {
            get
            {
                return this.metrics;
            }
            set
            {
                this.metrics = value;
            }
        }

        string ReadCommand()
        {
            string command = Console.ReadLine().Trim();
            return command;
        }

        bool IsCommandValid(string command)
        {
            return command.Length >= 3;
        }

        bool IsOpenFieldCommand(string command)
        {
            string[] fieldCoordinates = command.Split(' ');
            int row;
            int column;

            if (FieldCoordinatesAreValidIntegers(fieldCoordinates, out row, out column) &&
                FieldCoordinatesAreInBoard(row, column))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FieldCoordinatesAreInBoard(int row, int column)
        {
            if ((row <= this.metrics.TotalRows && column <= this.metrics.TotalColumns) &&
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
