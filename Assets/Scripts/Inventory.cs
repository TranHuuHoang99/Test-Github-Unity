using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private void Awake(){
        if(instance != null){
            Debug.LogWarning("More than one of Inventory Found");
            return;
        }
        instance = this;
    }
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallback;
    public int space = 9;
    public List<Item> items = new List<Item>();
    public bool Add(Item item){
        if(!item.isDefaultItem){
            if(items.Count >= space){
                Debug.Log("Not enough Slot");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallback != null){
                onItemChangeCallback.Invoke();
            }
        }
        return true;
    }
    public void ClearItemInv(Item item){
        items.Remove(item);
        if(onItemChangeCallback != null){
            onItemChangeCallback.Invoke();
        }
    }
}
