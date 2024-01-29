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
        [SerializeField] private TextMeshProUGUI[] finalScoresText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private GameObject Player;
        public string[] finalScores;
        
        public AI[] ai;
        
        

        private void Awake()
        {
            Level = PlayerPrefs.GetInt("level", 1);
            levelText.text = "Level: " + Level;
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
            
            foreach (var a in ai)
            {
                a.StartGame();
                
            }
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
                finalScores[0] = "Your Score : " + textScore.text;
                finalScores[1] = ai[0].gameObject.name + " : " + ai[0].score;
                finalScores[2] = ai[1].gameObject.name + " : " + ai[1].score;
                

                for (int i = 0; i <= 2; i++)
                {
                    finalScoresText[i].text = finalScores[i];
                }
            }
        }

        public void RestartGame()
        {
            int currentScore = int.Parse(textScore.text);
            int scoreTotal = PlayerPrefs.GetInt("scoreTotal",0);
            scoreTotal += currentScore;
            PlayerPrefs.SetInt("scoreTotal",scoreTotal);
            int actualLevel = Mathf.FloorToInt(scoreTotal / 1000) + 1;
            PlayerPrefs.SetInt("level",actualLevel);

           
            
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

