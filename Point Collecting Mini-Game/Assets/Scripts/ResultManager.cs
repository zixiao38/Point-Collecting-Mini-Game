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

        if (GameManager.isWin)
        {
            title.text = "VICTORY!";
            title.color = new Color32(239, 199, 125, 255);
        }
        else
        {
            title.text = "LOSE!";
            title.color = new Color32(231, 159, 148, 255);
        }
        scoreText.text = "FINAL SCORE  " + GameManager.finalScore;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
