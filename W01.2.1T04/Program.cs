Int32 int32_attempts = 0;

for (; int32_attempts != 3; int32_attempts++) {
    Console.WriteLine("Enter your PIN");
    Console.WriteLine(3 - int32_attempts + " attempts left");
    String str_pin_attempt = Console.ReadLine();
    if (str_pin_attempt == "1234") {
        Console.WriteLine("Correct!");
        break;
    }
}

if (int32_attempts == 3) {
    Console.WriteLine("Your pass is confiscated.");
}