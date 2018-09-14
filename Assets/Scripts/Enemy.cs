using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//CTRL + M + O/P
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float hitDelay = 1f;
    public Color hitColor = Color.red;

    public Transform target;
    public NavMeshAgent agent;
    public Renderer rend;

    private Color originalColor;

    private void Start()
    {
        originalColor = rend.material.color;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    IEnumerator Hit()
    {
        rend.material.color = hitColor;
        yield return new WaitForSeconds(hitDelay);
        rend.material.color = originalColor;
    }
    public void DealDamage(int damageDealt)
    {
        StartCoroutine(Hit());

        health -= damageDealt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}