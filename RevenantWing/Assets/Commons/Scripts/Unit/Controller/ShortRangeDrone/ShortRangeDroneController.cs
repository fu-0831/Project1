using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#region コントローラー本体
public class ShortRangeDroneController : UnitBase
{
    ShortRangeDroneParameter parameter = null;

    StateManager stateManager = null;

    public override void SetUp(Vector3 appearancePosition)
    {
        base.SetUp(appearancePosition);
        parameter = unitParameter as ShortRangeDroneParameter;
        agent = GetComponent<NavMeshAgent>();
        stateManager = new StateManager(parameter, this.transform, agent);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        stateManager.iState?.OnUpdate();
        Debug.Log(stateManager.iState);
    }

    #endregion


    #region ステート関連
    // ステートマネージャー
    private class StateManager
    {
        // コントローラーから渡されるステート切り替え反映先
        public IState iState = null;

        // 各種ステートインスタンス ----------------------------------------------------------------
        public IdleState idleState = null;
        public MoveState moveState = null;

        public StateManager(ShortRangeDroneParameter parameter, Transform transform, NavMeshAgent agent)
        {
            idleState = new IdleState(this, parameter, transform);
            moveState = new MoveState(this, parameter, transform, agent);

            ChangeState(idleState);
        }

        public void ChangeState(IState nextState)
        {
            iState?.OnExit();
            iState = nextState;
            iState?.OnEnter();
        }
    }

    // 近距離ドローン基底ステート------------------------------------------------------------------
    private abstract class ShortRangeDroneStateBase : IState
    {
        protected StateManager stateManager = null;
        protected ShortRangeDroneParameter parameter = null;
        protected Transform transform = null;


        public ShortRangeDroneStateBase(StateManager stateManager, ShortRangeDroneParameter parameter, Transform transform)
        {
            this.stateManager = stateManager;
            this.parameter = parameter;
            this.transform = transform;
        }

        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void OnUpdate();
    }

    // 待機ステート--------------------------------------------------------------------------------
    private class IdleState : ShortRangeDroneStateBase
    {
        public IdleState(StateManager stateManager, ShortRangeDroneParameter parameter, Transform transform)
            : base(stateManager, parameter, transform)
        {

        }

        public override void OnEnter()
        {
            stateManager.ChangeState(stateManager.moveState);
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
        }
    }

    // 移動ステート---------------------------------------------------------------------------------
    private class MoveState : ShortRangeDroneStateBase
    {
        NavMeshAgent agent = null;

        public MoveState(StateManager stateManager, ShortRangeDroneParameter parameter, Transform transform, NavMeshAgent agent)
            : base(stateManager, parameter, transform)
        {
            this.agent = agent;
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            if (agent.path.corners.Length > 1)
            {
                transform.position += (agent.path.corners[1] - this.transform.position).normalized * parameter.MovePower * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation((agent.path.corners[1] - this.transform.position).normalized);
            }
        }
    }

    #endregion
}
