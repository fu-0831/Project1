using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShortRangeDroneController : UnitBase
{
    ShortRangeDroneParameter parameter = null;

    StateManager stateManager = null;

    public override void SetUp()
    {
        base.SetUp();
        parameter = unitParameter as ShortRangeDroneParameter;
        agent = GetComponent<NavMeshAgent>();
        stateManager = new StateManager(iState, agent);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.destination != Vector3.zero)
        {
            transform.position += (agent.path.corners[1] - this.transform.position).normalized * parameter.MovePower * Time.deltaTime;
        }
    }

    private class StateManager
    {
        // コントローラーから渡されるステート切り替え反映先
        IState iState = null;

        // 各種ステート----------------------------------------------------------------
        IdleState idleState = null;
        MoveState moveState = null;

        public StateManager(IState iState, NavMeshAgent agent)
        {
            this.iState = iState;

            idleState = new IdleState();
            moveState = new MoveState(agent);

            iState = moveState;
        }

        public void ChangeState(IState nextState)
        {
            iState?.OnExit();
            iState = nextState;
            iState?.OnEnter();
        }
    }

    private class IdleState : IState
    {
        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
        }
    }

    private class MoveState : IState
    {
        NavMeshAgent agent = null;

        public MoveState(NavMeshAgent agent)
        {
            this.agent = agent;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
        }
    }
}
