using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform SwordPivot;
    public float attackDuration = 0.3f;
    public float attackAngle = 120;
    public bool isAttacking = false;

    private PlayerMovement playerMovement;
    private InputAction attackAction;
    private float attackTimer = 0;
    private float currentAngle = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = playerMovement.facingDirection;
        currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(attackAction.WasPressedThisFrame()&&!isAttacking)
        {
            isAttacking = true;
            attackTimer = 0;
        }
        if(isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer < 0.08f)
            {
                float t = attackTimer / 0.08f;
                SwordPivot.localRotation = Quaternion.Euler(0, 0, currentAngle - attackAngle * t);
            }
            else if (attackTimer < 0.20f)
            {
                float t = (attackTimer - 0.08f) / 0.12f;
                SwordPivot.localRotation = Quaternion.Euler(0, 0, currentAngle - attackAngle + attackAngle * 2 * t);
            }
            else if(attackTimer < attackDuration)
            {
                float t = (attackTimer - 0.20f) / 0.10f;
                SwordPivot.localRotation = Quaternion.Euler(0, 0, currentAngle + attackAngle - attackAngle * t);
            }
            else
            {
                isAttacking = false;
            }
        }
        else
        {
            SwordPivot.localRotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }
}
