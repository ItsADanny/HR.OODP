class PlayingCard
{
    public string Suit;
    public string Rank;

    //Remove the void from the constructor to fix the constructor
    public PlayingCard(string suit, string rank)
    {
        this.Suit = suit;
        this.Rank = rank;
    }

    public string GetDescription() => $"The {this.Rank} of {this.Suit}";
}