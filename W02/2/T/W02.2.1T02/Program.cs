static class Program
{
    static void Main()
    {
        Artist artist1 = new("Rihanna");
        artist1.ComposeSong("Umbrella");
        artist1.ComposeSong("Where Have You Been");
        
        Artist artist2 = new("Michael Jackson");
        artist2.ComposeSong("Billy Jean");
        artist2.ComposeSong("Thriller");

        foreach (Artist artist in new[] { artist1, artist2 })
        {
            foreach (Song song in artist.ComposedSongs)
            {
                Console.WriteLine(song.Info());
            }
        }
    }
}