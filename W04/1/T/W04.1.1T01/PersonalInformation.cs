public static class PersonalInformation {

    public static void PrintName(string input) {
        Console.WriteLine(input);
    }

    public static void PrintName(string input1, string input2) {
        Console.WriteLine($"{input1} {input2}");
    }

    public static void PrintName(char input1, string input2) {
        Console.WriteLine($"{input1}. {input2}");
    }

    public static int IncreaseSalary(int input) => input += 100;

    public static double IncreaseSalary(int input1, double input2) => (Convert.ToDouble(input1) * input2) + Convert.ToDouble(input1);
}