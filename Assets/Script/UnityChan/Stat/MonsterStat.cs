using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    // Start is called before the first frame update
    void Start()
    {
        _maxHp = 100;
        _curHp = _maxHp;
    }
}
