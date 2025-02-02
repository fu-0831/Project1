using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("�I�u�W�F�N�g�ݒ�"), Tooltip("�I�u�W�F�N�g�v�[���p�p�����[�^"),
     SerializeField]
    ObjectPoolParameter parameter;
    [Tooltip("�I�u�W�F�N�g�v�[���p�������j�b�g���X�g"), SerializeField]
    UnitList unitList;


    UnitObjectPool unitPool = null;
    UnitLender unitLender = null;


    // �e�X�g�p
    [SerializeField] SquadParameter squadParameter;
    [SerializeField] TestUnitOperation testOperation;
    [SerializeField] Transform relayPoint;
    private void Awake()
    {
        unitPool = new UnitObjectPool(parameter, unitList);
        unitPool.SetUp();
        unitLender = new UnitLender(unitPool);

        // �e�X�g�p
    }

    public UnitSquadManager SpawnUnit(UnitID unitID)
    {
        return new UnitSquadManager(squadParameter, unitLender, relayPoint.position);
    }

}
