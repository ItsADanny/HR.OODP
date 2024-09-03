Int32 int32_user_age_1, int32_user_age_2;

Console.WriteLine("What is your age?");
int32_user_age_1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("What is the age of the student next to you?");
int32_user_age_2 = Convert.ToInt32(Console.ReadLine());

if (int32_user_age_1 > int32_user_age_2) {
    Console.WriteLine("You are older");
} else if (int32_user_age_1 < int32_user_age_2) {
    Console.WriteLine("You are younger");
} else {
    Console.WriteLine("Your ages are equal");
}