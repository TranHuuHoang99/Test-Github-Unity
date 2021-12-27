using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    // gan trong luc cho nhan vat
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] AudioSource footStep;
    [SerializeField] private AudioSource effectSound;
    private float groundDistance = 0.4f;
    private bool isGrounded;
    public float gravity = -9.81f;


    public float speed;
    public float jumpHeight = 1;
    private Vector3 moveDirection;

    Vector3 velocity;

    //Mouse Look reference

    private void Start(){
        effectSound.loop = true;
        effectSound.Play();
    }
    private void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if(!isGrounded && velocity.y < 0 && footStep.isPlaying == false){
            velocity.y = -2f;
            footStep.Play();
        }
        if(Input.GetKey(KeyCode.Space) && isGrounded){ // jump function
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        MoveFunc(); // key code W S A D

        if(controller.isGrounded == true && controller.velocity.magnitude > 2f && footStep.isPlaying == false){
            footStep.Play();
        }
        
        
    }
    private void MoveFunc(){
        float moveX = Input.GetAxis("Horizontal"); // lay button A D
        float moveZ = Input.GetAxis("Vertical"); // lay button W S
        moveDirection  = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
