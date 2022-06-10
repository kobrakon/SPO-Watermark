using BepInEx;
using UnityEngine;

namespace SPOWM
{
    [BepInPlugin("com.kobrakon.spowatermark", "SPOWatermark", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new SPOWMPatch().Enable();
        }
    }
}
