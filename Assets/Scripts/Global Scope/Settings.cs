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
    private static float _effectSoundLevel = 15;
    private static float _musicSoundLevel = 15;
    private static bool _isCamYInverted = false;
    public static float EffectSoundLevel => _effectSoundLevel;
    public static float MusicSoundLevel => _musicSoundLevel;
    public static bool IsCamYInverted => _isCamYInverted;

    #endregion

    #region OutputVariables
    [SerializeField] private CinemachineFreeLook MainCam;
    [SerializeField] private SoundManagement soundManagement;

    #endregion


    public void SetEffectSounds(Slider value)
    {
        EffectSounds = value;
        _effectSoundLevel = EffectSounds.value;

    }
    public void SetMusicSounds(Slider value)
    {
        MusicSounds = value;
        _musicSoundLevel = MusicSounds.value;

    }

    public void SetInvertCamYCheckSign(Toggle value)
    {
        InvertCamYCheckSign = value;
        _isCamYInverted = value.isOn;
        AxisState temp = MainCam.m_YAxis;
        temp.m_InvertInput = value.isOn;
        MainCam.m_YAxis = temp;
    }

}
