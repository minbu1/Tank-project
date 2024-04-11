using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float heightOffset = 2f;

    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target.transform.position + Vector3.up * heightOffset);
    }
}
