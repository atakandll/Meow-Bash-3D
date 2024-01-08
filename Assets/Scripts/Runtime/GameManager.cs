using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private TextMeshProUGUI textTimer;
        [SerializeField] private TextMeshProUGUI textScore;
        [SerializeField] private TextMeshProUGUI finalTextScore;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        
        

        private void Awake()
        {
            for (int i = 1; i <= rooms.Length; i++)
            {
                if(i<=Level)
                    rooms[i-1].SetActive(true);
            }
            bestScoreText.text ="Best: " + PlayerPrefs.GetInt("scoreMax",0).ToString();
        }
        

        public void StartGame()
        {
            GameStartarted = true;
            tutorials[0].SetActive(false);
            InvokeRepeating("SetTimer",1,1);
        }

        public void SetTimer()
        {
            timerValue--;
            textTimer.text = timerValue.ToString();
            
            if (timerValue == 0)
            {
                GameEnded = true;
                CancelInvoke();
                endScreen.SetActive(true);
                finalTextScore.text = "Score: " + textScore.text;
            }
        }

        public void RestartGame()
        {
            int currentScore = int.Parse(textScore.text);
            int scoreMax = PlayerPrefs.GetInt("scoreMax",0);
            
            if (currentScore > scoreMax)
                PlayerPrefs.SetInt("scoreMax",currentScore);
            
            timerValue = 20;
            Application.LoadLevel(Application.loadedLevelName);
        }


        public void WatchExtraTimeVideo()
        {
            //
            //
            GetExtraTime();
        }
        public void GetExtraTime()
        {
            timerValue = 10 + PlayerPrefs.GetInt("timeLevel",1);
            textTimer.text = timerValue.ToString();
            InvokeRepeating("SetTimer",1,1);
            GameEnded = false;
            endScreen.SetActive(false);

        }
    }
}

