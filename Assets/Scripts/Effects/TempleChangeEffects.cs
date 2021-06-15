using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TempleChangeEffects : MonoBehaviour
{
    [SerializeField] private GameObject Sea;
    [SerializeField] [Range(.1f, 10)] float RisingTime = 2.5f;
    [SerializeField] [Range(.1f, 20)] float RisingLevel = 5f;
    [HideInInspector]
    public bool ChangeTempleNow = false;
    [HideInInspector]
    public bool EffectsEnded = true;

    public void FirstPhaseEffect()
    {
        StartCoroutine(RiseAndLowerSea(RisingTime, RisingLevel));
        StopCoroutine("RiseAndLowerSea");
    }
    IEnumerator RiseAndLowerSea(float time, float riseLevel)
    {
        EffectsEnded = false;
        Vector3 startPos = Sea.transform.position;
        Vector3 endPos = Sea.transform.position.Modify(Vector3Values.Y, Sea.transform.position.y + riseLevel);
        float lerpTime = 0;

        while (lerpTime < time)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, lerpTime / time);
            Sea.transform.position = newPos;
            yield return null;
            lerpTime += Time.deltaTime;
        }
        ChangeTempleNow = true;
        lerpTime = 0;
        while (lerpTime < time)
        {
            Vector3 newPos = Vector3.Lerp(endPos, startPos, lerpTime / time);
            Sea.transform.position = newPos;
            yield return null;
            lerpTime += Time.deltaTime;
        }
        EffectsEnded = true;
        ChangeTempleNow = false;
    }
}
