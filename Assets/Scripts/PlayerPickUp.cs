using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPickUp : MonoBehaviour
{
    public static PlayerPickUp instance;
    [SerializeField] private Transform player;
    private void Awake(){
        instance = this;
    }
    [SerializeField] private Transform placeHolder;
    [SerializeField] private Transform inspectorPlace;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private Text itemName;
    public GameObject inspectorCamera;
    public Camera fpsCamHorror;
    public GameObject crossHairCam;
    public GameObject flashLight;
    private float forwardForce = 7;
    private float upwardForce = 4;
    public bool isDestroyed = true;
    private GameObject lampDestroyed;

    public void InspectItems(Item itemInspector){
        GameObject _itemInspector = Instantiate(itemInspector.itemPrefabs, inspectorPlace.transform.position, inspectorPlace.transform.rotation) as GameObject;
        _itemInspector.GetComponent<Rigidbody>().isKinematic = true;
        _itemInspector.GetComponent<BoxCollider>().isTrigger = true;
        _itemInspector.layer = LayerMask.NameToLayer("UI");
        _itemInspector.GetComponent<ItemScripts>().enabled = true;
        itemName.text = _itemInspector.ToString();
    }
    public void DroppingItem(Item item){
        GameObject _itemPrefabs = Instantiate(item.itemPrefabs, placeHolder.transform.position, placeHolder.transform.rotation) as GameObject;
        _itemPrefabs.GetComponent<Rigidbody>().isKinematic = false;
        _itemPrefabs.GetComponent<BoxCollider>().isTrigger = false;

        _itemPrefabs.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
            //them rotation cho sung
        float random = Random.Range(-1f, -1f);
        _itemPrefabs.GetComponent<Rigidbody>().AddTorque(new Vector3(random, random, random) * 10);

        _itemPrefabs.GetComponent<Rigidbody>().AddForce(fpsCamHorror.transform.forward * forwardForce, ForceMode.Impulse);
        _itemPrefabs.GetComponent<Rigidbody>().AddForce(fpsCamHorror.transform.up * upwardForce, ForceMode.Impulse);
    }
    public void HoldItem(Item itemHeld){
        GameObject _itemHeld = Instantiate(itemHeld.itemPrefabs, itemHolder.transform.position, itemHolder.transform.rotation) as GameObject;
        _itemHeld.transform.SetParent(itemHolder);
        _itemHeld.layer = LayerMask.NameToLayer("Holder");
        _itemHeld.GetComponent<Rigidbody>().isKinematic = true;
        _itemHeld.GetComponent<BoxCollider>().isTrigger = true;
        lampDestroyed = _itemHeld;
    }
    public void DestroyLamp(){
        if(isDestroyed == false){
            Destroy(lampDestroyed);
        }
    }
}
