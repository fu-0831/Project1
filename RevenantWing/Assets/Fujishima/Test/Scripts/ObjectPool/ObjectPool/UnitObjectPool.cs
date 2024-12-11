using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitObjectPool : MonoBehaviour, IUnitPool
{
    [Header("オブジェクト設定"), Tooltip("オブジェクトプールパラメータ"), SerializeField]
    ObjectPoolParameter objectPoolParameter;
    [Tooltip("ユニットリスト"), SerializeField] UnitList unitList;

    Dictionary<UnitID, Queue<UnitBase>> unitPool = new Dictionary<UnitID, Queue<UnitBase>>();

    /// <summary>
    /// オブジェクトプールのセットアップを行います。オブジェクトプールに登録されているリスト内ユニットの初期生成を行います。
    /// </summary>
    public void SetUp()
    {
        foreach (UnitID id in Enum.GetValues(typeof(UnitID)))
        {
            foreach (UnitBase unit in unitList.Units)
            {
                if (id != unit.UnitID) continue;

                unitPool.Add(id, new Queue<UnitBase>());

                for (int i = 0; i < objectPoolParameter.InitialCreateCount; i++)
                {
                    UnitBase createUnit = Instantiate(unit);
                    unitPool[id].Enqueue(createUnit);
                    createUnit.gameObject.SetActive(false);
                    createUnit.transform.parent = this.transform;
                }

            }
        }
    }

    /// <summary>
    /// 引数に指定されたIDを持つユニットを貸し出します。オブジェクトプール内に待機中のユニットがない場合新たに生成します。
    /// </summary>
    /// <param name="unitID"></param>
    /// <returns></returns>
    public UnitBase TakeUnit(UnitID unitID)
    {
        UnitBase lendUnit = null;
        if (unitPool[unitID].TryDequeue(out lendUnit))
        {
            lendUnit.gameObject.SetActive(true);
            return lendUnit;
        }

        else
        {
            foreach (UnitBase unit in unitList.Units)
            {
                if (unitID != unit.UnitID) continue;

                UnitBase createUnit = Instantiate(unit);
                createUnit.transform.parent = this.transform;
                return createUnit;
            }

            return default;
        }
    }

    /// <summary>
    /// 引数に指定したユニットをオブジェクトプールに返却します。
    /// </summary>
    /// <param name="returnDrone"></param>
    public void ReturnUnit(UnitBase returnUnit)
    {
        returnUnit.gameObject.SetActive(false);
        unitPool[returnUnit.UnitID].Enqueue(returnUnit);
    }

}
