﻿using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(GameObjectManager))]
    public class GameManager : MonoBehaviour
    {
        public GameObjectManager GameObjectManager
        {
            get { return this.gameObject.GetComponent<GameObjectManager>(); }
        }

        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject); // sets this to not be destroyed when reloading scene 
            }
            else
            {
                if (Instance != this)
                {
                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                    Destroy(gameObject);
                }
            }

            Initialize();
        }

        public void Initialize()
        {
            GameObjectManager.Initialize();
        }
    }
}
