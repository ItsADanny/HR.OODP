//First we create two integers which we are going to need to store the size of our board
int size = 0;
//Then we request an size for the height of the board from the user
//We are going to use a do-while loop so that we can continue to ask the user until we get a valid awnser (so an awnser that is not lower then 2!)
do {
    size = Convert.ToInt32(Console.ReadLine());
} while (size < 2);

//Now we create a list variable in which we are going to store our board before we print it in reverse so that we always have a Black tile in the lower left corner
List<string> board = new();

//After that we are going to use a Nested For-loop to generate the board
//We begin by using a for-loop to generate the rows of our board
for (int y = 0; y != size; y++) {
    //We are going to use a string variable called row to store our boards row that we are going to print.
    //This we be reset every time we are going to make a new row
    string row = "";
    //Then we generate the columns in our row based on its row and column
    for (int x = 0; x != size; x++) {
        //To make it so that we get a checkerboard pattern we are going to preform a simple calulation.
        //Based on this calculation we are going to make that field either White or Black
        if ((x + y) % 2 == 0) {
            row += "B";
        } else {
            row += "W";
        }
    }
    //Now we add the row to the board
    board.Add(row);
}
//Then we reverse our board
board.Reverse();

//Now we print our reversed board
foreach (string row in board) {
    Console.WriteLine(row);
}