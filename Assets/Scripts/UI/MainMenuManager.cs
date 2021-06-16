using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject warningWindow;
    bool _warningEventsInitialized = false;

    private Dictionary<string, GameObject> buttons = new Dictionary<string, GameObject>();

    private void Start()
    {
        buttons["Continue"] = FindObjectOfType<MM_ContinueButtonID>().gameObject;
        buttons["NewGame"] = FindObjectOfType<MM_NewGameButtonID>().gameObject;

        UpdateMenuContent();
    }
    public void Continue()
    {
        Debug.Log("Continue");
    }
    public void NewGame()
    {
        Debug.Log("NewGame");
        ManageWarningPopup warningManager = warningWindow.GetComponent<ManageWarningPopup>();
        if (!_warningEventsInitialized)
        {
            warningManager.PositiveClick += CreateNewSave;
            warningManager.NegativeClick += CancelCreatingNewSave;
            warningManager.CloseClick += CloseWarningWindow;
            _warningEventsInitialized = true;
        }
        warningWindow.SetActive(true);
    }


    /* -------------------------------------    Warning Window Events   ---------------------------------------- */

    private void CreateNewSave()
    {
        // ToDo : Create Save System
        UpdateMenuContent();
        CloseWarningWindow();
        SceneManager.LoadScene("Gameplay");
    }
    private void CancelCreatingNewSave()
    {
        CloseWarningWindow();
    }
    private void CloseWarningWindow()
    {
        warningWindow.SetActive(false);
    }
    private void UpdateMenuContent()
    {
        if (GlobalVariables.IsThereAnySaveFiles)
        {
            buttons["Continue"].GetComponent<Button>().interactable = true;
            buttons["Continue"].GetComponent<ButtonPressEffect>().enabled = true;
        }
        else
        {
            buttons["Continue"].GetComponent<Button>().interactable = false;
            buttons["Continue"].GetComponent<ButtonPressEffect>().enabled = false;
        }
    }
}
