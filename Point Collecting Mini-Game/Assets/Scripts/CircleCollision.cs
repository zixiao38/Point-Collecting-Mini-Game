using UnityEngine;

public class CircleCollision : MonoBehaviour
{
    public int score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
