﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Repeat : MonoBehaviour
    {
        public float moveSpeed = 10f;
        public bool isRepeating = true;
        public SpriteRenderer rend;
        private float width;

        // Use this for initialization
        void Start()
        {
            if(rend)
            {
                // Get width from collider and scale by transform
                width = rend.bounds.size.x;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            // Get position
            Vector3 pos = transform.position;

            float timeScale = GameManager.Instance.timeScale;
            // Move position
            pos += Vector3.left * moveSpeed * Time.deltaTime * timeScale;
            //IF leaving left side if screen and is repeating
            if (pos.x < -width && isRepeating)
            {
                // Repeat = Move to opposite side of screen
                float offset = (width - .01f) * 2;
                Vector3 newPosition = new Vector3(offset, 0, 0);
                pos += newPosition;
            }

            transform.position = pos;
        }
    }
}

