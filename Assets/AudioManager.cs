using UnityEngine;
using System.Collections;

namespace GM
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public bool bgSound = true;
        public bool efSound = true;

        [SerializeField]
        AudioSource mainAudio;
        [SerializeField]
        AudioSource effectAudio;

        [SerializeField]
        AudioClip selectStage;

        [SerializeField]
        AudioClip rainClip;

        void Start()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        public void rainBG()
        {
            mainAudio.clip = rainClip;
            mainAudio.Play();
        }
    }
}