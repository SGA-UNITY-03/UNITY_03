using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;

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
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        // s
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * Time.deltaTime * _speed;

        // a
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime * _speed;

        // d
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime * _speed;

        // Scaling
        // z
        if (Input.GetKey(KeyCode.O))
            transform.localScale += Vector3.one * Time.deltaTime;
        if (Input.GetKey(KeyCode.P))
            transform.localScale -= Vector3.one * Time.deltaTime;

    }
}
