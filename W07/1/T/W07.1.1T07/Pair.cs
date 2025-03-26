public class Pair<T1, T2> {
    public T1 Fst {get; private set;}
    public T2 Snd {get; private set;}

    public Pair(T1 fst, T2 snd) {
        Fst = fst;
        Snd = snd;
    }
}