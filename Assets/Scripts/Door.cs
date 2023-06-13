using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";
    public int totalKeysNeeded = 3;
    public string keyRequestTag = "KeyRequest";
    public string nextScene = "Scene02";

    private Inventory playerInventory;
    private Text keysRequestText;
    private bool isOpen = false;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        playerInventory = playerObject.GetComponent<Inventory>();

        GameObject keysRequestObject = GameObject.FindGameObjectWithTag(keyRequestTag);
        keysRequestText = keysRequestObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && !isOpen)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        if (playerInventory.collectedKeys == totalKeysNeeded)
        {
            isOpen = true;
            Debug.Log("¡La puerta se ha abierto!");

            SceneManager.LoadScene(nextScene);
        }
        else
        {
            int remainingKeys = totalKeysNeeded - playerInventory.collectedKeys;
            keysRequestText.text = "Faltan " + remainingKeys + " llaves para abrir la puerta.";
        }
    }
}
