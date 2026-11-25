using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 facingDirection = new Vector2(1, 0);
    public float speed = 10;
    private Rigidbody2D player;
    private InputAction moveAction;
    private Vector2 movement;
    private Animator PlayerAnimator;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        player = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
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
        UpdatePlayerAnimation();
    }

    private void UpdatePlayerAnimation()
    {
        int state = 0;
        if(movement.y > 0)
        {
            state = 2;
        }
        else if (movement.y < 0)
        {
            state = 1;
        }
        else if (movement.x > 0)
        {
            state = 3;
        }
        else if (movement.x < 0)
        {
            state = 4;
        }
        PlayerAnimator.SetInteger("State", state);
    }
}
