using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public List<GameObject> _ballList;
    private GameObject _ball;
    private Transform _muzzle;
    private Transform _head;

    public float _speed = 5.0f;

    private void Awake()
    {
    }

    private void OnEnable()
    {
    }
    void Start()
    {
        // ������ ��������
        // ������ Resources ���� �ȿ� �ִ� ������Ʈ�� ������ �� �ִ�.
        _ball = Resources.Load<GameObject>($"Prefabs/Ball");
        _muzzle = transform.Find("Body/Head/Barrel/Muzzle");
        _head = transform.Find("Body/Head");

        if(_ball == null)
            Debug.Log("Ball�� �� ã�ѽ��ϴ�.");
        if (_muzzle == null)
            Debug.Log("Muzzle�� �� ã�ҽ��ϴ�.");
        if (_head == null)
            Debug.Log("Head�� �� ã�ҽ��ϴ�.");

        _ballList = GameObject.Find("ObjectPool").GetComponent<ObjectPool>().GetList();

        if (GameObject.Find("ObjectPool") == null)
            Debug.Log("ObjectPool ��ã��");

        if (_ballList.Count == 0)
            Debug.Log("ballList�� ��ã��");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            this.GetComponent<Transform>().rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // local : �θ� ����
            // world : world ����

            // Instantiate : ���ӿ�����Ʈ�� �����ؼ� Clone�� ����� ���忡 �����Ű�� �Լ�

            GameObject ball = _ballList.Find(ball => ball.activeSelf == false);
            if (ball != null)
            {
                ball.SetActive(true);
                ball.transform.position = _muzzle.position;
                ball.GetComponent<TankBall>().SetDirection(_head.transform.TransformDirection(Vector3.forward));
            }
        }
    }
}