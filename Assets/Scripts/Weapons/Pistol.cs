using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack()          
    {
            GameObject clone = Instantiate(projectile, spawnPoint.transform.position, transform.rotation); //Instantiate a new bullet from prefab bullet
            Projectile newProjectile = clone.GetComponent<Projectile>(); //Get the component from the new projectile
            newProjectile.Fire(transform.forward); //Tell the projectile to fire
    }
  
}
