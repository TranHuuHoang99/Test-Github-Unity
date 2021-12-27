using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorScript : MonoBehaviour
{
    public static InspectorScript instance;
    private void Awake(){
        instance = this;
    }
    public PlayerMoveMent unlockMovement;
    public MouseLook unlockMouseLook;
    public GameObject blurEffect;
    public Button exitInspector;
    private Item item;

    public void ShowCursorMouse(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        unlockMouseLook.enabled = false;
        unlockMovement.enabled = false;
    }
    private void HideCursorMouse(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        unlockMouseLook.enabled = true;
        unlockMovement.enabled = true;
    }
    public virtual void OnExitInspectMode(){
        ItemScripts.instance.DestroyInspectView();
        PlayerPickUp.instance.inspectorCamera.SetActive(false);
        InventoryInput.instance.enabled = true;
        blurEffect.SetActive(false);
        HideCursorMouse();
    }
}
