﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class PlayerInput : MonoBehaviour
    {
        public Player player;
        public int weaponIndex = 0;


        private void Start()
        {
            // Select the first weapon
            player.SelectWeapon(weaponIndex);
        }

        // Update is called once per frame
        void Update()
        {
            WeaponSwitch();

            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            player.Move(inputH, inputV);

            if (Input.GetButtonDown("Jump"))
            {
                player.Jump();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                player.Attack();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                player.Interact();
            }
        }

        private void WeaponSwitch()
        {
            int currentIndex = weaponIndex;
            // If Q is pressed && weaponIndex > 0
            if (Input.GetKeyDown(KeyCode.Q) && weaponIndex > 0)
            {
                // decrement weaponIndex
                weaponIndex--;
            }
            // If E is pressed && weaponIndex <= length
            if (Input.GetKeyDown(KeyCode.E) && weaponIndex <= player.weapons.Length)
            {
                // increment weaponindex
                weaponIndex++;
            }
            // If currentIndex has changed
            if (currentIndex != weaponIndex)
            {
                // Update weapon index
                weaponIndex = currentIndex;
                // Select weaponIndex
                player.SelectWeapon(weaponIndex);
            }


        }
    }
}

