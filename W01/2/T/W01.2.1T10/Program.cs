//Create a List that can contain double's
List<double> Grades = new List<double>();

//Add the grades
Grades.Add(7);
Grades.Add(5.5);
Grades.Add(3.2);
Grades.Add(10);
Grades.Add(4.5);

//Create a int that will store how many students have passed
//and initialize this with a value of 0
int passed = 0;

//Now use a for-loop to iterate through the list
for (int i = 0; i != Grades.Count(); i++) {
    //Check if the grade is atleast a 5.5, if so then increase passed by 1
    if (Grades[i] >= 5.5) {
        passed++;
    }
}

//Finally print the result
Console.WriteLine($"{passed} out of {Grades.Count()} students passed");