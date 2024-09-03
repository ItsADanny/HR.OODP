Int32 int32_age;

Console.WriteLine("");
int32_age = Convert.ToInt32(Console.ReadLine());

switch (int32_age)
{
    case int32_age >= 0 and <= 12:
        Console.WriteLine("Age " + int32_age + ": a child");
        break;
    case int32_age is >= 13 and <= 19:
        Console.WriteLine("Age " + int32_age + ": a teenager");
        break;
    case int32_age is >= 20 and <= 150:
        Console.WriteLine("Age " + int32_age + ": an adult");
        break;
    default:
        Console.WriteLine("Age " + int32_age + ": invalid");
        break;
}