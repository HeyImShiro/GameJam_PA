using System;
using UnityEngine;

[Serializable]
public class NPCChaseState : BaseState
{
    public bool isChasing;
    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnEnterState");
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnUpdateState");
    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnExitState");
    }

}

