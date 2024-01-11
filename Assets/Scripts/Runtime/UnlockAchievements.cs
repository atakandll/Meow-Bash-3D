using System;
using UnityEngine;

namespace Runtime
{
    public class UnlockAchievements : MonoBehaviour
    {
        public string AchievementID;
        public GameObject check;

        private void Start()
        {
            if (PlayerPrefs.GetInt(AchievementID, 0) == 1)
            {
                check.SetActive(true);
            }
            
        }
    }
}