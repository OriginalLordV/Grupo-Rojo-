using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int totalKeysNeeded = 3;
    public string nextSceneName = "Scene02"; // Nombre de la siguiente escena

    private Inventory playerInventory;
    private bool doorUnlocked = false;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInventory.collectedKeys == totalKeysNeeded && !doorUnlocked)
        {
            doorUnlocked = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
