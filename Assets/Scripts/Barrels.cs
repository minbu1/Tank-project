using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    public int damage = 20;
    public float range = 3;

    public override void Destroy()
    {
        var healths = FindObjectOfType<Health>();
        foreach (var health in healths)
        {
            if (Vector3.Distance(health.transform.position, transform.position) < range)
                health.TakeDamage(damage);
        }
    }
}
