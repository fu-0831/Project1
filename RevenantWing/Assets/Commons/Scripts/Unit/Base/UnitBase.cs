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

    // �i�r���b�V��
    protected NavMeshAgent agent = null;

    // �ǐՑΏۃg�����X�t�H�[��
    protected Transform targetTransform = null;



    /// <summary>
    /// ���j�b�g�̃Z�b�g�A�b�v���s���܂��B
    /// </summary>
    public virtual void SetUp(Vector3 appearancePosition) 
    {
        transform.position = appearancePosition;
    }

    /// <summary>
    ///  �ړ��^�[�Q�b�g(Transform)��ݒ肵�܂��B
    /// </summary>
    /// <param name="transform"></param>
    public void SetTarget(Transform transform)
    {
        targetTransform = transform;
        agent.SetDestination(targetTransform.position);
    }

    /// <summary>
    /// �ړ��|�W�V����(Vector3)��ݒ肵�܂��B
    /// </summary>
    /// <param name="movePos"></param>
    public void SetTarget(Vector3 movePos)
    {
        agent.SetDestination(movePos);
    }

    /// <summary>
    /// �ړ��Ώۂ��폜���܂��B
    /// </summary>
    public void RemoveTarget()
    {
        agent.ResetPath();
        targetTransform = null;
    }

    /// <summary>
    /// �ړ��Ώۂ��G��I�u�W�F�N�g�̏ꍇ�A�X�V���܂��B
    /// </summary>
    public void UpdateTarget()
    {
        if (targetTransform != null)
            agent.SetDestination(targetTransform.position);
    }
}