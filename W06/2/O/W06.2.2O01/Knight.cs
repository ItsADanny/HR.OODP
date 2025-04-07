public class Knight : ChessPiece {
    int X {get; set;}
    int Y {get; set;}
    bool IsWhite {get; set;}

    public Knight(int x, int y, bool isWhite): base(x, y, isWhite) {
        X = x;
        Y = y;
        IsWhite = isWhite;
    }

    public override bool CanMove(int xAmount, int yAmount) {
        if (xAmount == 2 && yAmount == 1 | xAmount == -2 && yAmount == -1) {
            return true;
        }
        if (xAmount == 1 && yAmount == 2 | xAmount == -1 && yAmount == -2) {
            return true;
        }

        return false;
    }

    public override string ToString() => IsWhite ? $"White Knight at ({X}, {Y})" : $"Black Knight at ({X}, {Y})";
}