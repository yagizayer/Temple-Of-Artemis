using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class EndPhaseManagement : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private Text Header;
    [SerializeField] private Text Construction;
    [SerializeField] private Text TempleInfo;
    [SerializeField] private Camera EffectsCam;

    private TemplesAndQuestObjectsManagement TAQM;
    private DialogManagement _dialogManagement;
    private DrawQuestTargetPath _drawPath;
    private PhaseNames _lastKnownPhase = PhaseNames.EarlyPhase;
    private PrefabDatabaseManager _db;
    TempleChangeEffects _templeChange;
    private void Start()
    {
        _templeChange = FindObjectOfType<TempleChangeEffects>();
        TAQM = FindObjectOfType<TemplesAndQuestObjectsManagement>();
        _db = FindObjectOfType<PrefabDatabaseManager>();
        _dialogManagement = FindObjectOfType<DialogManagement>();
        _drawPath = FindObjectOfType<DrawQuestTargetPath>();
    }

    public void DeactivateEndScreen()
    {
        MainScreen.SetActive(true);
        EffectsCam.enabled = false;
    }

    public void ActivateEndScreen()
    {
        MainScreen.SetActive(false);
        EndScreen.SetActive(true);
        TempleInfo currentTempleInfo = _dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo;
        Header.text = currentTempleInfo.Header;
        Construction.text = currentTempleInfo.BuildingDate;
        string totalStrings = "";
        foreach (string item in currentTempleInfo.Lines)
            totalStrings += item + "\n\n";
        TempleInfo.text = totalStrings;


        _drawPath.Target = _db.PrefabDB[Npcs.Profesor.ToString()].transform;
        if (QuestTracker.CurrentPhaseName == PhaseNames.EndPhase)
            TAQM.ShowCurrentTemple(true);
        else
            TAQM.ShowCurrentTemple();

        _lastKnownPhase = QuestTracker.CurrentPhaseName;
        _templeChange.ChangeTempleNow = false;
    }

    private void FixedUpdate()
    {
        if (QuestTracker.CurrentPhaseName != _lastKnownPhase && _templeChange.EffectsEnded)
        {
            EffectsCam.enabled = true;
            if (QuestTracker.CurrentPhaseName == PhaseNames.FirstTemple)
            {
                _templeChange.FirstPhaseEffect();
            }
        }
        if (_templeChange.ChangeTempleNow)
                ActivateEndScreen();
    }
}
