using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird
{
    public class FlappyScore : MonoBehaviour
    {
        public Sprite[] numbers;
        public GameObject scoreTextPrefab;
        public Vector3 standbyPos = new Vector3(-15, 15);
        public int maxDigits;

        private GameObject[] scoreTextPool;
        private int[] digits;

        // Use this for initialization
        void Start()
        {            
            SpawnPool();
            // Subscribe to scoreAdded function to game manager
            GameManager.Instance.scoreAdded += RefreshScore;
            // Update score to start on zero
            RefreshScore(0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RefreshScore(int score)
        {
            // Convert score into array of digits
            int[] digits = GetDigits(score);
            // Loop throuh all digits
            for(int i = 0; // Initialisation
                i < digits.Length; // Condition
                i++) // Increment
            {
                // Get value of each digit
                int value = digits[i];
                // Get corresponding text element in pool
                GameObject textElement = scoreTextPool[i];
                // Get Image component attached to it
                Image img = textElement.GetComponent<Image>();
                // Assign sprite to number using value
                img.sprite = numbers[value];
                // Activate text element
                textElement.SetActive(true);

            }
            // Loop through all remianding text elements in the pool
            for (int i = digits.Length; i < scoreTextPool.Length; i++)
            {
                // Deactivate that element
                scoreTextPool[i].SetActive(false);
            }

        }

        void SpawnPool()
        {
            // Allocate memory for the score text pool
            scoreTextPool = new GameObject[maxDigits];
            // Loop through all available digits
            for (int i = 0; i < maxDigits; i++)
            {
                //Create a new game object offscreen. 
                GameObject clone = Instantiate(scoreTextPrefab, standbyPos, Quaternion.identity);
                // Get the image component attached to the clone
                Image img = clone.GetComponent<Image>();
                //Set sprite to corresponding number sprite.
                img.sprite = numbers[i];
                // Attach to self
                clone.transform.SetParent(transform);
                //Set name of text to images
                clone.name = i.ToString();
                // add it to pool
                scoreTextPool[i] = clone;
               
            }

        }
        // Converts numbers into a array of single digits
        int[] GetDigits(int number)
        {
            List<int> digits = new List<int>();
            // While numbers is greater than 10
            while (number >= 10)
            {
                // Modulus by 10 and rerurn remainder
                digits.Add(number % 10);
                // Divide total number by 10
                number /= 10;

            }
            // Add last number to digit
            digits.Add(number);
            //Flip the array around (it's backwards)
            digits.Reverse();
            // Return to array
            return digits.ToArray();
        }
    }
}

