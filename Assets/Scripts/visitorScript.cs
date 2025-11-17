using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class visitorScript : MonoBehaviour
{
    public AnimationClip giveLetterAnim;
    public bool giveLetter = false;
    public GameObject letter;
    public GameObject AI;
    
    void Start()
    {
        AI = GameObject.Find("AI");
    }
    void Update()
    {
        if (AI.GetComponent<AICommunicate>().sentimentResult) 
        {
            letter.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "I will try my best my son..";
        }
        if (giveLetter){
            gameObject.GetComponent<Animator>().Play(giveLetterAnim.name);
        letter.SetActive(true);
            giveLetter = false;
        }

    }
}
