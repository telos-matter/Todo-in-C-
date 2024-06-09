List<Task> tasks = [];
List<Task> completed = [];

// Define used functions
char ReadCharClear ()
{
    char c = Console.ReadKey().KeyChar;
    Console.Clear();
    return c;
}

void AddTask ()
{
    Console.WriteLine("Write your Todo:");
    string? prompt = Console.ReadLine();
    prompt ??= "";
    // Eh, a DateTime is too much, just Date
    Console.WriteLine("Is it due to some date? If yes, give the date (dd/mm/yyyy), otherwise press enter");
    string? dateString = Console.ReadLine();
    DateTime? associatedDT = null;
    try
    {
        associatedDT = Convert.ToDateTime(dateString);
    }
    catch (FormatException) {}

    Task task = new(prompt, associatedDT);
    tasks.Add(task);
    Console.WriteLine("Task added successfully!");
}

void SeeTasks ()
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No Todos.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"#{i}");
        Console.WriteLine(tasks[i]);
    }
}

void MarkCompleted ()
{   
    if (tasks.Count == 0)
    {
        Console.WriteLine("No Todos available.");
        return;
    }

    SeeTasks();
    Console.WriteLine();
    Console.WriteLine("Which Todo have you completed?");
    var input = Console.ReadLine();
    int taskNumber = -1;
    try
    {
        taskNumber = Convert.ToInt32(input);
    }
    catch (FormatException)
    {
        Console.WriteLine($"Invalid input {input}");
    }
    if (taskNumber >= 0 && taskNumber < tasks.Count)
    {
        Task task = tasks[taskNumber];
        task.Completed = true;
        tasks.RemoveAt(taskNumber);
        completed.Add(task);
        Console.WriteLine($"#{taskNumber} marked as completed!");
    }
    else
    {
        Console.WriteLine($"Unknown Todo {taskNumber}");
    }
}

void SeeCompleted ()
{
    if (completed.Count == 0)
    {
        Console.WriteLine("Yet to complete a Todo. Go do something!");
        return;
    }

    for (int i = 0; i < completed.Count; i++)
    {
        Console.WriteLine($"#{i}");
        Console.WriteLine(completed[i]);
    }
}

void SeeDue ()
{
    bool showedNothing = true;
    DateTime now = DateTime.Now;
    for (int i = 0; i < tasks.Count; i++)
    {
        Task task =  tasks[i];
        if (task.AssociatedTD.HasValue && task.AssociatedTD.Value < now)
        {
            showedNothing = false;
            Console.WriteLine($"#{i}");
            Console.WriteLine(tasks[i]);
        }
    }

    if (showedNothing)
    {
        Console.WriteLine("No Todo is due right now.");
    }
}

// "Main"
Console.WriteLine("Welcome!");
bool running = true;
while (running)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("#1 Add a Todo");
    Console.WriteLine("#2 See all Todos");
    Console.WriteLine("#3 Mark a Todo as completed");
    Console.WriteLine("#4 See all completed Todos");
    Console.WriteLine("#5 See due Todos");
    Console.WriteLine("#6 Exit");
    
    char choice = ReadCharClear();
    
    switch(choice)
    {
        case '1':
            AddTask();
            break;
        
        case '2':
            SeeTasks();
            break;
        
        case '3':
            MarkCompleted();
            break;
        
        case '4':
            SeeCompleted();
            break;
        
        case '5':
            SeeDue();
            break;
        
        case '6':
            running = false;
            break;
        
        default:
            Console.WriteLine($"Invalid choice `{choice}`");
            break;
    }
    
    if (running)
    {
        ReadCharClear();
    }
}

Console.WriteLine("Bye bye 👋🏼");