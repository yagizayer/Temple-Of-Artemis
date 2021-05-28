using UnityEngine;


[CreateAssetMenu(fileName="New NPC", menuName="NPC")]
public class Npc_SO : ScriptableObject
{
    public GameObject prefab;
    public new string name;

    // public Vector3 startingPosition ;
    // public Quaternion startingRotation;
    public float startingScale = 1;

}
