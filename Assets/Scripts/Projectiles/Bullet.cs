using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 5f;
    public Rigidbody rigid;

    public void Fire(Vector3 direction) //method for firing the bullet using rigidbody
    {
        rigid.AddForce(direction * speed, ForceMode.Impulse); // add a force in the given 'direction' variable and use impulse
    }

    void OnTriggerEnter(Collider other) //when the bullet hits an object this function is called
    {
        Enemy enemy = other.GetComponent<Enemy>(); //Get the enemy component from it
        if (enemy) //If it is indeed an enemy 
        {
            enemy.DealDamage(damage); //Deal damage to the enemy
            Destroy(gameObject); //Destroy the bullet
        }
    }
}
