using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CollisionsDetector groundDetector;
    [SerializeField] Rigidbody2D body2D;
    [SerializeField] float Speed;
    [SerializeField] float jumpForce;
    [SerializeField] float currentJumps;
    [SerializeField] float maxJumps;
    [SerializeField] bool isGrounded;
    [SerializeField] bool lastGroundedState;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public float CurrentJumps { get => currentJumps; set => currentJumps = value; }

    public void Move(Vector2 direction)
    {
        body2D.linearVelocityX = direction.x * Speed;
    }
    public void Jump()
    {
        if (IsGrounded || CurrentJumps < maxJumps)
        {
            body2D.linearVelocityY = 0;
            body2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (CurrentJumps > 0)
        {
            CurrentJumps++;

        }

    }

    private void Update()
    {
        IsGrounded = groundDetector.DetectCollisions();
        if (IsGrounded == true && lastGroundedState == false)
        {
            CurrentJumps = 0;
            Debug.Log("El Jugador Aterrizo");
        }
        else if (IsGrounded == false && lastGroundedState == true)
        {
            CurrentJumps++;
            Debug.Log("El Jugador Dejo de Tocar el Piso");
        }
        lastGroundedState = IsGrounded;
    }
}
