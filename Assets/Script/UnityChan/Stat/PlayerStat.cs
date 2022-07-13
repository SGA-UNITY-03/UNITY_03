using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : BaseStat
{
    // Start is called before the first frame update
    void Start()
    {
        _maxHp = 300;
        _curHp = _maxHp;
    }

}
