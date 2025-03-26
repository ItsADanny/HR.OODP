public class Container<T> {
    private T _default;
    private T _value;
    public T Value {
        get {
            return _value;
        }
        set {
            _value = value;
        }
    }

    public Container (T value) {
        _default = value;
        Value = value;
    }

    public void ResetValue() => Value = _default;
}