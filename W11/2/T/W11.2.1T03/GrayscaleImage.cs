public class GrayscaleImage
{
    public int Height { get; }
    public int Width { get; }
    public int[,] PixelData {get;}
    //Set PixelData

    public GrayscaleImage(int height, int width)
    {
        //Set Width, Height and PixelData
        Height = height;
        Width = width;
        PixelData = new int[height, width];
    }

    public GrayscaleImage(int[,] pixelData)
    {
        //Set Width, Height and PixelData
        Height = pixelData[0, 0];
        Width = pixelData[0, 1];
        PixelData = pixelData;
    }
}