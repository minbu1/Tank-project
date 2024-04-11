using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLootBox : MonoBehaviour
{
    public GameObject bulletPrefab;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            player.bulletPrefab = bulletPrefab;
            Destroy(gameObject);
        }
    }
}
