using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class EndPhaseManagement : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;
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
    }
    private void OnDisable()
    {
        DeactivateEndScreen();
    }
    public void DeactivateEndScreen()
    {

    }

    public void ActivateEndScreen()
    {
        EndScreen.SetActive(true);
        TempleInfo currentTempleInfo = _dialogManagement.Storyline[_lastKnownPhase].PhaseEnd.templeInfo;
        Header.text = currentTempleInfo.Header;
        Construction.text = currentTempleInfo.BuildingDate;
        string totalStrings = "";
        foreach (string item in currentTempleInfo.Lines)
            totalStrings += item + "\n";
        TempleInfo.text = totalStrings;
        

        _drawPath.Target = _db.PrefabDB[Npcs.Profesor.ToString()].transform;

        TAQM.ShowCurrentTemple();
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
