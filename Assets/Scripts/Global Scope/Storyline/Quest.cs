using System.Collections.Generic;

public class Quest
{
    public Quest()
    {
    }

    public Quest(Dictionary<string, QuestObject> QuestObjects, List<QuestConversation> QuestConversations)
    {
        this.QuestObjects = QuestObjects;
        this.QuestConversations = QuestConversations;
    }
    public QuestConversation CurrentConvarsation { get; set; } = new QuestConversation();
    public Dictionary<string, QuestObject> QuestObjects { get; set; } = new Dictionary<string, QuestObject>();
    public List<QuestConversation> QuestConversations { get; set; } = new List<QuestConversation>();
}
