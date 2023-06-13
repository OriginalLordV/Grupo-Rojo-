using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int allSlots;
    private GameObject[] slot;

    public GameObject inventoryGameObject;
    public GameObject slotHolder;
    public int collectedKeys = 0;
    public int totalKeysNeeded = 3;

    public Text keysNeededText;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }

        inventoryGameObject.SetActive(true);
        keysNeededText.text = "Faltan " + (totalKeysNeeded - collectedKeys) + " llaves para abrir la puerta.";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;

                if(itemType=="Key"){
                    collectedKeys++;
                }

                UpdateInventoryText();

                return;
            }
        }
    }

    private void UpdateInventoryText()
    {
        keysNeededText.text = "Faltan " + (totalKeysNeeded - collectedKeys) + " llaves para abrir la puerta.";
    }
}
