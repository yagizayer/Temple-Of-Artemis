using System.Collections.Generic;
using UnityEngine;

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



    public int CurrentConversationNo { get; private set; } = -1;
    public QuestConversation CurrentConvarsation
    {
        get => (CurrentConversationNo == -1) ? QuestConversations[++CurrentConversationNo] : QuestConversations[CurrentConversationNo];
        set => CurrentConvarsation = value;
    }

    public QuestConversation NextConversation
    {
        get => (CurrentConversationNo + 1 < QuestConversations.Count) ? QuestConversations[++CurrentConversationNo] : null;
        private set => NextConversation = value;
    }


    public Dictionary<string, QuestObject> QuestObjects { get; set; } = new Dictionary<string, QuestObject>();
    public List<QuestConversation> QuestConversations
    {
        get => new List<QuestConversation>();
        set
        {
            Debug.Log("test");
            QuestConversations = value;
            CurrentConvarsation = value[0];
            NextConversation = value[0];
            CurrentConversationNo = 0;
        }
    }

    
}
