using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float _angleY = 0.0f;
    [SerializeField]
    private float _speed = 30.0f;
    void Start()
    {
        
    }

    void Update()
    {
        _angleY += 1.0f * Time.deltaTime * _speed;

        transform.localRotation = Quaternion.Euler(new Vector3(0, _angleY, 0));
    }
}
