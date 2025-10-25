using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScreenManager : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;

    // ✅ This method must be public and return void
    public void ShowResults(int chaosScore)
    {
        resultPanel.SetActive(true);
        resultText.text = "Game Over\n Score: " + chaosScore;
    }

    // ✅ This method must be public and return void
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ✅ This method must be public and return void
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}