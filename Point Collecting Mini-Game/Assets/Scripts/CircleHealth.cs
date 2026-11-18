using UnityEngine;

public class CircleHealth : MonoBehaviour
{
    public int scoreValue = 1;
    public int hitRequired = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Takehit()
    {
        hitRequired--;
        if(hitRequired <= 0)
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }

}
