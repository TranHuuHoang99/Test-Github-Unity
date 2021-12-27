using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScene : MonoBehaviour
{
    private void Update(){
        Time.timeScale = 0f;
    }
    public void Quit(){
        Application.Quit();
    }
}
