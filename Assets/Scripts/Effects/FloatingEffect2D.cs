using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FloatingEffect2D : MonoBehaviour
{

    [SerializeField] [Range(.001f, 100f)] private float FloatingRange = 1;
    [SerializeField] private Vector3 FloatingAxis = Vector3.up;

    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        StartCoroutine(StartFloating(rectTransform));
    }

    private IEnumerator StartFloating(RectTransform rectTransform)
    {
        while (true)
        {
            rectTransform.localPosition += Mathf.Sin(Time.time * Mathf.PI) / FloatingRange * FloatingAxis;
            yield return null;
        }
    }
}