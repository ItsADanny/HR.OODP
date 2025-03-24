class TextFile : File, IPrintable {
    new public string FileName {
        get {
            return FileName;
        }
        set {
            value += ".txt";
        }
    }
    public string Contents {get; set;}

    public TextFile(string fileName, string contents) : base(fileName) {
        FileName = fileName;
        Contents = contents;
    }

    public void Print() {
        Console.WriteLine(Contents);
    }
}