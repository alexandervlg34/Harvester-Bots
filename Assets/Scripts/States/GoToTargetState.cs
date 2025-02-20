using UnityEngine;

public class GoToTargetState : State
{
    private Unit _unit;
    private StateMachineData _data;
    private UnitStateMachine _stateMachine;
    private ResourceScanner _scanner;

    public GoToTargetState(Unit unit, StateMachineData data, UnitStateMachine stateMachine, ResourceScanner scanner)
    {
        _unit = unit;
        _data = data;
        _stateMachine = stateMachine;
        _scanner = scanner;
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

        _data.Resource = _scanner.TargetResource;

        if (_data.Resource)
        {
            _unit.NavMeshAgent.SetDestination(_data.Resource.transform.position);

            float distance = Vector3.Distance(_unit.transform.position, _data.Resource.transform.position);

            if (distance < _unit.DistanceToSelect)
            {
                _stateMachine.ChangeState(_unit.SelectResourceState);
            }
        }
    }
}
