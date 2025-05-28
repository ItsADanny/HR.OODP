public class Program
{
    public static void Main()
    {
        List<Restaurant> restaurants = new List<Restaurant>() {
            new Restaurant() {  Name = "De Gouden Draak", City = "Rotterdam", OpeningYear = 1998 },
            new Restaurant() {  Name = "De Vergulde lepel", City = "Rotterdam", OpeningYear = 2001 },
            new Restaurant() {  Name = "Het Zalmpje", City = "Gouda", OpeningYear = 1998 },
            new Restaurant() {  Name = "Wokcity", City = "Utrecht", OpeningYear = 2002 },
            new Restaurant() {  Name = "Pizzaria Italia", City = "Utrecht", OpeningYear = 2001 },
            new Restaurant() {  Name = "Restaurant Garam Masala", City = "Rotterdam", OpeningYear = 2006 },
            new Restaurant() {  Name = "Friethuis Zuid", City = "Rotterdam", OpeningYear = 2012 },
            new Restaurant() {  Name = "Pizzaria Della Nonna", City = "Gouda", OpeningYear = 2001 },
            new Restaurant() {  Name = "Punjabi Foods", City = "Utrecht", OpeningYear = 2009 },
        };

        // Program

        // Inside Program.cs use the provided data to print a list of all opening years with the amount of restaurants that opened in that year.
        // Output format will be like: {Year}:{AmountOfRestaurants}
        // Make sure the order is based on the amount of restaurants per year (most first)

        IEnumerable<IGrouping<int, Restaurant>> Grouped = restaurants.GroupBy(r => r.OpeningYear).OrderByDescending(k => k.Count());

        Print(Grouped);
    }

    public static void Print(IEnumerable<IGrouping<int, Restaurant>> data)
    {
        foreach (var Group in data)
        {
            Console.WriteLine($"{Group.Key}:{Group.Count()}");
        }
    }
}