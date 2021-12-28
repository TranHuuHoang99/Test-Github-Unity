using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private CharacterController controller;
    [SerializeField] private LayerMask groundMask;
    Vector3 velocity;

    void Update(){
        PlayerActivity();
    }


    // player movement and interact
    private void PlayerActivity(){
        // walk
        Movement.Walk(controller, 2, playerTransform);

        //jump and gravity
        velocity = Movement.JumpGrav(velocity, controller, groundCheck,groundMask, 1f);

        //run

        //sit

        //lay
    }
}
