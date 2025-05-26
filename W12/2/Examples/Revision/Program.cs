public class Program {
    public static void Main() {
        Console.WriteLine(Mystery(5));
    }

    // public static int Mystery(int n) => n <= 1 ? 1 : n * Mystery(n - 1);
    public static int Mystery(int n) {
        return n <= 1 ? 1 : n * Mystery(n - 1);
    }
}