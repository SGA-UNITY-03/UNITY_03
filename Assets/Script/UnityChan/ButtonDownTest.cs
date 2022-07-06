using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonDownTest : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public TMP_Text _tmpText;

    int _score = 0;
    public int test;

    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
    }

    // 리플렉션 : 자기 자신을 조사
    // meta file을 이용해서 자기 자신을 조사할 수 있다.

    void Bind<T>(Type type)
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i=0; i < names.Length; i++)
        {
            objects[i] = null;
        }
    }

    public void OnMouseClick()
    {
        Debug.Log("마우스 버튼이 눌렸습니다!");
        _score++;
        _tmpText.text = $"Score : {_score}";
    }
}
