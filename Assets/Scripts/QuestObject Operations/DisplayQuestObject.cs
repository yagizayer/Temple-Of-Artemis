using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider))]
public class DisplayQuestObject : MonoBehaviour
{
    public QuestObject_SO MyQuestObject;

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private MeshCollider _meshCollider;
    private BoxCollider _detectionCollider;
    private void Start()
    {
        SetAttributes();
    }

    [ContextMenu("SetAttributes")]
    public void SetAttributes()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshCollider = GetComponentInChildren<MeshCollider>() ?? CreateColliderObject();
        _detectionCollider = GetComponent<BoxCollider>();

        _detectionCollider.size = Vector3.one * .001f / MyQuestObject.Scale; // solely for Interaction detection
        _meshFilter.mesh = MyQuestObject.mesh;
        _meshRenderer.materials = MyQuestObject.Materials;
        transform.localScale = Vector3.one * MyQuestObject.Scale;
        _meshCollider.sharedMesh = SelectMesh(MyQuestObject);
        _meshCollider.transform.localPosition = MyQuestObject.ColliderOffset;
        _meshCollider.transform.localScale = MyQuestObject.ColliderScale / (MyQuestObject.ScaleColliderIndependent ? MyQuestObject.Scale : 1);
    }

    private MeshCollider CreateColliderObject()
    {
        GameObject ColliderObject = new GameObject("ColliderObject");
        ColliderObject.AddComponent<MeshCollider>();
        ColliderObject.transform.localPosition = Vector3.zero;
        ColliderObject.transform.SetParent(transform);
        return ColliderObject.GetComponent<MeshCollider>();
    }

    public Mesh SelectMesh(QuestObject_SO QuestObject)
    {
        Dictionary<ColliderType, Mesh> ColliderMeshPairs = new Dictionary<ColliderType, Mesh>();

        GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject Capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        ColliderMeshPairs[ColliderType.Cube] = Cube.GetComponent<MeshFilter>().sharedMesh;
        ColliderMeshPairs[ColliderType.Capsule] = Capsule.GetComponent<MeshFilter>().sharedMesh;
        ColliderMeshPairs[ColliderType.Sphere] = Sphere.GetComponent<MeshFilter>().sharedMesh;
        ColliderMeshPairs[ColliderType.Cylinder] = Cylinder.GetComponent<MeshFilter>().sharedMesh;
        ColliderMeshPairs[ColliderType.Mesh] = QuestObject.mesh;

        if (Application.isPlaying)
        {
            Destroy(Cube);
            Destroy(Capsule);
            Destroy(Sphere);
            Destroy(Cylinder);
        }
        if (Application.isEditor)
        {
            DestroyImmediate(Cube);
            DestroyImmediate(Capsule);
            DestroyImmediate(Sphere);
            DestroyImmediate(Cylinder);
        }
        return ColliderMeshPairs[QuestObject.colliderType];

    }

    public void SetScaleToDefault(Transform child)
    {
        child.localScale = child.localScale / MyQuestObject.Scale;
    }

}
