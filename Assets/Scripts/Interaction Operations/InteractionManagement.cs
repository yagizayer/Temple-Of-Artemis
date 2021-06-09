using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractionManagement : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] private SphereCollider InteractionVolume;
    [SerializeField] [Range(.001f, 30f)] private float InteractionRange = 10f;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private LayerMask Ignore;

    private List<InteractableIdentifier> _interactables = new List<InteractableIdentifier>();

    private void Start()
    {
        mainCamera = Camera.main.transform;
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

    public void test(float cursorPosx, float cursorPosy)
    {
        Vector2 cursorPos = new Vector2(cursorPosx, cursorPosy);
        Ray r = mainCamera.GetComponent<Camera>().ScreenPointToRay(cursorPos);
        if (Physics.Raycast(r, out RaycastHit hit, 100f, ~Ignore))
        {
            InteractableIdentifier id = hit.transform.GetComponent<InteractableIdentifier>();
            if (id)
            {
                if (_interactables.Contains(id))
                {
                    // TODO : Make Interaction(questSystem)
                    Debug.Log("Interaction Happened");
                }
            }
        }
    }

}
