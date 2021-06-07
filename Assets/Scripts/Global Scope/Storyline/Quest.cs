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
    public Dictionary<string, QuestObject> QuestObjects { get; set; }
    public List<QuestConversation> QuestConversations { get; set; }
}
