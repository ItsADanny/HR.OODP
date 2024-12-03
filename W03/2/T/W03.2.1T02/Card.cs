//Create an class called Card
class Card {
    //In this class we want 2 fields that are going to be readonly (as seen in the UML class diagram)
    public readonly string Suit;
    public readonly string Rank;

    //In the constructor for the Card class set the inputted suit and rank to the objects suit and rank fields
    public Card(string suit, string rank) {
        Suit = suit.ToLower();
        Rank = rank.ToLower();
    }

    //Make a method which will return the name of the card
    public string GetName() {
        //Check to see if the Suit is "clubs"
        if (Suit == "clubs") {
            //Check to see if the card object contains a valid rank, if not then we also return a invalid message at the end
            if (Rank == "ace") {
                return "Ace of Clubs";
            }
            if (Rank == "king") {
                return "King of Clubs";
            }
            if (Rank == "queen") {
                return "Queen of Clubs";
            }
            if (Rank == "jack") {
                return "Jack of Clubs";
            }
            int.TryParse(Rank, out int IntRank);
            if (IntRank != 0 & IntRank >= 2 & IntRank <= 10) {
                return $"{IntRank} of Clubs";
            }
        }
        //Check to see if the Suit is "diamonds"
        if (Suit == "diamonds") {
            //Check to see if the card object contains a valid rank, if not then we also return a invalid message at the end
            if (Rank == "ace") {
                return "Ace of Diamonds";
            }
            if (Rank == "king") {
                return "King of Diamonds";
            }
            if (Rank == "queen") {
                return "Queen of Diamonds";
            }
            if (Rank == "jack") {
                return "Jack of Diamonds";
            }
            int.TryParse(Rank, out int IntRank);
            if (IntRank != 0 & IntRank >= 2 & IntRank <= 10) {
                return $"{IntRank} of Diamonds";
            }
        }
        //Check to see if the Suit is "hearts"
        if (Suit == "hearts") {
            //Check to see if the card object contains a valid rank, if not then we also return a invalid message at the end
            if (Rank == "ace") {
                return "Ace of Hearts";
            }
            if (Rank == "king") {
                return "King of Hearts";
            }
            if (Rank == "queen") {
                return "Queen of Hearts";
            }
            if (Rank == "jack") {
                return "Jack of Hearts";
            }
            int.TryParse(Rank, out int IntRank);
            if (IntRank != 0 & IntRank >= 2 & IntRank <= 10) {
                return $"{IntRank} of Hearts";
            }
        }
        //Check to see if the Suit is "spades"
        if (Suit == "spades") {
            //Check to see if the card object contains a valid rank, if not then we also return a invalid message at the end
            if (Rank == "ace") {
                return "Ace of Spades";
            }
            if (Rank == "king") {
                return "King of Spades";
            }
            if (Rank == "queen") {
                return "Queen of Spades";
            }
            if (Rank == "jack") {
                return "Jack of Spades";
            }
            int.TryParse(Rank, out int IntRank);
            if (IntRank != 0 & IntRank >= 2 & IntRank <= 10) {
                return $"{IntRank} of Spades";
            }
        }
        //Check to see if the suit is a color and the rank is j (This would indicate that it is a Joker card)
        if (Suit == "red" & Rank == "joker") {
            return "Red Joker";
        }
        if (Suit == "black" & Rank == "joker") {
            return "Red Joker";
        }
        //If the suit and rank aren't a valid type then we return a error message
        return "INVALID CARD";
    }
}