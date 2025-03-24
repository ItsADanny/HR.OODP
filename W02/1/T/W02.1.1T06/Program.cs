static class Program
{
    static void Main()
    {
        Person person1 = new("Bruce", "Wayne");
        Person person2 = new("Clark", "Kent");
        Person person3 = new("Diana", "Prince");

        List<Person> personList = [person1, person2, person3];
        foreach (var person in personList)
        {
            Console.WriteLine(person.Introduce());
        }
    }
}