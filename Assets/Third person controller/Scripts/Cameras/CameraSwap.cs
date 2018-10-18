using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPerosnController
{
    public class CameraSwap : MonoBehaviour
    {
        public Transform[] lookObjects; //array of objects to look at
        public bool smooth = true; //is smooth enabled
        public float damping = 6; //smoothness value of camera
        [Header("GUI")]
        // public float scrW;
        // public float scrH;
        public int x = 10;
        public int y = 79;
        public int width = 50;
        public int height = 30;

        private int camIndex; //index into array of lookObjects
        private int camMax; //stores the total ammount of lookObjects
        private Transform target; //current target look object

        // Use this for initialization
        void Start()
        {
            //Last index of array
            camMax = lookObjects.Length - 1;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            //Get current object to look at
            target = lookObjects[camIndex];
            //if target is not null
            if (target)
            {
                //is smoothing enabled
                if (smooth)
                {
                    //calculate direction to look at target
                    Vector3 lookDirection = target.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(lookDirection);
                    //look at and dampen the rotation
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
                }
                else
                {
                    //look at the target without the smooth and dampen
                    transform.LookAt(target);
                }
            }
            else
            {
                //keep swapping cameras until a valid target is found
                CamSwap();

            }
        }

        void CamSwap()
        {
            //increase index by 1 to select next object
            camIndex++;

            //if index is greater than our max array size
            if (camIndex > camMax)
            {
                //reset camIndex back to zero
                camIndex = 0;
            }

        }
        // private void OnGUI()
        //  {
        // if(scrW != Screen.width / 16 || scrH != Screen.height/ 9)
        //    {
        //   scrW = Screen.width / 16;
        //   scrH = Screen.height / 9;
        //    }
        //  if (GUI.Button(new Rect(0.5f*scrW, 0.25f*scrH, 1.5f*scrW, 0.75f*scrH), "Swap"))
        //    {
        //Swap the cameras
        //   CamSwap();
        //   }
        // }
        void OnGUI()
        {
            if (GUI.Button(new Rect(x, y, width, height), "Swap"))
            {
                CamSwap();
            }
        }
    }
}

