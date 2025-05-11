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

    public void AdjustBrightness(double factor) {
        for (int i = 0; i < PixelData.GetLength(0); i++) {
            for (int e = 0; e < PixelData.GetLength(1); e++) {
                PixelData[i,e] = (int) (PixelData[i,e] * factor);
            }
        }
    }
}