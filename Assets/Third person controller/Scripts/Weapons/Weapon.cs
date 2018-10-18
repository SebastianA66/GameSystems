using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public abstract class Weapon : MonoBehaviour
    {
        public int damage = 100;
        public int ammo = 30;
        public float accuracy = 1f;
        public float range = 10f;
        public float rateoffire = 5f;
        public GameObject projectile;
        public Transform spawnPoint;
        protected int currentAmmo = 0;

        public abstract void Attack();

        public void Reload()
        {
            currentAmmo = ammo;
        }

    }
}

