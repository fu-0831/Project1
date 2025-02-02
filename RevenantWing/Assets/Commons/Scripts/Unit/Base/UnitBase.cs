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

    // ナビメッシュ
    protected NavMeshAgent agent = null;

    // 追跡対象トランスフォーム
    protected Transform targetTransform = null;



    /// <summary>
    /// ユニットのセットアップを行います。
    /// </summary>
    public virtual void SetUp(Vector3 appearancePosition) 
    {
        transform.position = appearancePosition;
    }

    /// <summary>
    ///  移動ターゲット(Transform)を設定します。
    /// </summary>
    /// <param name="transform"></param>
    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
        agent.SetDestination(targetTransform.position);
    }

    /// <summary>
    /// 移動ポジション(Vector3)を設定します。
    /// </summary>
    /// <param name="movePos"></param>
    public void SetTarget(Vector3 movePos)
    {
        agent.SetDestination(movePos);
    }

    /// <summary>
    /// 移動対象を削除します。
    /// </summary>
    public void RemoveTarget()
    {
        agent.ResetPath();
        targetTransform = null;
    }

    /// <summary>
    /// 移動対象が敵やオブジェクトの場合、更新します。
    /// </summary>
    public void UpdateTarget()
    {
        if (targetTransform != null)
            agent.SetDestination(targetTransform.position);
    }
}