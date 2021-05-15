using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GlobalVariables 
{

    [Header("Paths")]
    [SerializeField] static private string _NPCs_List_Path = "NPC_SOs";
    static public string NPCs_List_Path => _NPCs_List_Path;
}
