using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnitOperation : MonoBehaviour
{
    [SerializeField] UnitID unitID;

    [SerializeField] Transform target;

    [SerializeField] float targteUpdateTime;

    [SerializeField] int unitCreateCount;

    [SerializeField] UnitManager unitManager;


    Queue<UnitBase> testUnitQueue = new Queue<UnitBase>();

    float timeCount = 0;

    public Queue<UnitSquadManager> unitSquadManagers = new Queue<UnitSquadManager>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ユニット出すよ
        if (Input.GetKeyDown(KeyCode.J))
        {
            unitSquadManagers.Enqueue(unitManager.SpawnUnit(unitID));
        }
        // ユニット消すよ
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (unitSquadManagers.TryDequeue(out UnitSquadManager removeSquad))
            {
                removeSquad.RemoveSquad();
            }
        }

        // ユニットの移動先を更新するよ
        timeCount += Time.deltaTime;

        if (timeCount > targteUpdateTime)
        {
            foreach (UnitBase testUnit in testUnitQueue)
            {
                testUnit.UpdateTarget();
            }
            timeCount = 0; 
        }

        // ユニットの移動先を設定するよ
        if(Input.GetKeyDown(KeyCode.H))
        {
            foreach(UnitSquadManager squad in unitSquadManagers)
            {
                squad.SetSquadTarget(target);
            }
        }

        // ユニットの移動先を削除するよ
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (UnitSquadManager squad in unitSquadManagers)
            {
                squad.RemoveSquadTarget();
            }
        }
    }
}
