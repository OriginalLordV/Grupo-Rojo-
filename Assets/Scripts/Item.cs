 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;
    [HideInInspector]
    public bool equipped;
    [HideInInspector]   
    public GameObject keysManager;
    [HideInInspector]   
    public GameObject keys;
    
    public bool playersKeys;

    private void Start(){

        keysManager = GameObject.FindWithTag("KeysManager");

        if (!playersKeys)
        {
            int allKeys = keysManager.transform.childCount;

            for (int i = 0; i < allKeys; i++)
            {
                if (keysManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    keys=keysManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update(){

        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipped = false;
            }
            if (equipped==false)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
