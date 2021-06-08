using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DisplayQuestObject : MonoBehaviour
{
    public QuestObject_SO MyQuestObject;

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private void Start()
    {
        SetAttributes();
    }
    
    [ContextMenu("SetAttributes")]
    public void SetAttributes()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter.mesh = MyQuestObject.mesh;

        _meshRenderer.materials = MyQuestObject.Materials;
        transform.localScale = Vector3.one * MyQuestObject.Scale;
    }
}
