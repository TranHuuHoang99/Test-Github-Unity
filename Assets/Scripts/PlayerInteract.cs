using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract instance;
    private void Awake(){
        instance = this;
    }
    [SerializeField] private Camera fpsCam;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private GameObject blurEffect;
    private float range = 7f;
    private Transform _selection;
    public GameObject textElement;
    private CameraHorror itemCamera;
    private int redCol = 255;
    private int greenCol= 255;
    private int blueCol = 255;
    private Color highlightColor;
    private float intensity = 2;

    private void Start(){
        textElement.SetActive(false);
        highlightColor = new Color(redCol * intensity, greenCol * intensity, blueCol * intensity);
        
    }
    private void Update(){
        Interactable();
    }
    private void Interactable(){
        if(_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.color = new Color32(255,255,255,255);
            textElement.SetActive(false);
            _selection = null;
        }
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag)){
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null){
                    selectionRenderer.material.color = highlightColor;
                    textElement.SetActive(true);
                }
                _selection = selection;
            }
            if(selection.CompareTag(selectableTag)){
                var itemSelection = selection.GetComponent<ItemScripts>();
                if(Input.GetKeyDown(KeyCode.E) && itemSelection != null){
                    blurEffect.SetActive(true);
                    InspectorScript.instance.ShowCursorMouse();
                    itemSelection.ItemPicked();
                    PlayerPickUp.instance.inspectorCamera.SetActive(true);
                    textElement.SetActive(false);
                }
            }
        }
    }
}
