using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
class EffectsDict : SerializableDictionaryBase<EffectSound, AudioSource> { };
[System.Serializable]
class MusicsDict : SerializableDictionaryBase<MusicSound, AudioSource> { };

public class SoundManagement : MonoBehaviour
{
    [SerializeField] private EffectsDict EffectSounds;
    [SerializeField] private MusicsDict MusicSounds;

    public static bool InstanceExists = false;
    private void Start()
    {
        if (!InstanceExists)
            InstanceExists = true;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void RaiseOrLowerEffectSounds(float soundLevel)
    {
        foreach (KeyValuePair<EffectSound, AudioSource> item in EffectSounds)
            item.Value.volume = soundLevel;
    }
    public void RaiseOrLowerMusicSounds(float soundLevel)
    {
        foreach (KeyValuePair<MusicSound, AudioSource> item in MusicSounds)
            item.Value.volume = soundLevel;

    }
}
