static class Program
{
    static void Main()
    {
        DNA ancestor = new(null, "acgt");
         List<DNA> dnaLine = [ancestor];
        for (int i = 0; i < 25; i++)
        {
            ancestor = ancestor.Replicate();
            dnaLine.Add(ancestor);
        }

        while (ancestor.Ancestor != null)
        {
            Console.WriteLine(ancestor.Ancestor.Seq);
            ancestor = ancestor.Ancestor;
        }
    }
}