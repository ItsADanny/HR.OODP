//1. Create an array to store the following names: "Maggy", "Lisa", "Bart", "Homer", "Marge"
string[] TheDyslexicSimpsons = [
    "Maggy",
    "Lisa",
    "Bart",
    "Homer",
    "Marge"
];

//2. Write some code to make a copy of this array
//Create a String array which will be 5 strings long/large
string[] TheSimpsons = new string[5];
//We copy the strings from TheDyslexicSimpsons into the new TheSimpsons string array, starting from index 0
TheDyslexicSimpsons.CopyTo(TheSimpsons, 0);
//3. In the copy, change "Maggy" to "Maggie"
TheSimpsons[0] = "Maggie";

//4. Print out this new array
string OldArrayString = "";
string NewArrayString = "";

foreach (string str in TheDyslexicSimpsons) {
    if (OldArrayString != "") {
        OldArrayString += "\n";
    }
    OldArrayString += str;
}

foreach (string str in TheSimpsons) {
    if (NewArrayString != "") {
        NewArrayString += "\n";
    }
    NewArrayString += str;
}

Console.WriteLine($"Old Array:\n=====================================\n{OldArrayString}\n");
Console.WriteLine($"New Array:\n=====================================\n{NewArrayString}");