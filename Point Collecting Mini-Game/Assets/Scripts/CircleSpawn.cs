using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    public GameObject blueCircle;
    public GameObject greenCircle;
    public GameObject orangeCircle;
    public float spawnInterval = 0.5f;
    public bool isSpawning = false;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnCorcle();
            timer = 0;
        }
    }

    void SpawnCorcle()
    {
        int randomType = Random.Range(0, 3);
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        float randomX = Random.Range(bottomLeft.x + 1, topRight.x - 1);
        float randomY = Random.Range(bottomLeft.y + 1, topRight.y - 1);

        if (randomType == 0)
        {
            Vector3 spownPosition = new Vector3(randomX, topRight.y + 1, 0);
            Instantiate(blueCircle, spownPosition, Quaternion.identity);
        }
        else if(randomType == 1)
        {
            Vector3 spownPosition = new Vector3(randomX, randomY, 0);
            Instantiate(greenCircle, spownPosition, Quaternion.identity);
        }
        else
        {
            Vector3 spownPosition = new Vector3(randomX, randomY, 0);
            Instantiate(orangeCircle, spownPosition, Quaternion.identity);
        }
    }

    public void ClearCircles()
    {
        CircleClick[] circles = FindObjectsByType <CircleClick>(FindObjectsInactive.Include);

        foreach (CircleClick circle in circles)
        {
            Destroy(circle.gameObject);
        }
    }
}
