using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterControll : BaseControll
{
    public GameObject _monsterInfo;
    Slider _hpSlider;

    MonsterStat _stat;

    private Vector3 _movePos = Vector3.zero;
    private Vector3 _originPos;
    [SerializeField]
    private float _movingDistance;

    protected override void Start()
    {
        base.Start();

        if (_monsterInfo == null)
            _monsterInfo = transform.Find("Monster_Info").gameObject;

        _hpSlider = _monsterInfo.GetComponentInChildren<Slider>();

        if (_hpSlider == null)
            Debug.LogError("못찾음");

        _stat = GetComponent<MonsterStat>();

        _speed = 10.0f;
        _state = Define.State.IDLE;

        StartCoroutine("Co_MonsterAIMove");

        _movingDistance = 5.0f;
    }

    private void OnEnable()
    {
        _movePos = transform.position;
        _originPos = transform.position;
    }

    private void OnDisable()
    {
        StopCoroutine("Co_MonsterAIMode");
    }

    protected override void Update()
    {
        base.Update();
        SetHpBar();

        gameObject.SetActive(!_stat.IsDead());
    }

    void SetHpBar()
    {
        Transform parent = _monsterInfo.transform.parent;
        _monsterInfo.transform.position = 
            parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y);
        _monsterInfo.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWeapon")
        {
            Debug.Log("몬스터 공격당함");
            _stat.Damaged(30);
            _hpSlider.value = _stat.HpRatio();
        }
    }

    IEnumerator Co_MonsterAIMove()
    {
        if (_isMove == false)
            yield return new WaitForSeconds(3.0f);

        State = Define.State.MOVE;
        _isMove = true;
        Debug.Log("AIMove 호출");
        float x;
        float z;

        x = Random.Range(- 1.0f + _originPos.x, 1.0f + _originPos.x);
        z = Random.Range(- 1.0f + _originPos.z, 1.0f + _originPos.z);

        _movePos = new Vector3(x, 0.0f, z);

        yield return new WaitForSeconds(7.0f);
        StartCoroutine("Co_MonsterAIMove");
    }

    void RandMove()
    {
        // TODO: 범위 밖으로 나가지못하게

        // 목표지점 찍고
        // 목표지점은 originPos에서 rand 범위 값으로 준다.

        // 이동방향
        // 이동하다가 originPos에서 일정거리 이상 멀어지면 return
        // -> 다시 돌아갈 조건

        Vector3 temp = _movePos - _originPos;

        transform.Translate(temp.normalized * Time.deltaTime * 5.0f);

        if (temp.magnitude > 1.0f)
            State = Define.State.IDLE;

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position + _movePos),Time.deltaTime);
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();
        RandMove();
    }

    protected override void UpdateIdle()
    {
        base.UpdateIdle();
        _isMove = false;
    }

    protected override void UpdateAttack()
    {
        base.UpdateAttack();

    }
}
