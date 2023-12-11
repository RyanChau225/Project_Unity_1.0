using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private TimeDisplay timeDisplay;

    public GameOverPanel gameOverPanel;
    public LeaderboardUI leaderboardUI; // Assign in the Inspector


    public ScoreSubmitForm scoreSubmitForm; // Assign in the Inspector

    private int playerKills = 0; // Variable to track player kills
    private float playerTime = 0f; // Variable to track elapsed time

    void Start()
    {
        // Find the TimeDisplay script in the scene
        timeDisplay = FindObjectOfType<TimeDisplay>();
    }

    void Update()
    {
        // Update playerTime each frame
        playerTime += Time.deltaTime;
    }

    public void AddKill()
    {
        // Call this method whenever the player gets a kill
        playerKills++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // This code gets executed when the player collides with an object tagged as "Enemy"
            Die();
        }
    }

    void Die()
    {
        // Handle the player's death here
        Debug.Log("Player has died!");

        gameObject.SetActive(false);
        gameOverPanel.ShowGameOverPanel();
        int kills = KillCounter.Instance.GetKillCount();
        float time = playerTime; // Fetch the elapsed time

        scoreSubmitForm.ShowForm(playerKills, playerTime);
    
        leaderboardUI.ShowLeaderboardPanel(); 
     


        // Stop the time
        if (timeDisplay != null)
        {
            timeDisplay.StopTimer();
        }
    }
}
