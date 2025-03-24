//We begin by creating a class called Todo
public class ToDo {
    //This class will contain a List called TaskList
    public List<Task> TaskList;

    //In its constructor we are going to create a new list in the Variable TaskList
    public ToDo() {
        TaskList = new List<Task>();
    }

    //This method will add a task to the TaskList by Creating a new Task and adding it to our TaskList
    //by just inputting a taskname
    public void AddTask(string str_taskname) {
        TaskList.Add(new Task(str_taskname));
    }

    //This method return a task based on if it can find a task with the same name
    public Task GetTask(string str_taskname) {
        //We iterate through the tasks
        foreach (Task task in TaskList) {
            //If we find a task with a matching taskname then we return this task
            if (task.Name == str_taskname) {
                return task;
            }
        }
        //If we can't find a matching task then we return a null value
        return null;
     }

    //This method returns a string which includes all the tasks and their current status
    public string Report() {
        //We first define a return string value
        string str_returnValue = "";
        //We iterate through the tasks and use the Info() method from the Task object and use it to add a row
        //to our return value string
        foreach (Task task in TaskList) {
            str_returnValue += $"{task.Info()}\n";
        }
        //After that we return the return value string
        return str_returnValue;
    }
}