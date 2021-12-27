using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBed : MonoBehaviour
{   
    public static DeathBed instance;
    private void Awake(){
        instance = this;
    }
    public Animator deathBedAnim;
    public AudioSource deathBedSound;

    public void OnDeathBed(){
        deathBedAnim.enabled = true;
        if(deathBedSound.isPlaying == false){
            deathBedSound.Play();
        }
        Destroy(this.gameObject);
    }

    
}
