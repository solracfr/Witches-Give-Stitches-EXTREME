using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //create a public method TakeDamage()
    public void TakeDamage(float damageDealt)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageDealt;
        
        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
