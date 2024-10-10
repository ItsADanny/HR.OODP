abstract class ChessPiece {
    public int X;
    public int Y;

    public char Color;
    public bool IsCaptured = false;

    public ChessPiece(int x, int y, char color) {
        X = x;
        Y = y;
        Color = color;
    }

    //Here we declare that a class based on the ChessPiece class.
    //Should have a function called move
    public abstract void Move(int destX, int destY);
}