class Artist
{
    public string Name;
    public List<Song> ComposedSongs = [];

    public Artist(string name) => Name = name;

    // Your poetry here
    public void ComposeSong(string title) {
        Song newSong = new Song(Name, title);
        ComposedSongs.Add(newSong);
    }
}