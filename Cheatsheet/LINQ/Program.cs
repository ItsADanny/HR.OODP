public class Program
{
    public static void Main()
    {
        //Test data which will be used in the examples
        List<Student> students = new List<Student>()
        {
            new Student("TUM3412344", "Martin Dinkelburg", "DE", "Berlin"),
            new Student("HR1153256", "Lucas Stikkelbroek", "NL", "Rotterdam"),
            new Student("UC3333313", "William Lions", "UK", "Coventry"),
            new Student("UC3333323", "William Winsor", "UK", "London"),
            new Student("TUM3426346", "Ferdinand Porsche", "DE", "Stuttgart"),
            new Student("TUM3445345", "Mercedes Jellinek", "DE", "Berlin"),
            new Student("HR1222332", "Jesse Klaver", "NL", "Den haag"),
            new Student("HR1235435", "Bart van Kessel", "NL", "Rotterdam"),
            new Student("HR1245343", "Maik Brouwer", "NL", "Rotterdam"),
            new Student("UC3433323", "Charles Winsor", "UK", "London")
        };

        //Test data which will be used in the examples
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        //Test data which will be used in the examples
        List<int> ints = [0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20];

        //Test data which will be used in the examples
        List<int> Duplicates = [0, 2, 2, 6, 8, 10, 12, 12, 16, 20, 20];

        //==========================================================================================================================================================
        //LINQ EXAMPLES:
        List<Student> dutchStudents = students.Where(s => s.Country == "NL").ToList();    //Returns a list where all the students are from NL
        Student[] orderedStud       = students.OrderBy(s => s.Name).ToArray();            //Returns a array where all the students are in alpabetical order
        Student[] orderedStudDesc   = students.OrderByDescending(s => s.Name).ToArray();  //Returns a array where all the students are in reversed order
        List<int> reversedNumbers   = Enumerable.Reverse(numbers).ToList();               //Returns a reversed list of the integers
        int[] SameNumbers           = numbers.Intersect(ints).ToArray();                  //Returns a array with what ints that both lists/arrays have in common
        int[] distinctNumbers       = Duplicates.Distinct().ToArray();                    //Returns a array with all the unique numbers from a list/array
        string[] names              = students.Select(s => s.Name).ToArray();             //Returns a array with all the Names of the students
        //==========================================================================================================================================================

        //==========================================================================================================================================================
        //iGrouping EXAMPLE:
        IEnumerable<IGrouping<string, Student>> GroupedStudents = students.OrderBy(s => s.Country).GroupBy(s => s.Country);

        foreach (var dataLine in GroupedStudents)
        {
            Console.WriteLine($"Country: {dataLine.Key}"); //Print the key in which we grouped the data

            Student[] studentsPerCountry = dataLine.ToArray(); //Retrieve the data from our grouped object
            int pos = 1;
            foreach (Student student in studentsPerCountry) // Iterate through the data
            {
                Console.WriteLine($" {pos}. ID: {student.ID}, Name: {student.Name}, City: {student.City}");
                pos++;
            }
        }
        //==========================================================================================================================================================
    }
}

public class Student
{
    public string ID;
    public string Name;
    public string Country;
    public string City;

    public Student(string id, string name, string country, string city)
    {
        ID = id;
        Name = name;
        Country = country;
        City = city;
    }
}