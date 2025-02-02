using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitObjectPool :  IUnitPool
{
    [Header("オブジェクト設定"), Tooltip("オブジェクトプールパラメータ"), SerializeField]
    ObjectPoolParameter parameter;
    [Tooltip("ユニットリスト"), SerializeField] UnitList unitList;

    Dictionary<UnitID, Queue<UnitBase>> unitPool = new Dictionary<UnitID, Queue<UnitBase>>();

    // シーン上に配置するオブジェクトの親オブジェクト
    GameObject parentObject = new GameObject("ObjectPool");

    public UnitObjectPool() { }
    public UnitObjectPool(ObjectPoolParameter parameter,UnitList unitList)
    {
        this.parameter = parameter;
        this.unitList = unitList;
    }

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

                for (int i = 0; i < parameter.InitialCreateCount; i++)
                {
                    UnitBase createUnit = UnityEngine.Object.Instantiate(unit);
                    unitPool[id].Enqueue(createUnit);
                    createUnit.gameObject.SetActive(false);
                    createUnit.transform.parent = parentObject.transform;
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
        if (unitPool[unitID].TryDequeue(out UnitBase lendUnit))
        {
            lendUnit.gameObject.SetActive(true);
            return lendUnit;
        }

        else
        {
            foreach (UnitBase unit in unitList.Units)
            {
                if (unitID != unit.UnitID) continue;

                UnitBase createUnit = UnityEngine.Object.Instantiate(unit);
                createUnit.transform.parent = parentObject.transform;
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
