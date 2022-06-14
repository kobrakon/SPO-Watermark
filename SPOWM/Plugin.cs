using BepInEx;
using UnityEngine;

namespace SPOWM
{
    [BepInPlugin("com.kobrakon.spowatermark", "SPOWatermark", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static GameObject Hook;

        private void Awake()
        {
            Hook = new GameObject("AlphaLabelController");
            Hook.AddComponent<AlphaLabelController>();
            DontDestroyOnLoad(Hook);
        }
    }
}
