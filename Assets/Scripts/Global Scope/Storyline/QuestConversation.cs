using System.Collections.Generic;

public class QuestConversation
{
    public QuestConversation()
    {
    }

    public QuestConversation(string Speaker, List<string> Lines)
    {
        this.Speaker = Speaker;
        this.Lines = Lines;
    }
    public int CurrentLineNo { get; private set; }
    public string NextLine { get => Lines[CurrentLineNo + 1]; private set => NextLine = value; }
    public string Speaker { get; set; } = string.Empty;
    public List<string> Lines { get; set; } = new List<string>();
}
