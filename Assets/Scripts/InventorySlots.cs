using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public static InventorySlots instance;
    private void Awake(){
        instance = this;
    }
    public Image icon;
    public Button removeButton;
    private Item item;
    
    
    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton(){
        item.UnUse();
        Inventory.instance.ClearItemInv(item);
        PlayerPickUp.instance.isDestroyed = false;
    }
    public void UseItem(){
        if(item != null){
            item.Use();
        }
    }
}
