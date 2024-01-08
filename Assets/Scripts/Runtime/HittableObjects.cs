using System;
using UnityEngine;

namespace Runtime
{
    public class HittableObjects : MonoBehaviour
    {
        public int Points = 50;
        public int coins;

        private void Awake()
        {
            coins = PlayerPrefs.GetInt("coins", 1);
        }
    }
}