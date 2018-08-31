using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public KeyCode fireButton;

    private void Update()
    {
        if(Input.GetKeyDown(fireButton)) //if fire button is pressed
        {
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation); //Instantiate a new bullet from prefab bullet
            Bullet newBullet = clone.GetComponent<Bullet>(); //Get the component from the new bullet
            newBullet.Fire(transform.forward); //Tell the bullet to fire
        }
    }

}
