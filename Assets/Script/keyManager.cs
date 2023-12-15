using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyManager : MonoBehaviour
{
    public MeshRenderer _meshRenderer;
    public static keyManager instance;
    public bool keyPicked;

    private void Awake()
    {
        instance = this;
    }
   private void OnTriggerEnter(Collider other) {

    if(other.gameObject.tag == "Player"){
        keyPicked = true;
        _meshRenderer.enabled = false;
        Popup_Manager.instance.ShowPopupMessage("Key Picked Up");
    }
   }
}
