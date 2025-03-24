static class Program
{
    static void Main()
    {
        /* Create a Person named john with the following pets:
         * - a Dog named Nugent
         * - a Cat named Steve
         * - a Goldfish named Brutus
         * Then for each Pet, print John's name, what the Pet is and their name.
         */

        //Create the list that will contain our pets
        List<Pet> Pets = new List<Pet>();

        //Add the new pet objects to the List of Pet objects
        Pets.Add(new Pet("Dog", "Nugent"));
        Pets.Add(new Pet("Cat", "Steve"));
        Pets.Add(new Pet("Goldfish", "Brutus"));

        //Create a new person called John and add the pets list to him
        Person John = new Person("John", Pets);

        //Now use a foreach to print the pets name and species from John
        foreach (Pet pet in John.Pets) {
            Console.WriteLine($"John has a {pet.WhatAmI} named {pet.Name}");
        }
    }
}