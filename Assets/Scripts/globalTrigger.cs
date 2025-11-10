using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalTrigger : MonoBehaviour
{
    public GameObject mailWrite;
    public GameObject mailArrive;

    bool mailWriteTrigger;

    bool mailArriveTrigger;

    bool HouseDoorTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            if (mailWriteTrigger)
            {
                mailWrite.SetActive(true);
            }
            else if (mailArriveTrigger) 
            {
                mailArrive.SetActive(true);
            }
            else if (HouseDoorTrigger) 
            {
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "mailWrite")
            {
                mailWriteTrigger = true;
            }
            else if (other.gameObject.tag == "mailArrive")
            {
                mailArriveTrigger = true;
            }
            if (other.gameObject.tag == "houseDoor")
            {
                HouseDoorTrigger = true;
            }
    }
    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "mailWrite")
            {
                mailWriteTrigger = false;
            }
            else if (other.gameObject.tag == "mailArrive")
            {
                mailArriveTrigger = false;
            }
            if (other.gameObject.tag == "houseDoor")
            {
                HouseDoorTrigger = false;
            }
    }
}
