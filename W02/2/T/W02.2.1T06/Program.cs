static class Program
{
    static void Main()
    {
        /*Create a List of Pets here:
         *- a Dog named Nugent
         *- a Cat named Steve
         *- a Goldfish named Brutus
         */

        //Create the list that will contain our pets
        List<Pet> Pets = new List<Pet>();

        //Add the new pet objects to the List of Pet objects
        Pets.Add(new Pet("Dog", "Nugent"));
        Pets.Add(new Pet("Cat", "Steve"));
        Pets.Add(new Pet("Goldfish", "Brutus"));

        //Now use a foreach to print the pets name and species
        foreach (Pet pet in Pets) {
            Console.WriteLine($"I have a {pet.WhatAmI} named {pet.Name}");
        }
    }
}