public interface IStorable {
    public string FileName {get; set;}
    public void Load();
    public void Save();
}