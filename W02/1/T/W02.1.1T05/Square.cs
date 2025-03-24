class Square
{
    public int Side;

    public Square(int side)
    {
        this.Side = side;
    }

    public int GetArea() => this.Side * this.Side;
    public int GetPerimeter() => 4 * this.Side;
}