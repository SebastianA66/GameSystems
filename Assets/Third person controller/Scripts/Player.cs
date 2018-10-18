using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CTRL + K + D

namespace ThirdPerosnController
{
    public class Player : MonoBehaviour
    {
        public bool rotateToMainCamera = false;
        public bool rotateWeapon = false;


        public float moveSpeed = 5f;
        public float jumpHeight = 10f;
        public Rigidbody rigid;
        public float rayDistance = 1f;
        public LayerMask ignoreLayers;
        public Weapon[] weapons;

        private Weapon currentWeapon;
        private bool isGrounded = false;
        private Vector3 moveDir;
        private bool isJumping;

        private void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
        }





        // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
        // private void OnCollisionEnter(Collision collision)
        // {

        // }

        private bool IsGrounded()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(groundRay, out hit, rayDistance, ~ignoreLayers))
            {
                return true; //is grounded
            }
            return false; // is not grounded
        }

        // Update is called once per frame
        private void Update()
        {


            Vector3 camEuler = Camera.main.transform.eulerAngles;

            if (rotateToMainCamera)
            {
                moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
            }

            Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

            if (isJumping && IsGrounded())
            {
                force.y = jumpHeight;
                isJumping = false;
            }

            rigid.velocity = force;

            //if(moveDir.magnitude > 0)
            // {
            // Rotate the player to that moveDir
            //transform.rotation = Quaternion.LookRotation(moveDir);
            // }
            Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
            transform.rotation = playerRotation;

            if (rotateWeapon)
            {
                Quaternion weaponRotaton = Quaternion.AngleAxis(camEuler.x, Vector3.right);
                currentWeapon.transform.localRotation = weaponRotaton;
            }


        }

        private void DisableAllWeapons()
        {
            // Loop through every weapon
            foreach (Weapon weapon in weapons)
            {
                // Deactivate weapon's GameObject
                weapon.gameObject.SetActive(false);
            }

        }

        // Selects and switches out the current weapon
        public void SelectWeapon(int index)
        {
            //check index is within range of weapons array
            // is within range i >= 0 && i < length
            // is not within range i < 0 && i >= length
            if (index < 0 || index >= weapons.Length)
                return;
            // Disable all weapons
            DisableAllWeapons();
            // Enable weapon at index
            weapons[index].gameObject.SetActive(true);

            // Set the currentWeapon
            currentWeapon = weapons[index];
        }
        public void Move(float inputH, float inputV)
        {
            moveDir = new Vector3(inputH, 0f, inputV);
            moveDir *= moveSpeed;
        }

        public void Jump()
        {
            isJumping = true;
        }

        public void Attack()
        {
            currentWeapon.Attack();
        }
        public void Interact()
        {
            // If interactable is found
            //if (interactObject)
            //{
            //    // Run interact
            //    interactObject.Interact();
            //}
        }
    }
}
