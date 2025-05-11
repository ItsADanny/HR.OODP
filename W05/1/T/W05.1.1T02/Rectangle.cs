class Rectangle
{
    public int Length, Width;

    public Rectangle(int length, int width)
    {
        Length = length;
        Width = width;
    }

    //We add Virtual to all the methods in this class.
    //We do this so that we can override them in a class which is derived from this class
    public virtual int Area() => Length * Width;
    public virtual int Perimeter() => 2*Length + 2*Width;

    public virtual string Info() => $"Length: {Length}; Width: {Width}";
}