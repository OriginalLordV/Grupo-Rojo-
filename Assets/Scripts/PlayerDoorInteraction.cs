using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDoorInteraction : MonoBehaviour
{
    public GameObject keysRequestObject;
    private bool isTouchingDoor;
    private Text keysRequestText;

    private void Start()
    {
        keysRequestText = keysRequestObject.GetComponent<Text>();
        keysRequestText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            isTouchingDoor = true;
            keysRequestText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            isTouchingDoor = false;
            keysRequestText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isTouchingDoor && Input.GetKeyDown(KeyCode.E))
        {
            // Realizar acciones al interactuar con la puerta
        }
    }
}
