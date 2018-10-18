using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class Door : Interactable
    {

        public bool isOpen = false;
        public Animator anim;


        //public override void Interact()
        //{
        //    bool isOpen = anim.GetBool("IsOpen"); // Toggle isOpen
        //    anim.SetBool("IsOpen", isOpen); // Animate door
        //}
    }
}

