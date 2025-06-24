//↓ This defines our input to a variable which we can use
Action<Person> UpdateCountryField = (Person human) => {  //We can use => { } to use multiple lines
        //↑ This defines the input for our lambda function
    if (human is not null) {
        if (human.CountryOfBirth is null || human.CountryOfBirth == "") {
            human.CountryOfBirth = "Unknown";
        }
    } //Since we dont need to return a value we can just let the code end without using a return.
};

    //↓    ↓ This defines the input for our lambda function
Func<int, int, int> Add = (int a, int b) => a + b;
              //↑ This defines the output for our lambda function.
Console.WriteLine("1 + 5 = " + Add(1, 5)); //Result: "1 + 5 = 6"


//HOF (High Order Function)
public int PerfromHOF(int a, int b, Func<int, int, int> HOF) {
    return HOF(a, b);
}

//===================================================================================================================================
//This won't appear on the cheatsheet

public class Person
{
    public string Name;
    public string? CountryOfBirth;

    public Person(string name, string? countryOfBirth)
    {
        Name = name;
        CountryOfBirth = countryOfBirth;
    }
}