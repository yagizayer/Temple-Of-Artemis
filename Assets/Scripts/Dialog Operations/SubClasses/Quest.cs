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


    private QuestConversation _currentConvarsation = new QuestConversation();
    public QuestConversation CurrentConvarsation
    {
        get
        {
            if (QuestConversations.Count == 0) return null;
            if (CurrentConversationNo == -1) return QuestConversations[0];
            if (CurrentConversationNo >= QuestConversations.Count) return null;
            return QuestConversations[CurrentConversationNo];
        }
        set { _currentConvarsation = value; }
    }

    private QuestConversation _nextConversation = new QuestConversation();
    public QuestConversation NextConversation
    {
        get
        {
            if (QuestConversations.Count == 0) return null;
            if (CurrentConversationNo + 1 >= QuestConversations.Count) return null;
            return QuestConversations[++CurrentConversationNo];
        }
        private set { _nextConversation = value; }
    }

    public string NextLine
    {
        get
        {
            // if (CurrentConversationNo == QuestConversations.Count) return null;
            return CurrentConvarsation?.NextLine ?? NextConversation?.NextLine;
        }
    }


    public Dictionary<string, QuestObject> QuestObjects { get; set; } = new Dictionary<string, QuestObject>();
    private List<QuestConversation> _questConversations = new List<QuestConversation>();
    public List<QuestConversation> QuestConversations
    {
        get => _questConversations;
        set
        {
            _questConversations = value;
            CurrentConvarsation = _questConversations[0];
            NextConversation = _questConversations[0];
            CurrentConversationNo = 0;
        }
    }


}
