using UnityEngine;
using UnityEngine.UIElements;

public class CollisionsDetector : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] Vector3 size;
    [SerializeField] LayerMask layers;

    public Collider2D DetectCollisions()
    {
        return Physics2D.OverlapBox(pivot.position, size, 0, layers);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(pivot.position, size);
    }

}
