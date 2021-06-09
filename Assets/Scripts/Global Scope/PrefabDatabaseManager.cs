using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDatabaseManager : MonoBehaviour
{
    public Dictionary<string, GameObject> PrefabDB = new Dictionary<string, GameObject>();
    [SerializeField] List<GameObject> _prefabObjects = new List<GameObject>();
    [SerializeField] List<string> _prefabNames = new List<string>();

    private void Start()
    {
        if (_prefabObjects.Count != _prefabNames.Count)
        {
            Debug.LogError("Different number of keys and values!");
            return;
        }
        for (int pairNo = 0; pairNo < _prefabObjects.Count; pairNo++)
        {
            PrefabDB[_prefabNames[pairNo]] = _prefabObjects[pairNo];
        }
    }
}
