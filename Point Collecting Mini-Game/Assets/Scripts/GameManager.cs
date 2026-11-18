using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int targetScore = 15;
    public float gameTime = 10f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI timerText;
    public CircleSpawn spawn;
    private bool gameRun = false;
    private float timeLeft;

    public static int finalScore;
    public static bool isWin;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        timeLeft = gameTime;
        gameRun = true;

        spawn.ClearCircles();
        spawn.isSpawning = true;

        scoreText.text = "Score: " + score;
        targetText.text = "Target: " + targetScore;
        timerText.text = "Time: " + timeLeft.ToString("F2");
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

        timerText.text = "Time: " + timeLeft.ToString("F2");
        scoreText.text = "Score: " + score;

        if (timeLeft <= 0)
        {
            EndGame();
        }

    }
    void EndGame()
    {
        gameRun = false;
        spawn.isSpawning = false;
        spawn.ClearCircles();

        finalScore = score;
        isWin = score >= targetScore;

        SceneManager.LoadScene("ResultScene");
    }

    public void AddScore(int points)
    {
        if (!gameRun)
        {
            return;
        }
        score += points;
    }
}
