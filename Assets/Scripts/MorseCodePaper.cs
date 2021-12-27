using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCodePaper : MonoBehaviour
{
    public static MorseCodePaper instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] private GameObject text;
    public AudioSource morseCodeOpen;

    private void Start(){
        text.SetActive(false);
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            OffMorseText();
        }
    }
    public void OnMorseText(){
        if(morseCodeOpen.isPlaying == false){
            morseCodeOpen.Play();
        }
        text.SetActive(true);
    }
    public void OffMorseText(){
        text.SetActive(false);
    }
}
