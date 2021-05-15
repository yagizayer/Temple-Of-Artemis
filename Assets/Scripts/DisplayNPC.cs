using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNPC : MonoBehaviour
{
    [SerializeField] private NPC_SO myNPC;
    public NPC_SO MyNPC
    {
        get { return myNPC; }
        set
        {
            myNPC = value;
            GameObject npcPrefab = GameObject.Instantiate(myNPC.prefab, Vector3.zero, Quaternion.identity);
            npcPrefab.transform.SetParent(GFX.transform);
            gameObject.name += "(" + npcPrefab.name + ")";
            transform.localPosition = myNPC.startingPosition;
            transform.localRotation = myNPC.startingRotation;
            transform.localScale = Vector3.one * myNPC.startingScale;
        }
    }

    private GameObject GFX, UI;

    private void Awake()
    {
        foreach (Transform item in transform)
        {
            if (item.name == "GFX") GFX = item.gameObject;
            if (item.name == "UI") UI = item.gameObject;
        }
    }
}
