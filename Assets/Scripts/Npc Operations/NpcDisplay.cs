using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// execution order : -50
[SelectionBase]
public class NpcDisplay : MonoBehaviour
{
    public Npc_SO MyNPC;
    public GameObject NpcGameObject { get; private set; }
    [SerializeField] private GameObject previewGFX;


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
        NpcGameObject = GameObject.Instantiate(MyNPC.prefab, Vector3.zero, Quaternion.identity);
        NpcGameObject.transform.SetParent(GFX.transform);
        NpcGameObject.transform.localPosition = new Vector3(0, -0.9f, 0);
        // NpcGameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
        NpcGameObject.transform.localRotation = Quaternion.identity;
        gameObject.name += "(" + NpcGameObject.name + ")";
        // transform.localPosition = previewGFX.transform.position;
        transform.localRotation = previewGFX.transform.rotation;
        transform.localScale = Vector3.one * MyNPC.startingScale;
    }
    void RemovePreview()
    {
        previewGFX.SetActive(false);
    }


}
