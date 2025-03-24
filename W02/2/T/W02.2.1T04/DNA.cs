//Create the DNA class
class DNA {
    //Create a string field name Seq
    public string Seq;

    //Create the constructor and set the input seq to the objects Seq
    public DNA(string seq) {
        Seq = seq;
    }

    //Create a method called Replicate1 which will return a new DNA object
    //with the same Sequence
    public DNA Replicate1() {
        return new DNA(Seq);
    }

    //Create a method called Replicate1 which will return this DNA object
    public DNA Replicate2() {
        return this;
    }

    //Create a method called Mutate which will replace the current objects
    //Seq string with a new one that has been given as a parameter
    public void Mutate(string seq) {
        Seq = seq;
    }
}