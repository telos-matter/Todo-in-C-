using System.Text.Json;


const string FILE_NAME = "tasks.json";


// Initialize
List<Task> tasks;

// Deserialize data from the file
if (File.Exists(FILE_NAME))
{
    var jsonText = File.ReadAllText(FILE_NAME);
    tasks = JsonSerializer.Deserialize<List<Task>>(jsonText)!;
}
else
{
    // If it does not exist then just initialize an empty list
    tasks = [];
}


// Define needed / used functions
Task? getTask (int id)
{
    foreach (var task in tasks)
    {
        if (task.Id == id)
        {
            return task;
        }
    }

    return null;
}

void serialize ()
{
    string jsonString = JsonSerializer.Serialize(tasks);
    File.WriteAllText(FILE_NAME, jsonString);
}

char ReadCharClear ()
{
    char c = Console.ReadKey().KeyChar;
    Console.Clear();
    return c;
}

void AddTask ()
{
    Console.WriteLine("What is this Task about? 🤔");
    string? prompt = Console.ReadLine();
    prompt ??= "";
    // Eh, a DateTime is too much, just Date
    Console.WriteLine("Is it due some day? If so, give the date (dd/mm/yyyy), otherwise press enter. 📅");
    string? dateString = Console.ReadLine();
    DateTime? associatedDT = null;
    try
    {
        associatedDT = Convert.ToDateTime(dateString);
    }
    catch (FormatException) {}

    Task task = new(tasks.Count +1, prompt, associatedDT);
    tasks.Add(task);
    serialize();
    Console.WriteLine("Task added successfully! 💯");
}

/*
Returns if true if there was a none completed task and
thus it was shown. Otherwise false.
*/
bool SeeTasks ()
{
    bool showedNothing = true;

    foreach (var task in tasks)
    {
        if (task.Completed)
        {
            continue;
        }
        Console.WriteLine(task);
        showedNothing = false;
    }

    if (showedNothing)
    {
        Console.WriteLine("No Tasks. Write something 😊");
    }

    return !showedNothing;
}

void MarkCompleted ()
{   
    if (!SeeTasks())
    {
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Which Task have you completed?");
    var input = Console.ReadLine();
    int taskID;
    try
    {
        taskID = Convert.ToInt32(input);
    }
    catch (FormatException)
    {
        Console.WriteLine($"Invalid input {input} ❌");
        return;
    }

    Task? task = getTask(taskID);
    if (task == null)
    {
        Console.WriteLine($"Unknown Task {taskID}");
    }
    else
    {
        task.Completed = true;
        serialize();
        Console.WriteLine($"#{taskID} completed! 🎉");
    }
}

void SeeCompleted ()
{
    bool showedNothing = true;

    foreach (var task in tasks)
    {
        if (task.Completed)
        {
            Console.WriteLine(task);
            showedNothing = false;
        }
    }

    if (showedNothing)
    {
        Console.WriteLine("No Task is yet completed. Go finish a Task 🫡");
    }
}

void SeeDue ()
{
    bool showedNothing = true;
    DateTime now = DateTime.Now;
    foreach (var task in tasks)
    {
        if (!task.Completed && task.AssociatedTD.HasValue && task.AssociatedTD.Value < now)
        {
            showedNothing = false;
            Console.WriteLine(task);
        }
    }

    if (showedNothing)
    {
        Console.WriteLine("No Task is due at the moment. 👌🏼");
    }
}

// "Main"
Console.Clear();
Console.WriteLine($"Welcome! 👋🏼{Environment.NewLine}");

bool running = true;
while (running)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("#1 Add a Task 📝");
    Console.WriteLine("#2 See all your Tasks 📋");
    Console.WriteLine("#3 Mark a Task as completed ✅");
    Console.WriteLine("#4 See all completed Tasks 💯");
    Console.WriteLine("#5 See due Tasks 📅");
    Console.WriteLine("#6 Exit 🚪");
    
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
        
        case '6': case 'q':
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