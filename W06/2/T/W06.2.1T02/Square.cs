public class Square : Shape {
    public override double Area { get; }
    public override double Perimeter { get; }

    public Square(double length) {
        Area = length * length;
        Perimeter = length * 4;
    }

    public override string Info() => $"Square with sides of {Perimeter / 4}";
}