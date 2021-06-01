using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonPressEffect : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] [Range(.01f, 10)] private float offset = .2f;
    [SerializeField] private float offsetAmplitude = 100f;
    Transform _content;
    Vector3 _contentOrginalPosition;
    float _darkeningOffsetpercentage = .7f;
    private void Start()
    {
        foreach (Transform item in transform)
        {
            if (_content == null)
                _content = item;
        }
        if (!GetComponent<Button>().interactable)
        {
            this.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _contentOrginalPosition = _content.position;
        _content.position += -this.transform.up * offset / offsetAmplitude;
        if (_content.gameObject.GetComponent<Text>())
        {
            Color currentColor = _content.GetComponent<Text>().color;
            currentColor = new Color(currentColor.r * _darkeningOffsetpercentage, currentColor.g * _darkeningOffsetpercentage, currentColor.b * _darkeningOffsetpercentage);
            _content.GetComponent<Text>().color = currentColor;
        }
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (_content.gameObject.GetComponent<Text>())
        {
            Color currentColor = _content.GetComponent<Text>().color;

            currentColor = new Color(currentColor.r / _darkeningOffsetpercentage, currentColor.g / _darkeningOffsetpercentage, currentColor.b / _darkeningOffsetpercentage);
            _content.GetComponent<Text>().color = currentColor;
        }
        _content.position = _contentOrginalPosition;
    }

}
