using UnityEngine;
using TMPro;

public class ChaosManager : MonoBehaviour
{
    public static ChaosManager Instance;

    public TextMeshProUGUI chaosText;
    private int chaosScore = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddChaos()
    {
        chaosScore++;
        chaosText.text = "x" + chaosScore;
    }

    public int GetChaosScore()
    {
        return chaosScore;
    }
}