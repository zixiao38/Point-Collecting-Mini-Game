using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
