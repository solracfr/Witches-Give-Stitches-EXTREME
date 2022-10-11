using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target; // faster to do than grabbing a Transform
    [SerializeField] float damage = 20f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); // hones in on the Player, since there's just one
    }

    public void AttackHitEvent() // this function is called via the AnimationEvent in the Editor 
    {
        if (target == null) { return; }
        target.TakeDamage(damage);
    }

    public void OnDamageTaken()
    {
        Debug.Log(name + "I also know that we took damage.");
    }

}
