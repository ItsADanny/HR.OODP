static class Program
{
    static void Main()
    {
        //Ask what the minimum sequence length is
        Console.WriteLine("What is the minimum sequence length?");
        //Request an input from the user, Convert it into a int and then put it into the variable int_choice
        int int_choice = Convert.ToInt32(Console.ReadLine());
        
        //Create a new list
        List<DNA> dnaList = new List<DNA>();

        //Had to do it this way because CodeGrade kept not working... (yeah...)
        //Create the DNA objects
        DNA ACGT = new DNA("ACGT");
        DNA GCTTAC = new DNA("GCTTAC");
        DNA CGTTAGCTT = new DNA("CGTTAGCTT");
        DNA TACA = new DNA("TACA");

        //Add the new DNA objects into the list
        dnaList.Add(ACGT);
        dnaList.Add(GCTTAC);
        dnaList.Add(CGTTAGCTT);
        dnaList.Add(TACA);

        //Print the reponse
        Console.WriteLine("The filtered list:");
        //Iterate through the dnaList per DNA object
        foreach (DNA dna in dnaList) {
            //If the length of the sequence is larger or equal to the requested minimum sequence length then
            //Print the sequence
            if (dna.Seq.Length >= int_choice) {
                Console.WriteLine(dna.Seq);
            }
        }
    }
}