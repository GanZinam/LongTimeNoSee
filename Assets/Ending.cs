using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer bg;
    [SerializeField]
    SpriteRenderer cab;

    [SerializeField]
    Sprite badBG;
    [SerializeField]
    Sprite cabBG;

    [SerializeField]
    Animator bgANIM;

    [SerializeField]
    GameObject minigame;



    public void killBOSS()
    {
        bgANIM.SetTrigger("KILL");
        //bg.sprite = badBG;
        //cab.sprite = cabBG;

        GM.AudioManager.endResult = true;

        SMng.Direction = 3;
        SMng.interection = true;
        if (!SMng.sit)
        {
            SMng.Instance.HeroAnimator.SetBool("Shoot", true);
        }
        GM.AudioManager.instance.warningBG();
    }


    public void saveBOSS()
    {
        GM.AudioManager.endResult = false;
        SMng.Direction = 3;
        SMng.interection = true;


        // 미니게임

        // minigame.SetActive(true);

        SceneManager.LoadScene("End");
    }
}
