using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    Dictionary<string, List<GameObject>> _effectTable;
    int _poolCount = 10;

    void Start()
    {
        _effectTable = new Dictionary<string, List<GameObject>>();

        {
            List<GameObject> temp = new List<GameObject>();

            for (int i = 0; i < _poolCount; i++)
            {
                GameObject go = Managers.Resource.Instantiate("Hits/Hit_04", transform);

                if (go == null)
                    Debug.LogError("Hit Effect ��ã��");

                go.SetActive(false);
                temp.Add(go);
            }

            _effectTable["Attack4"] = temp;
        }
        {
            List<GameObject> temp = new List<GameObject>();
            for (int i = 0; i < _poolCount; i++)
            {
                GameObject go = Managers.Resource.Instantiate("Hits/Hit_03", transform);

                if (go == null)
                    Debug.LogError("Hit Effect ��ã��");

                go.SetActive(false);
                temp.Add(go);
            }

            _effectTable["Attack3"] = temp;
        }

    }

    public void PlayEffect(string name, Vector3 pos)
    {
        if (!_effectTable.ContainsKey(name))
            Debug.LogError(name + "�� ��ã��");

        foreach(GameObject go in _effectTable[name])
        {
            if (go.activeSelf == false)
            {
                go.SetActive(true);
                go.transform.position = pos;
                ParticleSystem particle = go.GetComponent<ParticleSystem>();
                particle.Play();
                break;
            }
        }
    }

    // ["Attack"] - [Hit4]

    // EffectManager -> "Attack" Effect�� Ʋ���ּ���
    // -> Attack ����Ʈ�� ã�Ƽ�... _effectTable���� ã�Ƽ�
    // -> �ش� ��ġ�� Play
}
