//Create a new Queue object
Queue<string> players = new Queue<string>(); //First in, First out

players.Enqueue("Henry"); //Add player to the queue
players.Enqueue("Sander"); //Add player to the queue

while (players.Count != 0)
{ //Continue the loop until the Queue reaches 0
    string selectPlayer = players.Peek(); //Get the current player from the Queue
    Console.WriteLine(selectPlayer);
    players.Dequeue(); //Remove the current player from the Queue
}

//Output:
//Henry
//Sander
