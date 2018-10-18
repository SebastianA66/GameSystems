using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class Incindiary : Projectile
    {
        public float dotDuration = 2f;

        public override void OnCollisionEnter(Collision col)
        {
            Enemy e = col.collider.GetComponent<Enemy>();
            if (e)
            {
                Burn(e);
            }
        }

        IEnumerator Burn(Enemy enemy)
        {
            yield return new WaitForSeconds(dotDuration);
            enemy.DealDamage(damage);
            StartCoroutine(Burn(enemy));
        }
    }
}

