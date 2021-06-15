using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class EndPhaseManagement : MonoBehaviour
{
    public UnityAction EndScreenClosing, EndScreenOpening;
    [SerializeField] private Text Header;
    [SerializeField] private Text Construction;
    [SerializeField] private Text TempleInfo;

    private TemplesAndQuestObjectsManagement TAQM;
    private DialogManagement _dialogManagement;
    private DrawQuestTargetPath _drawPath;
    private PhaseNames _lastKnownPhase = PhaseNames.EarlyPhase;
    private PrefabDatabaseManager _db;
    private void Start()
    {
        TAQM = FindObjectOfType<TemplesAndQuestObjectsManagement>();
        _db = FindObjectOfType<PrefabDatabaseManager>();
        _dialogManagement = FindObjectOfType<DialogManagement>();
        _drawPath = FindObjectOfType<DrawQuestTargetPath>();
        EndScreenClosing += DeactivateEndScreen;
    }
    private void OnDisable()
    {
        EndScreenClosing.Invoke();
    }
    private void DeactivateEndScreen()
    {

    }

    private void ActivateEndScreen()
    {
        TempleInfo currentTempleInfo = _dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo;
        Header.text = currentTempleInfo.Header;
        Construction.text = currentTempleInfo.BuildingDate;
        string totalStrings = "";
        foreach (string item in currentTempleInfo.Lines)
            totalStrings += item + "\n";
        _drawPath.Target = _db.PrefabDB[Npcs.Profesor.ToString()].transform;

        TAQM.ShowCurrentTemple();

        // Debug.Log(_dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.BeforeInfo);
        // Debug.Log(_dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo.Header);
        // Debug.Log(_dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo.BuildingDate);
        // Debug.Log(_dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo.Lines.Count);
        // Debug.Log(_dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.AfterInfo);
    }

    private void FixedUpdate()
    {
        if (QuestTracker.CurrentPhaseName != _lastKnownPhase)
        {
            ActivateEndScreen();
            _lastKnownPhase = QuestTracker.CurrentPhaseName;
        }
    }
}
