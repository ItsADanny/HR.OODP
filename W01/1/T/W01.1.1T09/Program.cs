int int_age;

Console.WriteLine("");
int_age = Convert.ToInt32(Console.ReadLine());

string result = "Age " + int_age + ": invalid";
result = int_age switch
{
    int n when (int_age >= 0 && int_age <= 12) => "Age " + int_age + ": a child",
    int n when (int_age >= 13 && int_age <= 19) => "Age " + int_age + ": a teenager",
    int n when (int_age >= 20 && int_age <= 150) => "Age " + int_age + ": an adult"
};

Console.WriteLine(result);