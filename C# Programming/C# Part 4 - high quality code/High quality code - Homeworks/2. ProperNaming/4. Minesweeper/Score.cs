namespace MinesSweeper
{
    using System;

    public class Score:IComparable
    {
        private string name;
        private int points;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Score() { }

        public Score(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public int CompareTo(object other) 
        {
            if (other == null)
            {
                return 1; 
            }
            else
            {
                if (other is Score)
                {
                    Score otherScore = other as Score;

                    if (this.Points == otherScore.Points)
                    {
                        return this.Name.CompareTo(otherScore.Name);
                    }
                    else
                    {
                        return this.Points - otherScore.Points;
                    }
                }
                else
                {
                    throw new ArgumentException("Object is not a score");
                }
            }          
        }
    }
    
}
