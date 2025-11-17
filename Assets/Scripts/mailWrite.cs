using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;


public class mailWrite : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject Player;
    public GameObject AI;
    private void Update()
    {
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = false;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            AI.GetComponent<AICommunicate>().message = inputField.text;
            AI.GetComponent<AICommunicate>().SendToPython();
            CloseInput();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FocusInputNextFrame());
    }

    private IEnumerator FocusInputNextFrame()
    {
        yield return null; 
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        inputField.Select();
        inputField.ActivateInputField();
    }

    private void OnDisable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        inputField.DeactivateInputField();
    }

    private void CloseInput()
    {
        inputField.DeactivateInputField();
        EventSystem.current.SetSelectedGameObject(null);
        Player.GetComponent<FirstPersonMovement>().enabled = true;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = true;
        inputField.text = "";
        gameObject.SetActive(false);

    }
}
