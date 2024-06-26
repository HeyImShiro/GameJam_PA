using System;
using UnityEngine;

[Serializable]
public class NPCHideState : BaseState
{
    
    public Transform[] HidingSpots;

    private Vector3 targetPosition;

    public override void OnEnterState(BaseStateMachine controller)
    {
        Debug.Log("NPCHideState:OnEnterState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        /*
        targetPosition = GetNearestHidingSpot(nPCStateMachine.transform.position);
        nPCStateMachine = SetDestination(targetPosition);
        nPCStateMachine = SetAgentSpeedMultiplier(2.5f);
        */
    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        Debug.Log("NPCHideState:OnUpdateState");
    }
    public override void OnExitState(BaseStateMachine controller)
    {
        Debug.Log("NPCHideState:OnExitState");
        NPCStateMachine nPCStateMachine = controller as NPCStateMachine;

        nPCStateMachine.SetAgentSpeedMultiplier(1f);
    }

    public Vector3 GetNearestHidingSpot(Vector3 position)
    {
        if (HidingSpots.Length < 2)
            return Vector3.zero;

        int shortestSqrtDistanceIndex = 0;
        float shortestSqrtDistance = (HidingSpots[0].position - position).sqrMagnitude;
        for (int i = 1; i < HidingSpots.Length; i++)
        {
            float sqrtDistance = (HidingSpots[i].position - position).sqrMagnitude;
            if (sqrtDistance < shortestSqrtDistance)
            {
                shortestSqrtDistance = sqrtDistance;
                shortestSqrtDistanceIndex = i;
            }
        }

        return HidingSpots[shortestSqrtDistanceIndex].position;

    }


}
