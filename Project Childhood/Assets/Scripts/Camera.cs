using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    public GameObject target;
    public float verticalOffset;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, verticalOffset + target.transform.position.y, transform.position.z);
    }
}
