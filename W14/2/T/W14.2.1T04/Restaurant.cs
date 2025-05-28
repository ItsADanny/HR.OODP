public class Restaurant
{
    // Restaurant

    // This class has the following properties:
    // * (String) Name (set + get)
    // * (String) City (set + get)
    // * (Int) OpeningYear (set + get)

    // A constructor is not needed

    public string Name { get; set; }
    public string City { get; set; }
    public int OpeningYear { get; set; }

    // Extend

    // Extend Restaurant with a ToString() method so the output is similar to:
    // Name: RestaurantX, City: Rotterdam, OpeningYear: 2022

    public override string ToString()
    {
        return $"Name: {Name}, City: {City}, OpeningYear: {OpeningYear}";
    }
}