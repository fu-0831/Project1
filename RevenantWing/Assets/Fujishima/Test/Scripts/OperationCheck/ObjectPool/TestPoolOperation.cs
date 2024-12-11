using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolOperation : MonoBehaviour
{
    [SerializeField] UnitObjectPool pool;

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
            testUnitQueue.Enqueue(pool.TakeUnit(UnitID.ShieldDrone));

        if (Input.GetKeyDown(KeyCode.K))
        {
            UnitBase returnUnit = null;
            if (testUnitQueue.TryDequeue(out returnUnit))
            {
                returnUnit.transform.position = Vector3.zero;
                pool.ReturnUnit(returnUnit);
            }
        }
    }
}
