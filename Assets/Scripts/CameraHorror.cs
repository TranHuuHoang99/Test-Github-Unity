using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraHorror : MonoBehaviour
{
    public static CameraHorror instance;
    private void Awake(){
        instance = this;
    }
    public bool on = false;
    public AudioSource snapSound;
    public AudioSource cameraOn;
    public AudioSource zoomingSound;
    private Camera onLiveZooming;
    [SerializeField] private Image recordRedDot;
    private float targetZoom;
    private float zoomFactor = 2f;
    private float zoomSpeed = 2f;
    public bool onAll = true;
    
    private void Start(){
        PlayerPickUp.instance.crossHairCam.SetActive(false);
        StartCoroutine(RecordingDot());
        onLiveZooming = Camera.main;
        targetZoom = 60f;
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.C) && on == true){
            OffCrossHairCam();
            if(cameraOn.isPlaying == false){
            cameraOn.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            if(on == true && PlayerPickUp.instance.crossHairCam != null){
                if(snapSound.isPlaying == false){
                    snapSound.Play();
                }
                TakeASnap();
            }
        }
        if(on == true){
            ZoomCameraLive();
        }
    }
    public void OnCrossHairCam(){
        if(PlayerPickUp.instance.crossHairCam != null){
            PlayerPickUp.instance.crossHairCam.SetActive(true);
        }
        if(cameraOn.isPlaying == false){
            cameraOn.Play();
        }
        if(onAll == true){
            on = true;
        }
    }
    public void OffCrossHairCam(){
        if(PlayerPickUp.instance.crossHairCam != null && PlayerPickUp.instance.flashLight != null){
            PlayerPickUp.instance.crossHairCam.SetActive(false);
            PlayerPickUp.instance.flashLight.SetActive(false);
        }
        onLiveZooming.fieldOfView = 60f;
        on = false;
    }
    private void TakeASnap(){
        PlayerPickUp.instance.flashLight.SetActive(true);
    }
    private IEnumerator RecordingDot(){
        while(true){
            yield return new WaitForSeconds(0.8f);
            if(recordRedDot != null){
                recordRedDot.enabled = false;
            }
            yield return new WaitForSeconds(0.8f);
            if(recordRedDot != null){
                recordRedDot.enabled = true;
            }
        }
    }
    private void ZoomCameraLive(){
        float scroll = 0.1f;
        if(Input.GetKey(KeyCode.V)){
            targetZoom -= scroll * zoomFactor;
            if(targetZoom <= 30f){
                targetZoom = 30f;
            }
            if(zoomingSound.isPlaying == false){
                zoomingSound.Play();
            }
        }
        else if(Input.GetKey(KeyCode.B)){
            targetZoom += scroll * zoomFactor;
            if(targetZoom >= 60f){
                targetZoom = 60f;
            }
            if(zoomingSound.isPlaying == false){
                zoomingSound.Play();
            }
        }
        onLiveZooming.fieldOfView = Mathf.Lerp(onLiveZooming.fieldOfView,targetZoom, Time.deltaTime*zoomSpeed);
    }
    public void OffForever(){
        onAll = false;
    }
}
