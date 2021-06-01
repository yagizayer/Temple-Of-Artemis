using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ManageWarningPopup : MonoBehaviour
{
    [SerializeField] [TextArea] private string _warningString;
    public string WarningString
    {
        get { return _warningString; }
        set
        {
            _warningString = value;
            WarningText.text = _warningString;
        }
    }

    [SerializeField] private string _positiveString;
    public string PositiveString
    {
        get { return _positiveString; }
        set
        {
            _positiveString = value;
            PositiveText.text = _positiveString;
        }
    }

    [SerializeField] private string _negativeString;
    public string NegativeString
    {
        get { return _negativeString; }
        set
        {
            _negativeString = value;
            NegativeText.text = _negativeString;
        }
    }

    [SerializeField] private UnityAction _positiveClick;
    public UnityAction PositiveClick
    {
        get { return _positiveClick; }
        set
        {
            _positiveClick = value;
            PositiveButton.onClick.AddListener(_positiveClick);
        }
    }

    [SerializeField] private UnityAction _negativeClick;
    public UnityAction NegativeClick
    {
        get { return _negativeClick; }
        set
        {
            _negativeClick = value;
            NegativeButton.onClick.AddListener(_negativeClick);
        }
    }

    [SerializeField] private UnityAction _closeClick;
    public UnityAction CloseClick
    {
        get { return _closeClick; }
        set
        {
            _closeClick = value;
            foreach (Button item in CloseButtons)
            {
                item.onClick.AddListener(_closeClick);
            }
        }
    }


    [SerializeField] Button PositiveButton;
    [SerializeField] Button NegativeButton;
    [SerializeField] Button[] CloseButtons;
    [SerializeField] Text WarningText;
    [SerializeField] Text PositiveText;
    [SerializeField] Text NegativeText;

}
