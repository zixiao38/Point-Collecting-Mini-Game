using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("ResultManager Start");

        Debug.Log("Title: " + title);
        Debug.Log("ScoreText: " + scoreText);

        if (title == null || scoreText == null)
        {
            Debug.LogError("ResultManager UI reference is missing!");
            return;
        }

        if (GameManager.isWin)
        {
            title.text = "WIN!";
            title.color = Color.green;
        }
        else
        {
            title.text = "LOSE";
            title.color = Color.red;
        }
        scoreText.text = "Final Score: " + GameManager.finalScore;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
