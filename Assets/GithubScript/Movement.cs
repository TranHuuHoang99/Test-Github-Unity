using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //walking function
    static public void Walk(CharacterController controller, float speed, Transform playerTransform){
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movedirection = playerTransform.transform.right * moveX + playerTransform.transform.forward * moveZ;
        controller.Move(movedirection * speed * Time.deltaTime);
    }



    //Gravity Function
    static public Vector3 JumpGrav(Vector3 velocity, CharacterController controller, Transform groundCheck, LayerMask groundMask, float jumpHeight){
        float gravity = -9.81f;
        float groundDistance = 0.4f;

        //gravity function
        bool isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if(isGrounded && velocity.y <0){
            velocity.y = -2f;
        }

        //jump function
        if(Input.GetKey(KeyCode.Space) && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        return velocity;
    }
}
