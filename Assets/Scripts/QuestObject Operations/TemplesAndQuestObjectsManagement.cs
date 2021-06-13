using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplesAndQuestObjectsManagement : MonoBehaviour
{
    [Header("Temples")]
    [SerializeField] private GameObject Temple_0;
    [SerializeField] private GameObject Temple_1;
    [SerializeField] private GameObject Temple_2;
    [SerializeField] private GameObject Temple_3;

    [Header("QuestObjects")]
    [Tooltip("Temple_0 and EarlyPhase Objects are here")]
    [SerializeField] private List<GameObject> Level_1;
    [Tooltip("Temple_1 and FirstTemple Objects are here")]
    [SerializeField] private List<GameObject> Level_2;
    [Tooltip("Temple_2 and LastTemple Objects are here")]
    [SerializeField] private List<GameObject> Level_3;

    public void ShowCurrentTemple(bool LastTemple = false)
    {
        HideEverything();
        if (QuestTracker.CurrentPhaseName == PhaseNames.EarlyPhase)
        {
            Temple_0.SetActive(true);
            foreach (GameObject item in Level_1)
            {
                item.SetActive(true);
            }
        }
        if (QuestTracker.CurrentPhaseName == PhaseNames.FirstTemple)
        {
            Temple_1.SetActive(true);
            foreach (GameObject item in Level_2)
            {
                item.SetActive(true);
            }
        }
        if (QuestTracker.CurrentPhaseName == PhaseNames.LastTemple)
        {
            Temple_2.SetActive(true);
            foreach (GameObject item in Level_3)
            {
                item.SetActive(true);
            }
        }
        if (LastTemple)
        {
            Temple_3.SetActive(true);
        }
        HideInteractedItems();
    }
    private void HideEverything()
    {
        Temple_0.SetActive(false);
        Temple_1.SetActive(false);
        Temple_2.SetActive(false);
        Temple_3.SetActive(false);
        foreach (GameObject item in Level_1)
            item.SetActive(false);
        foreach (GameObject item in Level_2)
            item.SetActive(false);
        foreach (GameObject item in Level_3)
            item.SetActive(false);
    }

    private void HideInteractedItems()
    {
        List<GameObject> currentQuestObjects = new List<GameObject>();
        if (QuestTracker.CurrentPhaseName == PhaseNames.EarlyPhase) currentQuestObjects = Level_1;
        if (QuestTracker.CurrentPhaseName == PhaseNames.FirstTemple) currentQuestObjects = Level_2;
        if (QuestTracker.CurrentPhaseName == PhaseNames.LastTemple) currentQuestObjects = Level_3;
        foreach (KeyValuePair<(PhaseNames, string), bool> questObject in QuestTracker.questObjectTracker)
        {
            if (questObject.Key.Item1 == QuestTracker.CurrentPhaseName)
            {
                foreach (GameObject item in currentQuestObjects)
                {
                    if (item.GetComponent<DisplayQuestObject>().MyQuestObject.KeyName == questObject.Key.Item2)
                    {
                        item.SetActive(!questObject.Value);
                    }
                }
            }
        }
    }

}
