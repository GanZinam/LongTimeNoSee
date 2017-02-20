using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDINGCUTSCENE : MonoBehaviour
{
    int cutIdx = -1;     // 카툰 컷 씬 인덱스

    [SerializeField]
    GameObject[] cartoonBAD;        // 카툰 12개 공간
    [SerializeField]
    GameObject[] cartoonHAPY;       // 카툰 8개 공간

    [SerializeField]
    GameObject bad;
    [SerializeField]
    GameObject happy;

    void Start()
    {
        if (GM.AudioManager.endResult)
            happy.SetActive(true);
        else
            bad.SetActive(true);

        GM.AudioManager.instance.init();
        GM.AudioManager.instance.endingCartoonBG();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            GM.LevelManager.myLevel = 3;
            SceneManager.LoadScene("Game");
        }
    }

    public void nex()
    {
        cutIdx++;

        if (!GM.AudioManager.endResult)
        {
            if (cutIdx < 12)
                cartoonBAD[cutIdx].SetActive(true);

            if (cutIdx.Equals(11))
                GM.AudioManager.instance.suicide();
        }
        else
        {
            if (cutIdx < 8)
                cartoonHAPY[cutIdx].SetActive(true);

            if (cutIdx.Equals(5))
                GM.AudioManager.instance.call();
        }
        GM.AudioManager.instance.endingCartoonBG();

        //if (cutIdx.Equals(9))
        //    titleObj.SetActive(true);
        //else if (cutIdx.Equals(10))
        //{
        //    cutIdx = 9;
        //    gameStart();
        //}
        //else
        //    cartoon[cutIdx].SetActive(true);
    }
}
