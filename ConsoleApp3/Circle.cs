using System;

namespace ConsoleApp3
{
    public class Circle
    {
        public int x;
        public int y;
        public int length;
        public int points;
        public double rad;
        public double area;

        public Circle(int x, int y, int length, int points)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.points = points;
            this.rad = this.length / (Math.PI * 2);
            this.area = (this.length * this.length) / (Math.PI * 4);
        }

        public bool Hit(int dotX, int dotY)
        {

            if ((dotY - this.x) * (dotX - this.x) +
                (dotY - this.y) * (dotY - this.y) <= this.rad * this.rad)
                return true;

            else
                return false;
        }

        public double shapeScore()
        {

            double equationCircle = this.getShapeType() * this.points / this.area;
            return equationCircle;
        }

        public int getShapeType()
        {
            return 2;
        }
    }
}