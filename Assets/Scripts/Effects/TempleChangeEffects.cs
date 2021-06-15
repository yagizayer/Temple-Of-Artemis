using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TempleChangeEffects : MonoBehaviour
{

    [Header("First Change")]
    [SerializeField] private GameObject Sea;
    [SerializeField] [Range(.1f, 10)] float RisingTime = 2.5f;
    [SerializeField] [Range(.1f, 20)] float RisingLevel = 5f;
    [Header("Second Change")]
    [SerializeField] private GameObject Explosions;
    [SerializeField] [Range(.1f, 20)] float ExplosionTime = 5f;

    [Header("Last Change")]


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

    public void SecondPhaseEffect()
    {
        StartCoroutine(MakeArgon(ExplosionTime));
        StopCoroutine("MakeArgon");
    }

    IEnumerator MakeArgon(float explosionTime)
    {
        Explosions.SetActive(true);
        float startScale = 0;
        float endScale = Explosions.transform.localScale.x;
        EffectsEnded = false;
        float effectTime = 0f;
        while (effectTime < explosionTime / 2)
        {
            Explosions.transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, effectTime);
            yield return null;
            effectTime += Time.deltaTime;
        }

        ChangeTempleNow = true;
        effectTime = 0;

        while (effectTime < explosionTime / 2)
        {
            Explosions.transform.localScale = Vector3.one * Mathf.Lerp(endScale, startScale, effectTime);
            yield return null;
            effectTime += Time.deltaTime;
        }
        EffectsEnded = true;
        ChangeTempleNow = false;
        Explosions.SetActive(false);
    }




}
