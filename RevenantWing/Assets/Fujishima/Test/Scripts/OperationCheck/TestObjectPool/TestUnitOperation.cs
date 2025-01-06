using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnitOperation : MonoBehaviour
{
    [SerializeField] UnitObjectPool pool;
    [SerializeField] UnitID unitID;

    [SerializeField] Transform target;

    [SerializeField] float targteUpdateTime;

    Queue<UnitBase> testUnitQueue = new Queue<UnitBase>();

    float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        pool.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        // ���j�b�g�o����
        if (Input.GetKeyDown(KeyCode.J))
        {
            UnitBase testUnit = pool.TakeUnit(unitID);
            testUnit.SetUp();
            testUnit.SetTarget(target);
            testUnitQueue.Enqueue(testUnit);
        }
        // ���j�b�g������
        if (Input.GetKeyDown(KeyCode.K))
        {
            UnitBase returnUnit = null;
            if (testUnitQueue.TryDequeue(out returnUnit))
            {
                returnUnit.transform.position = Vector3.zero;
                pool.ReturnUnit(returnUnit);
            }
        }

        // ���j�b�g�̈ړ�����X�V�����
        timeCount += Time.deltaTime;

        if (timeCount > targteUpdateTime)
        {
            foreach (UnitBase testUnit in testUnitQueue)
            {
                testUnit.UpdateTarget();
            }

            timeCount = 0; 
        }

        // ���j�b�g�̈ړ�����폜�����
        if(Input.GetKeyDown(KeyCode.L))
        {
            foreach(UnitBase testUnit in testUnitQueue)
            {
                testUnit.RemoveTarget();
            }
        }
    }
}
