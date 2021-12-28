using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveMent : MonoBehaviour
{
    [Header("object references")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    
    [Header("move numbers")]
    private float groundDistance = 0.4f;
    private bool isGrounded;
    public float gravity = -9.81f;
    public float speed;
    private Vector3 moveDirection;

    Vector3 velocity;

    private void Start(){
        
    }
    private void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if(!isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        MoveFunc(); 
    }
    public void MoveFunc(){
        float moveZ = 1f;
        moveDirection  = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
