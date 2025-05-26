public class Request
{
    public string Name;
    public string Description;
    public string CustomerName;

    public Request(string name, string description, string customerName)
    {
        Name = name;
        Description = description;
        CustomerName = customerName;
    }

    public override string ToString()
    {
        return $"Name: {Name}\nDescription: {Description}\nCustomer Name: {CustomerName}";
    }
}