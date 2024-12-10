using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitObjectPool : MonoBehaviour,IUnitPool
{
    [Header("オブジェクト設定"), Tooltip("オブジェクトプールパラメータ"), SerializeField]
    ObjectPoolParameter objectPoolParameter;
    [Tooltip("ユニットリスト"), SerializeField] UnitList unitList;

    Dictionary<UnitID, Queue<UnitBase>> dronePool = new Dictionary<UnitID, Queue<UnitBase>>();

    public void SetUp()
    {
        foreach (UnitID id in Enum.GetValues(typeof(UnitID)))
        {
            foreach (UnitBase unit in unitList.Units)
            {
                if (id != unit.UnitID) return;

                dronePool.Add(id, new Queue<UnitBase>());

                for (int i = 0; i < objectPoolParameter.InitialCreateCount; i++)
                {
                    UnitBase createUnit = Instantiate(unit);
                    dronePool[id].Enqueue(createUnit);
                }
            }
        }
    }

    public UnitBase TakeUnit()
    {
        return default;
    }

    public void ReturnUnit(UnitBase returnDrone)
    {
    }

}
