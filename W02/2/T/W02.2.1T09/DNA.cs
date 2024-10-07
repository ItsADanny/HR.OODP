class DNA
{
    private static Random _rand = new Random(0); //Seeded Random

    //ItsDanny's NOTE
    //Add 2 new public field to the DNA class
    public DNA Ancestor;
    public string Seq;

    //ItsDanny's NOTE
    //Create the Constructor for the DNA class
    public DNA(DNA ancestor, string seq) {
        //And set the ancestor and seq
        Ancestor = ancestor;
        //Add to seq .ToUpper() so that the sequence will always
        //be uppercase
        Seq = seq.ToUpper();
    } 

    //Create a method called Replicate
    //This will make a new DNA object with this as its ancestor and a
    //new mutated sequence
    public DNA Replicate() {
        //this will put this DNA object into our new DNA object which we return
        return new DNA(this, MutateTransition());
    }

    //Fields, constructor and Replicate here
    private string MutateTransition()
    {
        var indexToMutate = _rand.Next(0, Seq.Length);
        var mutatedSeq = Seq[0 .. indexToMutate] //Left of mutation
            + MutateTransitionTable(Seq[indexToMutate]) //Mutation
            + Seq[(indexToMutate+1) .. Seq.Length]; //Right of mutation
        return mutatedSeq;
    }

    private char MutateTransitionTable(char nucleotide) => nucleotide switch
    {
        'A' => 'G',
        'G' => 'A',
        'C' => 'T',
        'T' => 'C',
        _ => throw new ArgumentOutOfRangeException($"{nucleotide}", $"Unexpected nucleotide value: {nucleotide}"),
    };
    
}