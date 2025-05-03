using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Transform laserOrigin; // Lazerin ba�lad��� nokta
    public float maxDistance = 20f;
    public LineRenderer lineRenderer;
    public LayerMask laserCollisionMask; // Sadece bu layer'larla �arps�n

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, transform.right, maxDistance, laserCollisionMask);

        Vector3 endPosition;

        if (hit.collider != null)
        {
            endPosition = hit.point;

            // Karaktere de�di mi?
            if (hit.collider.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject); // veya ba�ka bir "�l�m" metodu
            }
        }
        else
        {
            endPosition = laserOrigin.position + transform.right * maxDistance;
        }

        // Lazer �izimi
        lineRenderer.SetPosition(0, laserOrigin.position);
        lineRenderer.SetPosition(1, endPosition);
    }
}
