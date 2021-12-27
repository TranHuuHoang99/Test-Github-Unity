using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public static GhostSpawn instance;
    private void Awake(){
        instance = this;
    }
    private int option = 0;
    
    public void JumpScare(Transform ghostSpawn, AudioSource horrorSound, GameObject ghostPrefabs){
        switch(option){
            case -1: 
                break;
            case 0:
                GameObject ghost = Instantiate(ghostPrefabs, ghostSpawn.transform.position, ghostSpawn.transform.rotation) as GameObject;
                ghost.GetComponent<GhostMovement>().enabled = true;
                // StartCoroutine(StaticCamera());
                Destroy(ghost, 2f);
                if(horrorSound.isPlaying == false){
                    horrorSound.Play();
                }
                option = -1;
                break;
        }       
    }
    public void RemakeInstantiate(){
        option = 0;
    }
    
    private IEnumerator StaticCamera(){
        yield return new WaitForSeconds(0.05f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PlayerPickUp.instance.flashLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        PlayerPickUp.instance.flashLight.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PlayerPickUp.instance.flashLight.SetActive(true);
    }
}
