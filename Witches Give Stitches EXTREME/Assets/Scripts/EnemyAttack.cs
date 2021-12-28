using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target; // faster to do than grabbing a Transform
    [SerializeField] float damage = 40f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); // hones in on the Player, since there's just one
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.TakeDamage(damage);
    }

}
