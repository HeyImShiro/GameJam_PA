using System;
using UnityEngine;

[Serializable]
public class NPCFleeState : BaseState
{
    public float FleeDistance;
    private Vector3 _fleePosition;
    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCFleeState:OnEnterState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        // Calculate the position to which you want to flee
       // _fleePosition = (nPCStateMachine.transform.position - nPCStateMachine.PlayerPosition).normalized + FleeDistance +     // HIER FEHLT NOCH WAS
       // + nPCStateMachine.transform.position;

        // Move to the calculated position
        nPCStateMachine.SetDestination(_fleePosition);
        nPCStateMachine.SetAgentSpeedMultiplier(2.5f);


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
