using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //create a public method TakeDamage()
    public void TakeDamage(float damageDealt)
    {
        hitPoints -= damageDealt;
        
        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
