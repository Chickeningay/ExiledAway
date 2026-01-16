using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class mailWrite : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject Player;
    public GameObject AI;
    public Letters lettersDB;
    public GameObject global;

    void Start()
    {
        lettersDB = FindObjectOfType<Letters>();
        AI = GameObject.Find("AI");
    }

    private void Update()
    {
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = false;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            int day = PlayerPrefs.GetInt("day");

            int replyDay = day - 1;

            bool replyingToFather = replyDay % 2 == 0;



            string letterId = replyingToFather
                ? PlayerPrefs.GetString("fatherPath")
                : PlayerPrefs.GetString("gfPath");


            var letter = lettersDB.Get(letterId);

            if (letter.isEnding&& replyingToFather)
            {
                letterId = PlayerPrefs.GetString("gfPath");
                letter = lettersDB.Get(letterId);
            }
            else if(letter.isEnding && !replyingToFather)
            {
                letterId = PlayerPrefs.GetString("fatherPath");
                letter = lettersDB.Get(letterId);
            }
            if (letter == null)
            {
                Debug.LogError("No letter found for ID: " + letterId);
                return;
            }

            var ai = AI.GetComponent<AICommunicate>();

            ai.instruction = letter.prompt;      
            ai.message = inputField.text;        

            ai.SendToPython();
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
