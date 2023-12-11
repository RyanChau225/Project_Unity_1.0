using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerScore
{
    public string initials;
    public float time;
    public int score;
}

public class ScoreSender : MonoBehaviour
{
    public string apiUrl = "http://localhost:3000/submitScore"; // Replace with your server's URL

    public void SendScore(string initials, float time, int score)
    {
        PlayerScore playerScore = new PlayerScore { initials = initials, time = time, score = score };
        StartCoroutine(PostScore(playerScore));
    }

    IEnumerator PostScore(PlayerScore playerScore)
    {
        string jsonData = JsonUtility.ToJson(playerScore);
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(apiUrl, jsonData))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error Submitting Score: " + request.error);
            }
            else
            {
                Debug.Log("Score Submitted Successfully: " + request.downloadHandler.text);
            }
        }
    }
}
