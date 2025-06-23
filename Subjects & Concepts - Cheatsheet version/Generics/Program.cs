/* Generic class: */ public class GenClass<T> { private T data; }
/* Generic method */ public static T GenMethod<T>(T value) { return value; }
/* Generic Interface */ public interface IGenInterface<T> { void Add(T item); }
/* Generics - Constraint Where */ public class Repo<T> where T: class, new() { void Add(T item) { } }