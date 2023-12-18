using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonation : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player"){
       Popup_Manager.instance.ShowPopupMessage("Bomb Detonated");
        HostageManager.instance.Exploded();
    }
   }
}
