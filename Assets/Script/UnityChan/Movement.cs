using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    Vector3 rayHitPostion = Vector3.zero;

    private bool _isMove = false;

    enum State
    {
        IS_MOVE,
        IS_WAIT,
        IS_DEAD,
        IS_SKILL
    }

    private float _ratio = 0.0f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Move2();

        if (_isMove)
        {
            anim.SetFloat("Speed", _speed);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        Jump();
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

    private void Move2()
    {
        // ī�޶���� Plaen�� ������ ���� ó�� �΋H���� ��ġ ã��
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red);

            RaycastHit hit;

            LayerMask layerMask = LayerMask.GetMask("Plane");

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                rayHitPostion = hit.point;
                Debug.Log(hit.transform.name);
            }
        }

        // ĳ���ͷ� ���� ������ ����Ʈ ��ġ�� ���� => ���������� ���������� ��ġ������ ����
        rayHitPostion.y = transform.position.y; // y�� ���� ĳ������ y���� ��ġ
        Vector3 directionToHit = rayHitPostion - transform.position; // ����
        Vector3 dir = directionToHit.normalized; // ���������� ���� ����

        if (directionToHit.magnitude < 0.01f)
        {
            _isMove = false;
            return;
        }

        transform.position += dir * _speed * Time.deltaTime;
        _isMove = true;

        transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5.0f * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJump", true);
        }
    }

    public void JumpDown()
    {
        anim.SetBool("IsJump", false);
    }
}
