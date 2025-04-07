namespace ChessPieces.Tests;

[TestClass]
public class ChessPiecesTest
{
    /* 
        Create data rows for the following moves: 
            x=1,y=3,expected=true
            x=4,y=2,expected=true
            x=4,y=3,expected=false
    */
    [DataTestMethod]
    [DataRow(1, 3, true)]
    [DataRow(4, 2, true)]
    [DataRow(4, 3, false)]
    public void CanMove_WhiteKnight(int x, int y, bool expected)
    {
        Knight WhiteKnight = new Knight(2, 1, true);
        Assert(WhiteKnight.CanMove(x, y) == expected);

        // create a white knight object with x = 2 and y = 1
        // Assert that the boolean value returned from the CanMove method equals the expected boolean value
    }

    /* 
        Create data rows for the following moves: 
            x=6,y=6,expected=true
            x=5,y=7,expected=true
            x=8,y=8,expected=false
    */
    [DataTestMethod]
    [DataRow(6, 6, true)]
    [DataRow(5, 7, true)]
    [DataRow(8, 8, false)]
    public void CanMove_BlackKnight(int x, int y, bool expected)
    {
        // create a black knight object with x = 7 and y = 8
        // Assert that the boolean value returned from the CanMove method equals the expected boolean value

        Knight BlackKnight = new Knight(7, 8, false);
        Assert(BlackKnight.CanMove(x, y) == expected);   
    }

}