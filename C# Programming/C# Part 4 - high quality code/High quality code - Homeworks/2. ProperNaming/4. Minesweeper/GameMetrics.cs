

namespace MinesSweeper
{
    using System.Reflection;
    using System.Text;

    public class GameMetrics
    {
        private readonly int totalEmptyFields = 35;
        private readonly int totalMines = 15;
        private readonly int boardRows = 5;
        private readonly int boardColumns = 10;
        private bool isFirstTurn = true;
        private bool newGameIsStarted;
        private bool mineIsBlown = false;
        private bool allMinesFound = false;
        private int row = 0;
        private int column = 0;
        private int openedEmptyFields = 0;        
        private bool gameIsExited = false;


        public GameMetrics(bool newGameIsStarted)
        {
            this.NewGameIsStarted = newGameIsStarted;
        }

        public bool IsFirstTurn
        {
            get
            {
                return this.isFirstTurn;
            }
            set
            {
                this.isFirstTurn = value;
            }
        }

        public bool GameIsExited
        {
            get
            {
                return this.gameIsExited;
            }
            set
            {
                this.gameIsExited = value;
            }
        }

        public int BoardRows
        {
            get
            {
                return this.boardRows;
            }
        }

        public int BoardColumns
        {
            get
            {
                return this.boardColumns;
            }
        }

        public int TotalMines
        {
            get
            {
                return this.totalMines;
            }
        }

        public int TotalEmptyFields
        {
            get
            {
                return this.totalEmptyFields;
            }
        }

        public bool MineIsBlown
        {
            get
            {
                return this.mineIsBlown;
            }
            set
            {
                this.mineIsBlown = value;
            }
        }

        public bool NewGameIsStarted
        {
            get
            {
                return this.newGameIsStarted;
            }
            set
            {
                this.newGameIsStarted = value;
            }
        }

        public bool AllMinesFound
        {
            get
            {
                return this.allMinesFound;
            }
            set
            {
                this.allMinesFound = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }
            set
            {
                this.column = value;
            }
        }

        public int OpenedEmptyFields
        {
            get
            {
                return this.openedEmptyFields;
            }
            set
            {
                this.openedEmptyFields = value;
            }
        }

        public override string ToString()
        {
            StringBuilder gameMetricsInfo = new StringBuilder();
            FieldInfo[] gameMetrixFields =
                this.GetType().
                GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var fieldInfo in gameMetrixFields)
            {
                gameMetricsInfo.AppendLine(fieldInfo.Name + ": " + fieldInfo.GetValue(this));
            }

            return gameMetricsInfo.ToString();
        }
    }
}
