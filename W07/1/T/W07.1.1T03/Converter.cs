public static class Converter<T1, T2> {
    public static T2 ConvertVariables(T1 t1, T2 t2) {
        return (T2) Convert.ChangeType(t1, typeof(T2));
    } 
}