public static class SalesHelper {
    public static void PrintSalesData(int[][] data) {
        for (int i = 0; i < data.Length; i++) {
            Console.WriteLine($"Sales data for department {i + 1}:");
            for (int e = 0; e < data[i].Length; e++) {
                Console.WriteLine($"- {data[i][e]}");
            }
            Console.WriteLine();
        }
    }
}