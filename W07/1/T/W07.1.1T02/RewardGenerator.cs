public static class RewardGenerator<T> {
    private static Random _random {
        get {
            return new Random(0);
        }
    }

    public static T GetRandomElement(List<T> list) => list[_random.Next()];
}