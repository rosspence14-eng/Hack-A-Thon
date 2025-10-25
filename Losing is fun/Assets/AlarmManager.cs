using UnityEngine;
using TMPro;

public class AlarmManager : MonoBehaviour
{
    public static AlarmManager Instance;

    public TextMeshProUGUI chaosText;
    private int chaosScore = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddChaos()
    {
        chaosScore++;
        chaosText.text = "Chaos: " + chaosScore;
    }
}