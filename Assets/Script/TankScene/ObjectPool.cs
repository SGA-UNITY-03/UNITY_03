using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int _poolCount = 30;

    public List<GameObject> _ballList;
    GameObject _ballOrigin;

    void Awake()
    {
        _ballList = new List<GameObject>(30);

        for(int i=0; i<_poolCount; i++)
        {
            GameObject go = Managers.Resource.Instantiate("Ball");
            go.transform.parent = transform;
            go.SetActive(false);
            _ballList.Add(go);
        }
    }

    public List<GameObject> GetList() { return _ballList; }
}
