using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New QuestObject", menuName = "QuestObject")]
public class QuestObject_SO : ScriptableObject
{
    [Header("Basic Attributes")]
    public string KeyName;
    [FormerlySerializedAs("Model")]
    public Mesh mesh;
    public Material[] Materials;
    [Range(.001f, 100f)] public float Scale = 1;
    public ColliderType colliderType = ColliderType.Cube;
    public Vector3 ColliderOffset = Vector3.zero;
    public Vector3 ColliderScale = Vector3.one;
    [Tooltip("Select this if you want to change mesh scale without changing collider scale")]
    public bool ScaleColliderIndependent = false;

    [Header("Dialog Attributes")]
    public string Name;
    public Npcs QuestNpc;
    [TextArea] public string[] QuestLines;

}
