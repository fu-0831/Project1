using System.Collections.Generic;
using UnityEngine;

public class UnitLender
{
    UnitObjectPool pool = null;

    public UnitLender(UnitObjectPool pool)
    {
        this.pool = pool;
    }

    /// <summary>
    /// 引数のIDを元にユニットをオブジェクトプールから借ります。
    /// </summary>
    /// <param name="id">ユニットのID</param>
    /// <param name="unitCount">生成するユニット数</param>
    /// <returns></returns>
    public List<UnitBase> LendUnits(UnitID id, int unitCount)
    {
        List<UnitBase> returnUnitList = new List<UnitBase>();
        for (int i = 0; i < unitCount; i++)
        {
            UnitBase takeUnit = pool.TakeUnit(id);
            takeUnit.gameObject.SetActive(true);
            returnUnitList.Add(takeUnit);
        }

        return returnUnitList;
    }

    /// <summary>
    /// 引数のユニットをオブジェクトプールに返却します
    /// </summary>
    /// <param name="returnUnit"></param>
    public void ReturnUnit(UnitBase returnUnit)
    {
        pool.ReturnUnit(returnUnit);
    }
}
