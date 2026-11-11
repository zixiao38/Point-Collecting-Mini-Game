using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int targetScore = 15;
    public float gameTime = 10f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winScoreText;
    public TextMeshProUGUI loseScoreText;

    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject losePanel;

    public CircleSpawn spawn;

    private float timeLeft;
    private bool gameRun = false;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowStartScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRun)
        {
            return;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        timerText.text = "Time: " + timeLeft.ToString("F5");

        if (timeLeft <= 0)
        {
            EndGame();
        }

    }

    public void StartGame()
    {
        score = 0;
        timeLeft = gameTime;
        gameRun = true;

        spawn.ClearCircles();
        spawn.isSpawning = true;

        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        scoreText.text = "Score: " + score;
        targetText.text = "Target: " + targetScore;
        timerText.text = "Time: " + timeLeft.ToString("F5");
    }
    void EndGame()
    {
        gameRun = false;
        spawn.isSpawning = false;
        spawn.ClearCircles();

        gamePanel.SetActive(false);

        if (score >= targetScore)
        {
            winPanel.SetActive(true);
            winScoreText.text = "Final Score: " + score;
        }
        else
        {
            losePanel.SetActive(true);
            loseScoreText.text = "Final Score: " + score;
        }
    }

    public void AddScore(int points)
    {
        if (!gameRun)
        {
            return;
        }
        score += points;
    }
    public void ShowStartScreen()
    {
        gameRun = false;
        spawn.isSpawning = false;
        spawn.ClearCircles();

        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
}
