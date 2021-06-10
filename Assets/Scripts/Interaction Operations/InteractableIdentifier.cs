using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableIdentifier : MonoBehaviour
{
    // this object is an Interactable Object
    public InteractionType interactionType = InteractionType.QuestObject;
    public PhaseNames RlatedPhase;
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
