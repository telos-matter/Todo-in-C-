using System.Text;
using System.Text.Json.Serialization;

class Task
{
    [JsonInclude]
    private readonly int _id;
    [JsonInclude]
    private string _prompt;
    [JsonInclude]
    private bool _completed;
    [JsonInclude]
    private readonly DateTime _creationDT;
    /*
    When should this task be finished,
    or when is it due,
    or when is it happening,
    or something similar.
    */
    [JsonInclude]
    private DateTime? _associatedDT; 

    [JsonConstructor]
    private Task (int _id, string _prompt, bool _completed, DateTime _creationDT, DateTime? _associatedDT) {
        this._id = _id;
        this._prompt = _prompt;
        this._completed = _completed;
        this._creationDT = _creationDT;
        this._associatedDT = _associatedDT;
    }

    public Task (int id, string prompt, DateTime? associatedDT)
    {
        _id = id;
        _prompt = prompt;
        _completed = false;
        _creationDT = DateTime.Now;
        _associatedDT = associatedDT;
    }

    [JsonIgnore]
    public int Id
    {
        get => _id;
    }

    [JsonIgnore]
    public string Prompt 
    {
        get => _prompt;
        set {_prompt = value;}
    }

    [JsonIgnore]
    public bool Completed
    {
        get => _completed;
        set {_completed = value;}
    }

    [JsonIgnore]
    public DateTime CreationDT
    {
        get => _creationDT;
    }

    [JsonIgnore]
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