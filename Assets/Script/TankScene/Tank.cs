using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public List<GameObject> _ballList;
    private GameObject _ball;
    private Transform _muzzle;
    private Transform _head;

    private Transform _camera;
    private Transform _virtualCameraTransform;

    public float _speed = 5.0f;

    private void Awake()
    {
    }

    private void OnEnable()
    {
    }
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

        if (GameObject.Find("ObjectPool") == null)
            Debug.Log("ObjectPool 못찾음");

        if (_ballList.Count == 0)
            Debug.Log("ballList를 못찾음");

        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        if (_camera == null)
            Debug.Log("카메라 못찾음");

        _virtualCameraTransform = transform.Find("CameraPos");
        if (_virtualCameraTransform == null)
            Debug.Log("카메라Pos 못찾음");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        MoveCamera();
        RayCast();
        Move2();
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

            GameObject ball = _ballList.Find(ball => ball.activeSelf == false);
            if (ball != null)
            {
                ball.SetActive(true);
                ball.transform.position = _muzzle.position;
                ball.GetComponent<TankBall>().SetDirection(_head.transform.TransformDirection(Vector3.forward));
            }
        }
    }

    private void MoveCamera()
    {
        ////_cameara
        //_cameara.position = _virtualCameraTransform.position;
        //_cameara.rotation = _virtualCameraTransform.rotation;
    }

    private void RayCast()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);

        //RaycastHit hit;
        //LayerMask layerMask = LayerMask.GetMask("Tank") | LayerMask.GetMask("Plane");
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 10, layerMask))
        //    Debug.Log(hit.transform.name);
    }

    private void Move2()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir.Normalize();
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red);

            RaycastHit hit;
            Vector3 rayHitPostion = new Vector3();
            LayerMask layerMask = LayerMask.GetMask("Plane");

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                rayHitPostion = hit.point;
                Debug.Log(hit.transform.name);
            }

            rayHitPostion.y = transform.position.y;
            //Debug.Log(rayHitPostion);

            Vector3 directionToHit = rayHitPostion - transform.position; // 방향
            directionToHit.Normalize(); // 방향으로의 단위 벡터
            transform.position += directionToHit * _speed * Time.deltaTime;

            transform.rotation = 
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToHit), 5.0f * Time.deltaTime);
        }
    }
}
