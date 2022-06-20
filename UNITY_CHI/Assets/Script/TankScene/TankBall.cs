using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBall : MonoBehaviour
{
    Vector3 _direction = Vector3.forward;
    float _speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }
}
