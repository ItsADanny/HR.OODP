﻿class Program
{
    public static void Main()
    {
        Ventilator ventilator = new();
        for (int i = -1; i <= 3; i++)
        {
            ventilator.PressButton(i);
            Console.WriteLine(ventilator.Blow());
        }
    }
}