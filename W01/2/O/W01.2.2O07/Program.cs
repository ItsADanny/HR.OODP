//First we print a request message for a number between 2 and 9
Console.WriteLine("Give a number from 2-9:");
//Now we request an input from the user and put it into a int variable
int chosenNumber = Convert.ToInt32(Console.ReadLine());

//Now we are going to check if the number is either lower than 2 or higher then 9.
//If its lower then 2, we are going to set the number to 2
//If its highter then 9, we are going to set the number to 9
if (chosenNumber < 2) {
    chosenNumber = 2;
} else if (chosenNumber > 9) {
    chosenNumber = 9;
}

//After the check we are going to generate our table using a Nested for-loop
for (int y = -1; y != (chosenNumber + 1); y++) {
    //First we are going to start with an empty row.
    string row = "";
    //Then we are going to make the columns
    for (int x = 1; x != (chosenNumber + 1); x++) {
        //First we check if our row is -1 if so then we know we just need to make the headers for the multiplication table
        if (y == -1) {
            //If its the first part of header then we will create some small space first and then just add the number
            if (x == 1) {
                row += $"  |   {x}";
            // If its not the first part then we just add 3 spaces in front of the number
            } else {
                row += $"   {x}";
            }
        //If its not the first row (-1) then we know we need to print a line to seperate the headers of our multiplication table from the values of our table
        } else if (y == 0) {
            //Based on the current x position we need to use different amount of - characters
            if (x == 1) {
                row += "-------";
            } else if (x == chosenNumber) {
                row += "-----";
            } else {
                row += "----";
            }
        //And if its the not one of those we can just start printing the information of the multiplication table
        } else {
            //Now we calculate the number based on their X and Y
            string number = (x * y).ToString();
            //If its the first position on the X axes then we need to add a small part of the table first before we can add the number
            if (x == 1) {
                row += $"{number} |";
            }
            //Now we need to make the numbers space on the table take in 4 spots for this we are going to use a string which we are going to take into a while loop
            //until it has a length of 4 spots
            string numberField = "";
            for (int z = 0; z != (4 - number.Length); z++) {
                numberField += " ";
            }
            //After that we can add the number to the number field
            numberField += number;
            //And then we add this to the row.
            row += numberField;
        }
    }
    //Then we print the row
    Console.WriteLine(row);
}