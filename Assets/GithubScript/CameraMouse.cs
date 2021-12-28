using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float  mouseSens = 100f;

    private void Update(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MouseLook();
    }

    //mouse look
    private void MouseLook(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        playerTransform.Rotate(Vector3.up , mouseX);
    } 
}
