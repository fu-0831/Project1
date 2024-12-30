using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitBase : MonoBehaviour
{
    //�@���j�b�gID
    [Tooltip("���j�b�gID"), SerializeField] protected UnitID unitID;

    public UnitID UnitID { get => unitID; }

    // ���j�b�g�p�����[�^
    [Tooltip("���j�b�g�p�����[�^"), SerializeField] protected UnitBaseParameter unitParameter;

    // ���j�b�g���X�g
    private List<UnitBase> unitList = new List<UnitBase>();

    public List<UnitBase> UnitList
    {
        get => unitList;
        set => unitList = value;
    }

    // �X�e�[�g�p�ϐ�
    protected IState iState = null;

    // �i�r���b�V��
    protected NavMeshAgent agent = null;

    // �ǐՑΏۃg�����X�t�H�[��
    protected Transform targetTransform = null;

    /// <summary>
    /// ���j�b�g�̃Z�b�g�A�b�v���s���܂�
    /// </summary>
    public virtual void SetUp() { }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="transform"></param>
    public virtual void SetTarget(Transform transform) { }

    public virtual void SetTarget(Vector3 movePos) { }

    public virtual void RemoveTarget() { }
}