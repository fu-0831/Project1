using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitBase : MonoBehaviour
{
    //　ユニットID
    [Tooltip("ユニットID"), SerializeField] protected UnitID unitID;

    public UnitID UnitID { get => unitID; }

    // ユニットパラメータ
    [Tooltip("ユニットパラメータ"), SerializeField] protected UnitBaseParameter unitParameter;

    // ユニットリスト
    private List<UnitBase> unitList = new List<UnitBase>();

    public List<UnitBase> UnitList
    {
        get => unitList;
        set => unitList = value;
    }

    // ステート用変数
    protected IState iState = null;

    // ナビメッシュ
    protected NavMeshAgent agent = null;

    // 追跡対象トランスフォーム
    protected Transform targetTransform = null;

    public virtual void SetUp() { }

    public virtual void SetTarget(Transform transform) { }
}
