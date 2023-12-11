using UnityEngine;
using TMPro; // Make sure to include this if using TextMeshPro

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI killsText; // Assign this in the inspector
    public static KillCounter Instance { get; private set; }
    private int killCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateKillText();
    }

    public void AddKill()
    {
        killCount++;
        UpdateKillText();
    }

    public int GetKillCount()
    {
        return killCount;
    }

    private void UpdateKillText()
    {
        if (killsText != null)
        {
            killsText.text = "Kills: " + killCount;
        }
    }
}
