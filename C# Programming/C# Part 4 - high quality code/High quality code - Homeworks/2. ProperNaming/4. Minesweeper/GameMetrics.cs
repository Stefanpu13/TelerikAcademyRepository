﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int TotalEmptyFields
        {
            get
            {
                return 35;
            }
        }
    }
}