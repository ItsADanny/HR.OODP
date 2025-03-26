
public class ListWrapper<T> {
    private List<T> _myList;
    public int Count {get {return _myList.Count();}}

    public ListWrapper() => _myList = new List<T>();

    public void Add(T item) => _myList.Add(item);

    public T Get(int index) => _myList[index];

    public int HighestCount<U>(ListWrapper<U> otherList) {
        if (Count > otherList.Count)
            return Count;
        else
            return otherList.Count;
    }
}