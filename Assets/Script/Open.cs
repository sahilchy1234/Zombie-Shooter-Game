using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject objectToOpen;
  
   public void Awake()
   {
    objectToOpen.SetActive(true);
   }
}
