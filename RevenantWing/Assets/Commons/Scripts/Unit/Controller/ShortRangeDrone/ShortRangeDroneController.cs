using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShortRangeDroneController : UnitBase
{
    ShortRangeDroneParameter parameter = null;

    public override void SetUp()
    {
        base.SetUp();
        parameter = unitParameter as ShortRangeDroneParameter;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.destination != null)
        {
            transform.position += (agent.path.corners[1] - this.transform.position).normalized * parameter.MovePower * Time.deltaTime;
            Debug.Log(agent.path.corners[1]);
        }
    }

    public override void SetTarget(Transform transform)
    {
        base.SetTarget(transform);
        agent.SetDestination(transform.position);
    }
}
