using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public Item itemData;

    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < 3f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
                inv.AddItem(itemData);
                Destroy(gameObject);
            }
        }
    }
}
