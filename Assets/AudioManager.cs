using UnityEngine;
using System.Collections;

namespace GM
{
    public class AudioManager : MonoBehaviour
    {
        public bool bgSound = true;
        public bool efSound = true;
        
        [SerializeField]
        AudioSource mainAudio;
        [SerializeField]
        AudioSource effectAudio;

        [SerializeField]
        AudioClip selectStage;

        void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}