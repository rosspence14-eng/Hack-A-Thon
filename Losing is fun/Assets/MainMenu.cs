using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.LogError("LoadGame called with null or empty sceneName");
            return;
        }

        Debug.Log("Clicked: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }


    
}

