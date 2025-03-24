class Button
{   
    public string Text;
    //Set these fields to private (from public)
    private object _sender;
    private Action<object> _myAction;

    public Button(string text, object sender, Action<object> action)
    {
        Text = text;
        _sender = sender;
        _myAction = action;
    }

    public void Press() => _myAction(_sender);
}
