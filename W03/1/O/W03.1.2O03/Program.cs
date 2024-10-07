//This Program can be used to test your Game and Player classes
//If you have written you Game and Player classes correctly the your result should be that player 1
//Will win this game
class Program {
    static void Main () {
        //Create two player objects
        Player p1 = new Player("P1", 3, 9, 6);
        Player p2 = new Player("P2", 6, 6, 6);
        //We then create a Game object
        Game game = new Game(p1, p2);
        
        //We print the instructions for this game
        Console.WriteLine(Game.Instructions());

        //We then create a Dict to store our score
        Dictionary<Player, int> gameScore = new Dictionary<Player, int>();
        //We then add both player to our gameScore dictionary
        gameScore.Add(p1, 0);
        gameScore.Add(p2, 0);
        
        //We then go through the rounds in the game
        gameScore[game.Round1()]++;
        gameScore[game.Round2()]++;
        gameScore[game.Round3()]++;

        //At the end we retrieve both players their score and then display the final results and the winner
        int scoreP1 = gameScore[p1];
        int scoreP2 = gameScore[p2];

        //We print both players their scores
        Console.WriteLine($"Player 1: {scoreP1} points");
        Console.WriteLine($"Player 2: {scoreP2} points");

        //If player 1's score is higher then we print that player 1 has won
        if (scoreP1 > scoreP2) {
            Console.WriteLine("Player 1 has won the game!");
        //If player 2's score is higher then we print that player 2 has won
        } else if (scoreP1 < scoreP2) {
            Console.WriteLine("Player 2 has won the game!");
        //If its a draw then we print that the game has ended in a draw
        //(This is impossible with the way the game is designed but still)
        } else {
            Console.WriteLine("You both lost!, The game ended in a draw");
        }
    }
}