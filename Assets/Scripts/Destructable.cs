using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject vfx;

    public virtual void Destroy()
    {
        Instantiate(vfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
