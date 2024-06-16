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

    private NavMeshAgent _agent;

    private Camera _rayCamera;

    private Animator _animator;

    private int _speedParameterHash;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rayCamera = Camera.main;
        _animator = GetComponent<Animator>();

        _speedParameterHash = Animator.StringToHash("speed");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _rayCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                // Wenn das Objekt das angeklickt wurde den Ground Layer hat...
                if (raycastHit.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
                {
                    // Target Punkt wird versetzt
                    target.position = raycastHit.point;

                    // Agent folgt dem Target
                    _agent.SetDestination(target.position);
                }
            }
        }

        // Blendtree Parameter auf Geschwindigkeit von NavMesh Agent setzen
        _animator.SetFloat(_speedParameterHash, _agent.velocity.magnitude);

    }
}
