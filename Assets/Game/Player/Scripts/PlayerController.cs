using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput inputs;
    [SerializeField] PlayerMovement movement;


    private void OnEnable()
    {
        inputs.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        inputs.Jump.performed -= OnJump;
    }

    public void OnMove(CallbackContext context)
    {
        movement.Move(inputs.Move.ReadValue<Vector2>());
    }

    public void OnJump(CallbackContext context)
    {
        movement.Jump();
       
    }
    private void Update()
    {
        movement.Move(inputs.Direction);
        Flip();
    }

    public void Flip()
    {
        if (transform.eulerAngles.y == 0 && inputs.Direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (transform.eulerAngles.y == 180 && inputs.Direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }


}
