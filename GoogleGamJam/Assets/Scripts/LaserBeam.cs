using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Transform laserOrigin; // Lazerin baþladýðý nokta
    public float maxDistance = 20f;
    public LineRenderer lineRenderer;
    public LayerMask laserCollisionMask; // Sadece bu layer'larla çarpsýn

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, transform.right, maxDistance, laserCollisionMask);

        Vector3 endPosition;

        if (hit.collider != null)
        {
            endPosition = hit.point;

            // Karaktere deðdi mi?
            if (hit.collider.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject); // veya baþka bir "ölüm" metodu
            }
        }
        else
        {
            endPosition = laserOrigin.position + transform.right * maxDistance;
        }

        // Lazer çizimi
        lineRenderer.SetPosition(0, laserOrigin.position);
        lineRenderer.SetPosition(1, endPosition);
    }
}
