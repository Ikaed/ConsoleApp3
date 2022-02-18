namespace ConsoleApp3
{
    public class Square
    {
        public int x;
        public int y;
        public int length;
        public int points;
        public int area;
        public int botX;
        public int botY;
        public int topX;
        public int topY;


        public Square(int indexX, int indexY, int indexLength, int indexPoints)
        {
            this.x = indexX;
            this.y = indexY;
            this.length = indexLength;
            this.points = indexPoints;
            this.area = (this.length / 4) * (this.length / 4);
            this.botX = this.x - (this.length / 2);
            this.botY = this.y - (this.length / 2);
            this.topX = this.x + (this.length / 2);
            this.topY = this.y + (this.length / 2);
        }
        //int botX, int botY, int topX, int topY,
        public bool Hit(int dotX, int dotY)
        {
            if (dotX > this.botX && dotX < this.topX &&
                dotY > this.botY && dotY < this.topY)
                return true;

            else

                return false;
        }
        public double shapeScore()
        {
            double equationSquare = this.getShapeType() * this.points / this.area;
            return equationSquare;
        }
        public int getShapeType()
        {
            return 1;
        }
    }
}