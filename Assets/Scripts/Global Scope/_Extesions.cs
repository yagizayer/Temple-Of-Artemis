using UnityEngine;
using System.Collections.Generic;

public static class _Extesions
{
    public static Vector3 toVector3(this Vector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y, 0);
    }

    public static RectTransform resizeWidth(this RectTransform rectTransform)
    {
        float newWidth = rectTransform.sizeDelta.x * ((float)Screen.height / 1000);
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);
        return rectTransform;
    }
    // verilen nesnenin ve alt nesnelerinin boyutunu değiştirir.
    public static RectTransform scaleWidth(this RectTransform rectTransform)
    {
        Vector2 oldSize = rectTransform.sizeDelta;
        Vector2 newSize = new Vector2(rectTransform.sizeDelta.x * ((float)Screen.height / 1000), rectTransform.sizeDelta.y);
        Vector2 tempRatio = new Vector2(newSize.x / oldSize.x, newSize.y / oldSize.y);

        rectTransform.localScale = tempRatio;
        return rectTransform;
    }
    public static Vector3 toFloor(this Vector3 vector3)
    {
        return new Vector3(vector3.x, 0, vector3.z);
    }
    public static Vector3 setHeight(this Vector3 vector3, float targetHeight)
    {
        return new Vector3(vector3.x, targetHeight, vector3.z);
    }

    public static Transform Clear(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        return transform;
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

}
