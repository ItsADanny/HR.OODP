public class Program
{
    public static void Main()
    {
        List<ToDoItem> ToDoList = new List<ToDoItem>();

        ToDoList.Add(new ToDoItem("Do the dishes", "Clean the large bits of the plates with water, and then put them into the dishwasher", 1));
        ToDoList.Add(new ToDoItem("Homework", "Do the Homework assignments given during OODP", 4));
        ToDoList.Add(new ToDoItem("Vacuum your room", "Vacuum your room, its getting disguisting in there", 2));
        ToDoList.Add(new ToDoItem("Wash the car", "Wash the car, its sandy and dusty from standing outside", 3));
        ToDoList.Add(new ToDoItem("Reinstall Windows", "Reinstall Windows, It has been 6 months since the last fresh install and it has become slow again...", 2));
        ToDoList.Add(new ToDoItem("Do the laundry", "Do the laundry, You are running out of underwear!", 1));
        ToDoList.Add(new ToDoItem("Study for the exam", "Study for the Endterm exam of OODP", 2));
        ToDoList.Add(new ToDoItem("Get groceries", "Get groceries, we are running out of toilet paper and bread", 3));

        //Set some of the items to Completed
        ToDoList[1].Completed = true;
        ToDoList[4].Completed = true;
        ToDoList[5].Completed = true;
        ToDoList[6].Completed = true;

        //And now we can use sort to sort our items in our list into a neat order list with the completed items at the bottom and ranked in their priority
        ToDoList.Sort();

        foreach (ToDoItem item in ToDoList) {
            Console.WriteLine(item.ToString());
        }
    }
}

public class ToDoItem : IComparable<ToDoItem> //To use iComparable, add it at the end of the class you want to use it in/on
{
    public string Title;
    public string Description;
    public int Priority;
    public bool Completed;

    public ToDoItem(string title, string description, int priority)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Completed = false;
    }

    public int CompareTo(ToDoItem? other) //This needs to be implemented to use IComparable, and define what it must check to sort
    {
        if (other is null) return 1; //Base check to see if the other object is a null, 
                                     //if so we return a 1 to show that our original object is a higher position item

        int result = Completed.CompareTo(other.Completed); //Use the CompareTo from the basic value types, this will save alot of headaches

        //Short handed if-else statement version
        // return result != 0 ? result : other.Priority.CompareTo(Priority);

        // Long handed if-else statement version
        if (result != 0)
        {
            //If the result isn't 0 the we return it
            return result;
        }
        else
        {
            //If the result is 0, then check if the priority of the other item compared to this items priority
            //and return that as the result for this comparison
            return other.Priority.CompareTo(Priority);
        }
    }

    public override string ToString()
    {
        string returnValue = $"Title: {Title}\nPriority: {Priority}\nStatus: ";
        if (!Completed)
        {
            returnValue += "Not ";
        }
        returnValue += "Completed";
        return returnValue;
    }
}