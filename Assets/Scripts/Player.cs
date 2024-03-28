using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    Rigidbody rb;
    Vector3 input = new Vector3();

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //InvokeRepeating(Function name, time to start, repeat rate)
        InvokeRepeating(nameof(Fire), fireRate, fireRate);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.x = Input.GetAxisRaw("Vertical");

        transform.forward = input;
    }

    private void FixedUpdate()
    {
        //input.y = rb.velocity.y;
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
    }
}
