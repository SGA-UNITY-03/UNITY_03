using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private List<GameObject> _ballList;
    private GameObject _ball;
    private Transform _muzzle;
    private Transform _head;

    public float _speed = 5.0f;
    void Start()
    {
        // 프리팹 가져오기
        // 무조건 Resources 폴더 안에 있는 오브젝트를 가져올 수 있다.
        _ball = Resources.Load<GameObject>($"Prefabs/Ball");
        _muzzle = transform.Find("Body/Head/Barrel/Muzzle");
        _head = transform.Find("Body/Head");

        if(_ball == null)
            Debug.Log("Ball을 못 찾앗습니다.");
        if (_muzzle == null)
            Debug.Log("Muzzle을 못 찾았습니다.");
        if (_head == null)
            Debug.Log("Head를 못 찾았습니다.");

        _ballList = GameObject.Find("ObjectPool").GetComponent<ObjectPool>().GetList();
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
            // local : 부모 기준
            // world : world 기준

            // Instantiate : 게임오브젝트를 복사해서 Clone을 만들고 월드에 등장시키는 함수
            for (int i = 0; i < 30; i++)
            {
                if (_ballList[i].activeSelf == false)
                {
                    _ballList[i].SetActive(true);
                    _ballList[i].transform.position = _muzzle.position;
                    _ballList[i].GetComponent<TankBall>().SetDirection(_head.transform.TransformDirection(Vector3.forward));

                    return;
                }
            }
        }
    }
}
