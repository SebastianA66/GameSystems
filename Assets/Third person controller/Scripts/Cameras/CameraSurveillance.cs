//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//namespace ThirdPerosnController
//{
//    public class CameraOrbit : MonoBehaviour
//    {
//        public Transform Target;
//        public bool hideCursor = true; // making the cursor hidden
//        [Header("Orbit")]
//        public Vector3 offset = new Vector3(0, 0, 0);
//        public float xSpeed = 120f; // X orbit speed
//        public float ySpeed = 120f; // Y orbit speed
//        public float yMinLimit = -20f; // Y clamp min
//        public float yMaxLimit = 80f; // Y clamp max
//        public float distanceMin = 0.5f; //Minimum distance to target
//        public float distanceMax = 15f; // Maximum distance to target
//        [Header("Collision")]
//        public bool cameraCollision = true; //Camera collision enabling
//        public float camRadius = 0.3f; // Camera radius
//        public LayerMask ignoreLayers; // Layers ignored by collision
//
//        private Vector3 originalOffset; //Offset from the start of the game
//        private float distance; // current distance to camera
//        private float rayDistance = 1000f; //max distance ray check for collisions
//        private float x = 0f; //X degrees of rotation
//        private float y = 0f; //Y degrees of rotation
//
//        // Use this for initialization
//        void Start()
//        {
//            //Detach camera from parent
//            transform.SetParent(null);
//            //Set Target
//            //Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//            // is the cursor supposed to be hidden
//            if (hideCursor) // if hide cursor is true
//            {
//                Cursor.lockState = CursorLockMode.Locked; //hide the cursor
//                Cursor.visible = false;
//            }
//            //Original offset from target position
//            originalOffset = transform.position - Target.position;
//            // set ray distance to current distance magniture of camera
//            rayDistance = originalOffset.magnitude;
//            //get camera rotation
//            Vector3 angles = transform.eulerAngles;
//            // Set X and Y degrees to current camera rotation
//            x = angles.y;
//            y = angles.x;
//        }
//
//        void FixedUpdate()
//        {
//            // ifa target has been set 
//            if (Target)
//            {
//                // is camera collision enabled?
//                if (cameraCollision)
//                {
//                    // create a ray starting from target position and point backwards from camera
//                    Ray camRay = new Ray(Target.position, -transform.forward);
//                    RaycastHit hit;
//                    //shoot a sphere in defined ray direction
//                    if (Physics.SphereCast(camRay, camRadius, out hit, rayDistance, ~ignoreLayers, QueryTriggerInteraction.Ignore))
//                    {
//                        //set current camera distance to hit objects distance 
//                        distance = hit.distance;
//                        // exit function
//                        return;
//                    }
//                }
//                //set distance to original distance
//                distance = originalOffset.magnitude;
//            }
//        }
//
//        void Update()
//        {
//            //if target has been set
//            if (Target)
//            {
//                //rotate the camera based on mouse x and mouse y inputs
//                x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
//                y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
//                // Clamp the angle using the custom 'ClampAngle' function
//                y = ClampAngle(y, yMinLimit, yMaxLimit);
//                //Rotate the transform using euler angles
//                transform.rotation = Quaternion.Euler(y, x, 0);
//            }
//        }
//
//        void LateUpdate()
//        {
//            // if target has been set
//            if (Target)
//            {
//                //calculate local offset from offset
//                Vector3 localoffset = transform.TransformDirection(offset);
//                // Reposition camera to new position based off distance and offset
//                transform.position = (Target.position + localoffset) + -transform.forward * distance;
//            }
//        }
//
//        //Clamps the angle between -360 and +360 degrees and using the min and max angle
//        public static float ClampAngle(float angle, float min, float max)
//        {
//            if (angle < -360f)
//            {
//                angle += 360;
//            }
//
//            if (angle > 360f)
//            {
//                angle -= 360;
//            }
//
//            return Mathf.Clamp(angle, min, max);
//        }
//
//    }
//    public class CameraSurveillance : MonoBehaviour
//    {
//
//        public Camera[] cameras; //array of cameras to switch between 
//        public KeyCode prevKey = KeyCode.Q; //Filter back to previous cam
//        public KeyCode nextKey = KeyCode.E; //Filter forward to next cam
//        private int camIndex; //Current cam index from array
//        private int camMax; //Max ammount of cams in array
//        private Camera current; //the current camera selected
//                                // Use this for initialization
//        void Start()
//        {
//            //Get all camera children and store into array
//            cameras = GetComponentsInChildren<Camera>();
//            //Last Index of array = Array.Length -1
//            camMax = cameras.Length - 1;
//            //Activate the default camera
//            ActivateCamera(camIndex);
//        }
//
//        void ActivateCamera(int camIndex)
//        {
//            for (int i = 0; i < cameras.Length; i++)
//            {
//                Camera cam = cameras[i];
//                //if the current index matches the camIndex
//                if (i == camIndex)
//                {
//                    //enable this camera
//                    cam.gameObject.SetActive(true);
//                }
//                else
//                {
//                    // disable camera
//                    cam.gameObject.SetActive(false);
//                }
//            }
//        }
//
//
//        // Update is called once per frame
//        void Update()
//        {
//            //if the next key is pressed 
//            if (Input.GetKeyDown(nextKey))
//            {
//                //increase index
//                camIndex++;
//                if (camIndex > camMax)
//                {
//                    camIndex = 0;
//                }
//                ActivateCamera(camIndex);
//            }
//
//            //if the next key is pressed 
//            if (Input.GetKeyDown(prevKey))
//            {
//                //increase index
//                camIndex--;
//                if (camIndex < 0)
//                {
//                    camIndex = camMax;
//                }
//                ActivateCamera(camIndex);
//            }
//        }
//    }
//}
//
//