using System.Collections.Generic;

public class QuestConversation
{
    public QuestConversation()
    {
    }

    public QuestConversation(Npcs Speaker, List<string> Lines)
    {
        this.Speaker = Speaker;
        this.Lines = Lines;
    }
    public string CurrentLine
    {
        get => (CurrentLineNo == -1) ? Lines[++CurrentLineNo] : Lines[CurrentLineNo];
    }
    public int CurrentLineNo { get; private set; } = -1;
    public string NextLine
    {
        get => (CurrentLineNo + 1 < Lines.Count) ? Lines[++CurrentLineNo] : null;
    }
    public Npcs Speaker { get; set; }
    public List<string> Lines { get; set; } = new List<string>();

}
