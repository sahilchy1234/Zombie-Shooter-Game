using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
   public GameObject _object;

   private void OnDisable()
   {
     _object.SetActive(true);
   }


}
