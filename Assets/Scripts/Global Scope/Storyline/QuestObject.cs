using System.Collections.Generic;

public class QuestObject
{
    public QuestObject()
    {
    }

    public QuestObject(string Name, Npcs TargetNpc, List<string> Lines)
    {
        this.Name = Name;
        this.TargetNpc = TargetNpc;
        this.Lines = Lines;
    }
    public string Name { get; set; }
    public Npcs TargetNpc { get; set; }
    public List<string> Lines { get; set; }
}
