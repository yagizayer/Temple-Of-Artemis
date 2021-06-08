using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New QuestObject", menuName = "QuestObject")]
public class QuestObject_SO : ScriptableObject
{
    [Header("Basic Attributes")]
    [FormerlySerializedAs("Model")]
    public Mesh mesh;
    public Material[] Materials;
    [Range(.001f, 100f)] public float Scale = 1;
    [Header("Dialog Attributes")]
    public string Name;
    public Npcs QuestNpc;
    [TextArea] public string[] QuestLines;

}
