public class Circle : Shape {
    public override double Area { get; }
    public override double Perimeter { get; }

    public Circle(double radius) {
        Area = radius * Math.PI;
        Perimeter = (radius * Math.PI) * 2;
    }

    public override string Info() => $"Square with sides of {Area / Math.PI}";
}