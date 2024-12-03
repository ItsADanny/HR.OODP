static class HOF
{
    public static T[] Filter<T>(T[] array, Func<T, bool> predicate)
    {
        return FilterRecursive(array, predicate, 0);
    }

    private static T[] FilterRecursive<T>(T[] array, Func<T, bool> predicate, int index)
    {

    }
}
