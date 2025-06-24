public class Program
{
    //This example is based on a real exam question from the febuari 2025 endterm exam
    public static void Main()
    {
        //DATA FOR THIS DEMO;
        //==============================================================================
        Person GreatGrandfather_Winston = new Person("Winston", "UK", null, null);
        Person GreatGrandfather_Charles = new Person("Charles", "UK", null, null);
        Person GreatGrandfather_Noah = new Person("Noah", "PL", null, null);
        Person GreatGrandfather_Hades = new Person("Hades", "US", null, null);
        Person GreatGrandmother_Samantha = new Person("Samantha", "DE", null, null);
        Person GreatGrandmother_Elizabeth = new Person("Elizabeth", "US", null, null);
        Person GreatGrandmother_Synthia = new Person("Synthia", "NL", null, null);
        Person GreatGrandmother_Emlyn = new Person("Emlyn", "NL", null, null);

        Person Grandfather_Charles = new Person("Charles", "NL", GreatGrandfather_Charles, GreatGrandmother_Emlyn);
        Person Grandfather_Syverus = new Person("Syverus", "US", GreatGrandfather_Winston, GreatGrandmother_Elizabeth);
        Person Grandmother_Miia = new Person("Miia", "DE", GreatGrandfather_Noah, GreatGrandmother_Samantha);
        Person Grandmother_Hellana = new Person("Hellana", "US", GreatGrandfather_Hades, GreatGrandmother_Synthia);

        Person Father_Jake = new Person("Jake", "US", Grandfather_Syverus, Grandmother_Hellana);
        Person mother_Clara = new Person("Clara", "NL", Grandfather_Charles, Grandmother_Miia);

        Person Jackson = new Person("Charles", "NL", Father_Jake, mother_Clara);
        //==============================================================================

        //We can call the recursive function 1 time with the point from which we want to get data, 
        //for now we use the highest position and that is Jackson
        int HowManyFromNL = HowManyPeopleAreFromACountry(Jackson, "NL");
        int HowManyFromDE = HowManyPeopleAreFromACountry(Jackson, "DE");
        int HowManyFromUK = HowManyPeopleAreFromACountry(Jackson, "UK");
        int HowManyFromUS = HowManyPeopleAreFromACountry(Jackson, "US");
        int HowManyFromPL = HowManyPeopleAreFromACountry(Jackson, "PL");
        int HowManyFromFR = HowManyPeopleAreFromACountry(Jackson, "FR");

        //Here we output the result for Jackson
        Console.WriteLine("===================================");
        Console.WriteLine("Jackson:");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"From the Netherlands    : {HowManyFromNL}");
        Console.WriteLine($"From Germany            : {HowManyFromDE}");
        Console.WriteLine($"From the United Kingdom : {HowManyFromUK}");
        Console.WriteLine($"From the United States  : {HowManyFromUS}");
        Console.WriteLine($"From Poland             : {HowManyFromPL}");
        Console.WriteLine($"From France             : {HowManyFromFR}");
        Console.WriteLine("===================================");

        //We can also call our recursive function with a data point lower down the chain such as Grandmother Miia
        int HowManyFromNL_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "NL");
        int HowManyFromDE_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "DE");
        int HowManyFromUK_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "UK");
        int HowManyFromUS_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "US");
        int HowManyFromPL_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "PL");
        int HowManyFromFR_Miia = HowManyPeopleAreFromACountry(Grandmother_Miia, "FR");

        //Here we output the result for Grandmother Miia
        Console.WriteLine("===================================");
        Console.WriteLine("Grandmother Miia:");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"From the Netherlands    : {HowManyFromNL_Miia}");
        Console.WriteLine($"From Germany            : {HowManyFromDE_Miia}");
        Console.WriteLine($"From the United Kingdom : {HowManyFromUK_Miia}");
        Console.WriteLine($"From the United States  : {HowManyFromUS_Miia}");
        Console.WriteLine($"From Poland             : {HowManyFromPL_Miia}");
        Console.WriteLine($"From France             : {HowManyFromFR_Miia}");
        Console.WriteLine("===================================");
    }

    //Our recursive function to count how many people in the family tree are from a specific country
    public static int HowManyPeopleAreFromACountry(Person? person, string CountryOfBirth) {
        if (person is null) return 0; //Here we define the base case (which is important because without 1 we create and infinite loop)

        int returnValue = 0; //Our default awnser before we check
        if (person.CountryOfBirth == CountryOfBirth) {
            returnValue = 1;
        }
        //We return the result for our current person + we call our function recursivly on our Father and Mother so we go down the family
        //Tree until we reach our base case
        return returnValue + HowManyPeopleAreFromACountry(person.Father, CountryOfBirth) + HowManyPeopleAreFromACountry(person.Mother, CountryOfBirth);
    }
}

public class Person
{
    public string Name;
    public string CountryOfBirth;
    public Person? Father;
    public Person? Mother;

    public Person(string name, string country, Person? father, Person? mother)
    {
        Name = name;
        CountryOfBirth = country;
        Father = father;
        Mother = mother;
    }
}