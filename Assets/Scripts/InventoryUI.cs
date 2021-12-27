using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    
    Inventory inventory;
    InventorySlots[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlots>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void UpdateUI(){
        // Debug.Log("right");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }
            else{
                slots[i].ClearSlot();
            }
        }
    }
}
