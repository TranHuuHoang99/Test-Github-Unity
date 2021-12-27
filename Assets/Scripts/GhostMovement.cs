using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    // gan trong luc cho nhan vat
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private float groundDistance = 0.4f;
    private bool isGrounded;
    public float gravity = -9.81f;


    public float speed;
    public float jumpHeight = 1;
    private Vector3 moveDirection;

    Vector3 velocity;

    //Mouse Look reference

    private void Start(){
        
    }
    private void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if(!isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        MoveFunc(); // key code W S A D
    }
    public void MoveFunc(){
        float moveX = Input.GetAxis("Horizontal"); // lay button A D
        float moveZ = 1f;
        moveDirection  = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
