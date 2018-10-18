using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class Explosive : Projectile
    {

        public float explosionRadius = 5f;
        //  public GameObject explosion;

        public override void OnCollisionEnter(Collision col)
        {
            Explode();
            Effects();
            Destroy(gameObject);
        }

        void Effects()
        {
            Instantiate(particle, transform.position, transform.rotation);
        }

        void Explode()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var hit in hits)
            {
                Enemy e = hit.GetComponent<Enemy>();
                if (e)
                {
                    e.DealDamage(damage);
                }
            }
        }
    }

}