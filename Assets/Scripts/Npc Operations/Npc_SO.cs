using UnityEngine;


[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class Npc_SO : ScriptableObject
{
    public GameObject prefab;
    public Npcs NpcName = Npcs.Profesor;

    // public Vector3 startingPosition ;
    // public Quaternion startingRotation;
    public float startingScale = 1;

}
