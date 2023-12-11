using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public LeaderboardUI leaderboardUI;

    void Start()
    {
        Debug.Log("GameManager Start called");
        UpdateLeaderboardUI(GetDummyData());
    }


    private string GetDummyData()
    {
        // Example JSON data in the format expected from the server
        string dummyJson = "[{\"initials\":\"ABC\",\"time\":120.0,\"kills\":10}," +
                           "{\"initials\":\"DEF\",\"time\":90.5,\"kills\":8}," +
                           "{\"initials\":\"GHI\",\"time\":75.3,\"kills\":12}]";
        return dummyJson;
    }

    private void UpdateLeaderboardUI(string jsonData)
    {
        Debug.Log("Updating leaderboard with data: " + jsonData);
        leaderboardUI.UpdateLeaderboard(jsonData);
    }

}
