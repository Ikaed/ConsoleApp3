using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Lägga till i game


            Console.WriteLine("Mata in punkten (X,Y)");
            var inputDot = Console.ReadLine();

            //"shape ,X,Y,LENGTH ,POINTS;CIRCLE ,3,1,13,100; CIRCLE ,1,-1,15,200; square, -1 ,0 ,20 ,300; SQUARE , -3 ,2 ,8 ,400;";


            Console.WriteLine("Mata in värdena");


            var stringInput = Console.ReadLine().ToUpper();

            var trimmedInputDot = inputDot.Substring(1, inputDot.Length - 2);

            Console.WriteLine(trimmedInputDot);

            var trimmed = string.Concat(stringInput.Where(c => !char.IsWhiteSpace(c)));


            var dotValue = Regex.Split(trimmedInputDot, @",");


            var inputDotX = Convert.ToInt32(dotValue[0]);
            var inputDotY = Convert.ToInt32(dotValue[1]);


            //Header
            var startIndexHeader = 0;
            var lengthIndexHeader = 23;

            var substringHeader = trimmed.Substring(startIndexHeader, lengthIndexHeader);

            var headerVariables = Regex.Split(substringHeader, @",|;");


            var substringVariables = trimmed;

            //string[] listVariables = Regex.Split(substringVariables, @";|,");
            var listVariables = Regex.Split(substringVariables, @";");


            var indexShape = Array.FindIndex(headerVariables, row => row.Contains("SHAPE"));
            var indexX = Array.FindIndex(headerVariables, row => row.Contains("X"));
            var indexY = Array.FindIndex(headerVariables, row => row.Contains("Y"));
            var indexPoints = Array.FindIndex(headerVariables, row => row.Contains("POINTS"));
            var indexLength = Array.FindIndex(headerVariables, row => row.Contains("LENGTH"));


            var values = new List<string[]>();


            for (var i = 1; i <= listVariables.Length - 1; i++)
            {
                var seperateValues = Regex.Split(listVariables[i], @",");
                values.Add(seperateValues);
            }

            // Remove last array
            values.RemoveAt(values.Count - 1);

            var counterRow = 0;
            foreach (var item in values)
            {
                var counterCol = 0;
                Console.WriteLine("Row " + counterRow);
                foreach (var i in item)
                {
                    Console.WriteLine("Col " + counterCol + " " + i);
                    counterCol++;
                }

                counterRow++;
            }


            var shapeCircle = new List<Circle>();
            var shapeSquare = new List<Square>();


            foreach (var row in values)
            {
                var x = Convert.ToInt32(row[indexX]);
                var y = Convert.ToInt32(row[indexY]);
                var length = Convert.ToInt32(row[indexLength]);
                var points = Convert.ToInt32(row[indexPoints]);


                if (row[indexShape] == "CIRCLE")
                    shapeCircle.Add(new Circle(x, y, length, points));
                else if (row[indexShape] == "SQUARE") shapeSquare.Add(new Square(x, y, length, points));
            }

            var hitCircle = new List<double>();
            var missCircle = new List<double>();

            var dot = new Dot(inputDotX, inputDotY);

            foreach (var c in shapeCircle)
                if (c.Hit(dot.dotX, dot.dotY))
                    hitCircle.Add(c.shapeScore());
                else
                    missCircle.Add(c.shapeScore());


            var hitSquare = new List<double>();
            var missSquare = new List<double>();


            foreach (var s in shapeSquare)
                if (s.Hit(dot.dotX, dot.dotY))
                    hitSquare.Add(s.shapeScore());
                else
                    missSquare.Add(s.shapeScore());

            //Presenterar poängresultatet för spelet
            var game = new Game(missCircle, missSquare, hitSquare, hitCircle);
            Console.WriteLine("Poängresultat: " + game.score);
        }
    }
}