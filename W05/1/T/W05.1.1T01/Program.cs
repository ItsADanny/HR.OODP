class Program
{
    public static void Main()
    {   
        //You can normally use this but CodeGrade won't compile it if you use this so we use the version below
        // List<Person> people = [
        //     new Person("John Doe"),
        //     new Student("Jane Doe")
        // ];

        //Create a new List that can be filled with Person object
        List<Person> people = new List<Person>();
        //Add a new Person to the List called "John Doe"
        people.Add(new Person("John Doe"));
        //Add a new Student (Which is a class based on the Person class) to the List called "Jane Doe"
        people.Add(new Student("Jane Doe"));
        
        //Now we iterate through the List with a foreach
        foreach (Person person in people) {
            //First we use the Introduce() which is a method from the base class Person
            Console.WriteLine(person.Introduce());

            //In a if-statement we check if the person object we retrieved from our List is a Student
            //Which is a class that is based and inherits from the base class Person
            if (person is Student) {
                //If the Person is a Student, Then we cast it into a Student object
                Student student = (Student) person;
                //Then we use the Status() method from the Student class to get a string which we will then print to the console
                Console.WriteLine(student.Status());
            }
        }
    }
}