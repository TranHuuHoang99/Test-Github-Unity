using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpScare : MonoBehaviour
{
    public static JumpScare instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] private DoubleAutoDoor autodoor;
    [SerializeField] private Camera jumpScareCam;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private MouseLook lockMouse;

    public GameObject ghostPrefabs1;
    public GameObject ghostPrefabs2;
    public GameObject ghostPrefabs3;
    public GameObject ghostPrefabs4;
    [Header("First Jump Scare")]
    [SerializeField] private string  firstJumpScareTag = "FirstJumpScare";
    [SerializeField] private Transform firstJumpScare;
    [SerializeField] private GameObject firstBox;

    [Header("jump Scare 1")]
    [SerializeField] private Transform jumpScare;
    [SerializeField] private AudioSource jumpScareSound;
    [SerializeField] private string jumpScareTag = "JumpScare";
    [SerializeField] private GameObject jumpScareBox;

    [Header("jump Scare 2")]
    [SerializeField] private Transform jumpScare2;
    [SerializeField] private AudioSource jumpScareSound2;
    [SerializeField] private string jumpScareTag2 = "JumpScare2";
    [SerializeField] private GameObject jumpScareBox2;
    [Header("jump Scare 3")]
    [SerializeField] private Transform fade1;
    [SerializeField] private Transform fade2;
    [SerializeField] private Transform fade3;
    [SerializeField] private AudioSource fadeAwaySound;
    [Header("jump Scare 4")]
    [SerializeField] private string jumpScareTag4 = "DeathBed";
    public CameraShake camShake;
    [SerializeField] private AudioSource shakeSound;
    [Header("jump Scare 5")]
    [SerializeField] private string jumpScareTag5 = "DeathChair";
    [SerializeField] private AudioSource deathChairSound;
    [SerializeField] private BasicDoor doorChairClose;
    [Header("jump Scare 6")]
    [SerializeField] private string jumpScareTag6 = "DeathChair2";
    [SerializeField] private Transform ghostChairSpawn;
    [SerializeField] private AudioSource ghostChair2Sound;
    [SerializeField] private AudioSource CreepyLaughChair;
    [SerializeField] private GameObject strangleBox;
    [Header("jump Scare 7")]
    [SerializeField] private string jumpScareTag7 = "MorseGhost";
    [SerializeField] private Transform morseGhostSpawn;
    [SerializeField] private GameObject morseTriggerBox;
    [SerializeField] private GameObject morseTriggerBox2;
    [SerializeField] private BasicDoor morseDoor;
    [Header("jump Scare 8")]
    [SerializeField] private string jumpScareTag8 = "MorseGhost2";
    [SerializeField] private AudioSource morseGhostSound;
    [SerializeField] private AudioSource getOutSound;
    [SerializeField] private AudioSource doorBangging;
    [SerializeField] private AudioSource screamHorror;
    [SerializeField] private AudioSource whisper;
    [SerializeField] private AudioSource trumpetSound;
    [SerializeField] private GameObject bloodyPrint;
    [SerializeField] private DoubleAutoDoor exitOpen;
    [Header("Shut Down all effect sound")]
    [SerializeField] private string jumpScareTag9 = "ShutDownSound";
    [Header("Trigger Open Door 61")]
    [SerializeField] private string DoorTrigger61 = "DoorTrigger61";
    [SerializeField] private string cameraOff = "CameraOff";
    [SerializeField] private GameObject cameraBox;
    [SerializeField] private GameObject boxTrigger61;
    [SerializeField] private BasicDoor door62;
    [SerializeField] private CameraHorror camOff;
    [Header("Trigger Open Door 62")]
    [SerializeField] private string DoorTrigger62 = "DoorTrigger62";
    [SerializeField] private GameObject boxTrigger62;
    [SerializeField] private BasicDoor door63;
    [Header("Final Jump Scare")]
    [SerializeField] private string DoorTrigger64 = "Creature";
    [SerializeField] private Transform CreatureSpawn;
    [SerializeField] private GameObject boxCreature;
    [SerializeField] private AudioSource creatureSound;
    [SerializeField] private AudioSource creatureJumpScare;
    [SerializeField] private BasicDoor door64;
    [Header("Last Scene")]
    [SerializeField] private string lastTag = "Last";
    [SerializeField] private Transform lastSpawn;
    [SerializeField] private GameObject lastBox;
    private bool lastBool = false;
    [SerializeField] private GameObject lastLight;
    [SerializeField] private GameObject deadScene;

    private bool compeleted = false;
    private bool compeleted2 = false;
    private bool compeleted3 = false;
    private bool completeFade = false;
    private bool isTaken = false;
    private float range = 7f;

    private void Start(){
        jumpScareSound2.loop = true;
        
    }
    private void Update(){
        ActivateJumpScare();
        if(isTaken == true){
            StartCoroutine(TakeControllCam());
        }
    }
    private void ActivateJumpScare(){
        RaycastHit hit;
        if(Physics.Raycast(jumpScareCam.transform.position, jumpScareCam.transform.forward, out hit, range)){
            var selection = hit.transform;
            if(selection.CompareTag(firstJumpScareTag)){
                GameObject first = Instantiate(ghostPrefabs1, firstJumpScare.transform.position, firstJumpScare.transform.rotation) as GameObject;
                Destroy(firstBox);
                Destroy(first, 1f);
            }
            if(selection.CompareTag(jumpScareTag)){
                GhostSpawn.instance.RemakeInstantiate();
                GhostSpawn.instance.JumpScare(jumpScare, jumpScareSound, ghostPrefabs1);
                Destroy(jumpScareBox);
            }
            if(selection.CompareTag(jumpScareTag2)){
                GhostSpawn.instance.RemakeInstantiate();
                GhostSpawn.instance.JumpScare(jumpScare2, jumpScareSound2, ghostPrefabs1);
                StartCoroutine(StopSound());
                Destroy(jumpScareBox2);
                if(autodoor.autoDoorIDChirl == 6){
                    autodoor.doorOpenClose();
                }
                isTaken = true;
            }
            if(selection.CompareTag(jumpScareTag4)){
                DeathBed.instance.OnDeathBed();
                StartCoroutine(AfterDeathBedShake());
            }
            if(selection.CompareTag(jumpScareTag5)){
                DeathChair.instance.OnDeathChair();
                if(deathChairSound.isPlaying == false){
                    deathChairSound.Play();
                }
                StartCoroutine(DestroyChairAnim());
            }
            if(selection.CompareTag(jumpScareTag6)){
                GameObject Ghost3 = Instantiate(ghostPrefabs3, ghostChairSpawn.transform.position, ghostChairSpawn.transform.rotation) as GameObject;
                Destroy(Ghost3, 2);
                if(ghostChair2Sound.isPlaying == false && CreepyLaughChair.isPlaying == false){
                    CreepyLaughChair.Play();
                    ghostChair2Sound.Play();
                }
                Destroy(strangleBox, 3f);
                doorChairClose.doorID = 1;
            }
            if(selection.CompareTag(jumpScareTag7)){
                if(morseDoor.doorID == 21){
                    morseDoor.doorOpenClose();
                    morseTriggerBox2.SetActive(true);
                }
                Destroy(morseTriggerBox);
            }
            if(selection.CompareTag(jumpScareTag8)){
                GameObject ghost4 = Instantiate(ghostPrefabs1, morseGhostSpawn.transform.position, morseGhostSpawn.transform.rotation) as GameObject;
                Destroy(morseTriggerBox2);
                ghost4.GetComponent<GhostMovement>().speed = 50f;
                if(morseGhostSound.isPlaying == false){
                    morseGhostSound.Play();
                }
                Destroy(ghost4, 0.3f);
                StartCoroutine(GetOut());
            }
            if(selection.CompareTag(jumpScareTag9)){
                jumpScareSound2.Stop();
                trumpetSound.Stop();
            }
            if(selection.CompareTag(DoorTrigger61)){
                cameraBox.SetActive(true);
                if(door62.doorID == 62){
                    door62.ID = 62;
                    Destroy(boxTrigger61);
                }
            }
            if(selection.CompareTag(cameraOff)){
                Destroy(PlayerPickUp.instance.crossHairCam);
                Destroy(PlayerPickUp.instance.flashLight);
                Destroy(cameraBox);
            }
            if(selection.CompareTag(DoorTrigger62)){
                if(door63.doorID == 63){
                    door63.ID = 63;
                    Destroy(boxTrigger62);
                }
            }
            if(selection.CompareTag(DoorTrigger64)){
                Debug.Log("creature");
                StartCoroutine(OpenDoor64());
                GameObject creature = Instantiate(ghostPrefabs4, CreatureSpawn.transform.position, CreatureSpawn.transform.rotation) as GameObject;
                Destroy(boxCreature);
                Destroy(creature, 5f);
            }
            if(selection.CompareTag(lastTag)){
                StartCoroutine(LastScene());
                GameObject lastPref = Instantiate(ghostPrefabs1, lastSpawn.transform.position, lastSpawn.transform.rotation) as GameObject;
                Destroy(lastBox);
                Destroy(lastPref, 8f);
                trumpetSound.loop = true;
                if(trumpetSound.isPlaying == false){
                    trumpetSound.Play();
                }
            }
        }
    }
    private IEnumerator LastScene(){
        yield return null;
        lastLight.SetActive(false);
        yield return new WaitForSeconds(2f);
        lastLight.SetActive(true);
        yield return new WaitForSeconds(2f);
        lastLight.SetActive(false);
        yield return new WaitForSeconds(2f);
        lastLight.SetActive(true);
        yield return new WaitForSeconds(2f);
        trumpetSound.Stop();
        lastLight.SetActive(false);
        
        yield return new WaitForSeconds(4f);
        lastLight.SetActive(true);
        if(lastBool == false){
            GameObject lastGhost = Instantiate(ghostPrefabs1, lastSpawn.transform.position, lastSpawn.transform.rotation) as GameObject;
            lastGhost.GetComponent<GhostMovement>().speed = 50f;
            Destroy(lastGhost, 1.5f);
            lastBool = true;
        }
        yield return null;
        if(morseGhostSound.isPlaying == false){
            morseGhostSound.Play();
        }
        yield return new WaitForSeconds(2f);
        deadScene.SetActive(true);

    }
    private IEnumerator OpenDoor64(){
        yield return new WaitForSeconds(2.5f);
        if(creatureJumpScare.isPlaying == false){
            creatureJumpScare.Play();
        }
        yield return new WaitForSeconds(4f);
        if(door64.ID == 64){
            door64.doorID = 64;
        }
    }
    public void GetIDDoorFinal(BasicDoor door64){
        switch(door64.ID){
            case 64:
                if(creatureSound.isPlaying == false){
                    creatureSound.Play();
                }
                if(boxCreature != null){
                    boxCreature.SetActive(true);
                }
                break;
        }
    }
    private IEnumerator GetOut(){
        yield return new WaitForSeconds(1.5f);
        PlayerPickUp.instance.flashLight.SetActive(false);
        if(getOutSound.isPlaying == false){
            getOutSound.Play();
        }
        yield return new WaitForSeconds(5.5f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        bloodyPrint.SetActive(true);
        jumpScareSound2.loop = true;
        if(jumpScareSound2.isPlaying == false){
            jumpScareSound2.Play();
        }
        yield return new WaitForSeconds(6f);
        if(exitOpen.autoDoorID == 10){
            exitOpen.autoDoorIDChirl = 10;
        }
        trumpetSound.loop = true;
        if(trumpetSound.isPlaying == false){
            trumpetSound.Play();
        }
        yield return new WaitForSeconds(2f);
        if(doorBangging.isPlaying == false){
            doorBangging.Play();
        }
        yield return new WaitForSeconds(2f);
        if(screamHorror.isPlaying == false){
            screamHorror.Play();
        }
        yield return new WaitForSeconds(0.2f);
        if(whisper.isPlaying == false){
            whisper.Play();
        }
        
    }
    private IEnumerator DestroyChairAnim(){
        yield return null;
        if(doorChairClose.doorID == 1){
            doorChairClose.doorOpenClose();
            doorChairClose.doorID = 999;
        }
        yield return new WaitForSeconds(6.5f);
        DeathChair.instance.movement.enabled = true;
        DeathChair.instance.deathChairAnim.enabled = false;
    }
    private IEnumerator AfterDeathBedShake(){
        yield return new WaitForSeconds(4f);
        StartCoroutine(camShake.Shake(1.5f, 0.5f));
        if(shakeSound.isPlaying == false){
            shakeSound.Play();
        }
    }
    private IEnumerator TakeControllCam(){
        yield return new WaitForSeconds(5f);
        lockMouse.enabled = false;

        Quaternion targetCam = Quaternion.Euler(2.49f, -90.486f, 0f);
        cameraPos.transform.rotation = Quaternion.Slerp(cameraPos.transform.rotation, targetCam, Time.deltaTime * 2f);
        if(completeFade == false){
            StartCoroutine(GhostGotFade());
            completeFade = true;
        }
        ActiveSatanism.instance.satanCircle.SetActive(false);
        
    }
    private IEnumerator StopSound(){
        yield return new WaitForSeconds(8f);
        jumpScareSound2.Stop();
    }
    private IEnumerator GhostGotFade(){
        
        yield return new WaitForSeconds(2f);
        if(compeleted == false){
            GhostSpawn.instance.RemakeInstantiate();
            GhostSpawn.instance.JumpScare(fade1, fadeAwaySound, ghostPrefabs1);
            compeleted = true;
        }
                
        yield return new WaitForSeconds(2f);
        PlayerPickUp.instance.flashLight.SetActive(false);
        
        
        yield return new WaitForSeconds(2f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        if(compeleted2 == false){
            GhostSpawn.instance.RemakeInstantiate();
            GhostSpawn.instance.JumpScare(fade2, fadeAwaySound, ghostPrefabs2);
            compeleted2 = true;
        }
        
               
        yield return new WaitForSeconds(2f);
        PlayerPickUp.instance.flashLight.SetActive(false);

        yield return new WaitForSeconds(2f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        if(compeleted3 == false){
            GhostSpawn.instance.RemakeInstantiate();
            GhostSpawn.instance.JumpScare(fade3, fadeAwaySound, ghostPrefabs1);
            compeleted3 = true;
        }
        yield return new WaitForSeconds(1f);
        PlayerPickUp.instance.flashLight.SetActive(false);
        isTaken = false;
        yield return new WaitForSeconds(10f);
        PlayerPickUp.instance.flashLight.SetActive(true);
        lockMouse.enabled = true;
        ActiveSatanism.instance.lockMovement.enabled = true;
        
    }
}
