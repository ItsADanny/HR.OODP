class Program {
    static void Main(string[] args) {
        Queen queen = new(3, 7, 'W');
        //If a class is abstract then you can't create an object from that
        //class.
        // ChessPiece piece = new(0, 0, 'W');
        List<ChessPiece> pieces = [
            queen
        ];

        foreach (ChessPiece piece in pieces) {
            piece.Move(piece.Y - 1, piece.X);
        }
    }
}