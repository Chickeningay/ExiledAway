using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactBlocker : MonoBehaviour
{
    public GameObject firebox;
    public GameObject eatbox;
    public GameObject write;
    public GameObject door;
    public GameObject sleepcollider;
    public bool fireboxbool;
    public bool eat;
    public bool doorbool;
    public bool sleep;
    public bool writebool;

    // Start is called before the first frame update
    void Start()
    {
        door.active = false;
        write.active = false;
        sleepcollider.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("WoodAmount") < 0) { SceneManager.LoadScene(3); }
        if (PlayerPrefs.GetInt("FoodAmount") < 0) { SceneManager.LoadScene(3); }

        if (fireboxbool) { firebox.transform.parent.GetChild(0).gameObject.active = true; }
        if(eat && fireboxbool)
        {
            writebool = true;
        }
        if (doorbool) { door.active = true; }
        else { door.active = false; }
        if (writebool) { write.active = true; }
        else { write.active = false; }
        if (sleep) { sleepcollider.active = true; }
        else { sleepcollider.active = false; }

    }
}
