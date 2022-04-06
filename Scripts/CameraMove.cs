using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour{

    public Transform target;
    public float cameraSpeed = 0.15f;
    public Vector3 offset;

    void FixedUpdate(){
        transform.position = target.position + offset;

        transform.LookAt(target);
    } 
    

}
