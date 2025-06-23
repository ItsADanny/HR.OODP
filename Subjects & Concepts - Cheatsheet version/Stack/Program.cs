//Create a new Stack object
Stack<string> cards = new Stack<string>(); //First in, Last out

cards.Push("Ace of Spades"); //Add the card to the stack
cards.Push("Queen"); //Add the card to the stack

while (cards.Count != 0)
{ //Continue the loop until the Stack reaches 0
    string selectedCard = cards.Peek(); //Get the most recent item from the Stack
    Console.WriteLine(selectedCard); //Remove the most recent item from the Stack
    cards.Pop();
}

//Output:
//Queen
//Ace of Spades
