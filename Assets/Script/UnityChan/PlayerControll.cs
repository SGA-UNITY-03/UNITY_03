using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerControll : BaseControll
{
    public GameObject _hpBar;
    public Dictionary<string, GameObject> _swordTable;

    private GameObject _curSword;


    protected override void Start()
    {
        base.Start();

        InputManager input = Managers.Input;
        input.MouseAction -= OnClick;
        input.MouseAction += OnClick;
        input.KeyAction -= Attack;
        input.KeyAction += Attack;
        input.KeyAction -= Jump;
        input.KeyAction += Jump;

        _swordTable = new Dictionary<string, GameObject>();
        GameObject[] swords = GameObject.FindGameObjectsWithTag("PlayerWeapon");
        
        foreach(GameObject go in swords)
        {
            _swordTable[go.name] = go;
            go.GetComponent<Collider>().enabled = false;
            go.SetActive(false);
        }

        _swordTable["sword_epic"].SetActive(true);
        _curSword = _swordTable["sword_epic"];
    }


    protected override void Update()
    {
        base.Update();

    }

    private bool OnKeyBoard()
    {
        if (State == Define.State.ATTACK)
            return false;

        if (Input.GetKey(KeyCode.W))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            this.GetComponent<Transform>().rotation = q;

            if (Input.GetKey(KeyCode.A))
            {
                Quaternion qA = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
                transform.rotation = qA;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Quaternion qD = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
                transform.rotation = qD;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            return true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.rotation = q;

            if (Input.GetKey(KeyCode.A))
            {
                Quaternion qA = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
                transform.rotation = qA;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Quaternion qD = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
                transform.rotation = qD;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            return true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.rotation = q;

            if (Input.GetKey(KeyCode.W))
            {
                Quaternion qA = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
                transform.rotation = qA;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Quaternion qD = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
                transform.rotation = qD;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * _speed);

            return true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.rotation = q;

            if (Input.GetKey(KeyCode.W))
            {
                Quaternion qA = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
                transform.rotation = qA;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Quaternion qD = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
                transform.rotation = qD;
                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

                return true;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            return true;
        }

        return false;
    }
        
    private void OnClick(Define.MouseEvent evt)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red);

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("Plane");

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            _rayHitPostion = hit.point;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetBool("IsJump", true);
        }
    }

    public void ButtonJump()
    {
        _anim.SetBool("IsJump", true);
    }

    public void JumpDown()
    {
        _anim.SetBool("IsJump", false);
    }

    public void ChangeSword(string name)
    {
        foreach(var pair in _swordTable)
        {
            pair.Value.SetActive(false);
        }

        _swordTable[name].SetActive(true);
        _swordTable[name].GetComponent<Collider>().enabled = false;
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            State = Define.State.ATTACK;
        }
    }

    public void AttackEnd()
    {
        State = Define.State.IDLE;
        _curSword.GetComponent<Collider>().enabled = false;
    }

    public void WeaponColTrigger()
    {
        _curSword.GetComponent<Collider>().enabled = true;
    }

    private void MouseMove()
    {
        //_rayHitPostion.y = transform.position.y;
        Vector3 directionToHit = _rayHitPostion - transform.position;
        Vector3 dir = directionToHit.normalized;

        Vector3 orginPos = transform.position;
        orginPos += _capsuleCol.center;
        Debug.DrawRay(orginPos, dir * 1.2f, Color.red);
        if (Physics.Raycast(orginPos, dir, 1.2f, LayerMask.GetMask("Block")))
        {
            _isMove = false;
            return;
        }

        if (directionToHit.magnitude < 0.1f)
        {
            _isMove = false;
        }
        else
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.Move(dir * _speed * Time.deltaTime);
            //transform.position += dir * _speed * Time.deltaTime;
            _isMove = true;

            transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5.0f * Time.deltaTime);
        }
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();

        if (!OnKeyBoard())
            State = Define.State.IDLE;
    }

    protected override void UpdateIdle()
    {
        base.UpdateIdle();

        if(OnKeyBoard())
            State = Define.State.MOVE;
    }

    protected override void UpdateAttack()
    {
        base.UpdateAttack();
    }
}
