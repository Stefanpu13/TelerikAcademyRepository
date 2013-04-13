using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MinesSweeper
{
    class GameMetrics
    {
        private bool mineIsBlown = false;
        private bool newGameIsStarted;
        private bool allMinesFound = false;
        private int row = 0;
        private int column = 0;
        private int openedEmptyFields = 0;

        public GameMetrics(bool newGameIsStarted) 
        {
            this.NewGameIsStarted = newGameIsStarted;
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

        public int TotalEmptyFields
        {
            get
            {
                return 35;
            }
        }

        public override string ToString()
        {
            StringBuilder gameMetricsInfo = new StringBuilder();
            FieldInfo[] gameMetrixFields = 
                this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldInfo in gameMetrixFields)
            {
                gameMetricsInfo.AppendLine(fieldInfo.Name + ": " + fieldInfo.GetValue(this));
            }

            return gameMetricsInfo.ToString();
        }


    }
}
