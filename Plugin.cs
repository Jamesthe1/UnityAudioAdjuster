using HarmonyLib;
using BepInEx;

namespace AudioAdjustments {
    [BepInPlugin (guid, visibleName, version)]
    public class Plugin : BaseUnityPlugin {
        public const string guid = "jamesthe1.audioadjustments";
        public const string visibleName = "Audio Adjustments";
        public const string version = "1.0.0";

        private void Awake () {
            InitHarmony ();
            Logger.LogInfo (visibleName + " has fully loaded and is ready to go!");
        }
        
        private void InitHarmony () {
            Harmony harmony = new Harmony (guid);
            Logger.LogInfo ("Patching with harmony...");
            harmony.PatchAll ();
        }
    }
}
