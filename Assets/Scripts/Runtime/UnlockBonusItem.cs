using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    public class UnlockBonusItem : MonoBehaviour
    {
        public int DaysPlayed;
        public Button skin2Button;
        private void Start()
        {
            PlayerPrefs.GetInt("DaysPlayed");
            if (DaysPlayed >= 3)
            {
                PlayerPrefs.SetInt("Skin2_Unlocked", 1);
                skin2Button.interactable = true;
            }
        }
    }
}