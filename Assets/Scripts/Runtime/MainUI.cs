using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Runtime
{
    public class MainUI : MonoBehaviour
    {
        public TextMeshProUGUI coinText; // text of the coins
        
        [Header("Coin Upgrade")]
        public int currentCoins;
        public TextMeshProUGUI coinsPriceText;
        public TextMeshProUGUI coinsLevelText;
        [SerializeField] private Button coinsUpgradeButton;
        private int coinsLevel;
        private int initialPrice = 10;
        private int coinsActualPrice;

        [Header("Speed Upgrade")]
        public TextMeshProUGUI speedPriceText;
        public TextMeshProUGUI speedLevelText;
        [SerializeField] private Button speedUpgradeButton;
        private int speedLevel;
        private int speedActualPrice;
        
        
      
        [Header("Time Upgrade")]
        public TextMeshProUGUI timePriceText;
        public TextMeshProUGUI timeLevelText;
        [SerializeField] private Button timeUpgradeButton;
        private int timeLevel;
        private int timeActualPrice;
        

        private void Awake()
        {
            currentCoins = PlayerPrefs.GetInt("coins", 0);
            coinText.text = currentCoins.ToString();
            
            coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
            speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
            timeLevel = PlayerPrefs.GetInt("timeLevel", 1);
            
            int actualCoinPrice = initialPrice * coinsLevel;
            int actualSpeedPrice = initialPrice * speedLevel;
            int actualTimePrice = initialPrice * timeLevel;

            coinsPriceText.text = actualCoinPrice + " COINS";
            speedPriceText.text = actualSpeedPrice + " COINS";
            timePriceText.text = actualTimePrice + " COINS";

            coinsLevelText.text = "LEVEL: " + coinsLevel;
            speedLevelText.text = "LEVEL: " + speedLevel;
            timeLevelText.text = "LEVEL: " + timeLevel;
        }

        public void UpgradeCoinsButton()
        {
            coinsActualPrice = initialPrice * (coinsLevel + 1);
            if (currentCoins >= coinsActualPrice)
            { 
                currentCoins -= coinsActualPrice;
                PlayerPrefs.SetInt("coins", currentCoins);
                coinText.text = currentCoins.ToString();

                
                PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) + 1);
                coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
                coinsLevelText.text = "LEVEL: " + coinsLevel;
                coinsActualPrice = initialPrice * coinsLevel;
                coinsPriceText.text = coinsActualPrice + " COINS";
            }
            else
            {
                Debug.Log("Not enough coins");
                coinsUpgradeButton.interactable = false;
            }
            
        }

        public void UpgradeSpeedButton()
        {
            speedActualPrice = initialPrice * (speedLevel + 1);
            if (currentCoins >= speedActualPrice)
            { 
                currentCoins -= speedActualPrice;
                PlayerPrefs.SetInt("coins", currentCoins);
                coinText.text = currentCoins.ToString();

                
                PlayerPrefs.SetInt("speedLevel", PlayerPrefs.GetInt("speedLevel", 1) + 1);
                speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
                speedLevelText.text = "LEVEL: " + speedLevel;
                speedActualPrice = initialPrice * speedLevel;
                speedPriceText.text = speedActualPrice + " COINS";
            }
            else
            {
                Debug.Log("Not enough coins");
                speedUpgradeButton.interactable = false;
            }
        }

        public void UpgradeTimeButton()
        {
            timeActualPrice = initialPrice * (timeLevel + 1); 
            if (currentCoins >= timeActualPrice)
            { 
                currentCoins -= timeActualPrice;
                PlayerPrefs.SetInt("coins", currentCoins);
                coinText.text = currentCoins.ToString();

                
                PlayerPrefs.SetInt("timeLevel", PlayerPrefs.GetInt("timeLevel", 1) + 1);
                timeLevel = PlayerPrefs.GetInt("timeLevel", 1);
                timeLevelText.text = "LEVEL: " + timeLevel;
                timeActualPrice = initialPrice * timeLevel;
                timePriceText.text = timeActualPrice + " COINS";
            }
            else
            {
                Debug.Log("Not enough coins");
                timeUpgradeButton.interactable = false;
            }
        }
    }
}