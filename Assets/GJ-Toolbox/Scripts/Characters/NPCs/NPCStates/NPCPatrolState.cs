using System;
using UnityEngine;

[Serializable]
public class NPCPatrolState : BaseState
{
    public Transform[] Waypoints;

    private int currentWaypointIndex;
    private Vector3 targetPosition;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnEnterState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        if(targetPosition == Vector3.zero)
        {
            targetPosition = Waypoints[0].position;
        }

        npcStateMachine.SetDestination(targetPosition);
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnUpdateState");
        NPCStateMachine npcStateMachine = controller as NPCStateMachine;

        // Transitions
        // NPC reached waypoint? -> Switch to Idle
        float sqrtDistance = (npcStateMachine.transform.position - targetPosition).sqrMagnitude;
        if(sqrtDistance < 0.1f)
        {
            targetPosition = GetNextWaypoint();
            npcStateMachine.SwitchToState(npcStateMachine.IdleState);
        }

        // Transitions
        // Can see player -> Switch state
        if (npcStateMachine.canSeePlayer || npcStateMachine.canHearPlayer)
        {
            if (npcStateMachine.personalityIndex == 1)
            {
                npcStateMachine.SwitchToState(npcStateMachine.FleeState);
            }
            else if (npcStateMachine.personalityIndex == 2)
            {
                npcStateMachine.SwitchToState(npcStateMachine.HideState);
            }
            else if (npcStateMachine.personalityIndex == 3)
            {
                npcStateMachine.SwitchToState(npcStateMachine.ChaseState);
            }

        }


    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCPatrolState:OnExitState");
    }

    public Vector3 GetNextWaypoint()
    {
        currentWaypointIndex = ++currentWaypointIndex % Waypoints.Length;
        return Waypoints[currentWaypointIndex].position;
    }
}
