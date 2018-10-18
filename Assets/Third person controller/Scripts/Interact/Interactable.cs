using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class Interactable : MonoBehaviour
    {
        protected virtual void Interact()
        {
            print("interactable base class called!");
        }

    }
}

