using UnityEngine;
using TMPro; // Namespace for TextMesh Pro

public class ScoreSubmitForm : MonoBehaviour
{
    public TMP_InputField initialsInputField;
    public ScoreSender scoreSender; // Reference to the ScoreSender script

    private int playerKills;
    private float playerTime;

    public void ShowForm(int kills, float time)
    {
        playerKills = kills;
        playerTime = time;
        gameObject.SetActive(true); // Show the form
    }

    public void ReadStringInput(string s)
    {
        string input = s;
        Debug.Log(input);
    }

    public void OnSubmitClicked()
    {
        string initials = initialsInputField.text;
        if (initials.Length <= 2)
        {
            scoreSender.SendScore(initials, playerTime, playerKills);
            gameObject.SetActive(false); // Hide the form
        }
        else
        {
            Debug.LogError("Initials should be at most 2 characters long.");
        }
    }
}
