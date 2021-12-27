using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChair : MonoBehaviour
{
    public static DeathChair instance;
    private void Awake(){
        instance = this;
    }
    public PlayerMoveMent movement;
    public Animator deathChairAnim;
    
    public void OnDeathChair(){
        deathChairAnim.enabled = true;
        movement.enabled = false;
        Destroy(this.gameObject);
    }
}
