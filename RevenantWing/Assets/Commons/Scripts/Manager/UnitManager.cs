using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("オブジェクト設定"), Tooltip("オブジェクトプール用パラメータ"),
     SerializeField]
    ObjectPoolParameter parameter;
    [Tooltip("オブジェクトプール用生成ユニットリスト"), SerializeField]
    UnitList unitList;


    UnitObjectPool unitPool = null;
    UnitLender unitLender = null;


    // テスト用
    [SerializeField] SquadParameter squadParameter;
    [SerializeField] TestUnitOperation testOperation;
    [SerializeField] Transform relayPoint;
    private void Awake()
    {
        unitPool = new UnitObjectPool(parameter, unitList);
        unitPool.SetUp();
        unitLender = new UnitLender(unitPool);

        // テスト用
    }

    public UnitSquadManager SpawnUnit(UnitID unitID)
    {
        return new UnitSquadManager(squadParameter, unitLender, relayPoint.position);
    }

}
