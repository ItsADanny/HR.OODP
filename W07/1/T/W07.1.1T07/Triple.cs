public class Triple<T1, T2, T3> {
    public T1 Fst {get; private set;}
    public T2 Snd {get; private set;}
    public T3 Trd {get; private set;}

    public Triple(T1 fst, T2 snd, T3 trd) {
        Fst = fst;
        Snd = snd;
        Trd = trd;
    }
}