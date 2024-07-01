using System;
using UnityEngine;

[Serializable]
public class NPCChaseState : BaseState
{
    public float maxChaseDistance;
    public float chaseSpeedMultiplier;

    private float distanceToPlayer;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        npcStateMachine.SetAgentSpeedMultiplier(chaseSpeedMultiplier);
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        npcStateMachine.SetDestination(npcStateMachine.PlayerPosition);

        distanceToPlayer = (npcStateMachine.PlayerPosition - npcStateMachine.transform.position).sqrMagnitude;
        
        // Transition
        // If player is too far away -> Switch to Idle
        if(distanceToPlayer > maxChaseDistance)
        {
            npcStateMachine.SwitchToState(npcStateMachine.IdleState);
        }

    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCChaseState:OnExitState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        npcStateMachine.SetAgentSpeedMultiplier(1f);
    }

}

