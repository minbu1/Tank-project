using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))] // Added to enable audio playback

public class Player : MonoBehaviour
{
    public bool player1 = true;

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    public AudioClip movingSound; // Sound clip for when the player is moving
    public AudioClip standingSound; // Sound clip for when the player is standing still

    [Header("UI")]
    public Transform healthBar;

    [Header("VFX")]
    public GameObject dustVFX;

    private Rigidbody rb;
    private AudioSource audioSource; // Reference to the AudioSource component
    private Vector3 input = Vector3.zero; // Initialized as zero vector

    private bool isMoving = false; // Track if the player is moving or not

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Getting the AudioSource component

        //InvokeRepeating(Function name, time to start, repeat rate)
        InvokeRepeating(nameof(Fire), fireRate, fireRate);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }

    void Update()
    {
        if (player1)
        {
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrow");
            input.z = Input.GetAxis("VerticalArrow");
        }

        // Checking if the player is moving or not
        if (input != Vector3.zero)
        {
            transform.forward = input;

            if (!dustVFX.activeSelf)
                dustVFX.SetActive(true);

            isMoving = true;
            transform.forward = input;
        }
        else
        {
            if (!dustVFX.activeSelf)
                dustVFX.SetActive(false);

            isMoving = false;
        }


        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.clip = movingSound;
            audioSource.Play();
        }
        else if (!isMoving && !audioSource.isPlaying)
        {
            audioSource.clip = standingSound;
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        //input.y = rb.velocity.y;
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.localScale = new Vector3((float)currentHealth / maxHealth, 1, 1);
    }
}