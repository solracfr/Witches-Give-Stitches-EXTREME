using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target; // where it is in the world

    [SerializeField] float chaseRadius = 5f; // how far until enemy begins chasing

    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;

    EnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead()) // if enemy is Dead, stop chasing us pls
        {
            enabled = false; // refers to the checkbox on this script as seen in the inspector (EnemyAI.cs)
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRadius)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget(); // begin facing target we wanna attack

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        //Debug.Log($"{name} has seeked and is destroying {target.name}");
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation =
            Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation =
            Quaternion
                .Slerp(transform.rotation,
                lookRotation,
                Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
