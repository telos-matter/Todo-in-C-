using System.Text;

class Task
{

    private string prompt;
    private bool completed;
    private DateTime creationDT;
    /*
    When should this task be finished,
    or when is it due,
    or when is it happening,
    or something similar.
    */
    private DateTime? associatedDT; 

    public Task (string prompt, DateTime? associatedDT)
    {
        this.prompt = prompt;
        completed = false;
        creationDT = DateTime.Now;
        this.associatedDT = associatedDT;
    }

    public string Prompt {get; set;}

    public bool Completed {get; set;}

    public DateTime CreationDT {get;}

    public DateTime AssociatedTD {get; set;}

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"Prompt: `{prompt}`\n");
        sb.Append($"Completed: {completed}\n");
        sb.Append($"CreationDT: {creationDT}\n");
        sb.Append($"AssociatedDT: {associatedDT}");
        sb.Replace("\n", Environment.NewLine);
        return sb.ToString();
    }

}