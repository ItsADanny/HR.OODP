Int32 int32_age;

Console.WriteLine("");
int32_age = Convert.ToInt32(Console.ReadLine());

string result = int32_age switch
{
    int n when (int32_age >= 0 && int32_age <= 12) => "Age " + int32_age + ": a child",
    int n when (int32_age >= 0 && int32_age <= 12) => "Age " + int32_age + ": a teenager",
    int n when (int32_age >= 0 && int32_age <= 12) => "Age " + int32_age + ": an adult",
    int n when (int32_age >= 0 && int32_age <= 12) => "Age " + int32_age + ": invalid",
};

Console.WriteLine(result);