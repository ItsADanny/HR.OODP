public static class Converter<T> {
    public static T ConvertVariables(T T1, T T2) {
        return (T2) Convert.ChangeType(T1, typeof(T2));
    } 
}