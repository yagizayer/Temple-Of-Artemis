using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableIdentifier : MonoBehaviour
{
    // this object is an Interactable Object
    public InteractionType interactionType = InteractionType.QuestObject;
    public Transform MyUIElement;
    public bool isMyUIElementActive = true;
    private void Start()
    {
        MyUIElement = transform.Find("UI");
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
