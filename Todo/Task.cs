using System.Text;

class Task
{
    private readonly int _id;
    private string _prompt;
    private bool _completed;
    private readonly DateTime _creationDT;
    /*
    When should this task be finished,
    or when is it due,
    or when is it happening,
    or something similar.
    */
    private DateTime? _associatedDT; 

    public Task (int id, string prompt, DateTime? associatedDT)
    {
        _id = id;
        _prompt = prompt;
        _completed = false;
        _creationDT = DateTime.Now;
        _associatedDT = associatedDT;
    }

    public int Id
    {
        get => _id;
    }

    public string Prompt 
    {
        get => _prompt;
        set {_prompt = value;}
    }

    public bool Completed
    {
        get => _completed;
        set {_completed = value;}
    }

    public DateTime CreationDT
    {
        get => _creationDT;
    }

    public DateTime? AssociatedTD
    {
        get => _associatedDT;
        set {_associatedDT = value;}
    }

    // TODO more user friendly ToString
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"ID: {_id}\n");
        sb.Append($"Prompt: `{_prompt}`\n");
        sb.Append($"Completed: {_completed}\n");
        sb.Append($"CreationDT: {_creationDT}\n");
        sb.Append($"AssociatedDT: {_associatedDT}");
        sb.Replace("\n", Environment.NewLine);
        return sb.ToString();
    }

}