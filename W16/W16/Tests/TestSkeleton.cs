static class TestSkeleton
{
    public static void Attacks()
    {
        Skeleton skelly = new();
        Wizard wiz = new("Wizkid");

        while (skelly.IsAlive)
        {
            skelly.Attack(wiz);
        }
    }
}
