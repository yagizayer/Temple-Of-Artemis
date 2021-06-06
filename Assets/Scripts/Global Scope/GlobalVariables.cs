using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GlobalVariables
{


    static private string _npcListPath = "NPC_SOs";
    static public string NPCsListPath => _npcListPath;
    static private string _allConversationsJsonPath = "AllConversations";
    static public string AllConversationsPath => _allConversationsJsonPath;

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
