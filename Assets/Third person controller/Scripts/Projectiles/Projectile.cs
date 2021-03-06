﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class Projectile : MonoBehaviour
    {
        public int damage = 100;
        public float speed = 5f;
        public float range = 50f;
        public GameObject impact;
        public Rigidbody rigid;
        public ParticleSystem particle;

        public virtual void Fire(Vector3 direction)
        {
            rigid.AddForce(direction * speed, ForceMode.Impulse);
        }
        public virtual void OnCollisionEnter(Collision collision)
        {

        }

    }
}

