using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorImg : MonoBehaviour
{
    
    public float RotateX = 0; 
    public float RotateY = 0; 
    public float RotateZ = 0; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateX,RotateY,RotateZ);
    }
}
