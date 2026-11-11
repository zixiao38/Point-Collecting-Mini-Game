using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int scoreValue = 1;
    public int clicksRequired = 1;
    private int currentClicks = 0;
    private SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        currentClicks++;
        if(currentClicks < clicksRequired)
        {
            spriteRenderer.color = Color.green;
            return;
        }

        

        Destroy(gameObject);
    }
}
