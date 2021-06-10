using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableIdentifier : MonoBehaviour
{
    // this object is an Interactable Object
    public InteractionType interactionType = InteractionType.QuestObject;
    public PhaseNames RelatedPhase;
    public QuestNames RelatedQuest;

    [HideInInspector]
    public Transform MyUIElement;
    [HideInInspector]
    public bool isMyUIElementActive = true;
    private PrefabDatabaseManager db;
    private void Start()
    {
        MyUIElement = transform.Find("Interaction_UI");
        db = FindObjectOfType<PrefabDatabaseManager>();
        if (!MyUIElement)
        {
            MyUIElement = GameObject.Instantiate(db.PrefabDB["InteractableObjectUI"], transform, false).transform;
        }
        if (interactionType == InteractionType.QuestObject)
        {
            GetComponent<DisplayQuestObject>().SetScaleToDefault(MyUIElement);
        }

        if (interactionType == InteractionType.Npc)
            MyUIElement.GetFirstChild().Find("Context").GetComponent<Image>().sprite = GlobalVariables.ThreeDots;
        if (interactionType == InteractionType.QuestObject || (interactionType == InteractionType.Npc && RelatedQuest == QuestNames.FindAncientColumns))
            MyUIElement.GetFirstChild().Find("Context").GetComponent<Image>().sprite = GlobalVariables.MagnifyingGlass;


        HideUI();
    }
    public void ShowUI()
    {
        MyUIElement.gameObject.SetActive(true);
        isMyUIElementActive = true;
    }
    public void HideUI()
    {
        MyUIElement.gameObject.SetActive(false);
        isMyUIElementActive = false;
    }

}
