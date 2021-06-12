﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractionManagement : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] private SphereCollider InteractionVolume;
    [SerializeField] [Range(.001f, 30f)] private float InteractionRange = 10f;
    [SerializeField] private LayerMask Ignore;

    [Header("AfterInteraction")]
    [SerializeField] private GameObject TalkingScreen;
    [SerializeField] private GameObject AcquiredQuestObjectProjectionParent;


    DialogManagement dialogManagement;
    private List<InteractableIdentifier> _interactables = new List<InteractableIdentifier>();
    private Transform mainCamera;


    private bool _hasItem = false;
    private QuestObject_SO _holdingItem;




    private void Start()
    {
        mainCamera = Camera.main.transform;
        dialogManagement = FindObjectOfType<DialogManagement>();
    }

    private List<InteractableIdentifier> IdentifyInteractables(Vector3 center, float range)
    {
        Collider[] interactableObjects = Physics.OverlapSphere(center, range);
        Collider[] unInteractableObjects = Physics.OverlapSphere(center, range + 2);
        List<InteractableIdentifier> result = new List<InteractableIdentifier>();
        foreach (Collider item in interactableObjects)
        {
            InteractableIdentifier id = item.GetComponent<InteractableIdentifier>();
            if (id)
            {
                if (_interactables.Contains(id)) continue;
                result.Add(id);
            }
        }

        foreach (Collider item in unInteractableObjects)
        {
            InteractableIdentifier id = item.GetComponent<InteractableIdentifier>();
            if (id)
            {
                if (_interactables.Contains(id)) continue;
                id.HideUI();
            }
        }
        return result;
    }
    private void RotateUI(List<InteractableIdentifier> interactables)
    {
        foreach (InteractableIdentifier item in interactables)
        {
            item.MyUIElement.LookTarget(mainCamera);
            if (!item.isMyUIElementActive) item.ShowUI();
        }
    }

    private void FixedUpdate()
    {
        _interactables = IdentifyInteractables(transform.position, InteractionRange);
        RotateUI(_interactables);
    }

    public void GetInteraction(float cursorPosx, float cursorPosy)
    {
        Vector2 cursorPos = new Vector2(cursorPosx, cursorPosy);
        if (!TalkingScreen.activeSelf)
        {
            Ray r = mainCamera.GetComponent<Camera>().ScreenPointToRay(cursorPos);
            if (Physics.Raycast(r, out RaycastHit hit, 100f, ~Ignore))
            {
                InteractableIdentifier id = hit.transform.GetComponent<InteractableIdentifier>() ?? hit.transform.parent.GetComponent<InteractableIdentifier>();
                if (id)
                {
                    if (_interactables.Contains(id))
                    {
                        HandleInteraction(id);
                    }
                }
            }
        }
    }
    private void HandleInteraction(InteractableIdentifier id)
    {
        if (id.interactionType == InteractionType.QuestObject && !_hasItem)
        {
            // Acquired questItem
            _hasItem = true;
            _holdingItem = id.GetComponent<DisplayQuestObject>().MyQuestObject;
            if (!AcquiredQuestObjectProjectionParent.transform.HasChild())
            {
                id.GetComponent<InteractableIdentifier>().MyUIElement.gameObject.SetActive(false);
                GameObject questObjectSpriter = GameObject.Instantiate(id.gameObject, AcquiredQuestObjectProjectionParent.transform, false);
                questObjectSpriter.transform.Reset();
                dialogManagement.InteractWithQuestObject(_holdingItem.QuestNpc);
                id.gameObject.SetActive(false);
            }
        }
        if (id.interactionType == InteractionType.Npc)
        {
            DisplayQuestObject displayQuestObject = id.GetComponent<DisplayQuestObject>();
            if (displayQuestObject)
            {
                // Ancient Columns (specialCase)

            }
            else
            {
                Npc_SO npc = id.GetComponent<NpcDisplay>().MyNPC;
                if (_hasItem)
                {
                    // Item Dialogs
                    dialogManagement.InteractWithNpc(npc.NpcName, _holdingItem, () =>
                    {
                        AcquiredQuestObjectProjectionParent.transform.Clear();
                        _hasItem = false;
                        _holdingItem = null;
                    });
                }
                else
                {
                    // Quest Dialogs
                    dialogManagement.InteractWithNpc(npc.NpcName);
                }
            }
        }
    }



}
