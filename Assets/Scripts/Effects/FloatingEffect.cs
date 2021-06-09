using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{

    [SerializeField] [Range(.001f, 100f)] private float FloatingRange = 1;
    [SerializeField] private Vector3 FloatingAxis = Vector3.up;

    private void Start()
    {
        StartCoroutine(StartFloating());
    }

    private IEnumerator StartFloating()
    {
        while (true)
        {
            transform.position += Mathf.Sin(Time.time * Mathf.PI) / FloatingRange * FloatingAxis;
            yield return null;
        }
    }
}