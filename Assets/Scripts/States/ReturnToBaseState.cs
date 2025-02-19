using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToBaseState : MovementState
{
    public ReturnToBaseState(IStateSwitcher stateSwitcher, StateMachineData data, Unit unit) : base(stateSwitcher, data, unit)
    {

    }
}
