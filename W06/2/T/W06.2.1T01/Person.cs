public abstract class Person {
    public int Age {get; set;}
    public abstract string FirstName {get; set;}
    public abstract string LastName {get; set;}

    public Person(string firstName, string lastName, int age) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public abstract string Greet();
    public virtual string GetFullName() => $"{FirstName} {LastName}";
}