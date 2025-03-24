static class Program
{
    static void Main()
    {
        //Original code template
        //--------------------------------------------------------
        // int discount = 0.1;
        // int price = 55;
        // int discountPrice = price * discount;

        // var message;
        // message = $"The discount price is {discountPrice}";
        // Console.WriteLine(discountPrice)

        //First we fix our Int problem.
        //Since and int can only be a round number (so with out any decimal numbers)
        //we turn our int discount into a double discount so we can use decimal numbers
        double discount = 0.1;
        int price = 55;
        //Then we turn our int discount price into a double because we want to have 
        //decimal number for showing the correct price
        //And the we make it so that we first calculate our total discount and then subtract our discount from the price
        double discountPrice = price - (price * discount);

        //After this we just simpely print our result
        Console.WriteLine($"The discount price is {discountPrice}");
    }
}