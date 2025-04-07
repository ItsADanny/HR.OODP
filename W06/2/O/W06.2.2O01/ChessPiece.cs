public abstract class ChessPiece {
    int X {get; set;}
    int Y {get; set;}
    bool IsWhite {get; set;}

    public ChessPiece(int x, int y, bool isWhite) {
        X = x;
        Y = y;
        IsWhite = isWhite;
    }

    public abstract bool CanMove(int x, int y);
}