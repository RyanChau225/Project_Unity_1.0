using UnityEngine;
using TMPro; // If using TextMeshPro

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText; // Assign this in the Inspector

    public void UpdateLeaderboard(string data)
    {
        leaderboardText.text = data;
    }
    public void ShowLeaderboardPanel()
    {
        gameObject.SetActive(true); // Activate the Game Over panel
    }
}
