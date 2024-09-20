using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorImg : MonoBehaviour
{

    public Vector3 rotateSpeed = new Vector3(0f,0f,0f);


    // Update is called once per frame
    private void Start()
    {
        //
    }
    void Update()
    {
        transform.Rotate(rotateSpeed.x, rotateSpeed.y, rotateSpeed.z);
        // Quaternion rotation = Quaternion.Euler(rotateSpeed * Time.deltaTime);
        // transform.rotation *= rotation;
    }
}
