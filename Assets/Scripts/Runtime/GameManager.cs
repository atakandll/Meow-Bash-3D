using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GameManager : MonoBehaviour
    {
        public int Level = 1;
        public GameObject[] rooms;

        private void Awake()
        {
            for (int i = 1; i <= rooms.Length; i++)
            {
                if(i<=Level)
                    rooms[i-1].SetActive(true);
            }
        }
    }
}

