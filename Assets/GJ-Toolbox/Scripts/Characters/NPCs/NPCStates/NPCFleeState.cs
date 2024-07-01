using System;
using UnityEngine;

[Serializable]
public class NPCFleeState : BaseState
{
    public float fleeDistance;
    public float fleeSpeedMultiplier;

    private Vector3 fleePosition;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Calculate the position to which you want to flee
        fleePosition = (npcStateMachine.transform.position - npcStateMachine.playerPosition).normalized * fleeDistance
        + npcStateMachine.transform.position;

        // Move to the calculated position
        npcStateMachine.SetDestination(fleePosition);
        npcStateMachine.SetAgentSpeedMultiplier(fleeSpeedMultiplier);

    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnUpdateState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        // Reached the safe spot? -> Switch to Idle
        if ((nPCStateMachine.transform.position - fleePosition).sqrMagnitude < 3f)
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
