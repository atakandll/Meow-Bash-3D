using UnityEngine;

namespace Runtime
{
    public class SkinSelector : MonoBehaviour
    {
        public GameObject Shop;

        public void SelectSkin(int skinId)
        {
            Debug.Log("Selected Skin: " + skinId);
            Shop.SetActive(false);
        }
    }
}