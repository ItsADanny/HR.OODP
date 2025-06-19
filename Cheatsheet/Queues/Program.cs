using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main()
    {
        //Create a new Queue object
        Queue<Player> players = new Queue<Player>(); //First in, First out

        //Add players to the queue
        players.Enqueue(new Player("Player 1", "Wizard", 100));
        players.Enqueue(new Player("Player 2", "Knight", 100));

        while (players.Count != 0) //Continue the loop until the Queue reaches 0
        {
            Player selectPlayer = players.Peek(); //Get the current player from the Queue
            Console.WriteLine(selectPlayer.ToString());
            players.Dequeue(); //Remove the current player from the Queue
        }
    }
}

public class Player
{
    public string Name;
    public string Class;
    public int Health;
    private int MaxHealth;

    public Player(string name, string pClass, int health)
    {
        Name = name;
        Class = pClass;
        MaxHealth = health;
        Health = MaxHealth;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Class: {Class}, Health: {Health}/{MaxHealth}";
    }
}