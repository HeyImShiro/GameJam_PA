using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    // Time to wait before change the state
    public float minWaitTime;
    public float maxWaitTime;
    public int numberOfBoredStates;

    private float nextStateChangeTime;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextStateChangeTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Time.time > nextStateChangeTime) 
        {
            int randomIndex = Random.Range(1, numberOfBoredStates + 1);
            animator.SetInteger("boredIndex", randomIndex);

            nextStateChangeTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
        }
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("boredIndex", 0);
    }

}
