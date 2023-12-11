using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
    public void ShowGameOverPanel()
    {
        gameObject.SetActive(true); // Activate the Game Over panel
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
