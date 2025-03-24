static class Program
{
    static void Main()
    {
        Animal pet1 = null ;
        Person person1 = new("John Doe", pet1);
        Console.WriteLine(person1.Info());

        Animal pet2 = new("Max", "Whoof!");
        Person person2 = new Person("Jane Doe", pet2);
        Console.WriteLine(person2.Info());
    }
}