//We begin by creating a class which is derived from the Rectangle class
//(In other words, this class inherits from the Rectangle class)
class Cuboid : Rectangle {
    //We add a public integer field called Height
    public int Height;

    //We make a initializer for Cuboid and we use Base for the length and width.
    //but we put the Height into the Height field.
    public Cuboid(int length, int width, int height) : base(length, width) {
        Height = height;
    }

    //We make a method called Volume() which takes no parameters and return a integer with the volume of our Cuboid
    public int Volume() => Length * Width * Height;

    //We override the method Area() from the base class and put in our specific version for Cuboid
    //Formula: (2* (l*w + l*h + w*h))
    public override int Area() => 2 * ((Length * Width) + (Length * Height) + (Width * Height));

    //We override the method Perimeter() from the base class and put in our specific version for Cuboid
    //Formula: (4 * (l + w + h))
    public override int Perimeter() => 4 * (Length + Width + Height);

    //We override the method Info() from our base class and put in our specific version for Cuboid
    public override string Info()
    {
        //We use the string which we get from our base classes Info() method and 
        //add a small part to the end of the string with the Height of our Cuboid
        return base.Info() + "; Height: 6";
    }
}