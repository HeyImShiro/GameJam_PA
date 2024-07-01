using UnityEngine;

/// <summary>
/// Implementation of virtual eyes
/// </summary>
public class Eyes : Sense
{
    // Field of view
    public float fov;

    // Which layer are relevant
    public LayerMask detectionLayer;

    // Update is called once per frame
    protected override void Update()
    {
        if(IsInRange() && IsInFieldOfView() && IsNotOccluded()) 
        {
            isDetecting = true;
        }
        else 
        {
            isDetecting = false;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        base.Update();
        SenseGizmos.DrawRangeCircle(headReferenceTransform.position, transform.up, range);

        if (IsInRange()) 
        {
            SenseGizmos.DrawFOV(headReferenceTransform.position, headReferenceTransform.forward, Vector3.up, range, fov);

            if (IsInFieldOfView()) 
            {
                SenseGizmos.DrawRay(headReferenceTransform.position, player.position, IsNotOccluded());
            }
        }
    }
#endif

    // Player inside fov?
    public bool IsInFieldOfView()
    {
        Vector3 direction = directionToPlayer;
        direction.y = 0;

        Vector3 forward = headReferenceTransform.forward;
        forward.y = 0;
        float angleBetween = Vector3.Angle(forward, direction);
        return angleBetween < fov * 0.5f;
    }

    // Player not occluded by anything?
    public bool IsNotOccluded() 
    {
        RaycastHit hit;
        Ray ray = new Ray(headReferenceTransform.position, directionToPlayer);

        if(Physics.Raycast(ray, out hit, range, detectionLayer)) 
        {
            return hit.collider.gameObject.CompareTag("Player");
        }
        else
        {
            return false;
        }
    }

}
