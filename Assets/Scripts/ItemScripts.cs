using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour
{
    public static ItemScripts instance;
    private void Awake(){
        instance = this;
    }
    public AudioSource dropSound;
    public Item item;
    protected Vector3 posLastFame;

    private void OnCollisionEnter(Collision other){
        dropSound.Play();
    }
    private void Update(){
        mouseInspector();
    }
    public void ItemPicked(){
        Debug.Log(item.itemID);
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp){
            isInpected();
            Destroy(this.gameObject);
        }
    }
    public void isInpected(){
        item.Inspect();
        InventoryInput.instance.enabled = false;
    }
    private void mouseInspector(){
        if(Input.GetMouseButtonDown(0)){
            posLastFame = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)){
            var delta = Input.mousePosition - posLastFame;
            posLastFame = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) *transform.rotation;
        }
    }
    public void DestroyInspectView(){
        Destroy(this.gameObject);
    }
}
