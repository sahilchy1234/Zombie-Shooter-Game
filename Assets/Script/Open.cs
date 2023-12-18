using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject objectToOpen;
    public GameObject[] objectsToOpen;

    public void Awake()
    {
        objectToOpen.SetActive(true);

        if (objectsToOpen.Length != 0)
        {
            for (int i = 0; i < objectsToOpen.Length; i++)
            {
               objectsToOpen[i].SetActive(true);
            }
        }
    }
}
