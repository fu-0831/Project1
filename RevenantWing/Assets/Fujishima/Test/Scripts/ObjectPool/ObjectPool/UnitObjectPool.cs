using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitObjectPool :  IUnitPool
{
    [Header("�I�u�W�F�N�g�ݒ�"), Tooltip("�I�u�W�F�N�g�v�[���p�����[�^"), SerializeField]
    ObjectPoolParameter parameter;
    [Tooltip("���j�b�g���X�g"), SerializeField] UnitList unitList;

    Dictionary<UnitID, Queue<UnitBase>> unitPool = new Dictionary<UnitID, Queue<UnitBase>>();

    // �V�[����ɔz�u����I�u�W�F�N�g�̐e�I�u�W�F�N�g
    GameObject parentObject = new GameObject("ObjectPool");

    public UnitObjectPool() { }
    public UnitObjectPool(ObjectPoolParameter parameter,UnitList unitList)
    {
        this.parameter = parameter;
        this.unitList = unitList;
    }

    /// <summary>
    /// �I�u�W�F�N�g�v�[���̃Z�b�g�A�b�v���s���܂��B�I�u�W�F�N�g�v�[���ɓo�^����Ă��郊�X�g�����j�b�g�̏����������s���܂��B
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
    /// �����Ɏw�肳�ꂽID�������j�b�g��݂��o���܂��B�I�u�W�F�N�g�v�[�����ɑҋ@���̃��j�b�g���Ȃ��ꍇ�V���ɐ������܂��B
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
    /// �����Ɏw�肵�����j�b�g���I�u�W�F�N�g�v�[���ɕԋp���܂��B
    /// </summary>
    /// <param name="returnDrone"></param>
    public void ReturnUnit(UnitBase returnUnit)
    {
        returnUnit.gameObject.SetActive(false);
        unitPool[returnUnit.UnitID].Enqueue(returnUnit);
    }

}
