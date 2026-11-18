using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 facingDirection = new Vector2(1, 0);
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
        if (movement != Vector2.zero)
        {
            facingDirection = movement;
        }
        player.linearVelocity = movement * speed;
    }
}
