class Song
{
    public string ArtistName;
    public string Title;

    public Song(string artistName, string title)
    {
        ArtistName = artistName;
        Title = title;
    }

    public string Info() => $"{ArtistName} - {Title}";
}