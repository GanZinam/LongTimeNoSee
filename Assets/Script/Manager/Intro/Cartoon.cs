using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartoon : MonoBehaviour
{
    [SerializeField]
    GameObject[] cartoon;         // 카툰 9개 공간
    [SerializeField]
    GameObject cartoonCanvas;

    [SerializeField]
    GameObject titleObj;

    int cutIdx = -1;     // 카툰 컷 씬 인덱스

    void Start()
    {

        SMng.Instance.hideWeapon.SetActive(true);
        SMng.Direction = 3;
    }

    /**
     * @brief 다음 컷 씬으로 이동
     */
    public void nextCut()
    {
        cutIdx++;
        if (cutIdx.Equals(9))
            titleObj.SetActive(true);
        else if (cutIdx.Equals(10))
        {
            cutIdx = 9;
            gameStart();
        }
        else
            cartoon[cutIdx].SetActive(true);
    }
    [SerializeField]
    Animator MoveTitle;

    [SerializeField]
    Transform targetHero;
    [SerializeField]
    CameraFollow cam;

    public void gameStart()
    {
        if (SMng.TitleStartOn)
        {
            SMng.Instance.hideWeapon.SetActive(true);
            SMng.Direction = 3;
            cam.target = targetHero;

            if (GM.LevelManager.myLevel.Equals(0))
            {
                MoveTitle.SetTrigger("A");
                GM.AudioManager.instance.rainBG();
                SMng.Instance._level.StartCoroutine("direct_0");

                cam.gameObject.GetComponent<Animator>().SetTrigger("Intro");
            }
            cartoonCanvas.SetActive(false);
        }
    }

    // [0]-> 0, 1, 2
    // [1]-> 3, 4
    // [2]-> 5, 6
    // [3]-> 7, 8
    // [4]-> 9, 10




}
