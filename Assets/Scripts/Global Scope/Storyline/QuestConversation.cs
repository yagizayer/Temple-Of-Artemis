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
    public string Speaker { get; set; }
    public List<string> Lines { get; set; }
}
