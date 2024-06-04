using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health;
    public float invincibility = 1f;
    private float cooldown = 0f;

    public UnityEvent onDeath;

    void FixedUpdate()
    {
        if (cooldown > 0) cooldown -= Time.fixedDeltaTime;
    }

    public void Damage(float damage) {
        if (cooldown > 0) return;

        
        print(string.Format("{0} took {1} damage.", gameObject.name, damage));

        health -= damage;
        cooldown = invincibility;
        if (health <= 0) {
            onDeath.Invoke();
        }
    }
}
