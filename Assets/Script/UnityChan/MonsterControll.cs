using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterControll : BaseControll
{
    public GameObject _monsterInfo;
    Slider _hpSlider;

    MonsterStat _stat;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (_monsterInfo == null)
            _monsterInfo = transform.Find("Monster_Info").gameObject;

        _hpSlider = _monsterInfo.GetComponentInChildren<Slider>();

        if (_hpSlider == null)
            Debug.LogError("못찾음");

        _stat = GetComponent<MonsterStat>();
    }

    // Update is called once per frame
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
}
