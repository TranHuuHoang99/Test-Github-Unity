using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] prefsBox;
    public float repeatTime = 1/2f;
    public float delayTime = 2f;
    public int option = 1;

    //auto spawn a random box
    public void Spawn(){
        int randomOption = Random.Range(0, prefsBox.Length);
        int randomSpawn = Random.Range(0, spawnPos.Length);
        GameObject box = Instantiate(prefsBox[randomOption], spawnPos[randomSpawn].transform.position, spawnPos[randomSpawn].transform.rotation) as GameObject;
        Destroy(box, 10f);
    }

    private void ChangeOption(){
        option = 1;
    }

    private void Start(){
        InvokeRepeating("ChangeOption", 2, 1);
    }
    private void Update(){
        switch(option){
            case 0:
                break;
            case 1:
                Spawn();
                option = 0;
                break;
        }
    }
}
