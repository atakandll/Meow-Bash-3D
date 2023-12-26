using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runtime
{
    public class GameManager : MonoBehaviour
    {
        public bool GameStartarted = false;
        public  bool GameEnded = false;

        public int Level = 1;
        public GameObject[] rooms;
        public GameObject[] tutorials;
        public GameObject endScreen;
        [SerializeField] private int timerValue;
        [SerializeField] private TextMeshProUGUI textScore;
        

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
                InvokeRepeating("SetTimer",1,1);
            }
        }

        public void SetTimer()
        {
            timerValue--;
            textScore.text = timerValue.ToString();
            
            if (timerValue == 0)
            {
                GameEnded = true;
                CancelInvoke();
                endScreen.SetActive(true);
            }
        }

        public void RestartGame()
        {
            timerValue = 20;
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}

