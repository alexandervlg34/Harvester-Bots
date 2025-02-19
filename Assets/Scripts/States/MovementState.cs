using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    private readonly Unit _unit;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Unit unit)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _unit = unit;
    }
    public void Enter()
    {
        Debug.Log(GetType());
    }

    public void Exit()
    {
        
    }

    public virtual void Update()
    {
        _unit.NavMeshAgent.SetDestination(Data.Target.transform.position);
    }
}
