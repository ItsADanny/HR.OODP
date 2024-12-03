static class Lineage
{
    public static Organism GenerateLineage(List<string> dnaStrands)
    {
        return GenerateLineage(dnaStrands, 0);
    }

    // Overload GenerateLineage here

    public static void IntroduceRandomMutations(Organism organism, Func<string, string> mutator)
    {
        IntroduceRandomMutations(organism, mutator, organism.DNAStrand);
    }

    // Overload IntroduceRandomMutations here
}
