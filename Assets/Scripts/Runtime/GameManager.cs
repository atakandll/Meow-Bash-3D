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
        [SerializeField] private GameObject level1Obstacle;
        [SerializeField] private GameObject level2Obstacle;
        [SerializeField] private GameObject level3Obstacle;
        [SerializeField] private GameObject level4Obstacle;
        [SerializeField] private GameObject level5Obstacle;
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
            SetInitialPositions();
            InvokeRepeating("SetTimer",1,1);
            
            foreach (var a in ai)
            {
                a.StartGame();
                
            }
        }
        private void SetInitialPositions()
        {
            // Örneğin, her levelde başlangıç konumları farklı olsun.
            switch (Level)
            {
                case 1:
                    SetPositionsForLevel1();
                    level1Obstacle.SetActive(false);
                    Debug.Log("Level 1 obstacle destroyed");
                    break;
                case 2:
                    SetPositionsForLevel2();
                    level2Obstacle.SetActive(false);
                    Debug.Log("Level 2 obstacle destroyed");
                    break;
                case 3:
                    SetPositionsForLevel3();
                    level3Obstacle.SetActive(false);
                    Debug.Log("Level 3 obstacle destroyed");
                    break;
                case 4:
                    SetPositionsForLevel4();
                    level4Obstacle.SetActive(false);
                    Debug.Log("Level 4 obstacle destroyed");
                    break;
                case  5:
                    SetPositionsForLevel5();
                    level5Obstacle.SetActive(false);
                    Debug.Log("Level 5 obstacle destroyed");
                    break;
               
            }
        }

        private void SetPositionsForLevel1()
        {
          
            Player.transform.position = new Vector3(0f, 1f, 0f);
            ai[0].transform.position = new Vector3(1f, 1f, 0f);
            ai[1].transform.position = new Vector3(-1f, 1f, 0f);
            ai[2].transform.position = new Vector3(1f, -1f, 0f);
            ai[3].transform.position = new Vector3(-1f, -1f, 0f);
        }

        private void SetPositionsForLevel2()
        {
           
            Player.transform.position = new Vector3(0f, 2f, 0f);
            ai[0].transform.position = new Vector3(2f, 2f, 0f);
            ai[1].transform.position = new Vector3(-2f, 2f, 0f);
            ai[2].transform.position = new Vector3(2f, -2f, 0f);
            ai[3].transform.position = new Vector3(-2f, -2f, 0f);
        }
        private void SetPositionsForLevel3()
        {
            
            Player.transform.position = new Vector3(0f, 1f, 0f);
            ai[0].transform.position = new Vector3(1f, 1f, 0f);
            ai[1].transform.position = new Vector3(-1f, 1f, 0f);
            ai[2].transform.position = new Vector3(1f, -1f, 0f);
            ai[3].transform.position = new Vector3(-1f, -1f, 0f);
        }
        private void SetPositionsForLevel4()
        {
            
            Player.transform.position = new Vector3(0f, 1f, 0f);
            ai[0].transform.position = new Vector3(1f, 1f, 0f);
            ai[1].transform.position = new Vector3(-1f, 1f, 0f);
            ai[2].transform.position = new Vector3(1f, -1f, 0f);
            ai[3].transform.position = new Vector3(-1f, -1f, 0f);
        }
        private void SetPositionsForLevel5()
        {
            
            Player.transform.position = new Vector3(0f, 1f, 0f);
            ai[0].transform.position = new Vector3(1f, 1f, 0f);
            ai[1].transform.position = new Vector3(-1f, 1f, 0f);
            ai[2].transform.position = new Vector3(1f, -1f, 0f);
            ai[3].transform.position = new Vector3(-1f, -1f, 0f);
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

        public void GetExtraScore()
        {
            int currentScore = int.Parse(textScore.text);
            int scoreTotal = PlayerPrefs.GetInt("scoreTotal", 0);
            scoreTotal += (currentScore + 500) / 100;
            PlayerPrefs.SetInt("scoreTotal", scoreTotal);

            Debug.Log("Current Score: " + currentScore);
            Debug.Log("New Total Score: " + scoreTotal);

            textScore.text = scoreTotal.ToString();
            finalTextScore.text = scoreTotal.ToString();
            finalScoresText[0].text = finalScores[0] = "Your Score : " + scoreTotal.ToString();
        }
    }
}

