using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    // REQUIRED: Unity PAckage: AI Navigation


    // Wohin soll ich laufen?
    public Transform target;

    public LayerMask layerMask;

    private NavMeshAgent agent;
    private Camera rayCamera;
    private Animator animator;
    private int speedParameterHash;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rayCamera = Camera.main;
        animator = GetComponent<Animator>();

        speedParameterHash = Animator.StringToHash("speed");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                // Wenn das Objekt das angeklickt wurde den Ground Layer hat...
                if (raycastHit.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
                {
                    // Target Punkt wird versetzt
                    target.position = raycastHit.point;

                    // Agent folgt dem Target
                    agent.SetDestination(target.position);
                }
            }
        }

        // Blendtree Parameter auf Geschwindigkeit von NavMesh Agent setzen
        animator.SetFloat(speedParameterHash, agent.velocity.magnitude);

    }
}
