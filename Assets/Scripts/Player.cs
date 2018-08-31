using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CTRL + K + D

public class Player : MonoBehaviour
{
    public bool rotateToMainCamera = false;
    public Transform weapon;
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public Rigidbody rigid;
    public float rayDistance = 1f;
    public LayerMask ignoreLayers;

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }

    private bool isGrounded = false;

   

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
   // private void OnCollisionEnter(Collision collision)
   // {
       
   // }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true; //is grounded
        }
        return false; // is not grounded
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

       Vector3 camEuler = Camera.main.transform.eulerAngles;

        if(rotateToMainCamera)
        {
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            force.y = jumpHeight;
        }

        rigid.velocity = force;

        //if(moveDir.magnitude > 0)
        // {
        // Rotate the player to that moveDir
        //transform.rotation = Quaternion.LookRotation(moveDir);
        // }
        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        Quaternion weaponRotaton = Quaternion.AngleAxis(camEuler.x, Vector3.right);
        weapon.localRotation = weaponRotaton; 
        transform.rotation = playerRotation;
    }

}