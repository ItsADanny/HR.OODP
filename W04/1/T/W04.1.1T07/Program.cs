class Program
{
    public static void Main()
    {
        //Create a Person
        Person person = new("John Doe");
        //Create a Student
        Student student = new("Jane Doe");

        //Print John's introduction
        Console.WriteLine(person.Introduce());
        //Print Jane's introduction
        Console.WriteLine(student.Introduce());
        //Print Jane's status
        Console.WriteLine(student.Status());
        //Graduate Jane
        student.Graduate();
        //Print Jane's status again
        Console.WriteLine(student.Status());
    }
}