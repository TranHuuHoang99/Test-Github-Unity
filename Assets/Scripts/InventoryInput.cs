using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public static InventoryInput instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] MouseLook mouseLookScript;
    public bool itemIsUsing = true;


    private void Start(){
        inventoryGameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update(){
        for(int i = 0; i < toggleInventoryKeys.Length; i++){
            if(Input.GetKeyDown(toggleInventoryKeys[i])){
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                if(inventoryGameObject.activeSelf){
                    ShowCursorMouse();
                    mouseLookScript.enabled = false;
                }
                else{
                    HideCursorMouse();
                    mouseLookScript.enabled = true;
                }
                break;
            }
        }
    }
    private void ShowCursorMouse(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void HideCursorMouse(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
