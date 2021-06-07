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
    public int CurrentLineNo { get; private set; }
    public string NextLine { get => Lines[CurrentLineNo + 1]; private set => NextLine = value; }
    public string Name { get; set; } = string.Empty;
    public Npcs TargetNpc { get; set; } = Npcs.Profesor;
    public List<string> Lines { get; set; } = new List<string>();
}
