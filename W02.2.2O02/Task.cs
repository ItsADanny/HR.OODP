public class Task {

    public string Name;
    public bool IsDone;

    public Task(string str_name) {
        Name = str_name;
        IsDone = false;
    }

    public void Done() {
        IsDone = true;
    }

    public string Info() {
        if (IsDone) {
            return $"Task: {Name}, Status: Pending";
        }
        return $"Task: {Name}, Status: Pending";
    }
}