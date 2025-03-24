class Program
{
    public static void Main()
    {   
        // List<Person> people = [
        //     new Person("John Doe"),
        //     new Student("Jane Doe")
        // ];

        List<Person> people = new List<Person>();
        people.Add(new Person("John Doe"));
        people.Add(new Student("Jane Doe"));
            
        foreach (Person person in people) {
            Console.WriteLine(person.Introduce());

            if (person is Student) {
                Student student = (Student) person;
                Console.WriteLine(student.Status());
            }
        }
    }
}