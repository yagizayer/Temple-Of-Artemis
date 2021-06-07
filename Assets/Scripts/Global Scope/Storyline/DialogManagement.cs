using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagement : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Phase> _storyline;
    public Dictionary<string, Phase> Storyline => _storyline;
    void Start()
    {
        SetStoryline();
    }
    void SetStoryline()
    {
        Phase tempPhase = new Phase();
        Quest tempQuest = new Quest();
        QuestConversation tempQuestConversation = new QuestConversation();
        QuestObject tempQuestObject = new QuestObject();
        PhaseEnd tempPhaseEnd = new PhaseEnd();
        TempleInfo tempTempleInfo = new TempleInfo();

        #region EarlyPhase
            
        #endregion
    }
}
