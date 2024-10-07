//Create the class Song
class Song {
    //Create 2 field
    //1 string for Title
    //1 Artist for the Singer
    public string Title;
    public Artist Singer;

    //Create the constructor for the class Song
    public Song(string title) {
        //Set the songs title field to the title we are given when a song
        //is created
        Title = title;
        //Then for the Singer, Create a temporary Artist with the Name
        //"Unknown"
        Singer = new Artist("Unknown");
    }

    //Create a method called SetSinger, which will be used to set
    //a Artist object into the songs Singer field
    public void SetSinger(Artist singer) {
        Singer = singer;
    }

    //Create a method called Info, which will return the Info of this song
    //(Song title and Artist name)
    public string Info() {
        return $"{Title} is by {Singer.Name}";
    }

}