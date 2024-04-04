using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;

    public UnityEvent<int, int> onDamage;
    public UnityEvent onDie;

    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onDamage.Invoke(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            onDie.Invoke();
        }
    }
}
