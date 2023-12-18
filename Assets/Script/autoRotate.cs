using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotate : MonoBehaviour
{
       // Speed of rotation (degrees per second)
    public float rotationSpeed = 10f;

    // Axis to rotate around (default: Y axis)
    public Vector3 rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
