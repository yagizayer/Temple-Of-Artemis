using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GlobalVariables
{


    static private string _NPCs_List_Path = "NPC_SOs";
    static public string NPCs_List_Path => _NPCs_List_Path;

    static private bool _isThereAnySaveFiles;
    static public bool IsThereAnySaveFiles
    {
        get { return _isThereAnySaveFiles; }
        set
        {
            _isThereAnySaveFiles = value;
        }
    }
}
