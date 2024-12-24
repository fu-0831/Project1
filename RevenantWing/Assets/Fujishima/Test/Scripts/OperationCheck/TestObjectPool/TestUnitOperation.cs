using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnitOperation : MonoBehaviour
{
    [SerializeField] UnitObjectPool pool;
    [SerializeField] UnitID unitID;

    [SerializeField] Transform target;

    Queue<UnitBase> testUnitQueue = new Queue<UnitBase>();

    // Start is called before the first frame update
    void Start()
    {
        pool.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UnitBase testUnit = pool.TakeUnit(unitID);
            testUnit.SetUp();
            testUnit.SetTarget(target);
            testUnitQueue.Enqueue(testUnit);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            UnitBase returnUnit = null;
            if (testUnitQueue.TryDequeue(out returnUnit))
            {
                returnUnit.transform.position = Vector3.zero;
                pool.ReturnUnit(returnUnit);
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            foreach (UnitBase testUnit in testUnitQueue)
            {
                testUnit.SetTarget(target);
            }
        }
    }
}
