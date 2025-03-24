public class Program {
    static void Main() {
        List<Bill> bills = new () {
            new ElectricityBill(50, "John Smith"),
            new ElectricityBill(75, "Jane Doe"),
            new GasBill(100, "Bob Johnson", false),
            new GasBill(125, "John Doe", true)
        };

        double total = 0;
        foreach (Bill bill in bills) {
            Console.WriteLine(bill.GetDescription());
            total += (int) bill.Amount;
        }
        Console.WriteLine($"Total amount: {total}");
    }
}