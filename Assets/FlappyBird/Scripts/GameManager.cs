using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        public void Awake()
        {
            // Reference the first instance of GameManager
            Instance = this;
        }
        private void OnDestroy()
        {
            // Deference he destroyed instance
            Instance = null;
        }
        #endregion

        public int score = 0;
        public bool isGameOver = false;

        public delegate void IntCallBack(int number);
        public IntCallBack scoreAdded;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int scoreToAdd)
        {
            // Is the game over?
            if (isGameOver)
                // Exit the function. 
                return;
            // Add Score
            score += scoreToAdd;

            // Call subscribers
            scoreAdded.Invoke(score);
        }
    }

}
