using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSatanism : MonoBehaviour
{   
    public static ActiveSatanism instance;
    private void Awake(){
        instance = this;
    }
    public GameObject satanCircle;
    public PlayerMoveMent lockMovement;
    void OnTriggerEnter(Collider coll){
        if (coll.GetComponent<CharacterController>()){
            satanCircle.SetActive(true);
            JSSatanismCircle();
			Destroy(this.gameObject);
        }
	}

    public void JSSatanismCircle(){
        lockMovement.enabled = false;
    }
}
