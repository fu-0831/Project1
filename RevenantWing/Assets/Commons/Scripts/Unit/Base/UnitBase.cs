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

    /// <summary>
    /// ユニットのセットアップを行います
    /// </summary>
    public virtual void SetUp() { }

    /// <summary>
    ///  移動ターゲット(Transform)を設定します
    /// </summary>
    /// <param name="transform"></param>
    public virtual void SetTarget(Transform transform) { }

    /// <summary>
    /// 移動ポジション(Vector3)を設定します
    /// </summary>
    /// <param name="movePos"></param>
    public virtual void SetTarget(Vector3 movePos) 
    {
        agent.SetDestination(movePos);
    }

    public virtual void RemoveTarget() { }

    public virtual void UpdateTarget() { }
}