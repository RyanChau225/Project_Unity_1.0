using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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

        // You can disable the player, play a death animation, etc.
        // For example, here we'll just deactivate the player's GameObject:
        gameObject.SetActive(false);

        // Optionally, you can load a game over scene or trigger a game over UI
        // SceneManager.LoadScene("GameOverScene");
    }
}
