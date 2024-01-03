using UnityEngine;

namespace Runtime
{
    public class SkinSelector : MonoBehaviour
    {
        public GameObject Shop;
        public CatSkin CatSkin;

        public void SelectSkin(int skinId)
        {
            PlayerPrefs.SetInt("SelectedSkin", skinId);
            CatSkin.SetSkin(skinId);
            Shop.SetActive(false);
            
        }
    }
}