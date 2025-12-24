using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodscript : MonoBehaviour
{
    public int amount;
    public GameObject dataHolder;
    public List<GameObject> children = new List<GameObject>();
    void Start()
    {
        dataHolder = GameObject.Find("AI");
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject!= transform.GetChild(0).gameObject&& child.gameObject!=gameObject) { 
            children.Add(child.gameObject);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var child in children) { child.SetActive(false); }

        amount = PlayerPrefs.GetInt("WoodAmount");
        int kids=0;
        switch (amount)
        {
            case > 50:
                kids = 25;
                break;
            case > 40:
                kids = 20;
                break;
            case > 30:
                kids = 15;
                break;
            case > 20:
                kids = 10;
                break;
            case > 10:
                kids = 5;
                break;
        }
        for(int x = 0; x < kids; x++) 
        {
            children[x].SetActive(true);
        
        }
    }
}
