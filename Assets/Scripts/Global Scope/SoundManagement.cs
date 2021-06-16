using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class EffectsDict : SerializableDictionaryBase<EffectSound, AudioSource> { };
[System.Serializable]
public class MusicsDict : SerializableDictionaryBase<MusicSound, AudioSource> { };

public class SoundManagement : MonoBehaviour
{
    public EffectsDict EffectSounds;
    public MusicsDict MusicSounds;

    private float _lowerMultiplier = .3f;
    public static bool InstanceExists = false;
    private void Start()
    {
        if (!InstanceExists)
            InstanceExists = true;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(RotaredStart(.5f));
    }

    private IEnumerator RotaredStart(float waitForSec)
    {
        yield return new WaitForSecondsRealtime(waitForSec);




        StartSound(MusicSounds[MusicSound.MenuMusic]);
        if (SceneManager.GetActiveScene().name == "GamePlay")
        {
            StartSound(MusicSounds[MusicSound.EnvironmentMusic]);
        }
        else
        {
            StopSound(MusicSounds[MusicSound.EnvironmentMusic]);
        }
    }

    public void RaiseOrLowerEffectSounds(float soundLevel)
    {
        foreach (KeyValuePair<EffectSound, AudioSource> item in EffectSounds)
            item.Value.volume = soundLevel / 100f;

        EffectSounds[EffectSound.Running].volume *= _lowerMultiplier;
        EffectSounds[EffectSound.Walking].volume *= _lowerMultiplier;
    }
    public void RaiseOrLowerMusicSounds(float soundLevel)
    {
        foreach (KeyValuePair<MusicSound, AudioSource> item in MusicSounds)
        {
            item.Value.volume = soundLevel / 100f;
        }
        MusicSounds[MusicSound.MenuMusic].volume *= _lowerMultiplier;
    }

    public void StartSound(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    public void StopSound(AudioSource source)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }


}
