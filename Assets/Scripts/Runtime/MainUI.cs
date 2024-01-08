using System;
using UnityEngine;
using TMPro;

namespace Runtime
{
    public class MainUI : MonoBehaviour
    {
        public TextMeshProUGUI coinText;

        private void Awake()
        {
            coinText.text = PlayerPrefs.GetInt("coins", 0).ToString();
        }
    }
}