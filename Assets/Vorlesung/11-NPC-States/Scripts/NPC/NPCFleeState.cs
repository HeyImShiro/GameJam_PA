using System;
using UnityEngine;

[Serializable]
public class NPCFleeState : BaseState
{
    public float FleeDistance;
    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnEnterState");
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnUpdateState");
    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnExitState");
    }

}
