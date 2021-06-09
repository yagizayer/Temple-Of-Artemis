using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractionManagement : MonoBehaviour
{
    [SerializeField] private SphereCollider InteractionVolume;
    [SerializeField] [Range(.001f, 30f)] private float InteractionRange = 10f;
    [SerializeField] private List<InteractableIdentifier> _interactables = new List<InteractableIdentifier>();
    int _knownInteractableCount = 0;

    private void OnValidate()
    {
        InteractionVolume = InteractionVolume ?? GetComponent<SphereCollider>();
        InteractionVolume.radius = InteractionRange;
    }

    private List<InteractableIdentifier> IdentifyInteractables(Vector3 center, float range)
    {
        Collider[] interactableObjects = Physics.OverlapSphere(center, range);
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
        return result;
    }

    private void FixedUpdate()
    {
        _interactables = IdentifyInteractables(transform.position, InteractionRange);
        Debug.Log(_interactables.Count);
    }

}
