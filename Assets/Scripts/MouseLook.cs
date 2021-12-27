using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public static MouseLook instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] Transform playerBody;
    private float xRotation = 0f;
    public float MouseSens = 100f;

    // Update is called once per frame
    void Update()
    {
        MouseLookFunc();
    }
    private void MouseLookFunc(){
        float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
