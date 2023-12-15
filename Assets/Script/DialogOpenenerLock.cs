using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogOpenenerLock : MonoBehaviour
{
    public GameObject dialogObject;
    private string scene_name;
    

  
     void Start()
    {
          Scene scene = SceneManager.GetActiveScene();
          scene_name = scene.name;
    }


    void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player"){
      dialogObject.SetActive(true);
      
      if(scene_name == "Level 3"){
        if(keyManager.instance.keyPicked){
           HostageManager.instance.Exploded();
        }
      }
    }
   }
}
