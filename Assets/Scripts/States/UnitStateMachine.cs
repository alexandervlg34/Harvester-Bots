using System.Collections.Generic;
using System.Linq;


public class UnitStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public UnitStateMachine(Unit unit)
    {
        StateMachineData data = new StateMachineData();
        _states = new List<IState>()
        {
            new GoToTargetState(this,data, unit),
            new SelectResourceState(this,data, unit),
            new ReturnToBaseState(this,data, unit),
            new PutResourceState(this,data, unit)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
