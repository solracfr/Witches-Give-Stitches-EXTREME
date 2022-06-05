using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //create a public method TakeDamage()
    public void TakeDamage(float damageDealt)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageDealt;
        
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) { return; }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
