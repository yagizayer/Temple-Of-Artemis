using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManagement : MonoBehaviour
{
    [SerializeField] private GameObject NPC_Displayer;
    [Tooltip("List of NPCs")]
    [SerializeField] private List<NPC_SO> NPCs = new List<NPC_SO>();
    private void Start()
    {
        // getting NPC list from related resources folder
        foreach (NPC_SO NPC in Resources.LoadAll<NPC_SO>(GlobalVariables.NPCs_List_Path))
            NPCs.Add(NPC);

        foreach (NPC_SO NPC in NPCs)
        {
            GameObject tempDisplayer = GameObject.Instantiate(NPC_Displayer);
            tempDisplayer.transform.SetParent(transform);
            tempDisplayer.GetComponent<DisplayNPC>().MyNPC = NPC;
        }
        test();
    }


    public void test()
    {
        Debug.Log("test1");
        Debug.Log(StartCoroutine(test1(1)));
        Debug.Log("test2");
    }

    IEnumerator test1(float testval)
    {
        Debug.Log("test3");
        while (testval < 10)
        {
            yield return null;
            testval += Time.deltaTime;
        }
        Debug.Log("test4");
        StopCoroutine("test1");
    }
}
