//Create the deck class
class Deck {
    //Create a readonly list which will contain our cards
    public readonly List<Card> Cards = new List<Card>();

    //In the constructor generate the Deck and its required cards (And add the jokers if this has been requested)
    public Deck(bool areJokersIncluded) {
        //Create a list with strings which contains all the possible suits
        List<string> suits = [
            "clubs",
            "diamonds",
            "hearts",
            "spades"
        ];

        //Foreach over the suits list to generate the cards for each suit
        foreach (string suit in suits) {
            Cards.Add(new(suit, "2"));
            Cards.Add(new(suit, "3"));
            Cards.Add(new(suit, "4"));
            Cards.Add(new(suit, "5"));
            Cards.Add(new(suit, "6"));
            Cards.Add(new(suit, "7"));
            Cards.Add(new(suit, "8"));
            Cards.Add(new(suit, "9"));
            Cards.Add(new(suit, "10"));
            Cards.Add(new(suit, "ace"));
            Cards.Add(new(suit, "queen"));
            Cards.Add(new(suit, "king"));
            Cards.Add(new(suit, "jack"));
        }

        //If this deck must contain jokers then add the jokers to the deck
        if (areJokersIncluded) {
            Cards.Add(new("black", "joker"));
            Cards.Add(new("red", "joker"));
        }
    }

    public void Shuffle() {
        Random rand = new Random();
        int n = Cards.Count();
        while (n > 1) {
            n--;
            int k = rand.Next(n + 1);
            Card card = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = card;
        }
    }

    public Card Draw() {
        if (Cards.Count() >= 1) {
            //Get the last cards position
            int LastCardPos = Cards.Count() - 1;
            //Get the card from the card deck
            Card card = Cards[LastCardPos];
            //Remove the card from the deck
            Cards.Remove(card);
            //Return the drawn card
            return card;
        }
        //If we don't have any cards remaining in our deck then we return a null
        return null;
    }
}