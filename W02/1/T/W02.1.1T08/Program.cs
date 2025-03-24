static class Program
{
    static void Main()
    {
        PlayingCard card = new("Spades", "Ace");
        Console.WriteLine(card.GetDescription());
    }
}