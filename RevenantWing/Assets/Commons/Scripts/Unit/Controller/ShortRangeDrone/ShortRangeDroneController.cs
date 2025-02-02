using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#region �R���g���[���[�{��
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


    #region �X�e�[�g�֘A
    // �X�e�[�g�}�l�[�W���[
    private class StateManager
    {
        // �R���g���[���[����n�����X�e�[�g�؂�ւ����f��
        public IState iState = null;

        // �e��X�e�[�g�C���X�^���X ----------------------------------------------------------------
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

    // �ߋ����h���[�����X�e�[�g------------------------------------------------------------------
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

    // �ҋ@�X�e�[�g--------------------------------------------------------------------------------
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

    // �ړ��X�e�[�g---------------------------------------------------------------------------------
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
