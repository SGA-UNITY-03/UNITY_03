using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat : MonoBehaviour
{
    [SerializeField]
    protected float _curHp;
    [SerializeField]
    protected float _maxHp;

    // Start is called before the first frame update
    void Start()
    {
        _maxHp = 100;
        _curHp = _maxHp;
    }

    private void OnEnable()
    {
        _curHp = _maxHp;
    }

    public void Damaged(int attack)
    {
        _curHp -= attack;

        if (_curHp < 0)
            _curHp = 0;
    }

    public bool IsDead()
    {
        return _curHp <= 0;
    }

    public float HpRatio()
    {
        return (_curHp / _maxHp);
    }
}
