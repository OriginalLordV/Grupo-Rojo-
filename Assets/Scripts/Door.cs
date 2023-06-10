using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int totalKeysNeeded = 3;
    public string keyRequestTag = "KeysRequest";

    private Inventory playerInventory;
    private Text keysRequestText;

    private void Start()
    {
        // Obtener la referencia al inventario del jugador
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        // Buscar el objeto de texto con el tag especificado
        GameObject keysRequestObject = GameObject.FindGameObjectWithTag(keyRequestTag);

        // Obtener la referencia al componente Text del objeto de texto
        keysRequestText = keysRequestObject.GetComponent<Text>();
    }

    public void OpenDoor()
    {
        // Verificar si el jugador ha recolectado todas las llaves necesarias
        if (playerInventory.collectedKeys == totalKeysNeeded)
        {
            // Abrir la puerta
            Debug.Log("¡La puerta se ha abierto!");
        }
        else
        {
            // Calcular cuántas llaves faltan para abrir la puerta
            int remainingKeys = totalKeysNeeded - playerInventory.collectedKeys;

            // Mostrar el número de llaves restantes en el Text
            keysRequestText.text = "Faltan " + remainingKeys + " llaves para abrir la puerta.";
        }
    }
}
