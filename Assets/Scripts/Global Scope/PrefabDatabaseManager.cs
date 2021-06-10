using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDatabaseManager : MonoBehaviour
{

    private Dictionary<string, GameObject> _prefabDB = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> PrefabDB
    {
        get
        {
            if (_prefabObjects.Count != _prefabNames.Count)
            {
                Debug.LogError("Different number of keys and values!");
                return null;
            }
            for (int pairNo = 0; pairNo < _prefabObjects.Count; pairNo++)
            {
                _prefabDB[_prefabNames[pairNo]] = _prefabObjects[pairNo];
            }
            return _prefabDB;
        }
        private set
        {
            _prefabDB = value;
        }
    }
    [SerializeField] List<GameObject> _prefabObjects = new List<GameObject>();
    [SerializeField] List<string> _prefabNames = new List<string>();
}
