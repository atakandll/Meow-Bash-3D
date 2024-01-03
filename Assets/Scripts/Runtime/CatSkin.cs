
using UnityEngine;

namespace Runtime
{
    public class CatSkin : MonoBehaviour
    {
        public Texture[] skins;
        public Material catMaterial;
        private int selectedSkin;

        private void Awake()
        {
            selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
            catMaterial.mainTexture = skins[selectedSkin];
        }

        public void SetSkin(int skinId)
        {
            catMaterial.mainTexture = skins[skinId];

        }
    }

}
