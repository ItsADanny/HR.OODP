public class Department
{
    public string Name;
    private Queue<Request> _requests;

    public Department(string name)
    {
        Name = name;
        _requests = new Queue<Request>();
    }

    public void AddRequest(Request request) => _requests.Enqueue(request);
    public Request SolveNextRequest()
    {
        Request returnValue = _requests.Peek();
        _requests.Dequeue();
        return returnValue;
    }

    public Request GetNextRequest() => _requests.Peek();
    public void PrintAllRequests()
    {
        string printValue = "";
        foreach (Request request in _requests)
        {
            if (printValue != "")
            {
                printValue += "\n";
            }
            printValue += request.ToString();
        }
        Console.WriteLine(printValue);
    }
}