public class Program
{
    public static void Main()
    {
        //Create class Program with a Main that has a List of these Customers:

        // * Alice who lives in New York;
        // * Bob who lives in London;
        // * Charlie who lives in New York;
        // * Dave who lives in Paris.

        // Create a LINQ query that, from the customers where the city is New York, selects their name and print them.

        // NOTE: LINQ queries can be done with either the keywords from, where, select keywords, or the methods From, Where, Select methods.

        List<Customer> customers = [
            new Customer() { Name="Alice", City="New York" },
            new Customer() { Name="Bob", City="London" },
            new Customer() { Name="Charlie", City="New York" },
            new Customer() { Name="Dave", City="Paris" }
        ];

        List<Customer> names = customers.Select(c => c).Where(c => c.City == "New York").ToList();
        Print(names);
    }

    public static void Print(List<Customer> data)
    {
        foreach (Customer customer in data) {
            Console.WriteLine(customer.Name);
        }
    }
}