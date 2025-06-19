public class Program
{
    public static Person one = new Person("Kyle", 12);
    public static Person two = new Person("Henry", 14);
    public static Person three = new Person("Kyle", 12);
    public static Person? four = null;

    public static void Main()
    {
        Console.WriteLine($"Person \"one\" ({one.Name}) and \"two\" ({two.Name}) are equal: {one.Equals(two)}");        //False
        Console.WriteLine($"Person \"one\" ({one.Name}) and \"three\" ({three.Name}) are equal: {one.Equals(three)}");  //True
        Console.WriteLine($"Person \"two\" ({two.Name}) and \"three\" ({three.Name}) are equal: {two.Equals(three)}");  //False
        Console.WriteLine($"Person \"one\" ({one.Name}) and \"four\" (null) are equal: {one.Equals(four)}");            //False
    }
}

public class Person : IEquatable<Person> //Add IEquatable to the end to start implementing it
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public bool Equals(Person other)
    {
        if (other is null) return false;
        return Name == other.Name && Age == other.Age;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }
}