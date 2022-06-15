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
        // W�� �� ������ �ִ�.
        // 1�� Update�� 1000�� ��ǻ�� : +1000 * forward -> �ð���ȭ�� 1/1000 => 1
        // 1�� Update�� 10���ϴ� ��ǻ�� : +10 * forward -> �ð���ȭ�� 1/10   => 1
        // deltatime : �ð���ȭ��
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
