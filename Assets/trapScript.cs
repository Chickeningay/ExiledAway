using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class trapScript : MonoBehaviour
{
    public List<GameObject> children;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != gameObject&& gameObject.name=="trap")
            {
                children.Add(child.gameObject);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var child in children) { child.SetActive(false); }

        var amount = PlayerPrefs.GetInt("TrapAmount");
        int kids = 0;
        switch (amount)
        {
            case > 3:
                kids = 3;
                break;
            case > 2:
                kids = 2;
                break;
            case > 1:
                kids = 1;
                break;
        }
        for (int x = 0; x < kids; x++)
        {
            children[x].SetActive(true);

        }
    }
}
