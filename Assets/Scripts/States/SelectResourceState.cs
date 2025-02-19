using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectResourceState : MovementState
{
    public SelectResourceState(IStateSwitcher stateSwitcher, StateMachineData data, Unit unit) : base(stateSwitcher, data, unit)
    {
    }
}
