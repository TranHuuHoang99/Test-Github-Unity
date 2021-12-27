using UnityEngine;
using System.Collections;

public class BasicDoor : MonoBehaviour {
	
	public GameObject doorChild; 
	public GameObject audioChild; 
	
	public AudioClip openSound; 
	public AudioClip closeSound; 

	public AudioSource doorLocked;

	public int doorID = 0 ;
	public int ID = 1;
	
	private bool inTrigger = false; 
	private bool doorOpen = false; 
	
	
	public void doorOpenClose() {
		if (doorChild.GetComponent<Animation>().isPlaying == false) {
			if (doorOpen == false) {
				
				doorChild.GetComponent<Animation>().Play("Open");
				audioChild.GetComponent<AudioSource>().clip = openSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = true;
			}
			else {
				doorChild.GetComponent<Animation>().Play("Close");
				audioChild.GetComponent<AudioSource>().clip = closeSound;
				audioChild.GetComponent<AudioSource>().Play();
				doorOpen = false;
			}
		}
	}
	
	
	
	
	void OnTriggerEnter(Collider collider) {
		if (collider.GetComponent<CharacterController>())
			inTrigger = true;
	}
	void OnTriggerExit(Collider collider) {
		if (collider.GetComponent<CharacterController>())
			inTrigger = false;
	}
	
	void Update() {
		if (inTrigger == true) {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				if(ID == 64){
					JumpScare.instance.GetIDDoorFinal(this);
				}
				if(doorLocked.isPlaying == false){
					doorLocked.Play();
				}
				if(doorID == ID){
					doorOpenClose();
				}
			}
		}
	}
}
