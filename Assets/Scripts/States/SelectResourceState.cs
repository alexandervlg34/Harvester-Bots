using UnityEngine;

public class SelectResourceState : State
{
    private Unit _unit;
    private StateMachineData _data;
    private UnitStateMachine _stateMachine;

    public SelectResourceState(Unit unit, StateMachineData data, UnitStateMachine stateMachine)
    {
        _unit = unit;
        _data = data;
        _stateMachine = stateMachine;
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

        TakeResource(_data.Resource);

        _stateMachine.ChangeState(_unit.ReturnToBaseState);
    }

    private void TakeResource(Resource resource)
    {
        resource.transform.SetParent(_unit.CarryPoint);
        resource.transform.localPosition = Vector3.zero;
    }
}
