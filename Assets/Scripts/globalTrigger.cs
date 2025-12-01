using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalTrigger : MonoBehaviour
{
    public GameObject mailWrite;
    public GameObject mailArrive;
    public GameObject woodCounter;
    public GameObject wood;
    public GameObject foodCounter;
    public GameObject bed;
    bool mailWriteTrigger;
    bool bedTrigger;
    bool mailArriveTrigger;
    bool foodTrigger;
    bool HouseDoorTrigger;
    bool woodTrigger;
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
            else if (woodTrigger) 
            {
                woodCounter.GetComponent<countWood>().woodCount++;
                wood.GetComponent<Animator>().Play("woodChop");
            }
            else if (bedTrigger)
            {
                bed.GetComponent<sleepScript>().enabled = true ;
            }
            else if (foodTrigger)
            {
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
            if (other.gameObject.tag == "wood")
            {
                woodTrigger = true;
            }
            if (other.gameObject.tag == "bed")
            {
                bedTrigger = true;
            }
            if (other.gameObject.tag == "food")
            {
            foodCounter.GetComponent<countFood>().foodCount++;
            Destroy(other.transform.parent.gameObject);
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
            if (other.gameObject.tag == "wood")
            {
                woodTrigger = false;
            }
            if (other.gameObject.tag == "bed")
            {
                bedTrigger = false;
            }
            if (other.gameObject.tag == "food")
            {
                foodTrigger = false;
            }
    }
}
