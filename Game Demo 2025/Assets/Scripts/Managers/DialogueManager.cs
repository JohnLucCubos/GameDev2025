using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyUnity.Utilities
{
    public class DialogueManager : MonoBehaviour
    {
        // Singleton
        private static DialogueManager _instance;
        public static DialogueManager Instance { get { return _instance; } }
        [Header("UI Components")]
        [SerializeField] TextMeshProUGUI _dialogueText;
        [SerializeField] TextMeshProUGUI _characterName;
        [SerializeField] Image _characterImage;
        [Header("Dialogue Components")]
        [SerializeField] bool _isComplete = true;
        [SerializeField] bool _endScene;
        [SerializeField] float textDelay;
        private Queue<Dialogue> _dialogue = new();
        [Header("Audio Manager")]
        [SerializeField] AudioManager _audioManager;

        // Getters and Setters
        public int getCount { get { return _dialogue.Count; } }
        public bool isSceneEnding { get { return _endScene; } }

        void Awake()
        {
            this.gameObject.tag = "DialogueManager";
            // create singleton
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;

            DontDestroyOnLoad(this.gameObject);
            StartCoroutine(LateStart());
        }

        // gives the audio system enough time to transition between scenes
        IEnumerator LateStart()
        {
            yield return new WaitForSeconds(1f);
            _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        /// <summary>
        /// Loads the dialogue script into a queue to display in a textbox
        /// </summary>
        /// <param name="dialogueScript">Script used to be loaded into the Dialogue System</param>
        public void DisplayDialogue(DialogueScript dialogueScript)
        {
            _dialogue.Clear();

            foreach (Dialogue script in dialogueScript.dialogue)
                _dialogue.Enqueue(script);

            _isComplete = true;
            _endScene = false;
        }
        /// <summary>
        /// Loads the next sentence in the Dialogue Script
        /// </summary>
        public void DisplayNextSentence()
        {
            if (_dialogue.Count == 0 || !_isComplete) return;
            var script = _dialogue.Dequeue();

            _characterName.text = script.characterName;
            if (_characterImage != null && script.characterSprite != null) 
                _characterImage.sprite = script.characterSprite;

            StartCoroutine(TypeWriter(script.sentences, script.audioSFX));
        }

        // ===== Text Animations =====
        // TODO: Create a way to Have different Text Animations
        IEnumerator TypeWriter(string sentence, string soundName)
        {
            if (soundName != string.Empty) _audioManager.Play(soundName);

            for (int letter = 0; letter < sentence.Length + 1; letter++)
            {
                yield return new WaitForSeconds(textDelay);
                _dialogueText.text = sentence[..letter];
            }

            yield return new WaitForEndOfFrame();
            _isComplete = true;
            if(_dialogue.Count == 0) _endScene = true;
        }
    }
}