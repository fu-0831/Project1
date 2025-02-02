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
    /// ������ID�����Ƀ��j�b�g���I�u�W�F�N�g�v�[������؂�܂��B
    /// </summary>
    /// <param name="id">���j�b�g��ID</param>
    /// <param name="unitCount">�������郆�j�b�g��</param>
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
    /// �����̃��j�b�g���I�u�W�F�N�g�v�[���ɕԋp���܂�
    /// </summary>
    /// <param name="returnUnit"></param>
    public void ReturnUnit(UnitBase returnUnit)
    {
        pool.ReturnUnit(returnUnit);
    }
}
