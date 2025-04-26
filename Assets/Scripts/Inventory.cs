using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] itemSlots = new Item[6];
    public Transform itemHolder; // точка, де показується зброя
    private GameObject currentEquippedItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem(0);
        }
    }

    public void AddItem(Item newItem)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == null)
            {
                itemSlots[i] = newItem;
                Debug.Log("Додано: " + newItem.itemName);
                return;
            }
        }
    }

    void EquipItem(int index)
    {
        if (itemSlots[index] != null)
        {
            if (currentEquippedItem != null)
                Destroy(currentEquippedItem);

            currentEquippedItem = Instantiate(itemSlots[index].itemPrefab, itemHolder);
            currentEquippedItem.transform.localPosition = Vector3.zero;
            currentEquippedItem.transform.localRotation = Quaternion.identity;
        }
    }
}
