using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D player;
    private InputAction moveAction;
    private Vector2 movement;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        movement = movement.normalized;
        player.linearVelocity = movement * speed;
    }
}
