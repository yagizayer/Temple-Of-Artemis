using UnityEngine;
using System.Collections.Generic;

public static class _Extesions
{
    public static Vector3 toVector3(this Vector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y, 0);
    }
    public static Transform Clear(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        return transform;
    }
    public static bool HasChild(this Transform transform)
    {
        foreach (Transform child in transform)
            return true;
        return false;
    }
    public static void Reset(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
    public static void Reset(this RectTransform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        transform.anchorMin = Vector2.zero;
        transform.anchorMax = Vector2.one;
        transform.sizeDelta = Vector2.zero;
        transform.rect.Set(0, 0, 100, 100);
    }
    public static Dictionary<T1, T2> AddRange<T1, T2>(this Dictionary<T1, T2> me, Dictionary<T1, T2> other)
    {
        foreach (KeyValuePair<T1, T2> item in other)
            me.Add(item.Key, item.Value);
        return me;
    }

    public static Transform LookTarget(this Transform me, Transform target)
    {
        me.rotation = Quaternion.LookRotation(me.position - target.position, Vector3.up);
        return me;
    }

    public static Transform GetFirstChild(this Transform me)
    {
        foreach (Transform item in me)
        {
            return item;
        }
        return null;
    }


}
