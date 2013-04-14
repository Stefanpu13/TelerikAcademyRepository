namespace MinesSweeper
{
    using System;

    public class Score : IComparable
    {
        private string name;
        private int points;

        public Score() { }

        public Score(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
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
                        // From two players with equal result the one whose name is 
                        // lexicographically first will be placed at a higher position.
                        return otherScore.Name.CompareTo(this.Name);
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
