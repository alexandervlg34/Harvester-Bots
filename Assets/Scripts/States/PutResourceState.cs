
public class PutResourceState : State
{
    private Unit _unit;
    private StateMachineData _data;
    private UnitStateMachine _stateMachine;
    private ResourcesGenerator _resourcesGenerator;

    public PutResourceState(Unit unit, StateMachineData data, UnitStateMachine stateMachine, ResourcesGenerator resourcesGenerator)
    {
        _unit = unit;
        _data = data;
        _stateMachine = stateMachine;
        _resourcesGenerator = resourcesGenerator; 
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

        DropResource(_data.Resource);

        _resourcesGenerator.Destroy(_data.Resource);

        _stateMachine.ChangeState(_unit.GoToTargetState);
    }

    private void DropResource(Resource resource)
    {
        resource.transform.SetParent(null);
    }
}
