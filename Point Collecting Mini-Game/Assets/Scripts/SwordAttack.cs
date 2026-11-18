using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public PlayerAttack playerAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerAttack.isAttacking)
        {
            CircleHealth circle = collision.GetComponent<CircleHealth>();
            if(circle != null)
            {
                circle.Takehit();
            }
        }
    }
}
