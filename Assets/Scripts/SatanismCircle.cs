using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanismCircle : MonoBehaviour
{   
    public static SatanismCircle instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] private GameObject satanismOnActive;
    private bool hintChecked2 = false;
    private bool hintChecked3 = false;
    private bool hintChecked4 = false;
    private bool hintChecked5 = false;
    private bool hintChecked6 = false;
    private void Update(){
        if(hintChecked2 && hintChecked3 == true && hintChecked4 == true && hintChecked5 && hintChecked6 == true){
            if(satanismOnActive != null){
                satanismOnActive.SetActive(true);
            }
        }
    }
    public void GiveHintOut(DoubleAutoDoor deathNumbs){
        int hintNumbs = deathNumbs.autoDoorIDChirl;
        switch(hintNumbs){
            case 2:
                hintChecked2 = true;
                break;
            case 3:
                hintChecked3 = true;
                break;
            case 4:
                hintChecked4 = true;
                break;
            case 5:
                hintChecked5 = true;
                break;
            case 6:
                hintChecked6 = true;
                break;
            default:
                break;
        }
    }
}
