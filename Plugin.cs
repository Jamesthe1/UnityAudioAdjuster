using UnityEngine.SceneManagement;
using BepInEx;

namespace AudioAdjustments {
    [BepInPlugin (guid, visibleName, version)]
    public class Plugin : BaseUnityPlugin {
        public const string guid = "jamesthe1.audioadjustments";
        public const string visibleName = "Audio Adjustments";
        public const string version = "1.0.3";

        private void Awake () {
            SceneManager.sceneLoaded += AddSound;
            Logger.LogInfo (visibleName + " has fully loaded and is ready to go!");
        }

        public void OnModUnload () {
            SceneManager.sceneLoaded -= AddSound;
        }
        
        private void AddSound (Scene scene, LoadSceneMode mode) {
            AudioUpdater.Spawn ();
        }
    }
}
