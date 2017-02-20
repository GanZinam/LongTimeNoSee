using UnityEngine;
using System.Collections;

namespace GM
{
    public class AudioManager : MonoBehaviour
    {
        public static bool endResult = false;       // f 배드 : t 해피

        public static AudioManager instance;

        public bool bgSound = true;
        public bool efSound = true;

        [SerializeField]
        AudioSource mainAudio;
        [SerializeField]
        AudioSource effectAudio;
        [SerializeField]
        AudioSource effectAudio2;

        [SerializeField]
        AudioClip selectStage;

        [Header("_BG_")]
        [SerializeField]
        AudioClip ingameClip;
        [SerializeField]
        AudioClip endingClip;
        [SerializeField]
        AudioClip warningClip;
        [SerializeField]
        AudioClip rainClip;

        [SerializeField]
        AudioClip deathPoliceClip;

        [Header("_OBJECT_")]
        [SerializeField]
        AudioClip mouseClip;
        [SerializeField]
        AudioClip cabinetClip;
        [SerializeField]
        AudioClip doorClip;
        [SerializeField]
        AudioClip stairClip;

        [Header("_KILL_")]
        [SerializeField]
        AudioClip gunClip;
        [SerializeField]
        AudioClip knifeClip;

        [Header("_ENDING_")]
        [SerializeField]
        AudioClip badClip;
        [SerializeField]
        AudioClip happyClip;

        [Header("_CARTOON_")]
        [SerializeField]
        AudioClip suicideClip;
        [SerializeField]
        AudioClip callClip;

        [Header("_LOCKPICK_")]
        [SerializeField]
        AudioClip lockPickClip;
        [SerializeField]
        AudioClip lockPickDoneClip;

        void Start()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        public void endingCartoonBG()
        {
            if (!endResult)
                mainAudio.clip = badClip;
            else
                mainAudio.clip = happyClip;
            mainAudio.Play();
        }
        public void ingameBG()
        {
            if (LevelManager.myLevel.Equals(3))
                mainAudio.clip = endingClip;
            else
                mainAudio.clip = ingameClip;
            mainAudio.Play();
        }
        public void rainBG()
        {
            mainAudio.clip = rainClip;
            mainAudio.Play();
        }
        public void endingBG()
        {
            mainAudio.clip = stairClip;
            mainAudio.Play();
        }
        public void warningBG()
        {
            mainAudio.clip = warningClip;
            mainAudio.Play();
        }

        public delegate void bgEffect();
        public IEnumerator changeVolume(bgEffect func)
        {
            while (mainAudio.volume > 0)
            {
                mainAudio.volume -= 0.05f;
                yield return new WaitForSeconds(0.07f);
            }
            func();
            while (mainAudio.volume < 1)
            {
                mainAudio.volume += 0.05f;
                yield return new WaitForSeconds(0.07f);
            }

        }

        public void deathPolice()
        {
            effectAudio.volume = 0.8f;
            effectAudio.clip = deathPoliceClip;
            effectAudio.Play();
        }

        public void cabinetIn()
        {
            effectAudio.volume = 1;
            effectAudio.clip = cabinetClip;
            effectAudio.Play();
        }

        public void doorIn()
        {
            effectAudio.volume = 1;
            effectAudio.clip = doorClip;
            effectAudio.Play();
        }

        public void stair()
        {
            effectAudio.volume = 1;
            effectAudio.clip = stairClip;
            effectAudio.Play();
        }

        public void byKnife()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = knifeClip;
            effectAudio2.Play();
        }
        public void byGun()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = gunClip;
            effectAudio2.Play();
        }

        public void init()
        {
            mainAudio.Stop();
            effectAudio.Stop();
            effectAudio2.Stop();
        }

        public void suicide()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = suicideClip;
            effectAudio2.Play();
        }
        public void call()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = callClip;
            effectAudio2.Play();
        }

        public void mouse()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = mouseClip;
            effectAudio2.Play();
        }

        public void lockPick()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = lockPickClip;
            effectAudio2.Play();
        }
        public void lockPickDone()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = lockPickDoneClip;
            effectAudio2.Play();
        }
    }
}