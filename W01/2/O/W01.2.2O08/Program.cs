//We start off by making a list filed with grades and a list that will contain our final grades
using System.Diagnostics;

List<double> grades = new();
//Had to add the data for the list in this way because CodeGrade didn't want it
grades.Add(6.5);
grades.Add(9.5);
grades.Add(4);
grades.Add(5);
grades.Add(4.5);
grades.Add(10);
grades.Add(7.1);
List<double> finalGrades = new();

//Now we are going to loop through the grades
foreach (double grade in grades) {
    
    //We print the grade
    Console.WriteLine($"Grade: {grade}");

    //We are going to check to see if the grade is below a 5.5,
    //If so then we are going to ask if the user wants to retake the course
    if (grade < 5.5) {

        //Now we are going to make a version of the grade that can be updated
        double editedGrade = grade;
        //Here we are defining a variable in which we will store the users response
        bool validResponse = false;
        
        //If the grade is below a 5.5, we are going to throw the user in a do-while loop until we get a valid response to our yes/no question
        do {
            //We print a message with the question if the user wants to retake the course
            Console.WriteLine("Retake this course? y/n");
            //We request an input from the user
            string userInput = Console.ReadLine().ToLower();
            //Check if the input is one of the valid options
            if (userInput == "y") {
                //If the user response is "y", then we increase the grade by 1 and set the validResponse bool to true
                editedGrade++;
                validResponse = true;
            } else if (userInput == "n") {
                //If the user response is "n", then we set the validResponse bool to true and do nothing with the grade
                validResponse = true;
            }
        } while (!validResponse);
        
        //After that we add the grade to our finalGrades list
        finalGrades.Add(editedGrade);
    } else {
        //If the grade is high enough from the start, then we are just going to add it to our final grades list
        finalGrades.Add(grade);
    }
}

//And at the end, we are going to print our final grade results
Console.WriteLine("Final grades:");
foreach (double grade in finalGrades) {
    Console.WriteLine(grade);
}