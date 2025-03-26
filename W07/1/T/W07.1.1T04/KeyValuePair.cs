public class KeyValuePair {
    public object Key { get; set; }
    public object Value { get; set; }

    public KeyValuePair(object key, object value) {
        Key = key;
        Value = value;
    }
}