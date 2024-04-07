using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 3;
    public int damage = 10;

    [Header("VFX")]
    public GameObject explosionVFX;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(explosionVFX, transform.position, Quaternion.identity);

        var enemy = collision.gameObject.GetComponent<Health>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
