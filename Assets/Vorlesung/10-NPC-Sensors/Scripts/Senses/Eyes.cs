using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skript wird auch in EditMode ausgeführt, wird gebraucht um die Gizmos zu zeichnen
[ExecuteInEditMode]
public class Eyes : MonoBehaviour
{
    public float Range;
    public float Fov;
    public bool IsDetecting { get; private set; }

    public LayerMask DetectionLayer;

    public Transform HeadReferenceTransform;

    private Transform _player;

    private Vector3 _directionToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        // Vektor zwischen NPC und Spieler berechnen
        _directionToPlayer = _player.position - HeadReferenceTransform.position;

        // Wird der Player detected?
        if(isInRange() && IsInFieldOfView() && IsNotOccluded())
        {
            IsDetecting = true;
        }
        else
        {
            IsDetecting = false;
        }
    }

    // #if UNITY_EDITOR ..... #endif -> Wird nur im Editor ausgeführt
#if UNITY_EDITOR
    // Custom Gizmo zeichnen
    void OnDrawGizmosSelected()
    {
        // Range
        SenseGizmos.DrawRangeCircle(HeadReferenceTransform.position, transform.up, Range);

        // Sichtkegel
        if(isInRange())
        {
            SenseGizmos.DrawFOV(HeadReferenceTransform.position, HeadReferenceTransform.forward, transform.up, Range, Fov);

            // Line of Sight
            if (IsInFieldOfView())
            {
                SenseGizmos.DrawRay(HeadReferenceTransform.position, _player.position, IsNotOccluded());
            }
        }

    }
#endif

    // Länge des Vektors vergleichen mit der Range -> Checkt ob der Spieler in Range ist
    public bool isInRange()
    {
        // Ist das gleiche wie: _directionToPlayer.magnitude < Range; Nur leichter für den PC zu rechnen
        return _directionToPlayer.sqrMagnitude <= Range * Range;
    }

    public bool IsInFieldOfView()
    {
        Vector3 direction = _directionToPlayer;
        direction.y = 0;

        Vector3 forward = HeadReferenceTransform.forward;
        forward.y = 0;

        float angleBetween = Vector3.Angle(forward, direction);
        return angleBetween < Fov * 0.5f;
    }

    // Raycast check, ob eine unblockierte Sichtlinie zum Player besteht 
    public bool IsNotOccluded()
    {
        RaycastHit hit;
        Ray ray = new Ray(HeadReferenceTransform.position, _directionToPlayer);

        if(Physics.Raycast(ray, out hit, Range, DetectionLayer))
        {
            return hit.collider.gameObject.CompareTag("Player");
        }
        else
        {
            return false;
        }
    }

}
