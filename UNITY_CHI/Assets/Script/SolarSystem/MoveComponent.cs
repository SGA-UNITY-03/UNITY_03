using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;
    private float _angleX = 0.0f;
    private float _angleY = 0.0f;
    private float _angleZ = 0.0f;

    private float _xDistance = 0.0f;
    private float _yDistance = 0.0f;
    private float _zDistance = 0.0f;

    void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        // W를 쭉 누르고 있다.
        // 1초 Update를 1000번 컴퓨터 : +1000 * forward -> 시간변화량 1/1000 => 1
        // 1초 Update를 10번하는 컴퓨터 : +10 * forward -> 시간변화량 1/10   => 1
        // deltatime : 시간변화량
        // w
        // Move
        if (Input.GetKey(KeyCode.W))
        {
            _zDistance += Time.deltaTime * _speed;
        }
        // s
        if (Input.GetKey(KeyCode.S))
        {
            _zDistance -= Time.deltaTime * _speed;
        }

        // a
        if (Input.GetKey(KeyCode.A))
        {
            _xDistance += Time.deltaTime * _speed;
        }
        // d
        if (Input.GetKey(KeyCode.D))
        {
            _xDistance -= Time.deltaTime * _speed;
        }

        transform.Translate(new Vector3(_xDistance, 0, _zDistance));

        // Scaling
        // z
        if (Input.GetKey(KeyCode.O))
            transform.localScale += Vector3.one * Time.deltaTime;
        if (Input.GetKey(KeyCode.P))
            transform.localScale -= Vector3.one * Time.deltaTime;

        // Rotation
        _angleX += Time.deltaTime * _speed;
        _angleY += Time.deltaTime * _speed;
        _angleZ += Time.deltaTime * _speed;

        // Y축
        if (Input.GetKey(KeyCode.Z))
            transform.rotation = Quaternion.Euler(new Vector3(0,_angleY,0));
        // X축
        if (Input.GetKey(KeyCode.X))
            transform.rotation = Quaternion.Euler(new Vector3(_angleX, 0, 0));
        // Z축
        if (Input.GetKey(KeyCode.C))
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angleZ));
    }
}
