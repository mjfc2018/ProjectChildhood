using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    
    public GameObject target;
    public float verticalOffset;

    void FixedUpdate()
    {
        transform.position = new Vector3(0, verticalOffset + target.transform.position.y, transform.position.z);
    }
}
