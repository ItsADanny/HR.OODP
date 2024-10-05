//We begin by creating a class called Todo
public class Task {
    //A task object will have the following field:
    //1. Name, in this field we are going to store the name of our task
    //2. IsDone, in this field we are going to store if the task is done 
    //   (This will be a boolean field (so true or false))
    public string Name;
    public bool IsDone;

    //In its constructor we are going to assign the inputted name to the Objects Name field and
    //set the IsDone field to false (by default)
    public Task(string str_name) {
        Name = str_name;
        IsDone = false;
    }

    //This method can be used to set the IsDone field to true, to indicate that the task is done
    public void Done() {
        IsDone = true;
    }

    //This method can be used to retriev if a task is done or not
    public string Info() {
        //If the IsDone field is true then we return that the task is done
        if (IsDone) {
            return $"Task: {Name}, Status: Done";
        }
        return $"Task: {Name}, Status: Pending";
    }
}