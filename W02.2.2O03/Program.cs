public class Program() {
    public static void Main() {
        Console.WriteLine("What is the minimum sequence length?");
        Int32 int32_choice = Convert.ToInt32(Console.ReadLine());
        
        List<DNA> dnaList = new List<DNA>();
        dnaList.Add(new DNA("ACGT"));
        dnaList.Add(new DNA("GCTTAC"));
        dnaList.Add(new DNA("CGTTAGCTT"));
        dnaList.Add(new DNA("TACA"));

        Console.WriteLine("The filtered list:");
        foreach (DNA dna in dnaList) {
            if (dna.seq.Length >= int32_choice) {
                Console.WriteLine(dna.seq);
            }
        }
    }
}