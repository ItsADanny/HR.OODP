using System.Globalization;

public class Plant : IComparable<Plant>
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock
    {
        get
        {
            return _stock;
        }
    }
    private int _stock;
    public DateOnly LastSold { get; set; }

    public Plant(string name, string category, int stock, string lastSold)
    {
        Name = name;
        Category = category;
        _stock = stock;
        LastSold = DateOnly.ParseExact(lastSold, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    public int CompareTo(Plant other)
    {
        return other == null ? 1 : Stock.CompareTo(other.Stock);
    }

    public int Sell(int amount)
    {
        if (amount <= _stock)
        {
            //Update the stock
            _stock -= amount;

            //Update the property LastSold to now
            LastSold = DateOnly.FromDateTime(DateTime.Now);

            //Return the amount we sold
            return amount;
        }
        else
        {
            //Get the amount of stock that is available, and update _stock to 0
            int sold = _stock;
            _stock = 0;

            //Update the property LastSold to now
            LastSold = DateOnly.FromDateTime(DateTime.Now);

            //Return the amount we sold
            return sold;
        }
    }
}