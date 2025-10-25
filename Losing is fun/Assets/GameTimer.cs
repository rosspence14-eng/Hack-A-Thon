using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 15f;
    private float timer;
    public TextMeshProUGUI timerText;

    private bool gameEnded = false;
    public bool timerActive = false; // ⬅️ Timer starts inactive

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (gameEnded || !timerActive) return;

        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0f); // Clamp to zero

        // Update UI
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
        }

        // Trigger game over
        if (timer <= 0f)
        {
            EndGame();
        }
    }

    public void StartTimer() // ⬅️ Call this from your intro script
    {
        timerActive = true;
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Time's up! Game Over.");

        var resultManager = Object.FindFirstObjectByType<ResultScreenManager>();
        if (resultManager != null && ChaosManager.Instance != null)
        {
            resultManager.ShowResults(ChaosManager.Instance.GetChaosScore());
        }
        else
        {
            Debug.LogError("ResultScreenManager or ChaosManager is missing!");
        }
    }
}