public class Program
{
    public static void Main()
    {
        //Create a new Stack object
        Stack<Card> cards = new Stack<Card>(); //First in, Last out

        //Add the cards to the stack
        cards.Push(new Card("Ace of Spades", 20));
        cards.Push(new Card("Queen", 10));

        while (cards.Count != 0) //Continue the loop until the Stack reaches 0
        {
            Card selectedCard = cards.Peek(); //Get the most recent item from the Stack
            Console.WriteLine(selectedCard.ToString()); //Remove the most recent item from the Stack
            cards.Pop();
        }
    }
}

public class Card
{
    public string Name;
    public int Points;

    public Card(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Points: {Points}";
    }
}