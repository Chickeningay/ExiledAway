using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class AICommunicate : MonoBehaviour
{
    [Header("LLM Instruction / Criteria")]
    [TextArea(3, 6)]
    public string instruction;

    [Header("Message to analyze")]
    [TextArea(3, 6)]
    public string message;

    [Header("LLM Boolean Result")]
    public bool result;

    private const string pythonUrl = "http://127.0.0.1:5005/analyze";

    // Call this from a button or another script
    public void SendToPython()
    {
        StartCoroutine(SendMessageToPython());
    }

    private IEnumerator SendMessageToPython()
    {
        if (string.IsNullOrEmpty(instruction) || string.IsNullOrEmpty(message))
        {
            Debug.LogWarning("Instruction or message is empty!");
            yield break;
        }

        string jsonData = JsonUtility.ToJson(new PromptWrapper(instruction, message));
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

                // Simple & safe boolean extraction
                result = request.downloadHandler.text.Contains("\"result\":true");
            }
            else
            {
                Debug.LogError($"HTTP Error {request.responseCode}: {request.error}");
                Debug.LogError($"Raw response: {request.downloadHandler.text}");
            }
        }
    }

    [System.Serializable]
    private class PromptWrapper
    {
        public string instruction;
        public string message;

        public PromptWrapper(string instruction, string message)
        {
            this.instruction = instruction;
            this.message = message;
        }
    }
}
