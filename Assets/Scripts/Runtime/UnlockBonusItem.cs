using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    public class UnlockBonusItem : MonoBehaviour
    {
        public int DaysPlayed;
        public Button skin2Button;
        public int currentCoins;
        public int currentScore;
        private void Start()
        {
            PlayerPrefs.GetInt("DaysPlayed");
            if (DaysPlayed >= 3)
            {
                PlayerPrefs.SetInt("Skin2_Unlocked", 1);
                skin2Button.interactable = true;
            }
            currentCoins = PlayerPrefs.GetInt("coins", 0);
            
            if (currentCoins >= 100)
            {
                PlayerPrefs.SetInt("CoinsCheck", 1);
               
            }
            currentScore = PlayerPrefs.GetInt("scoreTotal",0);
            if(currentScore >= 1000)
            {
                PlayerPrefs.SetInt("ScoreCheck", 1);
               
            }
             
        }
    }
}