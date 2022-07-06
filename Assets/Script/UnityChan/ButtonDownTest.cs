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

    // ���÷��� : �ڱ� �ڽ��� ����
    // meta file�� �̿��ؼ� �ڱ� �ڽ��� ������ �� �ִ�.

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
        Debug.Log("���콺 ��ư�� ���Ƚ��ϴ�!");
        _score++;
        _tmpText.text = $"Score : {_score}";
    }
}
