using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.y = (target.position + offset).y;
        transform.position = position;
    }

}

