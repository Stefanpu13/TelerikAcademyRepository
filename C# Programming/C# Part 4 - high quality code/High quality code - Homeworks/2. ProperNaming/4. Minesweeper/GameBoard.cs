using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class GameBoard
    {
        private char[,] underlyingBoard;
        private char[,] displayedBoard;        

        public char[,] UnderlyingBoard
        {
            get
            {
                return this.underlyingBoard;
            }
            set
            {
                this.underlyingBoard = value;
            }
        }

        public char[,] DisplayedBoard
        {
            get
            {
                return this.displayedBoard;
            }
            set
            {
                this.displayedBoard = value;
            }
        }

        public int BoardRows 
        { 
            get 
            {
                return 5;
            } 
        }

        public int BoardColumns
        {
            get
            {
                return 10;
            }
        }

        
    }
}
