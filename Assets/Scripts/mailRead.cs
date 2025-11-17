using UnityEngine;

public class mailRead : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        // Disable player movement/look while this UI is active
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = false;

        // Close the UI when pressing Enter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloseUI();
        }

    }

    private void OnEnable()
    {
        // Optional: lock cursor or do any setup when shown
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        // Optional: restore cursor behavior when hidden
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void CloseUI()
    {
        // Re-enable player controls
        Player.GetComponent<FirstPersonMovement>().enabled = true;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = true;

        // Hide this object
        gameObject.SetActive(false);
    }
}
