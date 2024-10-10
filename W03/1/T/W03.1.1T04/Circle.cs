//Create a class called Circle
class Circle {
    //This class contains 1 public double field
    public double Radius;

    //Create the Constructor and take a double as a parameter
    public Circle(double radius) {
        //And set this double as the Radius
        Radius = radius;
    }

    //Create a method that returns a double which contains
    //the area of the circle
    //Math.PI and Math.Pow are required!
    public double Area() => Math.PI * Math.Pow(Radius, 2);
}