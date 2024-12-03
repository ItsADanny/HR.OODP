public class Car {
    public string Brand;
    public string Color;

    public Car(string brand, string color) {
        Brand = brand;
        Color = color;
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Color: {Color}";
    }
}