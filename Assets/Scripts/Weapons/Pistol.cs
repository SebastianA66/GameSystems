using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack()          
    {
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation); //Instantiate a new bullet from prefab bullet
            Bullet newBullet = clone.GetComponent<Bullet>(); //Get the component from the new bullet
            newBullet.Fire(transform.forward); //Tell the bullet to fire
    }
  
}
