using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateMachine : BaseStateMachine
{
    public Vector3 playerPosition { get => player.position; }
    public bool canSeePlayer { get => eyes.isDetecting; }  
    public bool canHearPlayer { get => ears.isDetecting; }

    // Modifies NPC behaviour when it detects a Player 
    // 1 = Flee
    // 2 = Hide
    // 3 = Chase
    public int personalityIndex;

    public NPCIdleState IdleState;
    public NPCPatrolState PatrolState;
    public NPCFleeState FleeState;
    public NPCChaseState ChaseState;
    public NPCHideState HideState;
    
    private Eyes eyes;
    private Ears ears;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    private float initialAgentSpeed;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        WaypointGizmos.DrawWayPoints(PatrolState.Waypoints);
    }
#endif

    public override void Initialize()
    {
        eyes = GetComponentInChildren<Eyes>();
        ears = GetComponentInChildren<Ears>();

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        initialAgentSpeed = agent.speed;
        animator = GetComponent<Animator>();
        
        CurrentState = IdleState;
        CurrentState.OnEnterState(this);
    }

    // Tick wird jedes Frame aufgerufen um z.B. den Animator zu synchronisieren
    public override void Tick()
    {   
         //_animator.SetFloat("speed", _agent.velocity.magnitude);
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void SetAgentSpeedMultiplier(float multiplier)
    {
        agent.speed = initialAgentSpeed * multiplier;
    }

}
