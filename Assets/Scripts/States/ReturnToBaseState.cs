using UnityEngine;

public class ReturnToBaseState : State
{
    private Unit _unit;
    private StateMachineData _data;
    private UnitStateMachine _stateMachine;
    private Base _base;

    public ReturnToBaseState(Unit unit,StateMachineData data, UnitStateMachine stateMachine, Base targetBase)
    {
        _unit = unit;
        _data = data;
        _stateMachine = stateMachine;
        _base = targetBase;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        _unit.NavMeshAgent.SetDestination(_base.transform.position);

        float distance = Vector3.Distance(_unit.transform.position, _base.transform.position);

        if (distance < 5)
        {
            _stateMachine.ChangeState(_unit.PutResourceState);
        }
    }
}
