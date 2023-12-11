using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeTextTMP; // Assign this in the inspector
    private float timer;
    public bool isPlayerAlive = true; // Flag to check if the player is still alive

    void Update()
    {
        if (isPlayerAlive)
        {
            timer += Time.deltaTime;
            timeTextTMP.text = "Time: " + Mathf.FloorToInt(timer);
        }
    }

    public void StopTimer()
    {
        isPlayerAlive = false;
    }
}
