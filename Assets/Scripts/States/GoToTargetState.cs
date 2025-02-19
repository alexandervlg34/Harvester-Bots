using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTargetState : MovementState
{
    public GoToTargetState(IStateSwitcher stateSwitcher, StateMachineData data, Unit unit) : base(stateSwitcher, data, unit)
    {

    }

    

    public override void Update()
    {
        base.Update();

        StateSwitcher.SwitchState<SelectResourceState>();
    }
}
