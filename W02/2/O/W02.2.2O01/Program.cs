class Program
{
    public static void Main()
    {
        Ventilator ventilator = new();
        //We can simply solve the problem by setting the 4 from the original to 3 
        //and this will resolve the problem
        for (int i = -1; i <= 3; i++)
        {
            ventilator.PressButton(i);
            Console.WriteLine(ventilator.Blow());
        }
    }
}