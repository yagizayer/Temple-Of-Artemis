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
    public string CurrentLine
    {
        get => (CurrentLineNo == -1) ? Lines[++CurrentLineNo] : Lines[CurrentLineNo];
        private set => CurrentLine = value;
    }
    public int CurrentLineNo { get; private set; } = -1;
    public string NextLine
    {
        get => (CurrentLineNo + 1 < Lines.Count) ? Lines[++CurrentLineNo] : null;
        private set => NextLine = value;
    }
    public string Speaker { get; set; } = string.Empty;
    public List<string> Lines { get; set; } = new List<string>();

}
