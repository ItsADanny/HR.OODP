public class Program
{
    //DEMO DATA FOR THE EXAMPLES BELOW
    public static Person ClarkKent = new Person("Clark Kent", "");
    public static Person TonyStark = new Person("Tony Stark", "US");
    public static Person JeremyClarkson = new Person("Jeremy Clarkson", "");
    public static Person RichardHammond = new Person("Richard Hammond", null);
    public static Person JamesMay = new Person("James May", "UK");

    public static void Main()
    {
        //Lambda functions come in two different versions
        //Action and Func

        //Action
        //Action can be used when we can to make a lambda but don't need it to return something.
        //For example:
        //====================================================================================================
        //Say that we need to check and see if the Country of Birth from a person object is an empty string.
        //If so we want to put "Unknown" in its place.
        //We can use the following lambda function to do this:

                                                //↓ This defines our input to a variable which we can use
        Action<Person> UpdateCountryField = (Person human) =>  //We can use => { } to use multiple code lines in a lambda function
        {       //↑ This defines the input for our lambda function

            if (human is not null)
            {
                if (human.CountryOfBirth is null || human.CountryOfBirth == "")
                {
                    human.CountryOfBirth = "Unknown";
                }
            }
            //Since we dont need to return a value we can just let the code end without using a return.
        };

        //We can call our lambda like a normal method:
        Console.WriteLine("=========================================================================");
        Console.WriteLine("Before:");
        Console.WriteLine($"Name: {ClarkKent.Name}, Country of Birth: {ClarkKent.CountryOfBirth}");
        //Call the lambda as a method
        UpdateCountryField(ClarkKent);
        Console.WriteLine("After:");
        Console.WriteLine($"Name: {ClarkKent.Name}, Country of Birth: {ClarkKent.CountryOfBirth}");
        Console.WriteLine("=========================================================================");

        //Or we can use it as a parameter in a method:
        Console.WriteLine("=========================================================================");
        Console.WriteLine("Before:");
        Console.WriteLine($"Name: {JeremyClarkson.Name}, Country of Birth: {JeremyClarkson.CountryOfBirth}");
        Console.WriteLine($"Name: {RichardHammond.Name}, Country of Birth: {RichardHammond.CountryOfBirth}");
        Console.WriteLine($"Name: {JamesMay.Name}, Country of Birth: {JamesMay.CountryOfBirth}");
        //Call a method in which we put the action as a parameter:
        UpdateTrio(UpdateCountryField); //When used like this its considered a HOF (High Order Function)
        Console.WriteLine("After:");
        Console.WriteLine($"Name: {JeremyClarkson.Name}, Country of Birth: {JeremyClarkson.CountryOfBirth}");
        Console.WriteLine($"Name: {RichardHammond.Name}, Country of Birth: {RichardHammond.CountryOfBirth}");
        Console.WriteLine($"Name: {JamesMay.Name}, Country of Birth: {JamesMay.CountryOfBirth}");
        Console.WriteLine("=========================================================================");

        //Func
        //Func can be used on the other hand as a lambda from which we do expect a return value
        //For example:
        //====================================================================================================
        //Say that we are building a calculator application and we want to make a easy oneline method like add.
        //we can do it with a very short method:
        // public int Add(int a, int b) => a + b;
        //Or we can use a lambda like this:
            //↓    ↓ This defines the input for our lambda function
        Func<int, int, int> Add = (int a, int b) => a + b;
                      //↑ This defines the output for our lambda function.

        //So now when we want to run this we can do it just like Action:
        Console.WriteLine("1 + 5 = " + Add(1, 5));
    }

    //We can the use it for instance in a method as a parameter
    public static void UpdateTrio(Action<Person> condition)
    {
        condition(JeremyClarkson);
        condition(RichardHammond);
        condition(JamesMay);
    }
}

public class Person {
    public string Name;
    public string? CountryOfBirth;

    public Person(string name, string? countryOfBirth)
    {
        Name = name;
        CountryOfBirth = countryOfBirth;
    }
}