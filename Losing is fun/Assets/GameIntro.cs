using UnityEngine;

public class GameIntro : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject gameplayUI; // Optional: HUD or controls

    void Start()
    {
        // Show instructions, hide gameplay UI at start
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);

        if (gameplayUI != null)
            gameplayUI.SetActive(false);
    }

    public void BeginGame()
    {
        // Hide instructions, show gameplay UI
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);

        if (gameplayUI != null)
            gameplayUI.SetActive(true);

        // Start the timer
        GameTimer timer = Object.FindFirstObjectByType<GameTimer>();
        if (timer != null)
            timer.StartTimer();
        else
            Debug.LogWarning("GameTimer not found in scene!");
    }
}