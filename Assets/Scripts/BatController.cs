using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] float radius;
    [SerializeField] LayerMask layers;

    public Collider2D Target { get => _target; }
    [SerializeField] Collider2D _target;

    [SerializeField] float targetDistance;

    [SerializeField] float attackDistance;

    public float FlySpeed { get => _flySpeed; }
    [SerializeField] float _flySpeed;

    [SerializeField] Animator animator;

    [SerializeField] Vector2 lastPosition;

    private void Update()
    {
        if (lastPosition.x < transform.position.x && transform.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(0, 0);
        }
        else if (lastPosition.x > transform.position.x && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180);
        }

        lastPosition = transform.position;

        if (_target != null)
        {
            targetDistance = Vector2.Distance(transform.position, _target.transform.position);
        }

        animator.SetBool("CanAttack", targetDistance <= attackDistance && _target != null ? true : false);
        animator.SetBool("Target", _target);
    }
    void FixedUpdate()
    {
        _target = Physics2D.OverlapCircle(pivot.position, radius, layers);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pivot.position, radius);
    }
}
