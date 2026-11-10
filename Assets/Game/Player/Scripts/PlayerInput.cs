using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]


public class PlayerInput : MonoBehaviour
{
    InputSystem_Actions inputs;

    InputAction _Jump;
    InputAction _Move;

    public InputAction Jump { get => _Jump; set => _Jump = value; }

    public Vector2 Direction { get => Move.ReadValue<Vector2>(); }
    public InputAction Move { get => _Move; set => _Move = value; }

    private void Awake()
    {
        inputs = new();
        Jump = inputs.Player.Jump;
        Move = inputs.Player.Move;
        inputs.Enable();
    }
}
