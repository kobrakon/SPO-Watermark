using System;
using System.Linq;
using System.Xml;
using System.Reflection;
using Aki.Reflection.Patching;
using Aki.Reflection.Utils;
using System.IO;
using HarmonyLib;
using TMPro;
using EFT.UI;

namespace SPOWM
{
    public class SPOWMPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return PatchConstants.EftTypes.Single((Type x) => x.GetField("Taxonomy", BindingFlags.Instance | BindingFlags.Public) != null).GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
        }

        [PatchPostfix]
        private static void PatchPostFix(object __result)
        {
            Traverse.Create(MonoBehaviourSingleton<PreloaderUI>.Instance).Field("_alphaVersionLabel").Property("LocalizationKey", null).SetValue("{0}");
            Traverse.Create(MonoBehaviourSingleton<PreloaderUI>.Instance).Field("string_2").SetValue(SPOVersion());
            Traverse.Create(__result).Field("Major").SetValue(SPOVersion());
        }

        internal static string SPOVersion()
        {
            XmlDocument file = new XmlDocument();
            file.Load(Directory.GetCurrentDirectory() + "\\version.xml");
            XmlNodeList node = file.GetElementsByTagName("currentver");
            return node[0].InnerText;
        }
    }
}