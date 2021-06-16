using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Cinemachine;

public class Settings : MonoBehaviour
{
    #region SettingsVariables
    [SerializeField] private Slider EffectSounds;
    [SerializeField] private Slider MusicSounds;
    [SerializeField] private Toggle InvertCamYCheckSign;

    #endregion

    #region OutputVariables
    [SerializeField] private CinemachineFreeLook MainCam;
    [SerializeField] private SoundManagement SoundManager;
    #endregion



    private void Start()
    {
        SetCurrentValues();
    }

    public void SetCurrentValues()
    {
        if (SoundManager == null) SoundManager = FindObjectOfType<SoundManagement>();
        EffectSounds.value = GlobalVariables.EffectSoundLevel;
        MusicSounds.value = GlobalVariables.MusicSoundLevel;
        InvertCamYCheckSign.isOn = GlobalVariables.IsCamYInverted;

        SoundManager.RaiseOrLowerMusicSounds(GlobalVariables.MusicSoundLevel);
        SoundManager.RaiseOrLowerEffectSounds(GlobalVariables.EffectSoundLevel);


    }

    public void SetEffectSounds(Slider value)
    {
        EffectSounds = value;
        GlobalVariables.EffectSoundLevel = EffectSounds.value;
        SoundManager.RaiseOrLowerEffectSounds(GlobalVariables.EffectSoundLevel);
    }

    public void SetMusicSounds(Slider value)
    {
        MusicSounds = value;
        GlobalVariables.MusicSoundLevel = MusicSounds.value;
        SoundManager.RaiseOrLowerMusicSounds(GlobalVariables.MusicSoundLevel);
    }

    public void SetInvertCamYCheckSign(Toggle value)
    {
        InvertCamYCheckSign = value;
        GlobalVariables.IsCamYInverted = value.isOn;

        if (MainCam)
        {
            AxisState temp = MainCam.m_YAxis;
            temp.m_InvertInput = GlobalVariables.IsCamYInverted;
            MainCam.m_YAxis = temp;
        }

    }

}
