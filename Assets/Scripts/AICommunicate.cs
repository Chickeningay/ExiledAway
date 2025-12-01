using System.Collections;
using System.Text;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class AICommunicate : MonoBehaviour
{

    [Header("Message to send")]
    public string message;

    [Header("Sentiment result (true = positive, false = negative)")]
    public bool sentimentResult;

    private const string pythonUrl = "http://127.0.0.1:5005/analyze";

    // ✅ Call this function manually (via button or script)
    public void SendToPython()
    {
        StartCoroutine(SendMessageToPython());
    }

    private IEnumerator SendMessageToPython()
    {
        if (string.IsNullOrEmpty(message))
        {
            Debug.LogWarning("Message is empty!");
            yield break;
        }

        // Ensure valid JSON formatting
        string jsonData = JsonUtility.ToJson(new MessageWrapper(message));
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(pythonUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                sentimentResult = request.downloadHandler.text.Contains("\"positive\":true");
            }
            else
            {
                Debug.LogError($"HTTP Error {request.responseCode}: {request.error}");
                Debug.LogError($"Raw response: {request.downloadHandler.text}");
            }
        }
    }

    [System.Serializable]
    private class MessageWrapper
    {
        public string message;
        public MessageWrapper(string msg) { message = msg; }
    }
}
