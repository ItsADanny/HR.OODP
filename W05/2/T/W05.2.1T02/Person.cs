public class Person {
    private string _firstName;
    private string _lastName;
    public string FullName => $"{_firstName} {_lastName}";
    
    public Person(string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }
}