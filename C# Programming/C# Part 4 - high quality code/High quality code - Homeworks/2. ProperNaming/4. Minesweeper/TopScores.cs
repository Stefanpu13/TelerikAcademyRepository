using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesSweeper
{
    class TopScores
    {
        private Score score;
        private List<Score> scores;
        //private string name;
        //private int points;

        public TopScores() 
        {
            this.Scores = new List<Score>();
        }

        public TopScores(string name, int points) 
        {
            this.Score = new Score(name, points);
        }

        public List<Score> Scores
        {
            get
            {
                return this.scores;
            }
            set
            {
                this.scores = value;
            }
        }

        public Score Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public void Add(Score score) 
        {
            this.SortedAdd(score);
        }

        private void SortedAdd(Score score) 
        {
            int position = 0;

            while (score.CompareTo(this.Scores[position])<0)
            {
                position++;
            }

            this.Scores.Insert(position, score);

            if (this.Scores.Count>5)
            {
                this.Scores.RemoveAt(this.Scores.Count - 1);
            }

            //DisplayRankings(topScorers);
        }

        public void DisplayRankings()
        {
            Console.WriteLine("\nPoints:");
            if (this.Scores.Count > 0)
            {
                for (int i = 0; i < this.Scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields opened",
                        i + 1, this.Scores[i].Name, this.Scores[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No scores!!\n");
            }
        }
    }
}
