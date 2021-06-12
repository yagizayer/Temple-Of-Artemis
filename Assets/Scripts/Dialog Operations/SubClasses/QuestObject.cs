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
    public string CurrentLine
    {
        get => (CurrentLineNo == -1) ? Lines[++CurrentLineNo] : Lines[CurrentLineNo];
    }
    public int CurrentLineNo { get; private set; } = -1;
    public string NextLine { get => (CurrentLineNo + 1 < Lines.Count) ? Lines[++CurrentLineNo] : null; }
    public string Name { get; set; } = string.Empty;
    public Npcs TargetNpc { get; set; } = Npcs.Profesor;
    public List<string> Lines { get; set; } = new List<string>();
}
