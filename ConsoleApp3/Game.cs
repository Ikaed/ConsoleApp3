using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    public class Game
    {
        public double score;
        public List<double> shapeScoreHit = new List<double>();
        public List<double> shapeScoreMiss = new List<double>();


        public Game(List<double> shapeScoreMiss, List<double> shapeScoreHit, double score)
        {
            this.shapeScoreMiss = shapeScoreMiss;
            this.shapeScoreHit = shapeScoreHit;
            this.score = score;
        }


        public Game(List<double> missCircle, List<double> missSquare, List<double> hitSquare,
            List<double> hitCircle)
        {
            shapeScoreMiss = missCircle.Concat(missSquare).ToList();
            shapeScoreHit = hitSquare.Concat(hitCircle).ToList();
            score = Math.Round(shapeScoreHit.Sum() - 0.25 * shapeScoreMiss.Sum());
        }
    }
}