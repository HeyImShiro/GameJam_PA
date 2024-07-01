using System;
using UnityEngine;

[Serializable]
public class NPCIdleState : BaseState
{
    public float MinWaitTime;
    public float MaxWaitTime;

    private float leaveTime;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnEnterState");

        leaveTime = Time.time + UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Transitions
        // Can see or hear player -> Switch state
        if(npcStateMachine.CanSeePlayer || npcStateMachine.CanHearPlayer)
        {
            if(npcStateMachine.personalityIndex == 1)
            {
                npcStateMachine.SwitchToState(npcStateMachine.FleeState);
            }
            else if(npcStateMachine.personalityIndex == 2)
            {
                npcStateMachine.SwitchToState(npcStateMachine.HideState);
            }
            else if(npcStateMachine.personalityIndex == 3)
            {
                npcStateMachine.SwitchToState(npcStateMachine.ChaseState);
            }
            
        }
        // Time is up -> Switch to patrol
        if (Time.time > leaveTime)
        {
            npcStateMachine.SwitchToState(npcStateMachine.PatrolState);
        }

    }
     public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCIdleState:OnExitState");
    }
}

