using System;
using UnityEngine;

[Serializable]
public class NPCFleeState : BaseState
{
    public float FleeDistance;
    public float fleeSpeedMultiplier;

    private Vector3 _fleePosition;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Calculate the position to which you want to flee
        _fleePosition = (npcStateMachine.transform.position - npcStateMachine.PlayerPosition).normalized * FleeDistance
        + npcStateMachine.transform.position;

        // Move to the calculated position
        npcStateMachine.SetDestination(_fleePosition);
        npcStateMachine.SetAgentSpeedMultiplier(fleeSpeedMultiplier);

    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnUpdateState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        // Reached the safe spot? -> Switch to Idle
        if ((nPCStateMachine.transform.position - _fleePosition).sqrMagnitude < 3f)
        {
            nPCStateMachine.SwitchToState(nPCStateMachine.IdleState);
        }

    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnExitState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        nPCStateMachine.SetAgentSpeedMultiplier(1f);
    }

}
