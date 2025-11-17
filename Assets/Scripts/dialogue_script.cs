using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogue_script : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] children;
    int chosenChild=-1;
    public bool[] opened;
    public GameObject stranger;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        int childCount = transform.childCount;
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = false;
    }

    public void enableDiag(int x) 
    {
        chosenChild = x; Debug.Log($"enableDiag({x}) called");
        opened[x] = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (opened[0] == true && opened[1] == true && opened[2] == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stranger.GetComponent<visitorScript>().giveLetter = true;
                gameObject.SetActive(false);
            }
            transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "The stranger offers you a letter";
            

        }
        else if (true)
        {
            if (chosenChild != -1)
            {
                foreach (var x in children)
                {
                    x.SetActive(false);
                }
                children[chosenChild].SetActive(true);
            }
            else if (chosenChild == -1)
            {
                foreach (var x in children)
                {
                    x.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "";
                chosenChild = -1;
            }
            if (chosenChild == 0)
            {
                transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "...";
            }
            else if (chosenChild == 1)
            {
                transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "...";
            }
            else if (chosenChild == 2)
            {
                transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "...";
            }
        }
    }
    private void OnDisable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<FirstPersonMovement>().enabled = true;
        Player.transform.GetChild(0).GetComponent<FirstPersonLook>().enabled = true;
    }
}
