using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int pellets = 6;
    

    public override void Attack()
    {
        Vector3 direction = transform.forward;// Store forward direction of player
        Vector3 spread = Vector3.zero; // Calculate spread by using range
        spread += transform.up * Random.Range(-accuracy, accuracy); //Offset on local Y
        spread += transform.right * Random.Range(-accuracy, accuracy); //Offset on local X
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation); //Instantiate a new bullet from prefab bullet
        Bullet newBullet = clone.GetComponent<Bullet>(); //Get the component from the new bullet
        newBullet.Fire(transform.forward); //Tell the bullet to fire
    }

}
