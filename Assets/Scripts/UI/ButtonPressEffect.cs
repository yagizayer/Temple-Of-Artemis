using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class ButtonPressEffect : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text text;
    private void Start() {
        text = GetComponentInChildren<Text>();
    }

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log(eventData);
    }

    public void MoveText(){
        // Text
    }
}
