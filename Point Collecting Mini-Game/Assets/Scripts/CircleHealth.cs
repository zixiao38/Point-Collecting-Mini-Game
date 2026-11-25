using UnityEngine;

public class CircleHealth : MonoBehaviour
{
    public int scoreValue = 1;
    public int hitRequired = 1;
    public Sprite crackedSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    public void Takehit()
    {
        hitRequired--;
        if(hitRequired <= 0)
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
        else if(crackedSprite != null)
        {
                animator.enabled = false;
            spriteRenderer.sprite = crackedSprite;
        }
    }

}
