public static class Recursion {
    public static int RecursiveSum(int start) {
        if (start == 0) return 0;
        return start + RecursiveSum(start-1);
    }

    public static int Factorial(int start) {
        if (start <= 0) return -1;
        return start * Factorial(start-1);
    }
}