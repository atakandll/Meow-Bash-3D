using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    public class UnlockSkin : MonoBehaviour
    {
        public Button button;
        public string prefsKey;

        private void Start()
        {
            if (PlayerPrefs.GetInt(prefsKey, 0) == 1)
            {
                button.interactable = true;
            }
        }
    }
}