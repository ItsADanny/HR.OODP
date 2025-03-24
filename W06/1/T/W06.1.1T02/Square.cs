public class Square : IDrawable, IResizable
{
    public int Size { get; private set; }
    public Square(int size) => Size = size;

    public void Resize(double scale) => Size = (int) (Convert.ToDouble(Size) * scale);

    public void Draw() {
        for (int y = 0; y != Size; y++) {
            string row = "";
            for (int x = 0; x != Size; x++) {
                row += "*";
            }
            Console.WriteLine(row);
        }
    }
}