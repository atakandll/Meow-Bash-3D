using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GameManager : MonoBehaviour
    {
        public bool GameStartarted = false;

        public int Level = 1;
        public GameObject[] rooms;
        public GameObject[] tutorials;

        private void Awake()
        {
            for (int i = 1; i <= rooms.Length; i++)
            {
                if(i<=Level)
                    rooms[i-1].SetActive(true);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !GameStartarted)
            {
                GameStartarted = true;
                tutorials[0].SetActive(false);
            }
        }
    }
}

