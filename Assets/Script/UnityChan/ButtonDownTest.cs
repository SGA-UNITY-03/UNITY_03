using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonDownTest : MonoBehaviour
{
    public Text _UItext;
    public TMP_Text _tmpText;
    int _score = 0;

    private void Start()
    {
    }

    public void OnMouseClick()
    {
        Debug.Log("마우스 버튼이 눌렸습니다!");
        _score++;
        _tmpText.text = $"Score : {_score}";
    }
}
