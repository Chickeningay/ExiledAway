
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class visitorScript : MonoBehaviour
{
    public AnimationClip giveLetterAnim;
    public GameObject letterUI;
    public bool giveLetter;
    public GameObject AI;
    public Letters lettersDB;
    public bool once;
    bool resolved;

    void Start()
    {
        AI = GameObject.Find("AI");
        lettersDB = FindObjectOfType<Letters>();

        if (!PlayerPrefs.HasKey("gfPath"))
            PlayerPrefs.SetString("gfPath", "g1");

        if (!PlayerPrefs.HasKey("fatherPath"))
            PlayerPrefs.SetString("fatherPath", "f1");
    }

    void Update()
    {
        if (giveLetter&&!once)
        {
            once = true;
            GetComponent<Animator>().Play(giveLetterAnim.name);
            letterUI.SetActive(true);
        }
        if (resolved) return;

        bool isFatherDay = PlayerPrefs.GetInt("day") % 2 == 0;
        string pathKey = isFatherDay ? "fatherPath" : "gfPath";

        string currentId = PlayerPrefs.GetString(pathKey);
        var currentLetter = lettersDB.Get(currentId);
        if (currentLetter == null) return;
        
        bool result = AI.GetComponent<AICommunicate>().result;

        Letters.Letter nextLetter = currentLetter;

        if (!currentLetter.isEnding)
        {
            string nextId;
            if (currentId == "g2")
            {
                if (PlayerPrefs.GetInt("gaveFood") == 0)
                {
                    nextId = currentLetter.nextOnFalse;
                }
                else
                {
                   nextId = result
                    ? currentLetter.nextOnTrue
                    : currentLetter.nextOnFalse;
                }
            }
            else
            {
                nextId = result
                ? currentLetter.nextOnTrue
                : currentLetter.nextOnFalse;

            }

            if (!string.IsNullOrEmpty(nextId))
            {
                PlayerPrefs.SetString(pathKey, nextId);
                nextLetter = lettersDB.Get(nextId);
            }
        }

        if (nextLetter != null)
        {
            letterUI.transform.GetChild(0)
                .GetComponent<TMP_Text>().text = nextLetter.text;
        }
        

        resolved = true;
    }
}


