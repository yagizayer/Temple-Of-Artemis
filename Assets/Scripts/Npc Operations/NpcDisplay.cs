using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// execution order : -50
[SelectionBase]
public class NpcDisplay : MonoBehaviour
{
    [SerializeField] private GameObject previewGFX;
    [SerializeField] private Npc_SO myNPC; public Npc_SO MyNPC => myNPC;

    [SerializeField] private GameObject npcGameObject; public GameObject NpcGameObject => npcGameObject;

    private GameObject GFX, UI;

    private void Awake()
    {
        foreach (Transform item in transform)
        {
            if (item.name == "GFX") GFX = item.gameObject;
            if (item.name == "UI") UI = item.gameObject;
        }
    }
    private void Start()
    {
        RemovePreview();
        InitializeNpc();

    }
    private void InitializeNpc()
    {
        npcGameObject = GameObject.Instantiate(myNPC.prefab, Vector3.zero, Quaternion.identity);
        npcGameObject.transform.SetParent(GFX.transform);
        npcGameObject.transform.localPosition = new Vector3(0, -0.9f, 0);
        // npcGameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
        npcGameObject.transform.localRotation = Quaternion.identity;
        gameObject.name += "(" + npcGameObject.name + ")";
        // transform.localPosition = previewGFX.transform.position;
        transform.localRotation = previewGFX.transform.rotation;
        transform.localScale = Vector3.one * myNPC.startingScale;
    }
    void RemovePreview()
    {
        previewGFX.SetActive(false);
    }


}
