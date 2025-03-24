public interface IDocument : IStorable {
    public string Title {get; set;}
    public string Content {get; set;}
    public void Print();
}