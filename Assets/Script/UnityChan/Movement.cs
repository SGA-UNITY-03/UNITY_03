using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        InputManager input = Managers.Input;
        input.KeyAction -= Move; // 오류 방지 코드
        input.KeyAction += Move;
        input.MouseAction -= Move2;
        input.MouseAction += Move2;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            _isMove = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            _isMove = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            _isMove = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.rotation = q;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            _isMove = true;
        }

        //if (Input.anyKey)
        //    _isMove = false;
    }

    private void Move2(Define.MouseEvent evt)
    {
        // UI에 마우스가 올라와있으면 리턴
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red);

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("Plane");

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            rayHitPostion = hit.point;
            Debug.Log(hit.transform.name);
        }

        // 캐릭터로 부터 레이저 포인트 위치를 빼면 => 나에서부터 레이저찍힌 위치까지의 방향
        rayHitPostion.y = transform.position.y; // y의 값은 캐릭터의 y값과 일치
        Vector3 directionToHit = rayHitPostion - transform.position; // 방향
        Vector3 dir = directionToHit.normalized; // 방향으로의 단위 벡터

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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJump", true);
        }
    }

    public void ButtonJump()
    {
        anim.SetBool("IsJump", true);
    }

    public void JumpDown()
    {
        anim.SetBool("IsJump", false);
    }
}
