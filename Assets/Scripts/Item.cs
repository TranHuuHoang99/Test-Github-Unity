using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int itemID;
    public GameObject itemPrefabs;
    
    public virtual void Use(){
        switch(itemID){
            case 0:
                CameraHorror.instance.OnCrossHairCam();
                break;
            case 1:
                MorseCodePaper.instance.OnMorseText();
                break;
            case 3:
                PlayerPickUp.instance.HoldItem(this);
                break;
            case 4:
                Introduce.instance.OnMorseText();
                break;
        }
    }
    public virtual void UnUse(){
        PlayerPickUp.instance.DroppingItem(this);
        switch(itemID){
            case 0:
                CameraHorror.instance.OffCrossHairCam();
                break;
            case 1:
                MorseCodePaper.instance.OffMorseText();
                break;
            case 3:
                PlayerPickUp.instance.DestroyLamp();
                break;
        }
    }
    public virtual void Inspect(){
        PlayerPickUp.instance.InspectItems(this);
    }
}
