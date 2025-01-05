using UnityEngine;
using UnityEngine.UI;

namespace MyUnity.Utilities
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] SoundType type;
        [SerializeField] AudioManager audioSystem;
        void Awake()
        {
            if (audioSystem == null) return;

            audioSystem = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        /// <summary>
        /// Put script into the slider, slider changes the audio values based on type
        /// </summary>
        public void UpdateAudioValues()
        {
            foreach (var eachSound in audioSystem.getSounds)
            {
                if (eachSound.type != type) continue;
                audioSystem.ChangeVolume(eachSound.name, slider.value);
            }
        }
    }
}
