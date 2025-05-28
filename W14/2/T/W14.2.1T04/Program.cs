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

        // Inside Program.cs use the provided data to print a list of restaurants that are in Gouda or Utrecht.
        // You can only use Query Expression for this assignment.
        // Results should be sorted based on the year they opened (from the first to open to the last to open)

        List<Restaurant> restaurants1 = restaurants.Where(r => r.City == "Gouda" | r.City == "Utrecht").OrderBy(r => r.OpeningYear).ToList();

        Print(restaurants1);
    }

    public static void Print(List<Restaurant> data)
    {
        foreach (Restaurant restaurant in data)
        {
            Console.WriteLine(restaurant.ToString());
        }
    }
}