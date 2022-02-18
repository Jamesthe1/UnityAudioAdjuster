using UnityEngine;

namespace AudioAdjustments {
    public class AudioUpdater : MonoBehaviour {
        public static GameObject Instance { get; private set; }
        public static void Spawn () {
            if (Instance == null)
                Instance = new GameObject ("AudioUpdater", typeof (AudioUpdater));
        }

        // Seconds until update
        private const float maxUpdateTime = 1f;
        private float timeKeeper = 0f;
        private const float adjustmentRange = 0.25f;
        private void UpdateAudio () {
            // Not caching this because objects are likely to be added and removed
            AudioSource[] sources = FindObjectsOfType<AudioSource> ();
            for (int i = 0; i < sources.Length; i++) {
                float adjustment = Random.Range (-adjustmentRange, adjustmentRange);
                sources[i].pitch = Mathf.Clamp (sources[i].pitch + adjustment, 0f, 60f);
                sources[i].volume = Mathf.Clamp (sources[i].volume + adjustment, 0f, 1f);
            }
        }

        public void Start () {
            UpdateAudio ();
        }

        public void Update () {
            timeKeeper += Time.deltaTime;
            if (timeKeeper >= maxUpdateTime) {
                UpdateAudio ();
                timeKeeper = 0;
            }
        }
    }
}
