using System;
using UnityEngine;

namespace Runtime
{
    public class DaysSinceFirstLaunch : MonoBehaviour
    {
        private DateTime startDate;
        private DateTime today;

        private void Awake()
        {
            SetStartDate();
        }

        private void SetStartDate()
        {
            if (PlayerPrefs.HasKey("StartDate"))
            {
                startDate = Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
            }
            else
            {
                startDate = DateTime.Now;
                PlayerPrefs.SetString("StartDate", startDate.ToString());
            }
            PlayerPrefs.SetInt("DaysPlayed", (int)(DateTime.Now - startDate).TotalDays);
        }
    }
}