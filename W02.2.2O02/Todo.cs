public class Todo {
    public List<Task> TaskList;

    public Todo() {
        TaskList = new List<Task>();
    }

    public void AddTask(string str_taskname) {
        TaskList.Add(new Task(str_taskname));
    }

    public Task GetTask(string str_taskname) {
        Task returnTask = null;

        foreach (Task task in TaskList) {
            if (task.Name == str_taskname) {
                returnTask = task;
            }
        }

        return returnTask;
    }

    public string Report() {
        string str_returnValue = "";

        foreach (Task task in TaskList) {
            str_returnValue += $"{task.Info()}\n";
        }

        return str_returnValue;
    }
}