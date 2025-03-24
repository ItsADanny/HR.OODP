public class Person {
    public string Name;
    public int Age;

    public Person(string name, int age) {
        Name = name;
        Age = age;
    }

    public Person(string name) : this(name, 0) { }
}