using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogOpenenerLock : MonoBehaviour
{
  public GameObject keyLock_Object;
  public GameObject dialogObject;
  private string scene_name;



  void Start()
  {
    Scene scene = SceneManager.GetActiveScene();
    scene_name = scene.name;
  }


  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      dialogObject.SetActive(true);

      if (scene_name == "Level 3")
      {
        if (keyManager.instance.keyPicked)
        {
          HostageManager.instance.Exploded();
          keyLock_Object.SetActive(false);
        }
      }

      if (scene_name == "Level 4")
      {
        if (keyManager.instance.keyPicked)
        {
          HostageManager.instance.Exploded();
          keyLock_Object.SetActive(false);

        }
      }

      if (scene_name == "Level 5")
      {
        if (keyManager.instance.keyPicked)
        {
          HostageManager.instance.Exploded();
          keyLock_Object.SetActive(false);

        }
      }

      if (scene_name == "Level 6")
      {
        if (keyManager.instance.keyPicked)
        {
          HostageManager.instance.Exploded();
          keyLock_Object.SetActive(false);
        }
      }
    }
  }
}
